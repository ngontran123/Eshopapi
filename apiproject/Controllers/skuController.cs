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
using Helpers;
using Filter;
using Baseurl;
namespace Controllers
{
[Route("api/[controller]")]
    [ApiController]
    [CamelCaseControllerConfig]
 public class skuController : ControllerBase
 {
     private readonly EcommerContext _context;
     private readonly IrulService _uriservice;
     public skuController(EcommerContext context,IrulService uriservice)
     {
         _context=context;
         this._uriservice=uriservice;
     }
     [HttpGet]
     [CamelCaseControllerConfig]
     public async Task<IActionResult> GetSkus([FromQuery]PagedFilter filter)
     {  
        var resfilter=new PagedFilter(filter.pagenumber,filter.pagesize);
        var data= await _context.skus.Select(p=>p.toskuDTO()).Skip((resfilter.pagenumber-1)*resfilter.pagesize).Take(resfilter.pagesize)
        .ToListAsync();
        var route=Request.Path.Value;
         var totalcount=await _context.skus.Select(p=>p.toskuDTO()).CountAsync();
         var pagedesponse=Pagedresponse.createpagedresponse<SkuDTO>(data,filter,totalcount,_uriservice,route);
         return Ok(pagedesponse);
     }
     [HttpGet("{id}")]
     [CamelCaseControllerConfig]
     public async Task<ActionResult<SkuDTO>> Getsku(int id)
     {
      var sku1=await _context.skus.FindAsync(id);
      if(sku1==null)

      {
          return NotFound();
      }
      return Ok(new Response<SkuDTO>(sku1.toskuDTO()));
     }
     [HttpPost]
     public async Task<ActionResult<SkuDTO>> CreateProduct(SkuDTO sku2)
     {
         var sku1=sku2.tosku();
         _context.skus.Add(sku1);
         await _context.SaveChangesAsync();
         return CreatedAtAction(nameof(Getsku),new {id=sku1.id},sku1);
     }
     [HttpPut]
     public async Task<IActionResult> Updateproduct(SkuDTO sku2)
     {
         var sku1=await _context.skus.FindAsync(sku2.id);
         if(sku1==null)
         {
             return NotFound();
         }
        sku1.Mapto(sku2);
        _context.skus.Update(sku1);
        try{
            await _context.SaveChangesAsync();
        }
        catch(DbUpdateConcurrencyException) when (!SkuExist(sku1.id))
        {
            return NotFound();
        }
        return NoContent();
     }

     public bool SkuExist(int id)
     {
         return _context.skus.Any(p=>p.id==id);
     }
     [HttpDelete("{id}")]
     
     public async Task<IActionResult> DeleteProduct(int id)
     {
     var sku1=await _context.skus.FindAsync(id);
     if(sku1==null)
     {
         return NotFound();
     }
     _context.skus.Remove(sku1);
     await _context.SaveChangesAsync();
     return NoContent();
     }
 }
}