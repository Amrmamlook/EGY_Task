using FluentValidation;
using Mediator;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using OneOf;
using PhoneNumbers;
using System.ComponentModel.DataAnnotations;

namespace Task_Test.Medatior.Command
{
    public class AddClientCommand:IRequest<OneOf<OkObjectResult,BadRequestObjectResult>>
    {
        public string Name { get; set; }
        public string District { get; set; } // الحي
        public string Address { get; set; } // العنوان
        public string Nationality { get; set; } // الجنسية
        public string Job { get; set; } // الوظيفة
        public string Residence { get; set; }  // الاقامة
        public string Phone { get; set; }
    }

    public class ValidateClient :AbstractValidator<AddClientCommand> 
    {
        public ValidateClient()
        {
            RuleFor(x => x.Name).NotEmpty().NotNull().MaximumLength(50);
            RuleFor(x=>x.District).NotEmpty().NotNull();
            RuleFor(x=>x.Address).NotEmpty().MaximumLength(200);
            RuleFor(x=>x.Job).NotEmpty().NotNull();
            RuleFor(x=>x.Nationality).NotEmpty().NotNull();
            RuleFor(x=>x.Phone)
                .Must(BeValidPhoneNumber)
                .NotEmpty().NotNull();

        }
        private bool BeValidPhoneNumber(string phoneNumber)
        {
            var phoneNumberUtil = PhoneNumberUtil.GetInstance();
                  
                var numberProto = phoneNumberUtil.Parse(phoneNumber, null);
                return phoneNumberUtil.IsValidNumber(numberProto);
                
        }
    }
}
