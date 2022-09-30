using Microsoft.Extensions.Options;
using Oechsle.Api.Application.Interfaces;
using Oechsle.Api.CrossCutting.Common;
using Oechsle.Api.CrossCutting.Dto;
using Oechsle.Api.CrossCutting.IoC;
using Oechsle.Api.Domain.Models;
using Oechsle.Api.Infraestructure.Interfaces;
using Oechsle.Api.Infraestructure.Interfaces.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oechsle.Api.Application.Implementations
{
    public class EmployeeApplication : IEmployeeApplication
    {
        private readonly Lazy<IUnitOfWork> _unitOfWork;
        private readonly AppSetting _appSettings;

        public EmployeeApplication(IOptions<AppSetting> appSettings)
        {
            _unitOfWork = new Lazy<IUnitOfWork>(() => IocAutofacContainer.Current.Resolve<IUnitOfWork>());
            _appSettings = appSettings.Value;
        }

        private IUnitOfWork UnitOfWork => _unitOfWork.Value;

        private IEmployeeRepository EmployeeRepository => UnitOfWork.Repository<IEmployeeRepository>();
         
        public async Task<ResponseDto> DeleteEmployeeAsync(int id)
        {
            if (id == null || id == 0)
                return new ResponseDto
                {
                    Message = "El servicio DeleteEMployeeAsync retorno un error",
                    Status = Constants.SystemStatusCode.TechnicalError
                };

            var employer = new EmployeeEntity
            { 
                Id = id
            };

            UnitOfWork.Set<EmployeeEntity>().Attach(employer);
            UnitOfWork.Set<EmployeeEntity>().Remove(employer);
            UnitOfWork.SaveChanges();

            return new ResponseDto
            {
                Message = "El registro se eliminó correctamente",
                Status = Constants.SystemStatusCode.Ok
            };
        }

        public async Task<ResponseDto> GetAllEmployeeAsync()
        {
            var result = await EmployeeRepository.GetAllAsync();

            if (ReferenceEquals(null, result))
                return new ResponseDto
                {
                    Message = "Ocurrió un error en el servicio GetAllEmployeeAsync",
                    Status = Constants.SystemStatusCode.TechnicalError
                };

            return new ResponseDto
            {
                Message = "Se procesó correctamente",
                Status = Constants.SystemStatusCode.Ok,
                Data = result
            };
        }

        public async Task<ResponseDto> PostRegisterEmployeeAsync(RegisterEmployeeDto registerEmployeeDto)
        {
            if (ValidateEmployee(registerEmployeeDto))
                return new ResponseDto
                {
                    Message = "El servicio PostRegisterEmployeeAsync retornó un valor null",
                    Status = Constants.SystemStatusCode.TechnicalError
                };

            var employeeEntity = await SetEmployee(registerEmployeeDto);
            UnitOfWork.Set<EmployeeEntity>().Add(employeeEntity);
            UnitOfWork.SaveChanges();

            return new ResponseDto
            {
                Message = "El registro se actualizó correctamente",
                Status = Constants.SystemStatusCode.Ok                
            };
        }

        public async Task<ResponseDto> PutUpdateEmployeeAsync(UpdateEmployeeDto updateEmployeeDto)
        {
            var employeeEntity = await EmployeeRepository.PutAsync(updateEmployeeDto.id);

            if (ReferenceEquals(null, employeeEntity))
                return new ResponseDto
                {
                    Message = "El servicio PutUpdateEmployeeAsync retorno un error",
                    Status = Constants.SystemStatusCode.TechnicalError
                };

            employeeEntity.Name = updateEmployeeDto.Employee.employee_name;
            employeeEntity.Age = updateEmployeeDto.Employee.employee_age;
            employeeEntity.Salary = updateEmployeeDto.Employee.employee_salary;
            employeeEntity.ProfileImage = updateEmployeeDto.Employee.profile_image;
            UnitOfWork.SaveChanges();

            return new ResponseDto
            {
                Message = "Se procesó correctamente",
                Status = Constants.SystemStatusCode.Ok
            };
        }

        private async Task<EmployeeEntity> SetEmployee(RegisterEmployeeDto registerEmployeeDto)
        {
            var employee = new EmployeeEntity
            {
                Name = registerEmployeeDto.employee_name,
                Age = registerEmployeeDto.employee_age,
                Salary = registerEmployeeDto.employee_salary,
                ProfileImage = registerEmployeeDto.profile_image
            };

            return employee;
        }

        private bool ValidateEmployee(RegisterEmployeeDto registerEmployeeDto)
        {
            if (string.IsNullOrEmpty(registerEmployeeDto.employee_name))
                return true;

            if (registerEmployeeDto.employee_age == null)
                return true;

            if (registerEmployeeDto.employee_salary == null || registerEmployeeDto.employee_salary == 0)
                return true;

            return false;
        }
    }
}
