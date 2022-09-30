using Microsoft.EntityFrameworkCore;
using Oechsle.Api.Domain.Models;
using Oechsle.Api.Infraestructure.Implementations.Data;
using Oechsle.Api.Infraestructure.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Oechsle.Api.Infraestructure.Implementations
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly DataContext context;
        public EmployeeRepository(DataContext context)
        {
            this.context = context;
        }

        public async Task<List<EmployeeEntity>> GetAllAsync()
        {
            var query = await context.Employees.Select(x => new EmployeeEntity
            {
                Id = x.Id,
                Name = x.Name,
                DocumentNumber = x.DocumentNumber,
                Age = x.Age,
                Salary = x.Salary,
                ProfileImage = x.ProfileImage
            }).ToListAsync();

            return query;
        }

        public async Task<EmployeeEntity> PutAsync(int id)
        {
            var query = await context.Employees.Where(x => x.Id == id)
                .FirstOrDefaultAsync();

            return query;
        }
    }
}
