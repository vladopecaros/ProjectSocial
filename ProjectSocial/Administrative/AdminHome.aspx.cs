using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace ProjectSocial2.Administrative
{
    public partial class AdminHome : System.Web.UI.Page
    {
        SqlConnection Posts = new SqlConnection(ConfigurationManager.ConnectionStrings["Posts"].ConnectionString);
        SqlConnection Users = new SqlConnection(ConfigurationManager.ConnectionStrings["Users"].ConnectionString);
        SqlConnection Administrative = new SqlConnection(ConfigurationManager.ConnectionStrings["Administrative"].ConnectionString);
        SqlConnection LoginInfo = new SqlConnection(ConfigurationManager.ConnectionStrings["UserLoginInfo"].ConnectionString);
        string UserId;
        protected void Page_Load(object sender, EventArgs e)
        {
            this.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            btn_DeleteCom.Enabled = false;
            btn_ShowFromUser.Enabled = false;
            btn_ShowOnUser.Enabled = false;
            btn_ShowPost.Enabled = false;


        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (LoginInfo.State != ConnectionState.Open)
            {
                LoginInfo.Open();
            }

            int i = GridView1.SelectedIndex;
            //Find Usernames
            SqlCommand FindSnederUsername = new SqlCommand("select UserName from aspnet_Users where UserId = Cast('" + GridView1.Rows[i].Cells[2].Text + "' AS UNIQUEIDENTIFIER)", LoginInfo);
            SqlCommand FindReportedUsername = new SqlCommand("select UserName from aspnet_Users where UserId = Cast('" + GridView1.Rows[i].Cells[3].Text + "' AS UNIQUEIDENTIFIER)", LoginInfo);
            UserId = GridView1.Rows[i].Cells[3].Text;
            tb_CompId.Text = GridView1.Rows[i].Cells[1].Text;
            tb_FromUser.Text = Convert.ToString(FindSnederUsername.ExecuteScalar());
            tb_OnUser.Text = Convert.ToString(FindReportedUsername.ExecuteScalar());
            tb_OnPost.Text = GridView1.Rows[i].Cells[4].Text;
            tb_Date.Text = GridView1.Rows[i].Cells[5].Text;
            LoginInfo.Close();
            if (tb_CompId.Text != "")
            {
                btn_DeleteCom.Enabled = true;
            }
            if (tb_FromUser.Text != "")
            {
                btn_ShowFromUser.Enabled = true;
            }
            if (tb_OnUser.Text != "")
            {
                btn_ShowOnUser.Enabled = true;
            }
            if (tb_OnPost.Text != "")
            {
                btn_ShowPost.Enabled = true;
            }
        }

        protected void btn_DeleteCom_Click(object sender, EventArgs e)
        {
            if (Administrative.State != ConnectionState.Open)
            {
                Administrative.Open();
            }
            SqlCommand DeleteComplaaint = new SqlCommand("delete from Complaints where ComplaintId = " + Convert.ToInt32(tb_CompId.Text) + "", Administrative);
            DeleteComplaaint.ExecuteNonQuery();
            GridView1.DataBind();
            Administrative.Close();

        }

        protected void btn_ShowFromUser_Click(object sender, EventArgs e)
        {
            Server.Transfer("~/TheSite/User.aspx?Usn=" + tb_FromUser.Text);
        }

        protected void btn_ShowOnUser_Click(object sender, EventArgs e)
        {
            Server.Transfer("~/TheSite/User.aspx?Usn=" + tb_OnUser.Text);

        }

        protected void btn_ShowPost_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Administrative/PostView.aspx?PID=" + tb_OnPost.Text);
        }
    }
}