using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Oechsle.Api.Crud.Extensions
{
    public interface IServiceRegistrationContracts
    {
        public void RegisterAppServices(IServiceCollection services, IConfiguration configuration);
    }
}
