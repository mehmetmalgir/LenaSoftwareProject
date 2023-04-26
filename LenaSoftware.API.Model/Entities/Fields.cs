
using LenaSoftware.API.Structure.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace LenaSoftware.API.Model.Entities
{
    public class Fields : BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int? Age { get; set; }
        public int? FormId { get; set; }
        public Form Form { get; set; }




    }
}
