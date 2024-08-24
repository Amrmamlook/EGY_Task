using Task_Test.Medatior.Command;
using Task_Test.Service.Interface;

namespace Task_Test.Service
{
  public class ClientService(StoreContext _db) : IClientService
    {
        public async Task<ResponseResult> UpdateClientAsync(int clientId, UpdateClientCommand command, CancellationToken cancellationToken)
        {
            var client = await _db.Clients
            .Include(c => c.Phones) 
            .FirstOrDefaultAsync(c => c.Id == clientId, cancellationToken);

        if (client == null)
        {
            return new ResponseResult
            {
                Success = false,
                Message = "Client not found."
            };
        }

        // Update the client entity with the new data
        client.Name = command.Name;
        client.District = command.District;
        client.Address = command.Address;
        client.Natinality = command.Nationality;
        client.Job = command.Job;
        client.Residence = command.Residence;
        client.SalesMan = command.SalesMan;
        client.Description = command.Description;
        client.CustomerClassifications = command.CustomerClassification;
        client.Email = command.Email;
        client.DateModified = DateOnly.FromDateTime(DateTime.Now);
        client.ModifiedBy = 1;

        // Handle phone updates
        if (client.Phones == null || !client.Phones.Any())
        {
            if (!string.IsNullOrEmpty(command.Mobile) ||
                !string.IsNullOrEmpty(command.TelephoneOne) ||
                !string.IsNullOrEmpty(command.TelephoneTwo) ||
                !string.IsNullOrEmpty(command.WhatsApp))
            {
                var userPhone = new UserPhone
                {
                    Mobile = command.Mobile,
                    TelephoneOne = command.TelephoneOne,
                    TelephoneTwo = command.TelephoneTwo,
                    WhatsApp = command.WhatsApp,
                    Client = client
                };
                _db.UserPhone.Add(userPhone);
            }
        }
        else
        {
            var userPhone = client.Phones.First();
            userPhone.Mobile = command.Mobile;
            userPhone.TelephoneOne = command.TelephoneOne;
            userPhone.TelephoneTwo = command.TelephoneTwo;
            userPhone.WhatsApp = command.WhatsApp;
        }

        // Save changes
        await _db.SaveChangesAsync(cancellationToken);

        return new ResponseResult
        {
            Success = true,
            Message = "Client updated successfully"
        };
        }
    }
}
