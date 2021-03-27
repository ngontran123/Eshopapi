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
 public class customerController : ControllerBase
 {
     private readonly EcommerContext _context;
     public customerController(EcommerContext context)
     {
         _context=context;
     }
     [HttpGet]
     public async Task<IEnumerable<customerDTO>> Getcustomer()
     {
        return await _context.customers.Select(p=>p.tocustomerDTO()).ToListAsync();
     }
     [HttpGet("{id}")]
     public async Task<ActionResult<customerDTO>> Getsku(int id)
     {
      var cus1=await _context.customers.FindAsync(id);
      if(cus1==null)
      {
          return NotFound();
      }
      return cus1.tocustomerDTO();
     }
     [HttpPost]
     public async Task<ActionResult<customerDTO>> CreateProduct(customerDTO cus2)
     {
         var cus1=cus2.tocustomer();
         _context.customers.Add(cus1);
         await _context.SaveChangesAsync();
         return CreatedAtAction(nameof(Getcustomer),new {id=cus1.id},cus1);
     }
     [HttpPut]
     public async Task<IActionResult> Updateproduct(customerDTO cus2)
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