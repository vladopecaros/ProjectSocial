using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Security;
using System.Web.UI.WebControls;

namespace ProjectSocial2.TheSite
{
    public partial class Main : System.Web.UI.Page
    {
        SqlConnection Users = new SqlConnection(ConfigurationManager.ConnectionStrings["Users"].ConnectionString);
        SqlConnection LoginInfo = new SqlConnection(ConfigurationManager.ConnectionStrings["UserLoginInfo"].ConnectionString);
        SqlConnection Administrative = new SqlConnection(ConfigurationManager.ConnectionStrings["Administrative"].ConnectionString);
        SqlConnection Posts = new SqlConnection(ConfigurationManager.ConnectionStrings["Posts"].ConnectionString);
        string nqCurrentUserId = Membership.GetUser().ProviderUserKey.ToString();
        string CurrentUserId = "\"" + Membership.GetUser().ProviderUserKey.ToString() + "\"";
        List<Post> Postovi = new List<Post>();// List of posts
        protected void Page_Load(object sender, EventArgs e)
        {
            if (User.Identity.IsAuthenticated == false) {
            }
            this.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            hl_Profile.NavigateUrl = "~/TheSite/User.aspx?Usn=" + Membership.GetUser().UserName;
            LoadThemPosts();


        }
        private void LoadThemPosts()
        {
            List<Guid> FollowedUsers = new List<Guid>();
            List<Post> TemporaryPostList = new List<Post>();
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
            SqlCommand CheckFollowing = new SqlCommand("select Following from " + CurrentUserId + " where Following is not null;", Users);
            SqlDataReader GetFollowing = CheckFollowing.ExecuteReader();
            if (GetFollowing.HasRows == true)
            {
                while (GetFollowing.Read())
                {
                    FollowedUsers.Add(GetFollowing.GetGuid(0));
                }
            }
            foreach (Guid FollowedUser in FollowedUsers)
            {
                SqlCommand CheckPosts = new SqlCommand("select * from Posts where ByUserId like '" + FollowedUser + "';", Posts);
                SqlDataReader GetPosts = CheckPosts.ExecuteReader();
                SqlCommand FindUsername = new SqlCommand("select UserName from aspnet_Users where UserId like'" + FollowedUser + "';", LoginInfo);
                string FollowedUsername = FindUsername.ExecuteScalar().ToString(); ;
                if (GetPosts.HasRows == true)
                {
                    while (GetPosts.Read())
                    {
                        Post ThisPost = new Post();
                        ThisPost.Id = GetPosts.GetGuid(0);
                        ThisPost.ByUsername = FollowedUsername;
                        ThisPost.Content = GetPosts.GetString(2);
                        ThisPost.PostDate = GetPosts.GetDateTime(3);
                        ThisPost.Likes = GetPosts.GetInt32(4);
                        TemporaryPostList.Add(ThisPost);
                    }
                }
                if (TemporaryPostList.Count > 0)
                {
                    int n = 0;
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
                        if (n < 3)
                        {
                            Postovi.Add(TemporaryPostList[DelIndex]);
                            n++;
                        }
                        TemporaryPostList.RemoveAt(DelIndex);
                        DelIndex = 0;

                    }
                    TemporaryPostList.Clear();
                }


                GetPosts.Close();
            }
            if (Postovi.Count > 0)
            {
                int help = 0;
                int DelIndex = 0;
                DateTime max;
                max = Postovi[0].PostDate;
                while (Postovi.Count != 0)
                {
                    foreach (Post P in Postovi)
                    {

                        if (P.PostDate > max)
                        {
                            max = P.PostDate;
                            DelIndex = help;
                        }
                        help++;
                    }

                    TemporaryPostList.Add(Postovi[DelIndex]);
                    Postovi.RemoveAt(DelIndex);
                    DelIndex = 0;
                }
                Postovi = TemporaryPostList;
                int n = 0;
                string PrevUsername = "TestUsernumOne";
                foreach (Post P in Postovi)
                {
                    if (PrevUsername == P.ByUsername)
                    {
                        n++;
                    }
                    Populate(P.Content, P.PostDate, P.Likes, P.Id, P.ByUsername, n);
                    PrevUsername = P.ByUsername;
                }
            }

