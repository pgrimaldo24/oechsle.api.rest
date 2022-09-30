using Microsoft.EntityFrameworkCore;
using Oechsle.Api.CrossCutting.Dto;
using Oechsle.Api.Infraestructure.Implementations.Data;
using Oechsle.Api.Infraestructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oechsle.Api.Infraestructure.Implementations
{
    public class AuthRepository : IAuthRepository
    {
        private readonly DataContext context;
        public AuthRepository(DataContext context)
        {
            this.context = context;
        }

        public async Task<AuthDto> GetKeyAppAsync(CredentialDto credential)
        {
            if (credential.User == null && credential.Password == null)
                return null;

            return await context.Keyapps.Where(x => x.User == credential.User.ToString() && x.Password == credential.Password.ToString() && x.Flag == 1)
                    .Select(key => new AuthDto
                    {
                        Id = Convert.ToString(key.Id),
                        User = key.User.ToString(),
                        Password = key.Password.ToString(),
                        Status = Convert.ToString(key.Flag)
                    })
                    .FirstOrDefaultAsync();
        }
    }
}
