using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

public partial class Users_Main : System.Web.UI.MasterPage
{

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["User"] == null)
        {
            Response.Redirect("~/SignUp.aspx");
        }

        navLogOut.ServerClick += new EventHandler(navLogOut_Click);
        navShouts.ServerClick +=new EventHandler(navShouts_Click);
        navQuestion.ServerClick +=new EventHandler(navQuestion_Click);
    }

    protected void navShouts_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Users/Shouts.aspx/Username=?" + Session["User"].ToString());
    }

    protected void navQuestion_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Users/Home.aspx/Username=?" + Session["User"].ToString());
    }

    protected void navLogOut_Click(object sender, EventArgs e)
    {
        string title = "Logging Out";
        string mes = "Are you sure you want to Log-Out?";

        DialogResult res = MessageBox.Show(mes, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        if (res == DialogResult.Yes)
        {
                Response.Redirect("~/SignUp.aspx");
                this.Session.RemoveAll();
        }
        
    }
    protected void socialFb_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("https://www.facebook.com/");
    }
    protected void socialTwitter_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("https://twitter.com/");
    }
    protected void socialGoogle_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("https://mail.google.com/");
    }
    protected void imgButton_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("~/Users/UserProfile.aspx");
    }
}
