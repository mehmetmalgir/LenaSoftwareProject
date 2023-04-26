using System;

namespace LenaSoftwareProject.Consumer.Models.Dto_s
{
    public class ApiFormDto
    {
        public int Id { get; set; }
        public string FormName { get; set; }
        public string Description { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string FullName { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int? Age { get; set; }
    }
}
