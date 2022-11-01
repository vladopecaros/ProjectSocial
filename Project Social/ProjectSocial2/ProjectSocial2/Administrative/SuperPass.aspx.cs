using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Security;

namespace ProjectSocial2.Administrative
{
    public partial class SuperPass_Login : System.Web.UI.Page
    {
        int attempt;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_login_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["UserLoginInfo"].ConnectionString);
            if (con.State != System.Data.ConnectionState.Open)
                con.Open();
            if (true)
            {
                var user = Membership.GetUser().ProviderUserKey;
                SqlCommand cmd = new SqlCommand("select SuperPassword from SuperPasswords where AdminID = @p1", con);
                cmd.Parameters.AddWithValue("@p1", Membership.GetUser().ProviderUserKey);
                Convert.ToString(cmd.ExecuteScalar());
                if (Convert.ToString(cmd.ExecuteScalar()) == TextBox1.Text)
                {

                    Server.Transfer("~/Administrative/AdminHome.aspx");
                }
                else
                {
                    lbl_error.ForeColor = System.Drawing.Color.Red;
                    lbl_error.Text = "Incorect password";
                    attempt -= 1;
                }
            }

        }
    }
}