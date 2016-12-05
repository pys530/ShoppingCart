using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ShoppingCart.DAL;

namespace ShoppingCart
{
    public class BusinessLogic
    {

        public List<Product> getProductList()
        {
            DataAccess da = new DataAccess();
            return da.ProductSelectAll();

        }

        public List<Product> getActiveProductList()
        {
            DataAccess da = new DataAccess();
            return da.ProductSelectAllActive();
        }

        public void updateProduct(Product productToUpdate)
        {
            DataAccess da = new DataAccess();
            da.ProductUpdate(productToUpdate);
        }

        public void insertProduct(Product productToInsert)
        {
            DataAccess da = new DataAccess();
            da.ProductInsert(productToInsert);
        }

        public List<CartItem> getCartContents()
        {
            return (List<CartItem>)HttpContext.Current.Session["UserCart"];
        }


        public List<CartItem> addCartItem(CartItem item)
        {
            List<CartItem> currentCart = (List<CartItem>)HttpContext.Current.Session["UserCart"];

            if (!currentCart.Exists(s => s.ProductId == item.ProductId))
                currentCart.Add(item);

            else
            {
                CartItem curItem = currentCart.Find(s => s.ProductId == item.ProductId);
                int newQty = curItem.Quantity + item.Quantity;

                curItem.Quantity = newQty;
            }

            return currentCart;
        }


        public void deleteCartItem(CartItem item)
        {
            List<CartItem> currentCart = (List<CartItem>)HttpContext.Current.Session["UserCart"];
            currentCart.RemoveAll(s => s.ProductId == item.ProductId);

        }

        public int sumCartItems(List<CartItem> cart)
        {
          
            int items = 0;

            foreach (CartItem item in cart)
            {
                items += item.Quantity;
            }

            return items;

        }

        public int getVisitorId()
        {
            DataAccess dataAccess = new DataAccess();
            return dataAccess.InsertVisitor();

        }

        public void updateLastVisit(int visitorId)
        {
            DataAccess dataAccess = new DataAccess();
            dataAccess.UpdateVisit(visitorId);

        }

        public BusinessLogic()
        {

        }
    }
}

