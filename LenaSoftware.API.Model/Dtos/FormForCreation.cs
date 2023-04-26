
using Google.Protobuf.WellKnownTypes;
using LenaSoftware.API.Structure.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace LenaSoftware.API.Model.Dtos
{
    public class FormForCreation : IDto
    {
        public string FormName { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int? Age { get; set; }



    }
}
