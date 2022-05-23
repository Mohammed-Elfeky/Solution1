using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using d1.DTO;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using System;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.Extensions.Configuration;
using d1.Model;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Linq;

namespace d1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly IConfiguration config;

        public AccountController(UserManager<IdentityUser> userManager, IConfiguration config)
        {
            this.userManager = userManager;
            this.config = config;
        }

        [HttpPost("signUp")]
        public async Task<IActionResult> signUp(signUp form)
        {
            if(ModelState.IsValid==false) return BadRequest(ModelState);
            
            IdentityUser user = new IdentityUser();
            user.UserName = form.UserName;
            user.PasswordHash = form.Password;
            IdentityResult result = await userManager.CreateAsync(user,form.Password);

            if (result.Succeeded == true)
            {
                return Ok(user);
            }

            List<err> errors = new List<err>();
            foreach(var item in result.Errors) {
                errors.Add(new err() { msg = item.Description });
                    }
            return BadRequest(errors);
        }

        [HttpPost("signIn")]
        public async Task<IActionResult> signIn(signIn form)
        {
            if (ModelState.IsValid == false) {
                return BadRequest();
            }
  

            IdentityUser user=await userManager.FindByNameAsync(form.UserName);
            if (user == null) return Unauthorized("the user name or password is not correct");
            
            bool passIsCorrect= await userManager.CheckPasswordAsync(user, form.Password);
            if (!passIsCorrect) return Unauthorized("the user name or password is not correct");

            //claims
            var claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Name, user.UserName));
            claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id));
            claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));


            var roles =await userManager.GetRolesAsync(user);
            foreach(var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }


            //create token
            SecurityKey key =new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["jwt:key"]));
            SigningCredentials creds =new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            JwtSecurityToken token = new JwtSecurityToken(
                issuer: config["jwt:issuer"],
                audience: config["jwt:audiance"],
                claims: claims,
                expires: DateTime.Now.AddHours(3),
                signingCredentials: creds
            );


            return Ok(new{token = new JwtSecurityTokenHandler().WriteToken(token),expiration = token.ValidTo});
        }
    }
}
