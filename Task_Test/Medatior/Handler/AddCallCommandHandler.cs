using Mediator;
using Task_Test.Medatior.Command;

namespace Task_Test.Medatior.Handler
{
    public class AddCallCommandHandler(StoreContext _db) : IRequestHandler<AddCallCommand, ResponseResult>
    {
        public async ValueTask<ResponseResult> Handle(AddCallCommand request, CancellationToken cancellationToken)
        {
            var existingClient = await _db.Clients.FindAsync(request.ClientId,cancellationToken);
            if (existingClient is null)
            {
                return new ResponseResult
                {
                    Message= "Client Not Found",
                    Success= false
                };
            }
            if (!DateOnly.TryParseExact(request.CallHistory, "dd/MM/yyyy", out DateOnly parsedCallHistory))
            {
                return new ResponseResult
                {
                    Message = "CallHistory must be in the format dd/MM/yyyy.",
                    Success= false

                };
            }
            var newCall = new Calls
            {
                ClientId = request.ClientId,
                Description = request.Description,
                CallAdress = request.CallAdress,
                Employee = request.Employee,
                CallHistory = request.CallHistory,
                project= request.project,
                TypeOfCall = request.TypeOfCall,
            };

            _db.Add(newCall);
            await _db.SaveChangesAsync(cancellationToken);

            return new ResponseResult
            {
                Message = " Call Added successfully",
                Success= true
               
            };
        }
    }
}
