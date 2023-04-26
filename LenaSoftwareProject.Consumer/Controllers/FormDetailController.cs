using LenaSoftwareProject.Consumer.Models.Dto_s;
using LenaSoftwareProject.Consumer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Net;
using System;
using System.Reflection.Metadata.Ecma335;

namespace LenaSoftwareProject.Consumer.Controllers
{
    public class FormDetailController : Controller
    {
        
        public IActionResult Index()
        {
            var jsonData = TempData["jsonData"] as string;           
            var jsonModel = JsonConvert.DeserializeObject(jsonData);            
            ApiFormDto viewModel = new ApiFormDto();
            var stringi = jsonModel.ToString();
            viewModel = JsonConvert.DeserializeObject<ApiFormDto>(stringi);
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult GetFormById(int Id)
        {

            string jsonStr = HttpContext.Session.GetString("LoggedInUser");

            if (string.IsNullOrEmpty(jsonStr))
                return Redirect("/Authentication/LogIn");


            HttpClient client = new HttpClient();
            HttpResponseMessage msg = null;
            string jsonContent = string.Empty;


            client.BaseAddress = new Uri($"https://localhost:44392/api/Forms/{Id}");
            msg = client.GetAsync(client.BaseAddress).Result;

            if (msg.StatusCode == HttpStatusCode.OK)
            {

                ApiFormDto viewModel = new ApiFormDto();

                jsonContent = msg.Content.ReadAsStringAsync().Result;
                viewModel = JsonConvert.DeserializeObject<ApiFormDto>(jsonContent);

                var jsonData = jsonContent; 
                TempData["jsonData"] = JsonConvert.SerializeObject(jsonData);
                return Json(new { isSuccess = true });


                
            }


            return Json(new {isSuccess = false});
        }

       




    }
}
