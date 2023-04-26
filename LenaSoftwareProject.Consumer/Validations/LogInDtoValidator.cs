﻿using FluentValidation;
using LenaSoftwareProject.Consumer.Models.Dto_s;

namespace LenaSoftwareProject.Consumer.Validations
{
    public class LogInDtoValidator : AbstractValidator<LogInDto>
    {
        public LogInDtoValidator()
        {
            RuleFor(dto => dto.UserName)
               .NotEmpty()
               .WithMessage("Lütfen Kullanıcı Adını Giriniz.");

            RuleFor(dto => dto.Password)
                .NotEmpty()
                .WithMessage("Lütfen Şifrenizi Giriniz")
                .Length(8, 20)
                .WithMessage("Şifreniz En Az 8 En Çok 20 Karakter İçermelidir.");
        }



    }
}
