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
 public class SelleraddressController : ControllerBase
 {
     private readonly EcommerContext _context;
     public SelleraddressController(EcommerContext context)
     {
         _context=context;
     }
     [HttpGet]
     public async Task<IEnumerable<SelleraddressDTO>> Getaddress()
     {
        return await _context.selleraddresses.Select(p=>p.toselleraddressdto()).ToListAsync();
     }
     [HttpGet("{id}")]
     public async Task<ActionResult<SelleraddressDTO>> Getaddress(int id)
     {
      var sel1=await _context.selleraddresses.FindAsync(id);
      if(sel1==null)
      {
          return NotFound();
      }
      return sel1.toselleraddressdto();
     }
     [HttpPost]
     public async Task<ActionResult<SelleraddressDTO>> Createaddress(SelleraddressDTO s)
     {
         var s1=s.toselleraddress();
         _context.selleraddresses.Add(s1);
         await _context.SaveChangesAsync();
         return CreatedAtAction(nameof(Getaddress),new {id=s1.id},s1);
     }
     [HttpPut]
     public async Task<IActionResult> Updateaddress(SelleraddressDTO s)
     {
         var s1=await _context.selleraddresses.FindAsync(s.id);
         if(s1==null)
         {
             return NotFound();
         }
        s1.Mapto10(s);
        _context.selleraddresses.Update(s1);
        try{
            await _context.SaveChangesAsync();
        }
        catch(DbUpdateConcurrencyException) when (!addressExist(s1.id))
        {
            return NotFound();
        }
        return NoContent();
     }

     public bool addressExist(int id)
     {
         return _context.selleraddresses.Any(p=>p.id==id);
     }
     [HttpDelete("{id}")]
     
     public async Task<IActionResult> Deleteaddress(int id)
     {
     var s1=await _context.selleraddresses.FindAsync(id);
     if(s1==null)
     {
         return NotFound();
     }
     _context.selleraddresses.Remove(s1);
     await _context.SaveChangesAsync();
     return NoContent();
     }
 }
}