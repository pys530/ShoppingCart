﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ShoppingCart
{
    public partial class CartContents : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ContentPlaceHolder ph = (ContentPlaceHolder)Master.Master.FindControl("MainContent");
            LinkButton cart = (LinkButton)ph.FindControl("lbShoppingCart");
            cart.Visible = false;
        }
    }
}