using Mediator;
using OneOf;
using OneOf.Types;
using Task_Test.Medatior.Query;

namespace Task_Test.Medatior.Handler
{
    public class GetClientByIdQueryHandler(StoreContext _db) : IRequestHandler<GetClientByIdQuery, OneOf<OneOf.Types.NotFound, ClientInfoDto>>
    {
        public async ValueTask<OneOf<NotFound, ClientInfoDto>> Handle(GetClientByIdQuery request, CancellationToken cancellationToken)
        {
            var existingClient = _db.Clients.Where(x => x.Id == request.ClientId);

            if (existingClient is null)
            {
                return new NotFound();
            }

           var result = await existingClient.Select(c => new ClientInfoDto
           {
               Name = c.Name,
               Email = c.Email,
               District = c.District,
               Address = c.Address,
               Nationality = c.Natinality,
               Job = c.Job,
               Residence = c.Residence,
               SalesMan = c.SalesMan,
               Description = c.Description,
               CustomerClassifications = c.CustomerClassifications,
               CustomerSource = c.CustomerSource,
              

               Mobile = c.Phones.FirstOrDefault().Mobile,
               TelephoneOne = c.Phones.FirstOrDefault().TelephoneOne,
               TelephoneTwo = c.Phones.FirstOrDefault().TelephoneTwo,
               WhatsApp = c.Phones.FirstOrDefault().WhatsApp

           }).FirstOrDefaultAsync(cancellationToken);
            return result;
        }
    }
}
