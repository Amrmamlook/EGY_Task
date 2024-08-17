using Microsoft.AspNetCore.Identity;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Task_Test.Options.Request;
using Task_Test.Options.Response;
using Task_Test.Service.Interface;

namespace Task_Test.Service
{
    public class InitialAuthService(UserManager<AppUser> _userManager, AuthSettings _authSettings) : IAuthService
    {
        public async Task<AuthResult> CreateAccount(AccountRequest accountRequest)
        {
            var existingUserNameOwner = await _userManager.FindByNameAsync(accountRequest.UserName);
            if (existingUserNameOwner != null)
            {
                return new AuthResult { Errors = ["UserName is used"] };
            }

            var existingEmailOwner = await _userManager.FindByEmailAsync(accountRequest.Email);
            if (existingEmailOwner != null)
            {
                return new AuthResult { Errors = ["Email is used"] };
            }

            AppUser newUser = new()
            {
                Email = accountRequest.Email,
                UserName = accountRequest.UserName,
            };



            var commitResult = await _userManager.CreateAsync(newUser, accountRequest.Password);
            if (commitResult == null)
                return new AuthResult { Errors = ["Something went wrong"] };

            if (!commitResult.Succeeded)
            {
                var authResult = new AuthResult()
                {
                    Errors = []
                };

                foreach (var error in commitResult.Errors)
                {
                    authResult.Errors.Add(error.Description);
                }
                return authResult;
            }
            else
            {
                try
                {
                    await _userManager.AddToRoleAsync(newUser, "Admin");
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
                return await GenerateAuthResult(newUser);
            }
        }
        public async Task<AuthResult> GetToken(TokenRequest tokenRequest)
        {
            var wrongResult = new AuthResult { Errors = ["Invalid Credentials"] };

            var existingUserNameOwner = await _userManager.FindByNameAsync(tokenRequest.UserName);
            var existingEmailOwner = await _userManager.FindByEmailAsync(tokenRequest.UserName);
            if (existingUserNameOwner is null && existingEmailOwner is null)
            {
                return wrongResult;
            }

            AppUser appUser = existingUserNameOwner ?? existingEmailOwner!;

            var authenticatedUser = await _userManager.CheckPasswordAsync(appUser, tokenRequest.Password);

            if (!authenticatedUser)
            {
                return wrongResult;
            }
            else
            {
                return await GenerateAuthResult(appUser);
            }
        }
        private async Task<AuthResult> GenerateAuthResult(AppUser appUser)
        {
            var authResult = new AuthResult() { SuccessfulOperation = true };
            //generate the token logic

            var userClaims = await _userManager.GetClaimsAsync(appUser);
            var roles = await _userManager.GetRolesAsync(appUser);
            IList<Claim> userRoleClaims = [];
            foreach (var role in roles)
            {
                if (role != null)
                {
                    var claim = new Claim("role", role);
                    userRoleClaims.Add(claim);
                }
            }

            Guid jwtId = Guid.NewGuid();
            var tokenClaims = new List<Claim>()
            {
                new(JwtRegisteredClaimNames.Jti,jwtId.ToString()),
                new(JwtRegisteredClaimNames.Sub,appUser.UserName ?? appUser.Id.ToString()),
                new(JwtRegisteredClaimNames.Email,appUser.Email ?? appUser.Id.ToString()),
                new("uid",appUser.Id.ToString())
            };

            IList<Claim> totalClaims = tokenClaims.Union(userClaims)
                                            .Union(userRoleClaims).ToList();

            var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_authSettings.Key));

            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(totalClaims),
                SigningCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256),
                Expires = DateTime.UtcNow + _authSettings.TokenLifetime,
                IssuedAt = DateTime.UtcNow,
                Issuer = _authSettings.Issuer,
                Audience = _authSettings.Audience,
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var jwtToken = tokenHandler.CreateToken(tokenDescriptor);
            string jwtString = tokenHandler.WriteToken(jwtToken);

            authResult.AccessToken = jwtString;

           

            return authResult;
        }
    }
}


       
    

