using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Security;

namespace ProjectSocial2.TheSite
{
    public partial class EditProfile : System.Web.UI.Page
    {

        SqlConnection Users = new SqlConnection(ConfigurationManager.ConnectionStrings["Users"].ConnectionString);
        SqlConnection LoginInfo = new SqlConnection(ConfigurationManager.ConnectionStrings["UserLoginInfo"].ConnectionString);
        string nqSelectedUserId;
        string SelectedUserId;
        string nqCurrentUserId = Membership.GetUser().ProviderUserKey.ToString();
        string CurrentUserId = "\"" + Membership.GetUser().ProviderUserKey.ToString() + "\"";
        protected void Page_Load(object sender, EventArgs e)
        {
            Label1.Text = "You will be loged out if you change your username!";
            Label1.ForeColor = System.Drawing.Color.Red;
            if (!this.IsPostBack)
            {
                string SelectedUser = Membership.GetUser().UserName;
                if (LoginInfo.State != System.Data.ConnectionState.Open)
                {
                    LoginInfo.Open();
                }

                //GetId
                SqlCommand getid = new SqlCommand("select UserId from aspnet_Users where UserName = @p1", LoginInfo);
                getid.Parameters.AddWithValue("@p1", SelectedUser);
                nqSelectedUserId = Convert.ToString(getid.ExecuteScalar());
                SelectedUserId = "\"" + nqSelectedUserId + "\"";
                if (SelectedUserId == CurrentUserId)
                {
                    if (Users.State != System.Data.ConnectionState.Open)
                    {
                        Users.Open();
                    }

                    SqlCommand getbio = new SqlCommand("select Bio from " + CurrentUserId + ";", Users);
                    tb_Bio.Text = Convert.ToString(getbio.ExecuteScalar());

                    Users.Close();

                    tb_UserName.Text = SelectedUser;


                }
                else
                {
                    Response.Redirect("~/TheSite/Main.aspx");
                }
                LoginInfo.Close();
            }
        }

        protected void btn_cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/TheSite/Main.aspx");
        }

        protected void Save_Click(object sender, EventArgs e)
        {
            if (LoginInfo.State != System.Data.ConnectionState.Open)
            {
                LoginInfo.Open();
            }
            if (Users.State != System.Data.ConnectionState.Open)
            {
                Users.Open();
            }
            SqlCommand ChangeUsn = new SqlCommand("Update aspnet_Users set UserName = '" + tb_UserName.Text + "' where UserName = '" + Membership.GetUser().UserName + "';", LoginInfo);
            SqlCommand ChangeLowUsn = new SqlCommand("Update aspnet_Users set LoweredUserName = '" + tb_UserName.Text.ToLower() + "' where UserName = '" + Membership.GetUser().UserName.ToLower() + "';", LoginInfo);
            SqlCommand ChangeBio = new SqlCommand("Update " + CurrentUserId + " set Bio = '" + tb_Bio.Text + "' where Bio is not null;", Users);
            ChangeLowUsn.ExecuteNonQuery();
            ChangeUsn.ExecuteNonQuery();

            ChangeBio.ExecuteNonQuery();
            Response.Redirect("~/Accessing/login.aspx");
            Users.Close();
            LoginInfo.Close();

        }

        protected void tb_UserName_TextChanged(object sender, EventArgs e)
        {

        }
    }
}