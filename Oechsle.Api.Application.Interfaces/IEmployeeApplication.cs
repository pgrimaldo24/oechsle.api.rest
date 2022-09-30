using Oechsle.Api.CrossCutting.Dto;
using System.Threading.Tasks;

namespace Oechsle.Api.Application.Interfaces
{
    public interface IEmployeeApplication
    {
        Task<ResponseDto> GetAllEmployeeAsync();
        Task<ResponseDto> PostRegisterEmployeeAsync(RegisterEmployeeDto registerEmployeeDto);
        Task<ResponseDto> PutUpdateEmployeeAsync(UpdateEmployeeDto updateEmployeeDto);
        Task<ResponseDto> DeleteEmployeeAsync(int id);
    }
}
