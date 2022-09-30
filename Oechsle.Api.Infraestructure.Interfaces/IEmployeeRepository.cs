using Oechsle.Api.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oechsle.Api.Infraestructure.Interfaces
{
    public interface IEmployeeRepository
    { 
        Task<List<EmployeeEntity>> GetAllAsync();
        Task<EmployeeEntity> PutAsync(int id);
    }
}
