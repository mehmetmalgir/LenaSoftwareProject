
using LenaSoftware.API.Structure.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace LenaSoftware.API.Model.Entities
{
    public class Form : BaseEntity
    {
        public string FormName { get; set; }
        public string Description { get; set; }
        public DateTime? CreatedAt { get; set; }
        public int? UserId { get; set; }


        public Fields Field { get; set; }
        public User User { get; set; }
                

    }
}
