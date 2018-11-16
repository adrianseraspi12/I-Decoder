using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using System.Configuration;

public partial class Login : System.Web.UI.Page
{
    SqlConnection conUserAccount = new SqlConnection(ConfigurationManager.ConnectionStrings["DBUserAccount"].ConnectionString);

    protected void Page_Load(object sender, EventArgs e)
    {
        showSignUp.ServerClick += new EventHandler(showSignUp_Click);
        showLogIn.ServerClick += new EventHandler(showLogIn_Click);
    }

    protected void showSignUp_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/SignUp.aspx");
    }

    protected void showLogIn_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Login.aspx");
    }

    protected void btnLogIn_Click(object sender, EventArgs e)
    {
        checkLogin(txtUser.Text, txtPass.Text);
    }

    public void checkLogin(string enteredusername, string enteredpassword)
    {
        string title = "Unable to Login";
        string mes = "Wrong Username or Password, Try Again";

        conUserAccount.Open();
        string checkuser = ("select count(*) from UserAccount where Username='" + enteredusername + "'");

        SqlCommand com = new SqlCommand(checkuser, conUserAccount);
        int temp = Convert.ToInt32(com.ExecuteScalar().ToString());
        conUserAccount.Close();

        if (temp == 1)
        {
            conUserAccount.Open();

            string checkPasswordQuery = ("select Password from UserAccount where Username='" + enteredusername + "'");
            SqlCommand PassComm = new SqlCommand(checkPasswordQuery, conUserAccount);
            string correctpassword = PassComm.ExecuteScalar().ToString().Replace(" ", "");

            if (correctpassword == enteredpassword)
            {
                Session["User"] = txtUser.Text;
                Response.Redirect("~/Users/Home.aspx/Username=?" + this.txtUser.Text);      
            }
            else
            {
                MessageBox.Show(mes, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        else
        {
            MessageBox.Show(mes, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        conUserAccount.Close();
    }
}