using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;

public partial class Users_UserProfile : System.Web.UI.Page
{
    DataSet ds;
    SqlConnection conUserAccount = new SqlConnection(ConfigurationManager.ConnectionStrings["DBUserAccount"].ConnectionString);
    SqlConnection conForums = new SqlConnection(ConfigurationManager.ConnectionStrings["DBForums"].ConnectionString);
    SqlConnection conUser = new SqlConnection(ConfigurationManager.ConnectionStrings["DBUser"].ConnectionString);

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["User"] == null)
        {
            Response.Redirect("~/Login.aspx");
        }
        else
        {
            lblUsername.Text = Session["User"].ToString(); 
            //showPicture();
            if (!IsPostBack)
            {
                getRecentlyAskedQuestions();
                getCountedAnsweredQuestion();
                showAskedAnsweredNumber();
                
            }
        }
    }
    
    protected void btnLogout_Click(object sender, EventArgs e)
    {
        DialogResult result = MessageBox.Show("Are You Sure you want to Logout", "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
        if (result ==DialogResult.Yes )
        {
            Session.RemoveAll();
            Response.Redirect("~/Login.aspx");
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        visibleThings();
        //addPicture();
        //showPicture();
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        visibleThings();
    }
    protected void btnEdit_Click(object sender, EventArgs e)
    {
        btnCancel.Visible = true;
        btnSave.Visible = true;
        fuProfile.Visible = true;

        lblUsername.Visible = false;
        imgProfile.Visible = false;
    }

    public void visibleThings()
    {
        btnCancel.Visible = false;
        btnSave.Visible = false;
        fuProfile.Visible = false;

        lblUsername.Visible = true;
        imgProfile.Visible = true;
    }

    public void getRecentlyAskedQuestions()
    {
        try
        {
            conUserAccount.Open();

            string username = Session["User"].ToString();

            SqlCommand com = new SqlCommand("Select Title, Date from Question where Username='" + username + "'" , conUserAccount);
            ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(com);
            da.Fill(ds);
            rptRecentlyAskedQuestion.DataSource = ds;
            rptRecentlyAskedQuestion.DataBind();

            conUserAccount.Close();
        }
        finally { conUserAccount.Close(); }
    }

    public int countAnsweredQuestions()
    {
        try
        {
            conUserAccount.Open();

            string countquery = "Select count(*) from Question where Username='" + Session["User"].ToString() + "'";
            SqlCommand countcomm = new SqlCommand(countquery, conUserAccount);
            int temp = Convert.ToInt32(countcomm.ExecuteScalar().ToString());
            conUserAccount.Close();
            return temp;
        }
        finally { conUserAccount.Close(); }
    }
    
    public void getCountedAnsweredQuestion()
    {
        int temp = countAnsweredQuestions();

        try
        {
            conUser.Open();
            string query = "Update " + Session["User"].ToString() + " set Asked='" + temp + "'";
            SqlCommand com = new SqlCommand(query, conUser);
            SqlDataReader dr;
            dr = com.ExecuteReader();
            while (dr.Read())
            {
            }
            conUser.Close();
        }
        finally { conUser.Close(); }
    }

    public void showAskedAnsweredNumber()
    {
        conUser.Open();
        SqlDataReader dr;
        SqlCommand com = new SqlCommand("Select Asked, Answered from " + Session["User"].ToString() + "", conUser);
        dr = com.ExecuteReader();
        dr.Read();
        lblAsked.Text = dr["Asked"].ToString();
        lblAnswered.Text = dr["Answered"].ToString();
        conUser.Close();
    }

    public void addPicture()
    {
        if (fuProfile.HasFile)
        {
            int length = fuProfile.PostedFile.ContentLength;
            byte[] pic = new byte[length];
            fuProfile.PostedFile.InputStream.Read(pic, 0, length);

            try
            {
                conUser.Open();

                string query = "Insert into " + Session["User"].ToString() + " (Picture) values (@pic)";
                SqlCommand com = new SqlCommand(query, conUser);
                com.Parameters.AddWithValue("@pic", pic);
                com.ExecuteNonQuery();

                conUser.Close();
            }
            finally { conUser.Close(); }
        }
    }
    /// <summary>
    /// public void showPicture()
    ///{
    ///    try
    ///    {
    ///        conUser.Open();
    ///        SqlCommand com = new SqlCommand("Select Picture from " + Session["User"].ToString(), conUser);
    ///        SqlDataReader dr = com.ExecuteReader();
    ///
    ///        dr.Read();
    ///
    ///        byte[] imagedata = (byte[])dr["Picture"];
    ///        string img = Convert.ToBase64String(imagedata, 0, imagedata.Length);
    ///        imgProfile.ImageUrl = "data:image/png;base64" + img;
    ///        
    ///        imgProfile.ImageUrl = "~/Images/orange.jpg";
    ///        conUser.Close();
    ///    }
    ///    finally { conUser.Close(); }
    ///}
    /// </summary>


    protected void rptRecentlyAskedQuestion_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        LinkButton lblTitle = e.Item.FindControl("lblTitle") as LinkButton;
        Session["Question"] = lblTitle.Text;
        Response.Redirect("~/Users/SelectedQuestion.aspx/Username=?" + Session["User"].ToString());
    }
}