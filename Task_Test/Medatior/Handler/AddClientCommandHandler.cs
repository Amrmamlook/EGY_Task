using Mediator;
using Microsoft.EntityFrameworkCore;
using Task_Test.Medatior.Command;
using Task_Test.Options.Extension;

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

            await _db.SaveChangesAsync(cancellationToken);


            return new ResponseResult
            {
                Message = " created successfully",
                Success = true
            };
        }
    }
    public class UpdateClientCommandHandler(StoreContext _db) : IRequestHandler<UdateClientCommand, ResponseResult>
    {
        public async ValueTask<ResponseResult> Handle(UdateClientCommand request, CancellationToken cancellationToken)
        {
            var client = await _db.Clients
          .Include(c => c.Phones) 
          .FirstOrDefaultAsync(c => c.Id == request.ClientId, cancellationToken);

            if (client == null)
            {
                return new ResponseResult
                {
                    Success = false,
                    Message = "Client not found."
                };
            }

            client.Name = request.ClientName;
            client.District = request.District;
            client.Address = request.Address;
            client.Natinality = request.Nationality;
            client.Job = request.Job;
            client.Residence = request.Residence;
            client.SalesMan = request.SalesMan;
            client.Description = request.Description;
            client.CustomerClassifications = request.CustomerClassification;
            client.Email = request.Email;
            client.DateModified = DateOnly.FromDateTime(DateTime.Now);
            client.ModifiedBy = 1;

           
            if (client.Phones == null || !client.Phones.Any())
            {
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
                        Client = client
                    };
                    _db.UserPhone.Add(userPhone);
                }
            }
            else
            {
                var userPhone = client.Phones.First();
                userPhone.Mobile = request.Mobile;
                userPhone.TelephoneOne = request.TelephoneOne;
                userPhone.TelephoneTwo = request.TelephoneTwo;
                userPhone.WhatsApp = request.WhatsApp;
            }
            await _db.SaveChangesAsync(cancellationToken);

            return new ResponseResult
            {
                Success = true,
                Message = "Client updated successfully"
            };
        }
    }
}

