using System;
using System.Configuration;
using System.Data.SqlClient;

namespace ProjectSocial2.Administrative
{
    public partial class ProblemsPage : System.Web.UI.Page
    {
        SqlConnection Administrative = new SqlConnection(ConfigurationManager.ConnectionStrings["Administrative"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            btn_delete.Enabled = false;
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i = GridView1.SelectedIndex;
            tb_ProblemId.Text = Convert.ToString(GridView1.Rows[i].Cells[1].Text);
            tb_ProblemText.Text = Convert.ToString(GridView1.Rows[i].Cells[4].Text);
            if (tb_ProblemId.Text != "")
            {
                btn_delete.Enabled = true;
            }

        }

        protected void btn_delete_Click(object sender, EventArgs e)
        {
            if (Administrative.State != System.Data.ConnectionState.Open)
            {
                Administrative.Open();
            }
            try
            {
                int Id = Convert.ToInt32(tb_ProblemId.Text);
                SqlCommand DeleteProblem = new SqlCommand("delete from Problems where Id = " + Id + ";", Administrative);
                DeleteProblem.ExecuteNonQuery();
                Response.Write("<script>alert('Problem removed from list successfully')</script>");
            }
            catch
            {
                Response.Write("<script>alert('There was a problem. Problem not deleted!')</script>");

            }
            Administrative.Close();

        }
    }
}