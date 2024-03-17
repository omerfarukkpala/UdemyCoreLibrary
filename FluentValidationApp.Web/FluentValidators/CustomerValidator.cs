using FluentValidation;
using FluentValidationApp.Web.Models;
using System;

namespace FluentValidationApp.Web.FluentValidators
{
    public class CustomerValidator : AbstractValidator<Customer>
    {
        public string NotEmptyMessage { get; } = "{PropertyName} alanı boş geçilemez.";
        public CustomerValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage(NotEmptyMessage);
            RuleFor(x => x.Email).NotEmpty().WithMessage(NotEmptyMessage).EmailAddress().WithMessage("E-mail formatında yazınız.");

            RuleFor(x => x.Age).NotEmpty().WithMessage(NotEmptyMessage).InclusiveBetween(18, 60).WithMessage("Yaş aralığı 18 - 60 arasında olmalıdır.");

            RuleFor(x => x.BirthDay).NotEmpty().Must(x =>
            {
                return DateTime.Now.AddYears(-18) >= x;
            }).WithMessage("Yaşınız 18'den büyük olmalıdır.");

            RuleFor(x => x.Gender).IsInEnum().WithMessage("{PropertyName} alanı Erkek için 1 Kadın için 2 olmalıdır.");

            RuleForEach(x => x.Addresses).SetValidator(new AddressValidator());
        }
    }
}
