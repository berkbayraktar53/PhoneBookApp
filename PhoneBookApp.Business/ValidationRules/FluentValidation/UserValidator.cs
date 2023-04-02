using FluentValidation;
using PhoneBookApp.Entities.Concrete;

namespace PhoneBookApp.Business.ValidationRules.FluentValidation
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(p => p.FirstName).NotEmpty().WithMessage("Ad boş geçilemez");
            RuleFor(p => p.LastName).NotEmpty().WithMessage("Soyad boş geçilemez");
            RuleFor(p => p.Company).NotEmpty().WithMessage("Firma boş geçilemez");
        }
    }
}