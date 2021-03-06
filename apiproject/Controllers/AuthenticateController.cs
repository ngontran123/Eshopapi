using System;
using Models;
using Microsoft.AspNetCore.Http;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Data;
using usercustom;
using Microsoft.EntityFrameworkCore;
namespace Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class AuthenticateController : ControllerBase
  {
    private readonly UserManager<Applicationuser> userManager;
    private readonly RoleManager<IdentityRole> roleManager;
    private readonly IConfiguration _configuration;
    private readonly EcommerContext _ecommerContext;
    public AuthenticateController(UserManager<Applicationuser> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration, EcommerContext ecommerContext)
    {
      this.userManager = userManager;
      this.roleManager = roleManager;
      _configuration = configuration;
      _ecommerContext = ecommerContext;
    }

    [HttpPost]
    [Route("Login")]
    public async Task<IActionResult> login([FromBody] Login login)
    {
      var user = await userManager.FindByNameAsync(login.phone);
      if (user != null && await userManager.CheckPasswordAsync(user, login.password))
      {
        var userRole = await userManager.GetRolesAsync(user);
        var authclaims = new List<Claim>
          {
              new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
              new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),

          };
        foreach (var userrole in userRole)
        {
          authclaims.Add(new Claim("role", userrole));
        }
        var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));
        var token = new JwtSecurityToken(
                 issuer: _configuration["JWT:ValidIssuer"],
                 audience: _configuration["JWT:ValidAudience"],
                 expires: DateTime.Now.AddHours(500),
                 claims: authclaims,
                 signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                 );
        var refreshObject = new Refreshtoken
        {
          userName = login.phone,
          refreshToken = Guid.NewGuid().ToString()
        };
        await _ecommerContext.refreshtokens.AddAsync(refreshObject);
        await _ecommerContext.SaveChangesAsync();
        var token1 = new JwtSecurityTokenHandler().WriteToken(token);
        var expire = token.ValidTo;
        var userrole1 = await userManager.IsInRoleAsync(user, "customer");
       
       
        return Ok(new
        {
          token = new JwtSecurityTokenHandler().WriteToken(token),
          expiration = token.ValidTo,
          refreshToken = refreshObject.refreshToken
        });
      }
      return Unauthorized(new Response { status = "L???i", message = "T??i kho???n kh??ng h???p l???" });
    }
    
    [HttpPost]
    [Route("{refreshToken}/refresh")]
    public async Task<IActionResult> Refreshtoken([FromRoute] string refresh)
    {

      var refrest_token = await _ecommerContext.refreshtokens.SingleOrDefaultAsync(x => x.refreshToken == refresh);
      var user = await userManager.FindByNameAsync(refrest_token.userName);
      if (refrest_token == null)
      {
        return StatusCode(StatusCodes.Status500InternalServerError, new Response { status = "L???i", message = "Kh??ng c?? refresh token n??y trong c?? s??? d??? li???u" });
      }
      var userRole = await userManager.GetRolesAsync(user);
      var authclaims = new List<Claim>
          {
              new Claim(JwtRegisteredClaimNames.Sub ,refrest_token.userName),
              new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),

          };
      foreach (var userrole in userRole)
      {
        authclaims.Add(new Claim("role", userrole));
      }
      var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));
      var token = new JwtSecurityToken(
               issuer: _configuration["JWT:ValidIssuer"],
               audience: _configuration["JWT:ValidAudience"],
               expires: DateTime.Now.AddHours(12),
               claims: authclaims,
               signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
               );
      refrest_token.refreshToken = Guid.NewGuid().ToString();
      _ecommerContext.refreshtokens.Update(refrest_token);
      await _ecommerContext.SaveChangesAsync();

      return Ok(new
      {
        token = new JwtSecurityTokenHandler().WriteToken(token),
        expiration = token.ValidTo,
        refreshtoken = refrest_token.refreshToken
      });

    }
    
    [HttpPost]
    [Route("Register")]
    public async Task<IActionResult> Register([FromBody] Register register)
    {
      var userExists = await userManager.FindByNameAsync(register.name);
      if (userExists != null)
      {
        return StatusCode(StatusCodes.Status400BadRequest, new Response { status = "L???i", message = "T??i kho???n n??y ???? t???n t???i trong h??? th???ng" });
      }

      Applicationuser user = new Applicationuser()
      {
        Email = register.email,
        UserName = register.phoneNumber,
        SecurityStamp = Guid.NewGuid().ToString(),
        PhoneNumber = register.name,
        PhoneNumberConfirmed = true
      };
      var res = await userManager.CreateAsync(user, register.password);
      if (!res.Succeeded)
      {
        return StatusCode(StatusCodes.Status400BadRequest, new Response { status = "L???i", message = "Q??a tr??nh ????ng k?? user ???? x???y ra l???i." });

      }
      if (!await roleManager.RoleExistsAsync(UserRole.customer))
      {
        await roleManager.CreateAsync(new IdentityRole(UserRole.customer));
      }
      if (await roleManager.RoleExistsAsync(UserRole.customer))
      {
        await userManager.AddToRoleAsync(user, UserRole.customer);
      }
      
         var cus=new customer()
         {
             phoneNumber=user.UserName,
             password=user.PasswordHash,
             name=user.PhoneNumber,
             email=user.Email,
             accessToken=null,
             refreshToken=null

         };
         await _ecommerContext.customers.AddAsync(cus);
         await _ecommerContext.SaveChangesAsync();

      return Ok(new Response { status = "ok", message = "T??i kho???n ???????c t???o th??nh c??ng." });
    }
    
    [HttpPost]
    [Route("register-seller")]
    public async Task<IActionResult> registeradmin([FromBody] Register register)
    {
      var userExists = await userManager.FindByEmailAsync(register.email);
      if (userExists != null)
      {
        return StatusCode(StatusCodes.Status500InternalServerError, new Response { status = "L???i", message = "T??i kho???n n??y ???? t???n t???i trong h??? th???ng" });
      }
      else
      {
        Applicationuser user = new Applicationuser()
        {
          Email = register.email,
          UserName = register.phoneNumber,
          PhoneNumber = register.name,

          SecurityStamp = Guid.NewGuid().ToString(),

        };
        var res = await userManager.CreateAsync(user, register.password);
        if (!res.Succeeded)
        {
          return StatusCode(StatusCodes.Status500InternalServerError, new Response { status = "L???i", message = "Q??a tr??nh ????ng k?? user ???? x???y ra l???i." });

        }
        if (!await roleManager.RoleExistsAsync(UserRole.seller))
        {
          await roleManager.CreateAsync(new IdentityRole(UserRole.seller));
        }
        if (!await roleManager.RoleExistsAsync(UserRole.customer))
        {
          await roleManager.CreateAsync(new IdentityRole(UserRole.customer));
        }
        if (await roleManager.RoleExistsAsync(UserRole.seller))
        {
          await userManager.AddToRoleAsync(user, UserRole.seller);
        }
          var sel=new Seller()
            {
                 name=user.PhoneNumber,
                 password=user.PasswordHash,
                phoneNumber=user.UserName,
                 email=user.Email,
                 accessToken=null,
                 refreshToken=null
             };
            await _ecommerContext.seller.AddAsync(sel);
             await _ecommerContext.SaveChangesAsync();
        return Ok(new Response { status = "Ok", message = "???? ????ng k?? th??nh c??ng t??i kho???n seller." });
      }
    }

  }
}