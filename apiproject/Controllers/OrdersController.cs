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
     public OrdersController(EcommerContext context,IrulService urlservice)
     {
         _context=context;
         _uriService=urlservice;
     }
     [HttpGet]
     public async Task<IActionResult> Get_order_table([FromQuery]PagedFilter filter,[FromQuery]DateTime createdate,[FromQuery]String paymentmethod,[FromQuery]decimal shippingfee)
     {   
        var resfilter=new PagedFilter(filter.pagenumber,filter.pagesize);
        List<order_tableDTO> d=new List<order_tableDTO>();
        List<order_tableDTO> d1=new List<order_tableDTO>();
        var data2=await _context.ordertable.ToListAsync();
        var data3=await _context.ordertable.Where(q=>DateTime.Compare(createdate,q.createDate)==0&&q.paymentMethod.Equals(paymentmethod)&&q.shippingFee==shippingfee).ToListAsync();
        
        if(data3.Any())
        {  
            foreach(var ord1 in data3 )
        {
            var newword1=new order_tableDTO
            {
                id=ord1.id,
            createDate = createdate,
        updateDate = ord1.updateDate,
        paymentMethod = paymentmethod,
        shippingFee = shippingfee,
        shippingAddress = ord1.shippingAddress,
        totalPrice = ord1.totalPrice,
        status = ord1.status,
        customerId=ord1.customerId,
        orderitem1=await _context.orderitem.Where(x=>x.orderTableId==ord1.id).Select(p=>p.toorder_itemDTO()).ToListAsync()
            };
            d.Add(newword1);
        }

        }
        else{
        foreach(var ord in data2)
        {
           var neword=new order_tableDTO{
                id=ord.id,
             createDate  = ord.createDate,
        updateDate = ord.updateDate,
        paymentMethod = ord.paymentMethod,
        shippingFee = ord.shippingFee,
        shippingAddress = ord.shippingAddress,
        totalPrice = ord.totalPrice,
        status = ord.status,
        customerId=ord.customerId,
        orderitem1=await _context.orderitem.Where(x=>x.orderTableId==ord.id).Select(p=>p.toorder_itemDTO()).ToListAsync()
            };
            d.Add(neword);
        }
        }
        var route=Request.Path.Value;
         var totalcount=await _context.ordertable.Select(p=>p.toorder_tblDTO()).CountAsync();
         var pagedesponse=Pagedresponse.createpagedresponse<order_tableDTO>(d,filter,totalcount,_uriService,route);
            return Ok(pagedesponse);
        
     }
     [HttpGet("{id}")]
     public async Task<ActionResult<order_tableDTO>> Get_order_table(int id)
     {
      var ord=await _context.ordertable.FindAsync(id);
      if(ord==null)
      {
          return NotFound();
      }
       var neword=new order_tableDTO{
                id=ord.id,
                   createDate  = ord.createDate,
        updateDate = ord.updateDate,
        paymentMethod = ord.paymentMethod,
        shippingFee = ord.shippingFee,
        shippingAddress = ord.shippingAddress,
        totalPrice = ord.totalPrice,
        status = ord.status,
        customerId=ord.customerId,
        orderitem1=_context.orderitem.Where(x=>x.orderTableId==ord.id).Select(p=>p.toorder_itemDTO())
            };
        return Ok(new Response<order_tableDTO>(neword));
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