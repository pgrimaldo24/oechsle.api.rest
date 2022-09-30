using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oechsle.Api.Domain.Models
{
    public class KeyappEntity
    {
        public int Id { get; set; }
        public string User { get; set; }
        public string Password { get; set; } 
        public int Flag { get; set; } 
    }
}
