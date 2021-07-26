using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using WebApplication1.Model;

namespace WebApplication1.Repository
{
    public class AccountRepository :IAccountRepository
    {

        //For register
        private readonly UserManager<Applicationuser> _usermanager;



        //For Login

        private readonly SignInManager<Applicationuser> _signinManager;

        //for configuration

        private readonly IConfiguration _configuration;
        public AccountRepository(UserManager<Applicationuser> userManager , SignInManager<Applicationuser> signInManager, IConfiguration configuration)
        {
            _usermanager = userManager;
            _signinManager = signInManager;
            _configuration = configuration;
        }

        public async Task<IdentityResult> SignUpAsync(SingupModel singupModel)
        {
            var user = new Applicationuser()
            { 
                FullName = singupModel.FullName,
                Email =singupModel.Email,
                Address = singupModel.Address,
                UserName = singupModel.Email

            };
            return await _usermanager.CreateAsync(user, singupModel.Password);

        }


        public async Task<string> LoginAsycn(SignInModel sinInModel)
        {
            var result = await _signinManager.PasswordSignInAsync(sinInModel.email, sinInModel.Password, false, false);
            if(!result.Succeeded)
            {
                return null;
            }
            //Claims

            var authclaim = new List<Claim>
            {
             new Claim(ClaimTypes.Name,sinInModel.email),
             new Claim(JwtRegisteredClaimNames.Jti,
             Guid.NewGuid().ToString())

             };

            //Key

            var authsigninkey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration["Jwt:Secret"]));

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:ValidIssuser"],
                audience: _configuration["Jwt:ValidAudience"],
                expires: DateTime.Now.AddDays(1),


                claims:authclaim,
                signingCredentials:new SigningCredentials(authsigninkey,SecurityAlgorithms.HmacSha256Signature)
                
                );

            return new JwtSecurityTokenHandler().WriteToken(token);

        }

  
    }
}
