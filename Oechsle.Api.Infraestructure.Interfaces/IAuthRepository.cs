using Oechsle.Api.CrossCutting.Dto;
using System.Threading.Tasks;

namespace Oechsle.Api.Infraestructure.Interfaces
{
    public interface IAuthRepository
    {
        Task<AuthDto> GetKeyAppAsync(CredentialDto credential);
    }
}
