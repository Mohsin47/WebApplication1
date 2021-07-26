using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Model;

namespace WebApplication1.Repository
{
    public interface IAccountRepository
    {

        Task<IdentityResult> SignUpAsync(SingupModel singupModel);


        Task<string> LoginAsycn(SignInModel sinInModel);

    }
}
