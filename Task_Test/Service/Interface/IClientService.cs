using Task_Test.Medatior.Command;

namespace Task_Test.Service.Interface
{
    public interface IClientService
    {
        Task<ResponseResult> UpdateClientAsync(int clientId, UpdateClientCommand command, CancellationToken cancellationToken);
    }
}