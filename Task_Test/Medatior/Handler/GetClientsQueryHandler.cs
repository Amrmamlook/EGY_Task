using Mediator;
using Planta_BackEnd.Mediator;
using Task_Test.Medatior.Query;
using Task_Test.Options.Response;

namespace Task_Test.Medatior.Handler
{
    public class GetClientsQueryHandler(StoreContext _db) : IRequestHandler<GetClientsQuery, PageList<ClientDto>>
    {
        public async ValueTask<PageList<ClientDto>> Handle(GetClientsQuery request, CancellationToken cancellationToken)
        {

            var query = _db.Clients
                .Include(x=>x.AddedByUser)
                .Include(x=>x.ModifiedByUser).AsQueryable();

                var ClientsResponseDto =  query.Select(c => new ClientDto
                {
                    Name = c.Name,
                    Id = c.Id,
                    Job = c.Job,
                    Residence = c.Residence,
                    AddedBy = c.AddedByUser.UserName,
                    AccountCreationDate = c.AccountCreationDate.ToString(),
                    ModifiedBy = c.ModifiedByUser != null ? c.ModifiedByUser.UserName : null,
                    DateModified = c.DateModified.ToString(),
                    SalesMan = c.SalesMan,
                    Description= c.Description,
                    CustomerClassification = c.CustomerClassifications,
                }).OrderByDescending(x=>x.AccountCreationDate);

            var Clients = await PageList<ClientDto>.CreateAsync(ClientsResponseDto, 
                request.PageNumber, request.PageSize);

            return Clients;
        }
    }
}
