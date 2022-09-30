using System;
using System.Collections.Generic;
 
namespace Oechsle.Api.Domain.Models
{
    public class EmployeeEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string DocumentNumber { get; set; }
        public decimal? Salary { get; set; }
        public int? Age { get; set; }
        public string ProfileImage { get; set; }
    }
}
