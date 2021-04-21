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
  public class OrdersController : ControllerBase
  {
    private readonly EcommerContext _context;
    private readonly IrulService _uriService;
    public OrdersController(EcommerContext context, IrulService urlservice)
    {
      _context = context;
      _uriService = urlservice;
    }
    [HttpGet]
    public async Task<IActionResult> GetOrders([FromQuery] PagedFilter filter,[FromQuery] int id, [FromQuery] DateTime createdate, [FromQuery] String paymentmethod, [FromQuery] decimal shippingfee, [FromQuery] String status)
    {
      var resfilter = new PagedFilter(filter.pageIndex, filter.pageSize);
      var orderDTOs = await _context.ordertable
      .Where(q =>
      (id!=0 ? q.id == id : true)
      && (createdate==null ? DateTime.Compare(createdate, q.createDate)==0 : true)
      && (paymentmethod != null ? q.paymentMethod.Equals(paymentmethod) : true)
      && (shippingfee!=0 ? q.shippingFee == shippingfee : true)
      && (status!=null ? q.status.Equals(status) : true)
      ).Select(order=>order.toorder_tblDTO()).ToListAsync();
      foreach (var orderDTO in orderDTOs){
        var customerEntity = await _context.customers.FindAsync(orderDTO.customerId);
        orderDTO.customer = customerEntity.tocustomerDTO();
        var orderItemDTOs = await _context.orderitem.Where(item=>item.orderTableId == orderDTO.id).Select(item=>item.toorder_itemDTO()).ToListAsync();
        orderItemDTOs.ForEach(orderItemDTO => {
          var skuDTO  = _context.skus.Find(orderItemDTO.skuId).toskuDTO();
          skuDTO.images = _context.images.Where(image=>image.skuId==skuDTO.id).Select(image=>image.toimageDto()).ToList();
          orderItemDTO.sku = skuDTO;
        });
        orderDTO.orderItems = orderItemDTOs;
      }
      var route = Request.Path.Value;
      var totalcount = await _context.ordertable.Select(p => p.toorder_tblDTO()).CountAsync();
      var pagedesponse = Pagedresponse.createpagedresponse<OrderTableDTO>(orderDTOs, filter, totalcount, _uriService, route);
      return Ok(pagedesponse);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<OrderTableDTO>> GetOrder(int id)
    {
      var ord = await _context.ordertable.FindAsync(id);
      if (ord == null)
      {
        return NotFound();
      }
      var neword = new OrderTableDTO
      {
        id = ord.id,
        createDate = ord.createDate,
        updateDate = ord.updateDate,
        paymentMethod = ord.paymentMethod,
        shippingFee = ord.shippingFee,
        shippingAddress = ord.shippingAddress,
        totalPrice = ord.totalPrice,
        status = ord.status,
        customerId = ord.customerId,
        orderItems = _context.orderitem.Where(x => x.orderTableId == ord.id).Select(p => p.toorder_itemDTO())
      };
      return Ok(new Response<OrderTableDTO>(neword));
    }
    
    [HttpPost]
    public async Task<ActionResult<OrderTableDTO>> CreateOrder([FromBody] OrderTableDTO orderDTO)
    {
      var orderEntity = orderDTO.toOrder();
      _context.ordertable.Add(orderEntity);
      await _context.SaveChangesAsync();
      return CreatedAtAction(nameof(GetOrder), new { id = orderEntity.id }, orderEntity);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateOrder(OrderTableDTO tb2)
    {
      var table1 = await _context.ordertable.FindAsync(tb2.id);
      if (table1 == null)
      {
        return NotFound();
      }
      table1.Mapto2(tb2);
      _context.ordertable.Update(table1);
      await _context.SaveChangesAsync();
      return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteOrder(int id)
    {
      var t1 = await _context.ordertable.FindAsync(id);
      if (t1 == null)
      {
        return NotFound();
      }
      _context.ordertable.Remove(t1);
      await _context.SaveChangesAsync();
      return NoContent();
    }
  }
}