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
 public class AddressController : ControllerBase
 {
     private readonly EcommerContext _context;
     public AddressController(EcommerContext context)
     {
         _context=context;
     }
     [HttpGet]
     public async Task<IEnumerable<AddressDTO>> Getaddress()
     {
        return await _context.addresses.Select(p=>p.toaddressdto()).ToListAsync();
     }
     [HttpGet("{id}")]
     public async Task<ActionResult<AddressDTO>> Getaddress(int id)
     {
      var b1=await _context.addresses.FindAsync(id);
      if(b1==null)
      {
          return NotFound();
      }
      return b1.toaddressdto();
     }
     [HttpPost]
     public async Task<ActionResult<AddressDTO>> CreateProduct(AddressDTO ad2)
     {
         var ad1=ad2.toaddress();
         _context.addresses.Add(ad1);
         await _context.SaveChangesAsync();
         return CreatedAtAction(nameof(Getaddress),new {id=ad1.id},ad1);
     }
     [HttpPut]
     public async Task<IActionResult> UpdateBrand(AddressDTO b2)
     {
         var b1=await _context.addresses.FindAsync(b2.id);
         if(b1==null)
         {
             return NotFound();
         }
        b1.Mapto7(b2);
        _context.addresses.Update(b1);
        try{
            await _context.SaveChangesAsync();
        }
        catch(DbUpdateConcurrencyException) when (!AddressExist(b1.id))
        {
            return NotFound();
        }
        return NoContent();
     }

     public bool AddressExist(int id)
     {
         return _context.addresses.Any(p=>p.id==id);
     }
     [HttpDelete("{id}")]
     
     public async Task<IActionResult> Deleteaddress(int id)
     {
     var b1=await _context.addresses.FindAsync(id);
     if(b1==null)
     {
         return NotFound();
     }
     _context.addresses.Remove(b1);
     await _context.SaveChangesAsync();
     return NoContent();
     }
 }
}