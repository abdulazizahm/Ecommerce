using BL.AppServices;
using BL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class CartController : Controller
    {
        ProductAppService products = new ProductAppService();
        // GET: Cart
        public ActionResult Index()
        {
            decimal total = 0;
            if (Session["cart"] == null || ((List<Item>)Session["cart"]).Count == 0)
            {
                ViewBag.emptyCart = true;
                ViewBag.total = 0;
                return View();
            }
            List<Item> items = (List<Item>)Session["cart"];

            for (int i = 0; i < items.Count; i++)
            {
                total += (items[i].Quantity * items[i].Product.Offer_Price);
            }
            ViewBag.total = total;
            return View(items);
        }


        [HttpPost]
        public string AddToCart(int id)
        {
            ProductViewModel productModel = products.GetBroduct(id);
            if (Session["cart"] == null)
            {
                List<Item> cart = new List<Item>();
                cart.Add(new Item { Product = productModel, Quantity = 1 });
                Session["cart"] = cart;
            }
            else
            {
                List<Item> cart = (List<Item>)Session["cart"];
                int index = IsExist(id);
                if (index != -1)
                {
                    cart[index].Quantity++;
                }
                else
                {
                    cart.Add(new Item { Product = productModel, Quantity = 1 });
                }
                Session["cart"] = cart;
            }
            return $"{((List<Item>)Session["cart"]).Count}";
        }


        [HttpPost]
        public string Remove(int id)
        {
            List<Item> cart = (List<Item>)Session["cart"];
            int index = IsExist(id);
            cart.RemoveAt(index);
            Session["cart"] = cart;

            decimal total = 0;
            foreach (var item in cart)
            {
                total += (item.Product.Offer_Price * item.Quantity);
            }

            return total.ToString();
        }

        private int IsExist(int id)
        {
            List<Item> cart = (List<Item>)Session["cart"];
            for (int i = 0; i < cart.Count; i++)
                if (cart[i].Product.Id.Equals(id))
                    return i;
            return -1;
        }

    }
}