using FluentValidation.Results;
using LenaSoftwareProject.Consumer.Models.Contexts;
using LenaSoftwareProject.Consumer.Models.Dto_s;
using LenaSoftwareProject.Consumer.Validations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Linq;

namespace LenaSoftwareProject.Consumer.Controllers
{
    public class AuthenticationController : Controller
    {
        [HttpGet]
        public IActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        public IActionResult LogIn(LogInDto dto)
        {
            LogInDtoValidator validator = new LogInDtoValidator();
            var result = validator.Validate(dto);

            if (result.IsValid)
            {
                LenaSoftwareDbContext context = new LenaSoftwareDbContext();
                var user = context.Users.SingleOrDefault(x => x.UserName == dto.UserName && x.Password == dto.Password);

                if (user == null)
                {
                    return Json(new { isSuccess = false, Message = "Kullanıcı Bulunamadı!" });
                }

                var jsonStr = JsonConvert.SerializeObject(user);
                HttpContext.Session.SetString("LoggedInUser", jsonStr);

                return Json(new { isSuccess = true });

            }
            else
            {
                string errorMessages = "<div class = 'alert alert-warning'>";
                foreach (ValidationFailure item in result.Errors)               
                {
                    errorMessages += $"<div>{item.ErrorMessage}</div>";
                }

                errorMessages += "</div>";

                return Json(new { isSuccess = false, Message = errorMessages });

            }




        }
    }
}
