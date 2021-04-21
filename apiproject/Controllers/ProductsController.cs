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
    public ProductsController(EcommerContext context, IrulService uriservice)
    {
      _context = context;
      this._uriservice = uriservice;
    }

    [CamelCaseControllerConfig]
    [HttpGet]
    public async Task<IActionResult> GetProduct([FromQuery] PagedFilter filter, [FromQuery] int brandid, [FromQuery] int categoryid, [FromQuery] String status)
    {
      var resfilter = new PagedFilter(filter.pageIndex, filter.pageSize);

      var productDTOs = await _context.product
      .Where(p => 
        (brandid != 0 ? p.brandId == brandid : true) 
        && (categoryid != 0 ? p.categoryId == categoryid : true) 
        && (status != null ? p.status.Equals(status) : true))
      .Select(p=>p.toProductDTO())
      .ToListAsync();

      foreach (var productDTO in productDTOs)
      {
        // Create skuDTOs
        var skuDTOs = await _context.skus.Where(sku => sku.productId == productDTO.id).Select(sku => sku.toskuDTO()).ToListAsync();
        foreach(var skuDTO in skuDTOs){
            // Create imageDTOs
            skuDTO.images = await _context.images.Where(img => img.skuId == skuDTO.id).Select(img=>img.toimageDto()).ToListAsync();
        }
        productDTO.skus = skuDTOs;
      }
        var route = Request.Path.Value;
        var totalcount = await _context.product.Select(p => p.toProductDTO()).CountAsync();
        var pagedesponse = Pagedresponse.createpagedresponse<ProductDTO>(productDTOs, filter, totalcount, _uriservice, route);
        return Ok(pagedesponse);
    }

    [CamelCaseControllerConfig]
    [HttpGet("{id}")]
    public async Task<ActionResult<ProductDTO>> GetProduct(int id)
    {
      var product = await _context.product.FindAsync(id);
      var productDTO = product.toProductDTO();
      var skuDTOs = await _context.skus.Where(sku => sku.productId == productDTO.id).Select(sku => sku.toskuDTO()).ToListAsync();
      foreach(var skuDTO in skuDTOs){
        skuDTO.images = await _context.images.Where(img => img.skuId == skuDTO.id).Select(image=>image.toimageDto()).ToListAsync();
      }
      productDTO.skus = skuDTOs;
      if (productDTO == null)
      {
        return NotFound();
      }
      return Ok(new Response<ProductDTO>(productDTO));
    }

    [HttpPost]
    public async Task<ActionResult<ProductDTO>> CreateProduct(ProductDTO p2)
    {
      var p1 = p2.toProduct();
      _context.product.Add(p1);
      await _context.SaveChangesAsync();
      return CreatedAtAction(nameof(GetProduct), new { id = p1.id }, p1);
    }

    [HttpPut]
    public async Task<IActionResult> Updateproduct([FromBody] ProductDTO productForm)
    {
      var productEntity = await _context.product.FindAsync(productForm.id);
      if (productEntity == null)
      {
        return NotFound();
      }
      productEntity.Mapto6(productForm);
      _context.product.Update(productEntity);
      try
      {
        await _context.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException) when (!ProductExist(productEntity.id))
      {
        return NotFound();
      }
      return Ok();
    }

    public bool ProductExist(int id)
    {
      return _context.product.Any(p => p.id == id);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProduct(int id)
    {
      var p1 = await _context.product.FindAsync(id);
      if (p1 == null)
      {
        return NotFound();
      }
      _context.product.Remove(p1);
      await _context.SaveChangesAsync();
      return NoContent();
    }
  }
}