
using System;
using System.Web;
using System.Web.UI.WebControls;
using System.Collections.Generic;

namespace ShoppingCart
{

    public partial class BrowseProducts : System.Web.UI.Page
    {

       

        
        protected void dlProduct_ItemCommand(object source, DataListCommandEventArgs e)
        {
            BusinessLogic bl = new BusinessLogic();
            List<CartItem> myCart = bl.getCartContents();

            var productId = e.CommandArgument.ToString();
            var name = ((Label)e.Item.FindControl("lblName")).Text;
            var description = ((Label)e.Item.FindControl("lblDescription")).Text;
            var price = ((Label)e.Item.FindControl("lblPrice")).Text;
            var quantityDDL = ((DropDownList)e.Item.FindControl("ddlQuantity"));
            //Business Logic for Cart Contents

            var quantity = quantityDDL.SelectedValue;
            quantityDDL.SelectedIndex = 0;

            int convertedProductId;
            decimal convertedPrice;
            int convertedQuantity;

            Int32.TryParse(productId, out convertedProductId);
            decimal.TryParse(price, out convertedPrice);
            Int32.TryParse(quantity, out convertedQuantity);

            CartItem newItem = new CartItem(convertedProductId, name, description, convertedPrice, convertedQuantity);
            myCart = bl.addCartItem(newItem);

            int cartItems = bl.sumCartItems(myCart);

            ContentPlaceHolder ph = (ContentPlaceHolder)Master.Master.FindControl("MainContent");
            Label cartLabel = (Label)ph.FindControl("lblCart");
            cartLabel.Text = "Shopping Cart (" + cartItems.ToString() + ")";


    //        protected string[] SplitWords(string s)
    //    {
    //        return Regex.Split(s, @"\W+");
    //    }
    //    protected string UpperCaseFirst(string s)
    //    {
    //        if (string.IsNullOrEmpty(s))
    //        {
    //            return string.Empty;
    //        }
    //        else
    //        {
    //            return char.ToUpper(s[0]) + s.Substring(1);
    //        }

    //    }
    //    protected List<Product> GetProducts(object source, EventArgs e)
    //    {
    //        var terms = Request.Form.GetValues("search");
    //        var t = terms[0];
    //        string[] words = SplitWords(t);
    //        List<string> listItems = new List<string>();

    //        foreach (var item in words)
    //        {
    //            listItems.Add(item);
    //        }
    //        List<Product> returnList = new List<Product>();
    //        BusinessLogic bl = new BusinessLogic();
    //        List<Product> products = bl.getProductList();
    //        // loop through the number of products
    //        foreach (Product product in products)
    //        {
    //            // loop through the terms passed
    //            foreach (var item in listItems)
    //            {
    //                // uppercase first letter to match dataset
    //                var itemU = UpperCaseFirst(item);
    //                var productU = product.Name;
    //                if (productU.Contains(itemU))
    //                {
    //                    returnList.Add(new Product
    //                    {
    //                        Id = product.Id,
    //                        Name = product.Name,
    //                        Price = product.Price,
    //                        Description = product.Description
    //                    });
    //                }
    //            }

    //        }
    //    }
    //}

    //        return returnList;
    //    }


        }
    }
}





