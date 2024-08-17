using Mediator;
using Planta_BackEnd.Mediator;
using Task_Test.Options.Response;

namespace Task_Test.Medatior.Query
{
    public record GetClientsQuery(int PageNumber,int PageSize) :IRequest<PageList<ClientDto>>;
}
