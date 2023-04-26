using FluentValidation;
using LenaSoftwareProject.Consumer.Models.Dto_s;

namespace LenaSoftwareProject.Consumer.Validations
{
    public class NewFormDtoValidator : AbstractValidator<NewFormDto>
    {
        public NewFormDtoValidator()
        {
            RuleFor(dto => dto.FormName).NotEmpty().WithMessage("Form İsmi Boş Bırakılamaz!");
            RuleFor(dto => dto.Description).NotEmpty().WithMessage("Lütfen Form Açıklaması Yazınız");
            RuleFor(dto => dto.Name).NotEmpty().WithMessage("İsim Boş Bırakılamaz");
            RuleFor(dto => dto.Surname).NotEmpty().WithMessage("Soyisim Boş Bırakılamaz");
        }

    }
}
