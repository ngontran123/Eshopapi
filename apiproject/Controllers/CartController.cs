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
 public class CartController : ControllerBase
 {
     private readonly EcommerContext _context;
     public CartController(EcommerContext context)
     {
         _context=context;
     }
     [HttpGet]
     public async Task<IEnumerable<CartDTO>> GetCart()
     {
        return await _context.cart.Select(p=>p.tocartdto()).ToListAsync();
     }
     [HttpGet("{id}")]
     public async Task<ActionResult<CartDTO>> GetCart(int id)
     {
      var cart1=await _context.cart.FindAsync(id);
      if(cart1==null)
      {
          return NotFound();
      }
      return cart1.tocartdto();
     }
     [HttpPost]
     public async Task<ActionResult<CartDTO>> Createcart(CartDTO c)
     {
         var c1=c.tocart();
         _context.cart.Add(c1);
         await _context.SaveChangesAsync();
         return CreatedAtAction(nameof(GetCart),new {id=c1.id},c1);
     }
     [HttpPut]
     public async Task<IActionResult> Updatecart(CartDTO c)
     {
         var s1=await _context.cart.FindAsync(c.id);
         if(s1==null)
         {
             return NotFound();
         }
        s1.Mapto11(c);
        _context.cart.Update(s1);
        try{
            await _context.SaveChangesAsync();
        }
        catch(DbUpdateConcurrencyException) when (!cartExist(s1.id))
        {
            return NotFound();
        }
        return NoContent();
     }

     public bool cartExist(int id)
     {
         return _context.cart.Any(p=>p.id==id);
     }
     [HttpDelete("{id}")]
     
     public async Task<IActionResult> Deletecart(int id)
     {
     var s1=await _context.cart.FindAsync(id);
     if(s1==null)
     {
         return NotFound();
     }
     _context.cart.Remove(s1);
     await _context.SaveChangesAsync();
     return NoContent();
     }
 }
}