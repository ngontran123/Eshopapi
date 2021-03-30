using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using DTO;
namespace DTO{
    public static class MappingProfile
    {
       public static SkuDTO toskuDTO(this sku sku1)
       {return new SkuDTO()
       {
         id=sku1.id,
        seller_sku=sku1.seller_sku,
         available=sku1.available,
         quantity=sku1.quantity,
        color=sku1.color,
         size=sku1.size,
         heigth=sku1.heigth,
       width=sku1.width,
        length=sku1.length,
         weight=sku1.weight,
         price=sku1.price
       };
       }
       public static sku tosku(this SkuDTO sku2)
       {
           return new sku()
           {
                
        seller_sku=sku2.seller_sku,
         available=sku2.available,
         quantity=sku2.quantity,
        color=sku2.color,
         size=sku2.size,
         heigth=sku2.heigth,
       width=sku2.width,
        length=sku2.length,
         weight=sku2.weight,
         price=sku2.price
           };
       }
       public static void Mapto(this sku sku1,SkuDTO sku2)
       {
        sku1.id=sku2.id;
        sku1.seller_sku=sku2.seller_sku;
         sku1.available=sku2.available;
         sku1.quantity=sku2.quantity;
        sku1.color=sku2.color;
         sku1.size=sku2.size;
        sku1.heigth=sku2.heigth;
       sku1.width=sku2.width;
        sku1.length=sku2.length;
         sku1.weight=sku2.weight;
         sku1.price=sku2.price;
       }
           public static order_itemDTO toorder_itemDTO(this order_item ori)
       {
           return new order_itemDTO()
           {
                 id=ori.id,
         orderTableId=ori.orderTableId,
         skuId=ori.skuId,
         name=ori.name,
        variation=ori.variation,
         price=ori.price,
         quantity=ori.quantity
           };
       }
       public static order_item toorder_item(this order_itemDTO ori1)
       {
           return new order_item()
           {
                 id=ori1.id,
         orderTableId=ori1.orderTableId,
         skuId=ori1.skuId,
         name=ori1.name,
        variation=ori1.variation,
         price=ori1.price,
         quantity=ori1.quantity
           };
       }
       public static void Mapto1(this order_item ori,order_itemDTO ori1)
       {
           
                 ori.id=ori1.id;
         ori.orderTableId=ori1.orderTableId;
         ori.skuId=ori1.skuId;
         ori.name=ori1.name;
        ori.variation=ori1.variation;
         ori.price=ori1.price;
         ori.quantity=ori1.quantity;
       }
       public static order_tableDTO toorder_tblDTO(this order_tbl ord)
       {
           return new order_tableDTO()
           {
                
        createDate=ord.createDate,
        updateDate=ord.updateDate,
       paymentMethod=ord.paymentMethod,
         shippingFee=ord.shippingFee,
         shippingAddress=ord.shippingAddress,
          totalPrice=ord.totalPrice,
       status=ord.status
           };
       }
       public static order_tbl toorder_tbl(this order_tableDTO ord1)
       {  return new order_tbl()
       {
                
        createDate=ord1.createDate,
        updateDate=ord1.updateDate,
       paymentMethod=ord1.paymentMethod,
         shippingFee=ord1.shippingFee,
         shippingAddress=ord1.shippingAddress,
          totalPrice=ord1.totalPrice,
          status=ord1.status
       };
    }
    public static void Mapto2(this order_tbl ord, order_tableDTO ord1)
    {
             ord.id=ord1.id;
        ord.createDate=ord1.createDate;
        ord.updateDate=ord1.updateDate;
       ord.paymentMethod=ord1.paymentMethod;
         ord.shippingFee=ord1.shippingFee;
         ord.shippingAddress=ord1.shippingAddress;
          ord.totalPrice=ord1.totalPrice;
       ord.status=ord1.status;
    }
   public static imageDTO toimageDto(this images img)
   {
       return new imageDTO()
       {
            url=img.url,
         skuId=img.skuId,
    
       };
   }
   public static images toimage(this imageDTO img1)
   {
       return new images()
       {
            url=img1.url,
         skuId=img1.skuId
    
       };
   }
    public static void Mapto3(this images img,imageDTO img1)
    {
        img.url=img1.url;
         img.skuId=img1.skuId;
    }
    public static customerDTO tocustomerDTO(this customer c)
    {
      return new customerDTO()
      { 
              id=c.id,
        name=c.name,
         email=c.email,
         phoneNumber=c.phoneNumber,
         gender=c.gender,
         password=c.password,
        accessToken=c.accessToken,
         accesExpire=c.accesExpire,
       refreshToken=c.refreshToken,
         refreshExpire=c.refreshExpire
      };
    }
    public static customer tocustomer(this customerDTO c1)
    {   return new customer()
    {
            id=c1.id,
        name=c1.name,
         email=c1.email,
         phoneNumber=c1.phoneNumber,
         gender=c1.gender,
         password=c1.password,
        accessToken=c1.accessToken,
         accesExpire=c1.accesExpire,
       refreshToken=c1.refreshToken,
         refreshExpire=c1.refreshExpire
    };  
    }
    public static void Mapto4(this customer c,customerDTO c1)
    {
            c.id=c1.id;
        c.name=c1.name;
         c.email=c1.email;
         c.phoneNumber=c1.phoneNumber;
         c.gender=c1.gender;
         c.password=c1.password;
        c.accessToken=c1.accessToken;
         c.accesExpire=c1.accesExpire;
       c.refreshToken=c1.refreshToken;
         c.refreshExpire=c1.refreshExpire;
    }
  public static brand toBrand(this brandDTO b)
  { return new brand()
  {
    id=b.id,
    name=b.name
  };

  }
  public static brandDTO toBrandDTO(this brand b1)
{
  return new brandDTO()
  {
    id=b1.id,
    name=b1.name
  };
}
public static void Mapto5(this brand b,brandDTO b1)
{
  b.id=b1.id;
  b.name=b1.name;
}
public static ProductDTO toproductdto(this Products pr1 )
{
    return new ProductDTO(){
            id=pr1.id,
        categoryId=pr1.categoryId,
        brandId=pr1.brandId,
         productName=pr1.productName,
      description=pr1.description,
         status=pr1.status
    };
}
public static Products toproduct(this ProductDTO pr2)
{
  return new Products()
  {
            id=pr2.id,
        categoryId=pr2.categoryId,
        brandId=pr2.brandId,
         productName=pr2.productName,
      description=pr2.description,
         status=pr2.status
  };
}
public static void Mapto6(this Products pr1,ProductDTO pr2)
{
          pr1.id=pr2.id;
        pr1.categoryId=pr2.categoryId;
        pr1.brandId=pr2.brandId;
         pr1.productName=pr2.productName;
      pr1.description=pr2.description;
         pr1.status=pr2.status;
}
public static AddressDTO toaddressdto(this Address ad)
{
  return new AddressDTO()
  {
         id=ad.id,
         cusId=ad.cusId,
         street=ad.street,
        address1=ad.address1,
        address2=ad.address2,
         address3=ad.address3
  };
}
  public static Address toaddress(this AddressDTO ad1)
  {
    return new Address()
    {
       id=ad1.id,
         cusId=ad1.cusId,
         street=ad1.street,
        address1=ad1.address1,
        address2=ad1.address2,
         address3=ad1.address3
    };
  }
  public static void Mapto7(this Address ad,AddressDTO ad1)
  {
     ad.id=ad1.id;
         ad.cusId=ad1.cusId;
         ad.street=ad1.street;
        ad.address1=ad1.address1;
        ad.address2=ad1.address2;
         ad.address3=ad1.address3;
  }
  public static CategoryDTO tocategoryDTO(this Category c)
  {
    return new CategoryDTO()
    {
      id=c.id,
      name=c.name
    };
  }
  public static Category tocategory(this CategoryDTO c1)
  {
    return new Category()
    {
      id=c1.id,
      name=c1.name
    };
  }
  public static void Mapto8(this Category c,CategoryDTO c1)
  {
    c.id=c1.id;
    c.name=c1.name;
  }
  public static SellerDTO tosellerdto(this Seller s)
  {
    return new SellerDTO()
    {
      id=s.id,
      phoneNumer=s.phoneNumer,
      name=s.name,
        email=s.email,
      password=s.password,
      secretKey=s.secretKey,
      accessToken=s.accessToken,
      accessExpire=s.accessExpire,
      refreshToken=s.refreshToken,
      refreshExpire=s.refreshExpire
    };
  }
  public static Seller toseller(this SellerDTO s1)
  {
    return new Seller()
    {
      id=s1.id,
      phoneNumer=s1.phoneNumer,
      name=s1.name,
        email=s1.email,
      password=s1.password,
      secretKey=s1.secretKey,
      accessToken=s1.accessToken,
      accessExpire=s1.accessExpire,
      refreshToken=s1.refreshToken,
      refreshExpire=s1.refreshExpire
    };
  }
  public static void Mapto9(this Seller s,SellerDTO s1)
  {
       s.id=s1.id;
      s.phoneNumer=s1.phoneNumer;
      s.name=s1.name;
        s.email=s1.email;
      s.password=s1.password;
      s.secretKey=s1.secretKey;
      s.accessToken=s1.accessToken;
      s.accessExpire=s1.accessExpire;
      s.refreshToken=s1.refreshToken;
      s.refreshExpire=s1.refreshExpire;
  }
  public static SelleraddressDTO toselleraddressdto(this Selleraddress s)
  {
    return new SelleraddressDTO()
    {

  
       id=s.id,
       sellerId=s.sellerId,
       street=s.street,
        address1=s.address1,
        address2=s.address2,
        address3=s.address3
  };
  }
  public static Selleraddress toselleraddress(this SelleraddressDTO s1)
  {  return new Selleraddress()
  {
      id=s1.id,
       sellerId=s1.sellerId,
       street=s1.street,
        address1=s1.address1,
        address2=s1.address2,
        address3=s1.address3
  };
  }
  public static void Mapto10(this Selleraddress s,SelleraddressDTO s1)
  {
       s.id=s1.id;
       s.sellerId=s1.sellerId;
       s.street=s1.street;
        s.address1=s1.address1;
        s.address2=s1.address2;
        s.address3=s1.address3;
  }
  public static CartDTO tocartdto(this Cart c)
  {
    return new CartDTO()
    {
      id=c.id,
      customerId=c.customerId,
      shippingFee=c.shippingFee,
      orderItem=c.orderItem,
      totalPrice=c.totalPrice
    };
  }
  public static Cart tocart(this CartDTO c1)
  {
       return new Cart()
    {
      id=c1.id,
      customerId=c1.customerId,
      shippingFee=c1.shippingFee,
      orderItem=c1.orderItem,
      totalPrice=c1.totalPrice
    };
  }
  public static void Mapto11(this Cart c,CartDTO c1)
  {
         c.id=c1.id;
      c.customerId=c1.customerId;
      c.shippingFee=c1.shippingFee;
      c.orderItem=c1.orderItem;
      c.totalPrice=c1.totalPrice;
  }
}
}



      