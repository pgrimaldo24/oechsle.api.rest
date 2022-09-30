using Autofac;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Oechsle.Api.Application.Interfaces;
using Oechsle.Api.CrossCutting.Common;
using Oechsle.Api.CrossCutting.Dto;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Oechsle.Api.Crud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly Lazy<IAuthApplication> _authApplication;
        private readonly AppSetting _appSettings; 

        public AuthController(ILifetimeScope lifetimeScope, IOptions<AppSetting> appSettings)
        {
            _authApplication = new Lazy<IAuthApplication>(() => lifetimeScope.Resolve<IAuthApplication>());
            _appSettings = appSettings.Value; 
        }

        private IAuthApplication AuthApplication => _authApplication.Value;
         
        [HttpPost("auth")]
        public async Task<JsonResult> AuthUser([FromBody] CredentialDto authDto)
        {
            ResponseDto response;
            try
            { 
                response = await AuthApplication.AuthApplicationAsync(authDto);
            }
            catch (FunctionalException ex)
            {
                response = new ResponseDto { Status = ex.FuntionalCode, Message = ex.Message, Data = ex.Data, TransactionId = ex.TransactionId };
                 
            }
            catch (TechnicalException ex)
            {
                response = new ResponseDto { Status = ex.ErrorCode, Message = ex.Message, Data = ex.Data, TransactionId = ex.TransactionId }; 
            }
            catch (Exception ex)
            {
                response = new ResponseDto { Status = Constants.SystemStatusCode.TechnicalError, Message = ex.Message }; 
            }
            return new JsonResult(response);
        }
    }
}
