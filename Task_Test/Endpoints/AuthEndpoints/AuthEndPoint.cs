using Microsoft.AspNetCore.Mvc;
using Task_Test.Options.Request;
using Task_Test.Service.Interface;

namespace Task_Test.Endpoints.AuthEndpoints
{
    public static class AuthEndPoint
    {
        public static void MapAuthEnPoints(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("api/Auth");

            group.MapPost("CreateAccount", Register);
            group.MapPost("Login", Login);
        }
        public static async Task<IResult> Register([FromServices] IAuthService authService ,[FromBody]AccountRequest accountRequest)
        {
            var result = await authService.CreateAccount(accountRequest);
            return Results.Ok(result);
        }
        public static async Task<IResult> Login(TokenRequest tokenRequest , [FromServices] IAuthService authService)
        {
            var authResult = await authService.GetToken(tokenRequest);
            return Results.Ok(authResult);
        }
    }
}
