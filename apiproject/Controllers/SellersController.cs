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
using System.IdentityModel.Tokens.Jwt;

namespace Controllers
{
[Route("api/[controller]")]
    [ApiController]
 public class SellersController : ControllerBase
 {
     private readonly EcommerContext _context;
     public SellersController(EcommerContext context)
     {
         _context=context;
     }
     [HttpGet]
     public async Task<IEnumerable<SellerDTO>> GetSeller()
     {
        return await _context.seller.Select(p=>p.tosellerdto()).ToListAsync();
     }
     [HttpGet("{id}")]
     public async Task<ActionResult<SellerDTO>> GetSeller(int id)
     {
      var sel1=await _context.seller.FindAsync(id);
      if(sel1==null)
      {
          return NotFound();
      }
      return sel1.tosellerdto();
     }

    [Route("info")]
    [HttpGet]
    public async Task<ActionResult<SellerDTO>> SellerInfoFormToken()
    {
      var auth = Request.Headers["Authorization"].ToString();
      var jwt = auth.Substring(auth.IndexOf(" ") + 1);
      var handler = new JwtSecurityTokenHandler();
      var token = handler.ReadJwtToken(jwt);
      var subject = token.Subject;
      var seller = await _context.seller.Where(seller => seller.phoneNumer == subject).FirstAsync();
      return seller != null ? seller.tosellerdto() : NotFound();
    }

     [HttpPost]
     public async Task<ActionResult<SellerDTO>> Createseller(SellerDTO s)
     {
         var s1=s.toseller();
         _context.seller.Add(s1);
         await _context.SaveChangesAsync();
         return CreatedAtAction(nameof(GetSeller),new {id=s1.id},s1);
     }
     [HttpPut]
     public async Task<IActionResult> Updateseller(SellerDTO s)
     {
         var s1=await _context.seller.FindAsync(s.id);
         if(s1==null)
         {
             return NotFound();
         }
        s1.Mapto9(s);
        _context.seller.Update(s1);
        try{
            await _context.SaveChangesAsync();
        }
        catch(DbUpdateConcurrencyException) when (!SelExist(s1.id))
        {
            return NotFound();
        }
        return NoContent();
     }

     public bool SelExist(int id)
     {
         return _context.seller.Any(p=>p.id==id);
     }
     [HttpDelete("{id}")]
     
     public async Task<IActionResult> DeleteSeller(int id)
     {
     var s1=await _context.seller.FindAsync(id);
     if(s1==null)
     {
         return NotFound();
     }
     _context.seller.Remove(s1);
     await _context.SaveChangesAsync();
     return NoContent();
     }
 }
}