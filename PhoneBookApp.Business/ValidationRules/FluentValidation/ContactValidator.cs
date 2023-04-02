using FluentValidation;
using PhoneBookApp.Entities.Concrete;

namespace PhoneBookApp.Business.ValidationRules.FluentValidation
{
    public class ContactValidator : AbstractValidator<Contact>
    {
        public ContactValidator()
        {
            RuleFor(p => p.Type).NotEmpty().WithMessage("Bilgi tipi boş geçilemez");
            RuleFor(p => p.Content).NotEmpty().WithMessage("Bilgi içeriği boş geçilemez");
        }
    }
}