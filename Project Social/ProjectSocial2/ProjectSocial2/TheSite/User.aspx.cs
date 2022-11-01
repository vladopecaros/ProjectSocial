using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Security;
using System.Web.UI.WebControls;

namespace ProjectSocial2.TheSite
{
    public partial class User : System.Web.UI.Page
    {
        SqlConnection Users = new SqlConnection(ConfigurationManager.ConnectionStrings["Users"].ConnectionString);
        SqlConnection LoginInfo = new SqlConnection(ConfigurationManager.ConnectionStrings["UserLoginInfo"].ConnectionString);
        SqlConnection Posts = new SqlConnection(ConfigurationManager.ConnectionStrings["Posts"].ConnectionString);
        string nqSelectedUserId;
        string SelectedUserId;
        string nqCurrentUserId = Membership.GetUser().ProviderUserKey.ToString();
        string CurrentUserId = "\"" + Membership.GetUser().ProviderUserKey.ToString() + "\"";
        List<Post> Postovi = new List<Post>();
        protected void Page_Load(object sender, EventArgs e)
        {
            string SelectedUser = Request["Usn"];
            if (LoginInfo.State != System.Data.ConnectionState.Open)
            {
                LoginInfo.Open();
            }
            int IsCurrentUser;
            //GetId
            SqlCommand getid = new SqlCommand("select UserId from aspnet_Users where UserName = @p1", LoginInfo);
            getid.Parameters.AddWithValue("@p1", SelectedUser);
            nqSelectedUserId = Convert.ToString(getid.ExecuteScalar());
            SelectedUserId = "\"" + nqSelectedUserId + "\"";
            //string CurrentUserId = "\"" + Membership.GetUser().ProviderUserKey.ToString() + "\"";
            lbl_user.Text = SelectedUser;
            LoginInfo.Close();
            //FollowCount
            LoadFollowCount(SelectedUserId);
            //PostCount
            PostCount(SelectedUserId);
            //Bio
            lbl_bio.Text = LoadBio(SelectedUserId);
            //Posts
            if (Request["Usn"] == Membership.GetUser().UserName)
            {

                IsCurrentUser = 1;
            }
            else
            {
                IsCurrentUser = 0;
            }
            LoadPosts(SelectedUserId, IsCurrentUser);
            //ButtonFunction
            if (SelectedUserId == CurrentUserId)
            {
                btn_function.Text = "Edit";
                btn_function.Click += new EventHandler(EditUser);
            }
            else
            {
                CheckFollowing(CurrentUserId, SelectedUserId);
            }
            LoginInfo.Close();
        }
        private void PostCount(string UserId)
        {
            if (Users.State != System.Data.ConnectionState.Open)
            {
                Users.Open();
            }
            SqlCommand LoadPosts = new SqlCommand("select COUNT(PostId) from " + UserId + " where PostId is not null;", Users);
            lbl_Posts.Text = Convert.ToString(Convert.ToInt32(LoadPosts.ExecuteScalar()));
            Users.Close();
        }
        private void LoadFollowCount(string UserId)
        {
            if (Users.State != System.Data.ConnectionState.Open)
            {
                Users.Open();
            }
            SqlCommand Followers = new SqlCommand("select COUNT(Follower) from " + UserId + " where Follower is not null;", Users);
            lbl_Followers.Text = Convert.ToString(Convert.ToInt32(Followers.ExecuteScalar()));
            SqlCommand Following = new SqlCommand("select COUNT(Following) from " + UserId + " where Following is not null;", Users);
            lbl_Following.Text = Convert.ToString(Convert.ToInt32(Following.ExecuteScalar()));
            Users.Close();
        }
        private string LoadBio(string ThisUser)
        {
            if (Users.State != System.Data.ConnectionState.Open)
            {
                Users.Open();
            }

            SqlCommand cmd = new SqlCommand("select Bio from " + ThisUser + ";", Users);
            string bio = Convert.ToString(cmd.ExecuteScalar());
            Users.Close();
            if (bio == "")
            {
                return ("/");
            }
            else
            {
                return (bio);
            }
        }
        private void LoadPosts(string UserId, int IsCurrentUser)
        {
            if (Posts.State != System.Data.ConnectionState.Open)
            {
                Posts.Open();
            }
            if (Users.State != System.Data.ConnectionState.Open)
            {
                Users.Open();
            }
            List<Post> TemporaryPostList = new List<Post>();

            SqlCommand CheckPosts = new SqlCommand("select * from Posts where ByUserId like '" + nqSelectedUserId + "';", Posts);
            SqlDataReader GetPosts = CheckPosts.ExecuteReader();
            if (GetPosts.HasRows == true)
            {
                while (GetPosts.Read())
                {
                    Post ThisPost = new Post();
                    ThisPost.Id = GetPosts.GetGuid(0);
                    ThisPost.ByUsername = Request["Usn"];
                    ThisPost.Content = GetPosts.GetString(2);
                    ThisPost.PostDate = GetPosts.GetDateTime(3);
                    ThisPost.Likes = GetPosts.GetInt32(4);
                    TemporaryPostList.Add(ThisPost);
                }
            }
            if (TemporaryPostList.Count > 0)
            {
                int t = 0;
                int help = 0;
                int DelIndex = 0;
                DateTime max;
                max = TemporaryPostList[0].PostDate;
                while (TemporaryPostList.Count != 0)
                {

                    foreach (Post P in TemporaryPostList)
                    {

                        if (P.PostDate > max)
                        {
                            max = P.PostDate;
                            DelIndex = help;
                        }
                        help++;
                    }
                    if (t < 3)
                    {
                        Postovi.Add(TemporaryPostList[DelIndex]);
                        t++;
                    }
                    TemporaryPostList.RemoveAt(DelIndex);
                    DelIndex = 0;

                }
                TemporaryPostList.Clear();
            }

            foreach (Post P in Postovi)
            {

                Populate(P.Content, P.PostDate, P.Likes, Convert.ToString(P.Id), IsCurrentUser);

            }
            GetPosts.Close();
        }
        private void Populate(string Content, DateTime Date, int Likes, string Id, int IsCurrentUser)
        {
            Label lblHr = new Label();
            lblHr.Text = string.Format("<hr />");
            Label lblBr = new Label();
            lblBr.Text = string.Format("<Br />");
            //content
            Label content = new Label();
            content.CssClass = "ContentLabel";
            content.ID = "ContOf" + Id;
            content.Text = Content;
            pnl_posts.Controls.Add(content);
            pnl_posts.Controls.Add(lblBr);
            //date

            Label date = new Label();
            date.ID = "DateOf" + Id;
            date.Text = Convert.ToString(Date.Date);
            pnl_posts.Controls.Add(date);
            //like
            Button btn = new Button();
            btn.ID = Id;
            btn.CssClass = "Button";
            if (IsCurrentUser == 0)
            {
                btn.Text = "Like(" + Likes + ")";
                btn.Click += new EventHandler(btn_Like_Click);


                SqlCommand checkiflike = new SqlCommand("select COUNT(LikedPost) from " + CurrentUserId + " where LikedPost like '" + Id + "' group by LikedPost;", Users);

                if (Convert.ToInt32(checkiflike.ExecuteScalar()) == 0)
                {
                    btn.BackColor = System.Drawing.Color.Green;

                }
                else
                {
                    btn.BackColor = System.Drawing.Color.Red;
                }



            }
            else
            {
                btn.Text = Likes + " Likes";
                btn.BackColor = System.Drawing.Color.LightBlue;
            }

            pnl_posts.Controls.Add(btn);
            //delete
            if (IsCurrentUser == 1)
            {
                Button btn1 = new Button();
                btn1.ID = "del_" + Id;
                btn1.CssClass = "Button";
                btn1.Text = "Delete";
                btn1.Click += new EventHandler(btn_Delete_Click);
                btn1.BackColor = System.Drawing.Color.Yellow;
                pnl_posts.Controls.Add(btn1);
            }
            pnl_posts.Controls.Add(lblHr);
        }
        void btn_Delete_Click(object sender, EventArgs e)
        {
            if (Users.State != System.Data.ConnectionState.Open)
            {
                Users.Open();
            }
            if (Posts.State != System.Data.ConnectionState.Open)
            {
                Posts.Open();
            }
            string CurrentUserId = "\"" + Membership.GetUser().ProviderUserKey.ToString() + "\"";
            Button btn = (Button)sender;
            string btn_id = btn.ID;
            string PostId = btn_id.Replace("del_", "");
            string nqPostId = PostId;
            PostId = "\"" + PostId + "\"";
            //DeleteFormAllPosts
            SqlCommand DelFromPosts = new SqlCommand("delete from Posts where PostId like '" + nqPostId + "';", Posts);
            DelFromPosts.ExecuteNonQuery();
            SqlCommand DeleteFromUser = new SqlCommand("delete from " + CurrentUserId + " where PostId like '" + nqPostId + "';", Users);
            DeleteFromUser.ExecuteNonQuery();

            Users.Close();
            Posts.Close();
            Response.Redirect(Request.RawUrl);
        }
        void btn_Like_Click(object sender, EventArgs e)
        {
            if (Posts.State != System.Data.ConnectionState.Open)
            {
                Posts.Open();
            }
            if (Users.State != System.Data.ConnectionState.Open)
            {
                Users.Open();
            }
            Button btn = (Button)sender;
            string CurrentUserId = "\"" + Membership.GetUser().ProviderUserKey.ToString() + "\"";
            string postid = "'" + btn.ID + "'";
            SqlCommand checkiflike = new SqlCommand("select COUNT(LikedPost) from " + CurrentUserId + " where LikedPost like " + postid + " group by LikedPost;", Users);

            if (Convert.ToInt32(checkiflike.ExecuteScalar()) == 0)
            {



                SqlCommand insertlike = new SqlCommand("insert into " + CurrentUserId + " (LikedPost) values (CAST(" + postid + " AS UNIQUEIDENTIFIER));", Users);
                insertlike.ExecuteNonQuery();
                SqlCommand HowManyLikes = new SqlCommand("select Likes from Posts where PostId like " + postid + ";", Posts);
                int NumLikes = Convert.ToInt32(HowManyLikes.ExecuteScalar());
                NumLikes += 1;
                SqlCommand like = new SqlCommand("update Posts set Likes = " + NumLikes + " where PostId like " + postid + ";", Posts);
                like.ExecuteNonQuery();
                btn.Text = "Like(" + NumLikes + ")";
            }
            else
            {
                SqlCommand removelike = new SqlCommand("delete from " + CurrentUserId + " where LikedPost like " + postid + ";", Users);
                removelike.ExecuteNonQuery();
                SqlCommand HowManyLikes = new SqlCommand("select Likes from Posts where PostId like " + postid + ";", Posts);
                int NumLikes = Convert.ToInt32(HowManyLikes.ExecuteScalar());
                NumLikes -= 1;
                SqlCommand like = new SqlCommand("update Posts set Likes = " + NumLikes + " where PostId like " + postid + ";", Posts);
                like.ExecuteNonQuery();
                btn.Text = "Like(" + NumLikes + ")";
            }


            Users.Close();
            Posts.Close();
            Response.Redirect(Request.RawUrl);
        }
        private void CheckFollowing(string CurrentUserId, string SelectedUserId)
        {
            if (Users.State != System.Data.ConnectionState.Open)
            {
                Users.Open();
            }
            SqlCommand checkiffollowing = new SqlCommand("select COUNT(Following) from " + CurrentUserId + " where Following like '" + nqSelectedUserId + "' group by Following;", Users);
            if (Convert.ToInt32(checkiffollowing.ExecuteScalar()) == 0)
            {
                btn_function.Text = "Follow";

            }
            else
            {
                btn_function.Text = "Unfollow";
            }
            btn_function.Click += new EventHandler(btn_FollowUnfollow_Click);
            Users.Close();
        }
        protected void btn_FollowUnfollow_Click(object sender, EventArgs e)
        {


            if (Users.State != System.Data.ConnectionState.Open)
            {
                Users.Open();
            }
            Button btn = (Button)sender;
            if (btn.Text == "Follow")
            {
                SqlCommand follow = new SqlCommand("insert into " + CurrentUserId + " (Following) values ('" + nqSelectedUserId + "');", Users);
                follow.ExecuteNonQuery();
                SqlCommand followed = new SqlCommand("insert into " + SelectedUserId + " (Follower) values ('" + nqCurrentUserId + "');", Users);
                followed.ExecuteNonQuery();
                Response.Redirect(Request.RawUrl);
            }
            else if (btn.Text == "Unfollow")
            {

                SqlCommand unfollow = new SqlCommand("delete from " + CurrentUserId + " where Following like '" + nqSelectedUserId + "';", Users);
                unfollow.ExecuteNonQuery();

                SqlCommand unfollowed = new SqlCommand("delete from " + SelectedUserId + " where Follower like '" + nqCurrentUserId + "';", Users);
                unfollowed.ExecuteNonQuery();
                Response.Redirect(Request.RawUrl);
            }
            Users.Close();
        }
        private void EditUser(object sender, EventArgs e)
        {
            Response.Redirect("~/TheSite/EditProfile.aspx");
        }

    }
}