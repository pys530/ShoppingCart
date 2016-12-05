using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ShoppingCart
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Login1.Focus();
        }
        // Login information for Administrator to view GridView and perform CRUD on records
        protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
        {

            if (Login1.UserName == "info" && Login1.Password == "451")
            {
                e.Authenticated = true;
            }

        }
    }
}