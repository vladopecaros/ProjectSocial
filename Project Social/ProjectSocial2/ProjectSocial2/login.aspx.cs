using System;

namespace ProjectSocial2
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Redirect("~/Accessing/login.aspx");
        }
    }
}