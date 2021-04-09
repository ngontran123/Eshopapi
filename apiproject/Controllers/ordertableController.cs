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
 public class ordertableController : ControllerBase
 {
     private readonly EcommerContext _context;
     public ordertableController(EcommerContext context)
     {
         _context=context;
     }
     [HttpGet]
     public async Task<IEnumerable<order_tableDTO>> Get_order_table()
     {
        return await _context.ordertable.Select(p=>p.toorder_tblDTO()).ToListAsync();
     }
     [HttpGet("{id}")]
     public async Task<ActionResult<order_tableDTO>> Get_order_table(int id)
     {
      var table=await _context.ordertable.FindAsync(id);
      if(table==null)
      {
          return NotFound();
      }
      return table.toorder_tblDTO();
     }
     [HttpPost]
     public async Task<ActionResult<order_tableDTO>> CreateProduct(order_tableDTO t1)
     {
         var t=t1.toorder_tbl();
         _context.ordertable.Add(t);
         await _context.SaveChangesAsync();
         return CreatedAtAction(nameof(t),new {id=t.id},t);
     }
     [HttpPut]
     public async Task<IActionResult> Updateproduct(order_tableDTO tb2)
     {
         var table1=await _context.ordertable.FindAsync(tb2.id);
         if(table1==null)
         {
             return NotFound();
         }
        table1.Mapto2(tb2);
        _context.ordertable.Update(table1);
        try{
            await _context.SaveChangesAsync();
        }
        catch(DbUpdateConcurrencyException) when (!orderExist(table1.id))
        {
            return NotFound();
        }
        return NoContent();
     }

     public bool orderExist(int id)
     {
         return _context.ordertable.Any(p=>p.id==id);
     }
     [HttpDelete("{id}")]
     
     public async Task<IActionResult> Deleteordertable(int id)
     {
     var t1=await _context.ordertable.FindAsync(id);
     if(t1==null)
     {
         return NotFound();
     }
     _context.ordertable.Remove(t1);
     await _context.SaveChangesAsync();
     return NoContent();
     }
 }
}