            Posts.Close();
            Users.Close();
            LoginInfo.Close();
        }
        private void Populate(string Content, DateTime Date, int Likes, Guid Id, string UserName, int i)
        {
            Label lblHr = new Label();
            lblHr.Text = string.Format("<hr />");
            Label lblBr = new Label();
            Label lblBr2 = new Label();
            Label lblBr3 = new Label();

            lblBr.Text = lblBr2.Text = lblBr3.Text = string.Format("<Br />");
            //User 
            HyperLink hl = new HyperLink();
            hl.ID = UserName + i;
            hl.Text = UserName;
            hl.NavigateUrl = "~/TheSite/User.aspx?Usn=" + UserName;
            pnl_posts.Controls.Add(hl);
            pnl_posts.Controls.Add(lblBr);
            //content
            Label content = new Label();
            content.CssClass = "ContentLabel";
            content.ID = "ContOf" + Id.ToString();
            content.Text = Content;
            pnl_posts.Controls.Add(content);
            pnl_posts.Controls.Add(lblBr2);


            //date
            Label date = new Label();
            date.ID = "DateOf" + Id.ToString();
            date.Text = Convert.ToString(Date);
            pnl_posts.Controls.Add(date);
            pnl_posts.Controls.Add(lblBr3);
            //like
            Button btn = new Button();

            btn.ID = Id.ToString();
            btn.CssClass = "LikeButton";
            btn.Text = "Like(" + Likes + ")";
            btn.Click += new EventHandler(btn_Like_Click);
            Users.Close(); Users.Open();
            SqlCommand checkiflike = new SqlCommand("select COUNT(LikedPost) from " + CurrentUserId + " where LikedPost like '" + Id + "' group by LikedPost;", Users);
            int IsLiked = Convert.ToInt32(checkiflike.ExecuteScalar());
            if (IsLiked == 0)
            {
                btn.Text = "Like(" + Likes + ")";
                btn.BackColor = System.Drawing.Color.Green;
            }
            else
            {
                btn.Text = "Liked(" + Likes + ")";
                btn.BackColor = System.Drawing.Color.Red;
            }

            pnl_posts.Controls.Add(btn);

            Button Report = new Button();
            Report.ID = "report_" + Id;
            Report.CssClass = "ReportButton";
            Report.Text = "Report";
            Report.ForeColor = System.Drawing.Color.Red;
            Report.Click += new EventHandler(btn_Report_Click);
            pnl_posts.Controls.Add(Report);

            pnl_posts.Controls.Add(lblHr);


        }
        void btn_Report_Click(object sender, EventArgs e)
        {
            if (Administrative.State != System.Data.ConnectionState.Open)
            {
                Administrative.Open();
            }
            if (Posts.State != System.Data.ConnectionState.Open)
            {
                Posts.Open();
            }
            Button ReportBtn = (Button)sender;
            string postid = "'" + ReportBtn.ID.Replace("report_", "") + "'";
            SqlCommand GetUserId = new SqlCommand("select ByUserId from Posts where PostId like " + postid + ";", Posts);
            string nqSelectedUserId = Convert.ToString(GetUserId.ExecuteScalar());
            SqlCommand SendComplaint = new SqlCommand("insert into Complaints values(CAST('" + nqCurrentUserId + "' AS UNIQUEIDENTIFIER),CAST('" + nqSelectedUserId + "' AS UNIQUEIDENTIFIER),CAST(" + postid + " AS UNIQUEIDENTIFIER),SYSDATETIME());", Administrative);
            SendComplaint.ExecuteNonQuery();
            Administrative.Close();
            Posts.Close();
            Response.Write("<script>alert('Thank you for your report. Our administrators will look into this.')</script>");
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

        protected void btn_PostPost_Click(object sender, EventArgs e)
        {
            if (Users.State != System.Data.ConnectionState.Open)
            {
                Users.Open();
            }
            if (Posts.State != System.Data.ConnectionState.Open)
            {
                Posts.Open();
            }

            if (tb_PostText.Text == "")
            {
                Response.Write("<script>alert('Post text cannot be empty!')</script>");
            }
            else if (tb_PostText.Text.Length > 500)
            {
                Response.Write("<script>alert('Post cannot be over 500 characters long!')</script>");

            }
            else
            {

                Guid thisGUID = Guid.NewGuid();

                SqlCommand IntoPosts = new SqlCommand("insert into Posts values (@PostId, '" + nqCurrentUserId + "', @Content, SYSDATETIME(), 0)", Posts);
                IntoPosts.Parameters.AddWithValue("@PostId", thisGUID);
                IntoPosts.Parameters.AddWithValue("@Content", tb_PostText.Text);
                IntoPosts.ExecuteNonQuery();
                SqlCommand IntoUser = new SqlCommand("insert into " + CurrentUserId + " (PostID) values (@PostID);", Users);
                IntoUser.Parameters.AddWithValue("@PostID", thisGUID);
                IntoUser.ExecuteNonQuery();
            }
            Posts.Close();
            Users.Close();

        }

        protected void btn_ReportProblem_Click(object sender, EventArgs e)
        {
            if (Administrative.State != System.Data.ConnectionState.Open)
            {
                Administrative.Open();
            }
            try
            {
                if (tb_ProblemText.Text == "")
                {
                    Response.Write("<script>alert('Problem text cannot be empty!')</script>");

                }else if (tb_ProblemText.Text.Length > 249)
                {
                    Response.Write("<script>alert('Problem description must be under 250 characters!')</script>");

                }
                else
                {
                    SqlCommand ReportProblem = new SqlCommand("insert into Problems values(cast('" + nqCurrentUserId + "' AS UNIQUEIDENTIFIER), SYSDATETIME(), '" + tb_ProblemText.Text + "');", Administrative);
                    ReportProblem.ExecuteNonQuery();
                }
            }
            catch
            {
                Response.Write("<script>alert('Error while sending problem!')</script>");

            }
            Administrative.Close();
        }
    }
}