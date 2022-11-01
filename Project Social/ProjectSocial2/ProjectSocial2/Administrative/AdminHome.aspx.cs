using System;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Security;
using System.Data;

namespace ProjectSocial2.Administrative
{
    public partial class AdminHome : System.Web.UI.Page
    {
        SqlConnection Posts = new SqlConnection(ConfigurationManager.ConnectionStrings["Posts"].ConnectionString);
        SqlConnection Users = new SqlConnection(ConfigurationManager.ConnectionStrings["Users"].ConnectionString);
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
            int i = GridView1.SelectedIndex;
            tb_CompId.Text = GridView1.Rows[i].Cells[1].Text;
            tb_FromUser.Text = GridView1.Rows[i].Cells[2].Text;
            tb_OnUser.Text = GridView1.Rows[i].Cells[3].Text;
            tb_OnPost.Text = GridView1.Rows[i].Cells[4].Text;
            tb_Date.Text= GridView1.Rows[i].Cells[5].Text;

            if (tb_CompId.Text != "")
            {
                btn_DeleteCom.Enabled = true;
            }
            if (tb_FromUser.Text != "")
            {
                btn_ShowFromUser.Enabled = true;
            }
            if (tb_OnUser.Text != "") {
                btn_ShowOnUser.Enabled = true;
            }
            if (tb_OnPost.Text != "")
            {
                btn_ShowPost.Enabled = true;
            }
        }
    }
}