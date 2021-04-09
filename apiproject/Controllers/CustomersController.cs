using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Data;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Models;
using DTO;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;

namespace Controllers
{
[Route("api/[controller]")]
    [ApiController]
 public class CustomersController : ControllerBase
 {
     private readonly EcommerContext _context;
     public CustomersController(EcommerContext context)
     {
         _context=context;
     }
     [HttpGet]
    public async Task<IEnumerable<customerDTO>> Getcustomer(string phoneNumber)
    {
      return await _context.customers
      .Select(p => p.tocustomerDTO()).ToListAsync();
    }
     
    [HttpGet("{id}")]
     public async Task<ActionResult<customerDTO>> Getcustomer(int id)
     {
      var cus1=await _context.customers.FindAsync(id);
      if(cus1==null)
      {
          return NotFound();
      }
      return cus1.tocustomerDTO();
     }

    [Route("info")]
    [HttpGet]
    public async Task<ActionResult<customerDTO>> CustomerInfoFormToken()
    {
      var auth =  Request.Headers["Authorization"].ToString();
      var jwt = auth.Substring(auth.IndexOf(" ")+1);
      var handler = new JwtSecurityTokenHandler();
      var token = handler.ReadJwtToken(jwt);
      var subject = token.Subject;
      var cus = await _context.customers.Where(cus=>cus.phoneNumber==subject).FirstAsync();
      return cus!=null ? cus.tocustomerDTO() : NotFound();
    }

     [HttpPost]
     public async Task<ActionResult<customerDTO>> Createcustomer(customerDTO cus2)
     {
         var cus1=cus2.tocustomer();
         _context.customers.Add(cus1);
         await _context.SaveChangesAsync();
         return CreatedAtAction(nameof(Getcustomer),new {id=cus1.id},cus1);
     }

     [HttpPut]
     public async Task<IActionResult> Updatecustomer(customerDTO cus2)
     {
         var cus1=await _context.customers.FindAsync(cus2.id);
         if(cus1==null)
         {
             return NotFound();
         }
        cus1.Mapto4(cus2);
        _context.customers.Update(cus1);
        try{
            await _context.SaveChangesAsync();
        }
        catch(DbUpdateConcurrencyException) when (!CusExist(cus1.id))
        {
            return NotFound();
        }
        return NoContent();
     }

     public bool CusExist(int id)
     {
         return _context.customers.Any(p=>p.id==id);
     }
     [HttpDelete("{id}")]
     
     public async Task<IActionResult> DeleteCustomer(int id)
     {
     var cus1=await _context.customers.FindAsync(id);
     if(cus1==null)
     {
         return NotFound();
     }
     _context.customers.Remove(cus1);
     await _context.SaveChangesAsync();
     return NoContent();
     }
 }
}