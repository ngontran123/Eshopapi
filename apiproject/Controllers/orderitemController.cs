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
using Filter;
using Baseurl;
using Helpers;
namespace Controllers
{
[Route("api/[controller]")]
    [ApiController]
 public class orderitemController : ControllerBase
 {
     private readonly EcommerContext _context;
     private readonly IrulService _urlservice;
     public orderitemController(EcommerContext context,IrulService urlservice)
     {
         _context=context;
         _urlservice=urlservice;
     }
     [HttpGet]
     public async Task<IActionResult> Getorderitem([FromQuery]PagedFilter filter1)
     {  var route=Request.Path.Value;
        var filter=new PagedFilter(filter1.pagenumber,filter1.pagesize);
        var data=await _context.orderitem.Select(p=>p.toorder_itemDTO()).Skip((filter.pagenumber-1)*filter.pagesize).Take(filter.pagesize).ToListAsync();
        int totalcount=await _context.orderitem.Select(p=>p.toorder_itemDTO()).CountAsync();
        var pagedesponse=Pagedresponse.createpagedresponse<order_itemDTO>(data,filter,totalcount,_urlservice,route);
        return Ok(pagedesponse);
     }
     [HttpGet("{id}")]
     public async Task<ActionResult<order_itemDTO>> Getorderitem(int id)
     {
      var or=await _context.orderitem.FindAsync(id);
      if(or==null)
      {
          return NotFound();
      }
      return Ok(new Response<order_itemDTO>(or.toorder_itemDTO()));
     }
     [HttpPost]
     public async Task<ActionResult<order_itemDTO>> CreateProduct(order_itemDTO or2)
     {
         var or1=or2.toorder_item();
         _context.orderitem.Add(or1);
         await _context.SaveChangesAsync();
         return CreatedAtAction(nameof(Getorderitem),new {id=or1.id},or1);
     }
     [HttpPut]
     public async Task<IActionResult> Updateproduct(order_itemDTO or2)
     {
         var or1=await _context.orderitem.FindAsync(or2.id);
         if(or1==null)
         {
             return NotFound();
         }
        or1.Mapto1(or2);
        _context.orderitem.Update(or1);
        try{
            await _context.SaveChangesAsync();
        }
        catch(DbUpdateConcurrencyException) when (!orderitemExist(or1.id))
        {
            return NotFound();
        }
        return NoContent();
     }

     public bool orderitemExist(int id)
     {
         return _context.orderitem.Any(p=>p.id==id);
     }
     [HttpDelete("{id}")]
     
     public async Task<IActionResult> Deleteprderitem(int id)
     {
     var or1=await _context.orderitem.FindAsync(id);
     if(or1==null)
     {
         return NotFound();
     }
     _context.orderitem.Remove(or1);
     await _context.SaveChangesAsync();
     return NoContent();
     }
 }
}