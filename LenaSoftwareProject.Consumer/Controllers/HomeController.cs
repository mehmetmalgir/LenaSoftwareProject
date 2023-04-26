using LenaSoftwareProject.Consumer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Threading.Tasks;
using LenaSoftwareProject.Consumer.Models.Dto_s;
using FluentValidation.Results;
using System.IO;
using System.Text;
using LenaSoftwareProject.Consumer.Validations;

namespace LenaSoftwareProject.Consumer.Controllers
{
    public class HomeController : Controller
    {
      
        public IActionResult Index()
        {
            string jsonStr = HttpContext.Session.GetString("LoggedInUser");

            if (string.IsNullOrEmpty(jsonStr))
                return Redirect("/Authentication/LogIn");


            HttpClient client = new HttpClient();
            HttpResponseMessage msg = null;
            string jsonContent = string.Empty;


            client.BaseAddress = new Uri("https://localhost:44392/api/Forms");
            msg = client.GetAsync(client.BaseAddress).Result;

            if (msg.StatusCode == HttpStatusCode.OK)
            {

                ViewModel viewModel = new ViewModel();

                jsonContent = msg.Content.ReadAsStringAsync().Result;
                viewModel.ApiFormDtos = JsonConvert.DeserializeObject<List<ApiFormDto>>(jsonContent);
                               

                return View(viewModel);
            }


            return null;

           
        }


        [HttpPost]
        public IActionResult CreateNewForm(NewFormDto dto)
        {
            NewFormDtoValidator validator = new NewFormDtoValidator();
            var result = validator.Validate(dto);
            if (result.IsValid)
            {

                HttpClient client = new HttpClient();

                client.BaseAddress = new Uri("https://localhost:44392/api/Forms");

                var jsonStr = JsonConvert.SerializeObject(new
                {
                    FormName = dto.FormName,
                    Description = dto.Description,
                    FullName = $"{dto.Name}+{dto.Surname}",
                    Name = dto.Name,
                    Surname = dto.Surname,
                    Age = dto.Age
                });



                StringContent content = new StringContent(jsonStr, Encoding.UTF8, "application/json");

                HttpResponseMessage msg =
                    client.PostAsync(client.BaseAddress, content).Result;

                if (msg.StatusCode == HttpStatusCode.Created)
                {
                    return Json(new { IsSuccess = true, Message = "Form Başarıyla Oluşturuldu" });
                }

                return Json(new { IsSuccess = false });

            }
            else
            {
                string errorMessages = "<div class= 'alert alert-warning'>";

                foreach (ValidationFailure item in result.Errors)
                {
                    errorMessages += $"<div>{item.ErrorMessage}</div>";
                }

                errorMessages += "</div>";

                return Json(new { IsSuccess = false, Message = errorMessages });
            }

        }




    }
}
