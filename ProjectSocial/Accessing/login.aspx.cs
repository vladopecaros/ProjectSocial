using System;
using System.Web;

namespace ProjectSocial2.Accessing
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            Session["IsSuperPasswordEntered"] = 0;
            
        }
    }
}