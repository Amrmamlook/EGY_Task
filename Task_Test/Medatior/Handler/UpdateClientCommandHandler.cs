using Mediator;
using Task_Test.Medatior.Command;

namespace Task_Test.Medatior.Handler
{
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

