using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Oechsle.Api.Domain.Models;
using Oechsle.Api.Infraestructure.Implementations.Configuration;

namespace Oechsle.Api.Infraestructure.Implementations.Data
{
    public class DataContext : DbContext
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public DataContext(DbContextOptions<DataContext> options, IHttpContextAccessor httpContextAccessor) : base(options)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new EmployeeConfiguration());
            builder.ApplyConfiguration(new KeyAppConfiguration());
        }

        public virtual DbSet<EmployeeEntity> Employees { get; set; }
        public virtual DbSet<KeyappEntity> Keyapps { get; set; }
    }
}
