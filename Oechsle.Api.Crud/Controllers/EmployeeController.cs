using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Oechsle.Api.Application.Interfaces;
using Oechsle.Api.CrossCutting.Common;
using Oechsle.Api.CrossCutting.Dto;
using Oechsle.Api.CrossCutting.IoC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Oechsle.Api.Crud.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)] 
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly Lazy<IEmployeeApplication> _employeeApplication;
        
        public EmployeeController(IOptions<AppSetting> appSettings)
        {
            _employeeApplication = new Lazy<IEmployeeApplication>(() => IocAutofacContainer.Current.Resolve<IEmployeeApplication>());
        }

        private IEmployeeApplication EmployeeApplication => _employeeApplication.Value;

        [HttpGet("GetAllEmployee")]
        public async Task<JsonResult> GetAllEmployee()
        {
            var response = new ResponseDto();
            try
            {
                response = await EmployeeApplication.GetAllEmployeeAsync();
            }
            catch (FunctionalException ex)
            {
                response = new ResponseDto { Status = ex.FuntionalCode, Message = ex.Message, Data = ex.Data, TransactionId = ex.TransactionId };
            }
            catch (TechnicalException ex)
            {
                response = new ResponseDto { Status = ex.ErrorCode, Message = ex.StackTrace.ToString(), Data = ex.Data, TransactionId = ex.TransactionId }; 
            }
            catch (Exception ex)
            {
                response = new ResponseDto { Status = Constants.SystemStatusCode.ServerError, Message = ex.StackTrace.ToString() }; 
            }

            return new JsonResult(response);
        }

        [HttpPost("PostRegisterEmployee")]
        public async Task<JsonResult> PostRegisterEmployee([FromBody] RegisterEmployeeDto registerEmployeeDto)
        {
            var response = new ResponseDto();
            try
            {
                response = await EmployeeApplication.PostRegisterEmployeeAsync(registerEmployeeDto);
            }
            catch (FunctionalException ex)
            {
                response = new ResponseDto { Status = ex.FuntionalCode, Message = ex.Message, Data = ex.Data, TransactionId = ex.TransactionId };
            }
            catch (TechnicalException ex)
            {
                response = new ResponseDto { Status = ex.ErrorCode, Message = ex.StackTrace.ToString(), Data = ex.Data, TransactionId = ex.TransactionId };
            }
            catch (Exception ex)
            {
                response = new ResponseDto { Status = Constants.SystemStatusCode.ServerError, Message = ex.StackTrace.ToString() };
            }

            return new JsonResult(response);
        }

        [HttpPut("PutUpdateEmployee")]
        public async Task<JsonResult> PutUpdateEmployee([FromBody] UpdateEmployeeDto updateEmployeeDto)
        {
            var response = new ResponseDto();
            try
            {
                response = await EmployeeApplication.PutUpdateEmployeeAsync(updateEmployeeDto);
            }
            catch (FunctionalException ex)
            {
                response = new ResponseDto { Status = ex.FuntionalCode, Message = ex.Message, Data = ex.Data, TransactionId = ex.TransactionId };
            }
            catch (TechnicalException ex)
            {
                response = new ResponseDto { Status = ex.ErrorCode, Message = ex.StackTrace.ToString(), Data = ex.Data, TransactionId = ex.TransactionId };
            }
            catch (Exception ex)
            {
                response = new ResponseDto { Status = Constants.SystemStatusCode.ServerError, Message = ex.StackTrace.ToString() };
            }

            return new JsonResult(response);
        }

        [HttpDelete("DeleteEmployee")]
        public async Task<JsonResult> DeleteEmployee(int id)
        {
            var response = new ResponseDto();
            try
            {
                response = await EmployeeApplication.DeleteEmployeeAsync(id);
            }
            catch (FunctionalException ex)
            {
                response = new ResponseDto { Status = ex.FuntionalCode, Message = ex.Message, Data = ex.Data, TransactionId = ex.TransactionId };
            }
            catch (TechnicalException ex)
            {
                response = new ResponseDto { Status = ex.ErrorCode, Message = ex.StackTrace.ToString(), Data = ex.Data, TransactionId = ex.TransactionId };
            }
            catch (Exception ex)
            {
                response = new ResponseDto { Status = Constants.SystemStatusCode.ServerError, Message = ex.StackTrace.ToString() };
            }

            return new JsonResult(response);
        }
    }
}
