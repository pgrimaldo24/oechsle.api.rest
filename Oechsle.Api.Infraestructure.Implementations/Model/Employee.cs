using System;
using System.Collections.Generic;

#nullable disable

namespace Oechsle.Api.Infraestructure.Implementations.Model
{
    public partial class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string DocumentNumber { get; set; }
        public decimal? Salary { get; set; }
        public int? Age { get; set; }
        public string ProfileImage { get; set; }
    }
}
