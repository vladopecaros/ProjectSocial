using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Security;
using System.Web.UI.WebControls;

namespace ProjectSocial2.TheSite
{
    public partial class Search : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["UserLoginInfo"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_search_Click(object sender, EventArgs e)
        {
            if (con.State != System.Data.ConnectionState.Open)
            {
                con.Open();
            }
            FindUsers();


        }

        private void FindUsers()
        {
            SqlCommand Finder = new SqlCommand("select UserName from aspnet_Users where UserName like '%" + tb_search.Text + "%'", con);
            //Finder.Parameters.AddWithValue("@p1", tb_search.Text);
            SqlDataReader rd = Finder.ExecuteReader();
            while (rd.Read())
            {
                if (rd.GetString(0) != Membership.GetUser().UserName)
                {
                    Populate(rd.GetString(0));
                }
            }

        }
        private void Populate(string Username)
        {
            //Horizontal line
            Label lbl = new Label();
            lbl.ID = "lbl_line";
            lbl.Text = string.Format("<hr />");
            //hyperlink to user
            HyperLink hl = new HyperLink();
            hl.Text = Username;
            hl.ID = "hl_" + Username;
            hl.NavigateUrl = "~/TheSite/User.aspx?Usn=" + Username;
            //inserting these into panel
            Panel1.Controls.Add(hl);
            Panel1.Controls.Add(lbl);
        }
    }
}