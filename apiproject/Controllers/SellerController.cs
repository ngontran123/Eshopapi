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
namespace Controllers
{
[Route("api/[controller]")]
    [ApiController]
 public class SellerController : ControllerBase
 {
     private readonly EcommerContext _context;
     public SellerController(EcommerContext context)
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