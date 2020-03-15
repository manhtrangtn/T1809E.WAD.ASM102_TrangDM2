using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using T1809E.WAD.ASM102_TrangDM2.Data;
using T1809E.WAD.ASM102_TrangDM2.Models;
using T1809E.WAD.ASM102_TrangDM2.Utils;

namespace T1809E.WAD.ASM102_TrangDM2.Controllers
{
    public class CartController : Controller
    {
      ASM102Context db = new ASM102Context();
      [Authorize]
      public ActionResult Add(int id, int quantity)
      {
        SetItem(id, quantity, false);
        return Redirect("ShowCart");
      }
      [Authorize]
      public ActionResult Update(int id, int quantity)
      {
        SetItem(id, quantity, false);
        return Redirect("ShowCart");
        }
      [Authorize]
      public ActionResult ShowCart()
      {
        return View(Session[Const.ShoppingCartName] as Cart);
      }
      [Authorize]
      public ActionResult Delete(int id)
      {
        SetItem(id, 0, true);
        return Redirect("ShowCart");
        }
      [Authorize]
      public ActionResult Clear()
      {
        Session[Const.ShoppingCartName] = null;
        return null;
      }
      public Cart GetCart()
      {
        if (Session[Const.ShoppingCartName] == null)
        {
          return new Cart();
        }
        else return Session[Const.ShoppingCartName] as Cart;
      }

      public void SetCart(Cart cart)
      {
        Session[Const.ShoppingCartName] = cart;
      }

      public void SetItem(int id, int quantity, bool isDelete)
      {
        Cart cart = GetCart();
        Product product = db.Products.FirstOrDefault(p => p.Id.Equals(id));
        if (product != null)
        {
          cart.Add(product, quantity);
          SetCart(cart);

          if (isDelete)
          {
            cart.Delete(id);
            SetCart(cart);
          }
        }
      }
    }
}