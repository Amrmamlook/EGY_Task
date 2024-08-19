using Mediator;
using Planta_BackEnd.Mediator;
using Task_Test.Medatior.Query;
using Task_Test.Options.Response;

namespace Task_Test.Medatior.Handler
{
    public class CallofClientQueryHandler(StoreContext _db) : IRequestHandler<GetCallsOfClientQuery, PageList<CallDto>>
    {
        public async ValueTask<PageList<CallDto>> Handle(GetCallsOfClientQuery request, CancellationToken cancellationToken)
        {
            var query =  _db.Calls.Where(x => x.ClientId == request.ClientId);

            var callsResponseDto = query.Select(x => new CallDto
            {
                Id= x.Id,
                CallHistory= x.CallHistory,
                CallAdress = x.CallAdress,
                TypeOfCall= x.TypeOfCall,
                Employee = x.Employee,
                Project= x.project,
                Description = x.Description

            }).OrderByDescending(x=>x.CallHistory);

            var  calls = await PageList<CallDto>.CreateAsync(callsResponseDto,
                request.PageNumber ,request.PageSize);

            return calls;
           
        }
    }
}
