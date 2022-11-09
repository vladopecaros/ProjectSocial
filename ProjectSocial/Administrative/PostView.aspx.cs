using System;
using System.Configuration;
using System.Data.SqlClient;

namespace ProjectSocial2.Administrative
{
    public partial class PostFinder : System.Web.UI.Page
    {
        string PostId;
        string UserId;
        SqlConnection Posts = new SqlConnection(ConfigurationManager.ConnectionStrings["Posts"].ConnectionString);
        SqlConnection Users = new SqlConnection(ConfigurationManager.ConnectionStrings["Users"].ConnectionString);
        SqlConnection LoginInfo = new SqlConnection(ConfigurationManager.ConnectionStrings["UserLoginInfo"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Posts.State != System.Data.ConnectionState.Open)
            {
                Posts.Open();
            }
            if (Users.State != System.Data.ConnectionState.Open)
            {
                Users.Open();
            }
            if (LoginInfo.State != System.Data.ConnectionState.Open)
            {
                LoginInfo.Open();
            }
            PostId = Request["PID"];
            btn_delete.Enabled = false;
            SqlCommand FindPostDetails = new SqlCommand("select Content, Date, Likes, ByUserId from Posts where PostId = Cast('" + PostId + "' AS UNIQUEIDENTIFIER);", Posts);
            SqlDataReader GetPostDetails = FindPostDetails.ExecuteReader();

            try
            {
                GetPostDetails.Read();
                lbl_Content.Text = GetPostDetails.GetString(0);
                lbl_Date.Text = "Posted On: " + GetPostDetails.GetDateTime(1).ToString();
                lbl_Likes.Text = "Likes: " + GetPostDetails.GetInt32(2).ToString();
                UserId = GetPostDetails.GetGuid(3).ToString();
                SqlCommand GetUserName = new SqlCommand("Select UserName from aspnet_Users where UserId= Cast('" + UserId + "' AS UNIQUEIDENTIFIER);", LoginInfo);
                lbl_User.Text = Convert.ToString(GetUserName.ExecuteScalar());
                btn_delete.Enabled = true;
            }
            catch
            {
                lbl_Content.Text = "UNREADABLE";
            }
            Posts.Close();
            Users.Close();
            LoginInfo.Close();
        }

        protected void btn_delete_Click(object sender, EventArgs e)
        {
            if (Posts.State != System.Data.ConnectionState.Open)
            {
                Posts.Open();
            }
            if (Users.State != System.Data.ConnectionState.Open)
            {
                Users.Open();
            }
            try
            {
                //Delete from user
                SqlCommand DeleteFromUser = new SqlCommand("delete from \"" + UserId + "\" where PostID = cast('" + PostId + "' AS UNIQUEIDENTIFIER)", Users);
                DeleteFromUser.ExecuteNonQuery();
                //Delete from posts
                SqlCommand DeleteFromPosts = new SqlCommand("delete from Posts where PostId = cast('" + PostId + "' AS UNIQUEIDENTIFIER)", Posts);
                DeleteFromPosts.ExecuteNonQuery();
                //Add notification
                SqlCommand LeaveNotification = new SqlCommand("insert into \"" + UserId + "\" (Notification, NotificationDate) values ('Your Post was reviewed by administration and was deleted!', SYSDATETIME())", Users);
                LeaveNotification.ExecuteNonQuery();
                Response.Write("<script>alert('Post deleted Successfully.')</script>");
            }
            catch {
                Response.Write("<script>alert('Error Deleting this post.')</script>");

            }
            Posts.Close();
            Users.Close();
        }
    }
}