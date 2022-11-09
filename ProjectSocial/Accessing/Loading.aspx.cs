using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Security;
using System.Web.UI;

namespace ProjectSocial2.Accessing
{

    public partial class Loading : System.Web.UI.Page
    {
        SqlConnection Users = new SqlConnection(ConfigurationManager.ConnectionStrings["Users"].ConnectionString);
        SqlConnection LoginInfo = new SqlConnection(ConfigurationManager.ConnectionStrings["UserLoginInfo"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            lbl_loading.ForeColor = System.Drawing.Color.Red;
            if (Users.State != System.Data.ConnectionState.Open)
            {
                Users.Open();
            }
            if (LoginInfo.State != System.Data.ConnectionState.Open)
            {
                LoginInfo.Open();
            }
            this.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
            LoadScreen();
            Users.Close();
            LoginInfo.Close();
            Response.Redirect("~/TheSite/Main.aspx");
        }
        private void LoadScreen()
        {
            string userid = "\"" + Membership.GetUser().ProviderUserKey + "\"";
            try
            {


                SqlCommand checking = new SqlCommand("select Existing from " + userid + ";", Users);
                lbl_loading.Text = "Checking if user exists...";
                if (Convert.ToInt32(checking.ExecuteScalar()) == 1)
                {
                    lbl_loading.Text = "User found, redirecting...";
                }
                return;
            }
            catch
            {
                lbl_loading.Text = "User not found, creating...";
                SqlCommand AddRole = new SqlCommand("insert into aspnet_UsersInRoles(UserId, RoleId) values (CAST('" + Membership.GetUser().ProviderUserKey + "' AS UNIQUEIDENTIFIER), CAST('74756D71-3B20-47E1-8D34-E46D64FEB87B' AS UNIQUEIDENTIFIER));", LoginInfo);
                AddRole.ExecuteNonQuery();
                SqlCommand creating = new SqlCommand("create table " + userid + "(Existing int, PostID uniqueidentifier, Bio varchar(300), Following uniqueidentifier, Follower uniqueidentifier, LikedPost uniqueidentifier, Notification varchar(200), NotificationDate datetime);", Users);
                SqlCommand populating = new SqlCommand("insert into " + userid + " (Existing, Bio) values (1, '');", Users);
                creating.ExecuteNonQuery();
                populating.ExecuteNonQuery();

                lbl_loading.Text = "User created, redirecting...";
                return;


            }


        }
    }
}