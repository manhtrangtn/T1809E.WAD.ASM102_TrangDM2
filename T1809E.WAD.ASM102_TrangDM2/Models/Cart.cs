using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace T1809E.WAD.ASM102_TrangDM2.Models
{
  public class Cart
  {
    public Dictionary<int, CartItem> Items;
    public double TotalPrice => Items.Values.Sum(i => i.TotalItemPrice);

    public Cart()
    {
      Items = new Dictionary<int, CartItem>();
    }

    public void Add(Product product, int quantity)
    {
      CartItem cartItem = new CartItem()
      {
        Id = product.Id,
        Name = product.Name,
        Thumbnail = product.Thumbnail,
        Price = product.Price,
        Quantity = quantity
      };
      bool isKeyExist = Items.ContainsKey(product.Id);
      if (isKeyExist)
      {
        var currentItem = Items[product.Id];
        cartItem.Quantity += currentItem.Quantity;
        Items[product.Id] = cartItem;
      }
      else
      {
        Items.Add(product.Id, cartItem);
      }
    }

    public void Update(Product product, int quantity)
    {
      Add(product, quantity);
    }

    public void Delete(int productId)
    {
      Items.Remove(productId);
    }

    public void Clear()
    {
      Items.Clear();
    }
  }

  public class CartItem
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public double Price { get; set; }
    public string Thumbnail { get; set; }
    public double TotalItemPrice => Price * Quantity;
    public int Quantity { get; set; }
  }
}