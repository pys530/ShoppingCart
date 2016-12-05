
using System;
using System.Web;
using System.Web.UI.WebControls;
using System.Collections.Generic;

namespace ShoppingCart
{

    public partial class BrowseProducts : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        
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
            


        }
    }
}





