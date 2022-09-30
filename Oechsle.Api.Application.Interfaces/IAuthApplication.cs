using Oechsle.Api.CrossCutting.Dto;
using System.Threading.Tasks;

namespace Oechsle.Api.Application.Interfaces
{
    public interface IAuthApplication
    {
        public Task<ResponseDto> AuthApplicationAsync(CredentialDto authDto);
    }
}
