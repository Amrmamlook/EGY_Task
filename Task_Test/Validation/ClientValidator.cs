using FluentValidation;
using Task_Test.Medatior.Command;

namespace Task_Test.Validation
{
    public class ClientValidator : AbstractValidator<AddClientCommand>
    {
        public ClientValidator()
        {
            RuleFor(x => x.ClientName).NotEmpty().MaximumLength(50);
            RuleFor(x => x.District).NotEmpty().NotNull();
            RuleFor(x => x.Address).NotEmpty().MaximumLength(200);
            RuleFor(x => x.Job).NotEmpty().NotNull();
            RuleFor(x => x.Nationality).NotEmpty().NotNull();
            RuleForEach(x => x.Phones).SetValidator(new UserPhoneValidator());
        }
    }

}
