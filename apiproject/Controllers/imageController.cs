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
 public class imageController : ControllerBase
 {
     private readonly EcommerContext _context;
     public imageController(EcommerContext context)
     {
         _context=context;
     }
     [HttpGet]
     public async Task<IEnumerable<imageDTO>> GetImage()
     {
        return await _context.images.Select(p=>p.toimageDto()).ToListAsync();
     }
     [HttpGet("{id}")]
     public async Task<ActionResult<imageDTO>> GetImage(int id)
     {
      var img=await _context.images.FindAsync(id);
      if(img==null)
      {
          return NotFound();
      }
      return img.toimageDto();
     }
     [HttpPost]
     public async Task<ActionResult<imageDTO>> CreateImage(imageDTO img2)
     {
         var img1=img2.toimage();
         _context.images.Add(img1);
         await _context.SaveChangesAsync();
         return CreatedAtAction(nameof(GetImage),new {id=img1.id},img1);
     }
     [HttpPut]
     public async Task<IActionResult> Updateproduct(imageDTO img2)
     {
         var img1=await _context.images.FindAsync(img2.id);
         if(img1==null)
         {
             return NotFound();
         }
        img1.Mapto3(img2);
        _context.images.Update(img1);
        try{
            await _context.SaveChangesAsync();
        }
        catch(DbUpdateConcurrencyException) when (!ImgExist(img1.id))
        {
            return NotFound();
        }
        return NoContent();
     }

     public bool ImgExist(int id)
     {
         return _context.images.Any(p=>p.id==id);
     }
     [HttpDelete("{id}")]
     
     public async Task<IActionResult> DeleteImage(int skuid)
     {
     var img1=await _context.images.FindAsync(skuid);
     if(img1==null)
     {
         return NotFound();
     }
     _context.images.Remove(img1);
     await _context.SaveChangesAsync();
     return NoContent();
     }
 }
}