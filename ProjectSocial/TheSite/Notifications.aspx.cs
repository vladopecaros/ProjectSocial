using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Security;
using System.Web.UI.WebControls;

namespace ProjectSocial2.TheSite
{
    public partial class Notifications : System.Web.UI.Page
    {
        SqlConnection Users = new SqlConnection(ConfigurationManager.ConnectionStrings["Users"].ConnectionString);
        string UserId;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Users.State != System.Data.ConnectionState.Open)
            {
                Users.Open();
            }
            UserId = Convert.ToString(Membership.GetUser().ProviderUserKey);
            try
            {
                SqlCommand LoadNotifications = new SqlCommand("select Notification, NotificationDate from \"" + UserId + "\" where Notification is not null;", Users);
            SqlDataReader GetNotifications = LoadNotifications.ExecuteReader();
            
                if (GetNotifications.HasRows == true)
                {
                    while (GetNotifications.Read())
                    {
                        if (!GetNotifications.IsDBNull(0) && !GetNotifications.IsDBNull(1))
                        {
                            Label Br2 = new Label();
                            Br2.Text = string.Format("<br />");
                            Panel1.Controls.Add(Br2);
                            Label NotificationText = new Label();
                            NotificationText.Text = GetNotifications.GetString(0);
                            Panel1.Controls.Add(NotificationText);
                            Label Br = new Label();
                            Br.Text = string.Format("<br />");
                            Panel1.Controls.Add(Br);
                            Label NotificationDate = new Label();
                            NotificationDate.Text = GetNotifications.GetDateTime(1).ToString();
                            Panel1.Controls.Add(NotificationDate);
                            Label Hr = new Label();
                            Hr.Text = string.Format("<hr />");
                        }

                    }
                }
                else
                {
                    Label NoNotificationNotice = new Label();
                    NoNotificationNotice.Text = "There is no new notifications";
                    Panel1.Controls.Add(NoNotificationNotice);
                }
            }
            catch
            {
                Response.Write("<script>alert('Error Loading Notifications')</script>");

            }
            Users.Close();
        }
    }
}