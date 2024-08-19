using Mediator;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Task_Test.DataContext.Models.User;
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
           // var userId = _httpContextAccessor.HttpContext.User.GetUserId();

           
            var newClient = new Client
            {
                Name = request.ClientName,
                Address = request.Address,
                District = request.District,
                Natinality = request.Nationality,
                Residence = request.Residence,
                Job = request.Job,
                Email = request.Email,
                AddedByUserId = 1,
                AccountCreationDate = DateOnly.FromDateTime(DateTime.UtcNow),
                SalesMan = request.SalesMan,
                CustomerClassifications = request.CustomerClassification,
                Description= request.Description,
            };
            _db.Clients.Add(newClient);

            if (!string.IsNullOrEmpty(request.Mobile) ||
             !string.IsNullOrEmpty(request.TelephoneOne) ||
             !string.IsNullOrEmpty(request.TelephoneTwo) ||
             !string.IsNullOrEmpty(request.WhatsApp))
            {
                var userPhone = new UserPhone
                {
                    Mobile = request.Mobile,
                    TelephoneOne = request.TelephoneOne,
                    TelephoneTwo = request.TelephoneTwo,
                    WhatsApp = request.WhatsApp,
                    Client = newClient
                };

               
                _db.UserPhone.Add(userPhone);
            }


            //newClient.Phones = userPhone;
          
            await _db.SaveChangesAsync(cancellationToken);


            return new ResponseResult
            {
                Message = " created successfully",
                Success = true
            };
        }
    }
}
