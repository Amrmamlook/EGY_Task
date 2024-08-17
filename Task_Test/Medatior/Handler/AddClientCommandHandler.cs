using Mediator;
using Microsoft.AspNetCore.Identity;
using Task_Test.Medatior.Command;
using Task_Test.Options.Extension;
using Task_Test.Options.Request;

namespace Task_Test.Medatior.Handler
{
    public class AddClientCommandHandler(StoreContext _db,IHttpContextAccessor _httpContextAccessor)
        : IRequestHandler<AddClientCommand, ResponseResult>
    {
        public async ValueTask<ResponseResult> Handle(AddClientCommand request, CancellationToken cancellationToken)
        {
            var userId = _httpContextAccessor.HttpContext.User.GetUserId();

           
            var newClient = new Client
            {
                Name = request.ClientName,
                Address = request.Address,
                District = request.District,
                Natinality = request.Nationality,
                Residence = request.Residence,
                Job = request.Job,
                Email = request.Email,
                AddedByUserId = userId,
                AccountCreationDate = DateOnly.FromDateTime(DateTime.UtcNow)
            };

            var userPhones = request.Phones?
            .Where(phone => !string.IsNullOrWhiteSpace(phone.Mobile) ||
                            !string.IsNullOrWhiteSpace(phone.TelephoneOne) ||
                            !string.IsNullOrWhiteSpace(phone.TelephoneTwo) ||
                            !string.IsNullOrWhiteSpace(phone.WhatsApp))
            .Select(phone => new UserPhone
            {
                Mobile = phone.Mobile,
                TelephoneOne = phone.TelephoneOne,
                TelephoneTwo = phone.TelephoneTwo,
                WhatsApp = phone.WhatsApp,
            
                Client = newClient 
            }).ToList();

           
            newClient.Phones = userPhones;
          
            _db.Clients.Add(newClient);
            await _db.SaveChangesAsync(cancellationToken);


            return new ResponseResult
            {
                message= " created successfully",
                Success = true
            };
        }
    }
}
