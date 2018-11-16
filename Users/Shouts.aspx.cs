using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Web.UI.HtmlControls;

public partial class Users_Shouts : System.Web.UI.Page
{
    SqlConnection conChat = new SqlConnection(ConfigurationManager.ConnectionStrings["DBChat"].ConnectionString);

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GetShouts();
            userPic();
        }
    }
    protected void Timer1_Tick(object sender, EventArgs e)
    {
        GetShouts();
    }
    protected void btnShout_Click(object sender, EventArgs e)
    {
        addMessage();
    }
    
    protected void Timer2_Tick(object sender, EventArgs e)
    {
        lblShouts.Text = MessageBox.Text.Length.ToString() + "/300";
    }

    public void GetShouts()
    {
        try
        {
            conChat.Open();
            SqlCommand com = new SqlCommand("Select Username, Message, Time, Pictures from MessageTable", conChat);
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(com);
            da.Fill(ds);
            Repeater1.DataSource = ds;
            Repeater1.DataBind();
        }
        finally { conChat.Close(); }
    }

    public void addMessage()
    {
        try
        {
            conChat.Open();

            var hour = DateTime.Now.Hour;
            var min = DateTime.Now.Minute;
            string time = hour.ToString() + ":" + min.ToString();

            SqlCommand com = new SqlCommand("insert into MessageTable (Username, Message, Time, Pictures) values (@user, @mes, @time, @pic)", conChat);
            com.Parameters.AddWithValue("@user", Session["User"].ToString());
            com.Parameters.AddWithValue("@mes", MessageBox.Text);
            com.Parameters.AddWithValue("@time", time);
            com.Parameters.AddWithValue("@pic", userImage.ImageUrl);
            com.ExecuteNonQuery();
        }
        finally { conChat.Close(); }
    }

    public void userPic()
    {
        Random rand = new Random();
        int num = rand.Next(1, 7);

        switch (num)
        {
            case 1:
                //blue
                userImage.ImageUrl = "~/Images/blue.jpg";
                Session["Image"] = "blue.jpg";
                break;
            case 2:
                //green
                userImage.ImageUrl = "~/Images/green.jpg";
                Session["Image"] = "green.jpg";
                break;
            case 3:
                //orange
                userImage.ImageUrl = "~/Images/orange.jpg";
                Session["Image"] = "orange.jpg";
                break;

            case 4:
                //pink
                userImage.ImageUrl = "~/Images/pink.jpg";
                Session["Image"] = "pink.jpg";
                break;

            case 5:
                //red
                userImage.ImageUrl = "~/Images/red.jpg";
                Session["Image"] = "red.jpg";
                break;

            case 6:
                //violet
                userImage.ImageUrl = "~/Images/Violet.jpg";
                Session["Image"] ="Violet.jpg";
                break;

            case 7:
                //yellow
                userImage.ImageUrl = "~/Images/yellow.jpg";
                Session["Image"] = "yellow.jpg";
                break;

            default:
                break;
        }
        
    }
}