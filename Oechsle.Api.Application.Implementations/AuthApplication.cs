using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Oechsle.Api.Application.Interfaces;
using Oechsle.Api.CrossCutting.Common;
using Oechsle.Api.CrossCutting.Dto;
using Oechsle.Api.CrossCutting.IoC;
using Oechsle.Api.Infraestructure.Interfaces;
using Oechsle.Api.Infraestructure.Interfaces.Data;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Oechsle.Api.Application.Implementations
{
    public class AuthApplication : IAuthApplication
    {
        private readonly AppSetting _appSettings;
        private Lazy<IUnitOfWork> _unitOfWork;

        public AuthApplication(IOptions<AppSetting> appSettings)
        {
            _unitOfWork = new Lazy<IUnitOfWork>(() => IocAutofacContainer.Current.Resolve<IUnitOfWork>());
            _appSettings = appSettings.Value;
        }

        private IUnitOfWork UnitOfWork => _unitOfWork.Value;
        private IAuthRepository AuthRepository => UnitOfWork.Repository<IAuthRepository>();

        public async Task<ResponseDto> AuthApplicationAsync(CredentialDto credential)
        {
            var response = new ResponseDto();
            var jwt = new JWTDto();
            var keyapp = await AuthRepository.GetKeyAppAsync(credential);

            if (ReferenceEquals(null, keyapp))
                return new ResponseDto
                {
                    Message = "Ocurrió un error en el servicioAuthenticationAsync",
                    Status = Constants.SystemStatusCode.TechnicalError
                };

            jwt.Token = await GenerarTokenJWTAsync(keyapp);

            if (keyapp.Status.Equals(Constants.StatusKey.ActivatedStatus))
                jwt.Status = "active";
            else
                jwt.Status = "inactive";

            response.Message = "Se procesó correctamente";
            response.Status = Constants.SystemStatusCode.Ok;
            response.Data = jwt;
            return response;
        }

        #region Method GenerateTokenJWT
        private async Task<string> GenerarTokenJWTAsync(AuthDto credential)
        {
            DateTime expires = DateTime.Now.AddHours(_appSettings.JWTConfigurations.ExpirationTimeHours);
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.JWTConfigurations.Secret);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                  new Claim(Constants.UserClaimsKeyApp.IdUserKeyApp, credential.Id),
                  new Claim(Constants.UserClaimsKeyApp.User, credential.User),
                  new Claim(Constants.UserClaimsKeyApp.Password, credential.Password),
                  new Claim(Constants.UserClaimsKeyApp.Status, credential.Status)
                }),
                Expires = expires,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                                                                SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
        #endregion

    }
}
