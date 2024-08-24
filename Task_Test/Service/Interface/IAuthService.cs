using Task_Test.Medatior.Command;
using Task_Test.Options.Request;
using Task_Test.Options.Response;

namespace Task_Test.Service.Interface
{
    public interface IAuthService
    {
        Task<AuthResult> CreateAccount(AccountRequest accountRequest);
        Task<AuthResult> GetToken(TokenRequest tokenRequest);
    }
}
