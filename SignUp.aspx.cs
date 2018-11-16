using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

public partial class SignUp : System.Web.UI.Page
{
    DataSet ds;
    SqlConnection conUserAccount = new SqlConnection(ConfigurationManager.ConnectionStrings["DBUserAccount"].ConnectionString);
    SqlConnection conUser = new SqlConnection(ConfigurationManager.ConnectionStrings["DBUser"].ConnectionString);

    int temp = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        showSignUp.ServerClick += new EventHandler(showSignUp_Click);
        showLogIn.ServerClick += new EventHandler(showLogIn_Click);

        if (IsPostBack)
        {
            conUserAccount.Open();
            string checkuser = "select count(*) from UserAccount where Username='" + newUser.Text + "'";
            SqlCommand cmd = new SqlCommand(checkuser, conUserAccount);
            temp = Convert.ToInt32(cmd.ExecuteScalar().ToString());
            if (temp == 1)
            {
                MessageBox.Show("Username already exist", "Unable to SignUp", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            conUserAccount.Close();
        }
    }

    protected void showSignUp_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/SignUp.aspx");
    }

    protected void showLogIn_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Login.aspx");
    }

    protected void btnSignUp_Click(object sender, EventArgs e)
    {
        if (temp == 0)
        {
            createProfileTable(newUser.Text);
            addDataToUserAccount(newUser.Text, newPass.Text);
        }
        else
        {
            MessageBox.Show("Username already exist", "Unable to SignUp", MessageBoxButtons.OK, MessageBoxIcon.Error);
            newUser.Text = "";
        }
    }

    public void addDataToUserAccount(string enteredusername, string enteredpassword)
    {
        try
        {
            conUserAccount.Open();

            string insertQuery = "insert into UserAccount (Username, Password) values (@Username, @Password)";
            SqlCommand cmd = new SqlCommand(insertQuery, conUserAccount);
            cmd.Parameters.AddWithValue("@Username", enteredusername);
            cmd.Parameters.AddWithValue("@Password", enteredpassword);
            cmd.ExecuteNonQuery();
            conUserAccount.Close();

            Session["User"] = newUser.Text;
            Response.Redirect("~/Users/Home.aspx");

        }
        catch (Exception ex)
        {
            Response.Write("Error: " + ex);
        }
        finally { conUserAccount.Close(); }   
    }

    public void createProfileTable(string username)
    {
        try
        {
            conUser.Open();

            string createTable = "CREATE TABLE " + username + " (Username nvarchar(50), Job nvarchar(50), Asked int, Answered int, Picture image)";
            SqlCommand com = new SqlCommand(createTable, conUser);
            com.ExecuteNonQuery();
            
            conUser.Close();

            string insertquery = "Insert into " + username + " (Asked, Answered) values (@ask, @answer)";
            using (SqlCommand newComm = new SqlCommand(insertquery, conUser))
            {
                conUser.Open();
                newComm.Parameters.AddWithValue("@ask", 0);
                newComm.Parameters.AddWithValue("@answer", 0);
                newComm.ExecuteNonQuery();
                conUser.Close();
            }
        }

        finally { conUser.Close(); }
    }
}