using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Data;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using Models;
using Microsoft.AspNetCore.Authorization;
using System.Text.Json;
using DTO;
using Helpers;
using Filter;
using Baseurl;
namespace Controllers
{
[Route("api/[controller]")]
    [ApiController]
     [CamelCaseControllerConfig]
 public class ProductsController : ControllerBase
 {
     private readonly EcommerContext _context;
     private readonly IrulService _uriservice; 
          public ProductsController(EcommerContext context,IrulService uriservice)
     {
         _context=context;
         this._uriservice=uriservice;
     }
      [CamelCaseControllerConfig]
     [HttpGet]
     public async Task<IActionResult> GetProduct([FromQuery]PagedFilter filter,[FromQuery]int brandid,[FromQuery]int categoryid,[FromQuery]String status)
     {  
        var resfilter=new PagedFilter(filter.pagenumber,filter.pagesize);
        var data= await _context.product.Select(p=>p.toproductdto()).Skip((resfilter.pagenumber-1)*resfilter.pagesize).Take(resfilter.pagesize)
        .ToListAsync();
        var data1=await _context.product.Where(p=>p.brandId==brandid&&p.categoryId==categoryid&&p.status==status).Select(p=>p.toproductdto()).ToListAsync();
        if(brandid!=' '&&categoryid!=' '&&status!=null)
        {
            return Ok(data1);
        }

        else{
        var route=Request.Path.Value;
         var totalcount=await _context.product.Select(p=>p.toproductdto()).CountAsync();
         var pagedesponse=Pagedresponse.createpagedresponse<ProductDTO>(data,filter,totalcount,_uriservice,route);
         return Ok(pagedesponse);
        }
        }
      [CamelCaseControllerConfig]
     [HttpGet("{id}")]
       public async Task<ActionResult<ProductDTO>> GetProduct(int id)
     {
      var p1=await _context.product.FindAsync(id);
      if(p1==null)

      {
          return NotFound();
      }
      return Ok(new Response<ProductDTO>(p1.toproductdto()));
     }

     [HttpPost]
     public async Task<ActionResult<ProductDTO>> CreateProduct(ProductDTO p2)
     {
         var p1=p2.toproduct();
         _context.product.Add(p1);
         await _context.SaveChangesAsync();
         return CreatedAtAction(nameof(GetProduct),new {id=p1.id},p1);
     }
     [HttpPut]
     public async Task<IActionResult> Updateproduct(ProductDTO p2)
     {
         var p1=await _context.product.FindAsync(p2.id);
         if(p1==null)
         {
             return NotFound();
         }
        p1.Mapto6(p2);
        _context.product.Update(p1);
        try{
            await _context.SaveChangesAsync();
        }
        catch(DbUpdateConcurrencyException) when (!ProductExist(p1.id))
        {
            return NotFound();
        }
        return NoContent();
     }

     public bool ProductExist(int id)
     {
         return _context.product.Any(p=>p.id==id);
     }
     [HttpDelete("{id}")]
     
     public async Task<IActionResult> DeleteProduct(int id)
     {
     var p1=await _context.product.FindAsync(id);
     if(p1==null)
     {
         return NotFound();
     }
     _context.product.Remove(p1);
     await _context.SaveChangesAsync();
     return NoContent();
     }
 }
}