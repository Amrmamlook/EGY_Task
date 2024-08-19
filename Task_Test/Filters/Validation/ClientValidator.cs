using FluentValidation;
using PhoneNumbers;
using Task_Test.Medatior.Command;

namespace Task_Test.Filters.Validation
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

            RuleFor(x => x.Mobile)
               .Must(BeValidPhoneNumber).WithMessage("Invalid mobile number format")
               .NotEmpty().NotNull();

            RuleFor(x => x.WhatsApp)
                .Must(BeValidPhoneNumber).WithMessage("Invalid WhatsApp number format")
                .When(x => !string.IsNullOrEmpty(x.WhatsApp));

            RuleFor(x => x.TelephoneOne)
                .Must(BeValidLandlinePhoneNumber).WithMessage("Invalid telephone one number format")
                .When(x => !string.IsNullOrEmpty(x.TelephoneOne));

            RuleFor(x => x.TelephoneTwo)
                .Must(BeValidLandlinePhoneNumber).WithMessage("Invalid telephone two number format")
                .When(x => !string.IsNullOrEmpty(x.TelephoneTwo));
        }
        private bool BeValidPhoneNumber(string phoneNumber)
        {
            var phoneNumberUtil = PhoneNumberUtil.GetInstance();

            var numberProto = phoneNumberUtil.Parse(phoneNumber, "EG");
            return phoneNumberUtil.IsValidNumber(numberProto);

        }
        private bool BeValidLandlinePhoneNumber(string phoneNumber)
        {
            var phoneNumberUtil = PhoneNumberUtil.GetInstance();
            var numberProto = phoneNumberUtil.Parse(phoneNumber, "EG");

            var numberType = phoneNumberUtil.GetNumberType(numberProto);
            return phoneNumberUtil.IsValidNumber(numberProto) && numberType == PhoneNumberType.FIXED_LINE;
        }
    }

}
