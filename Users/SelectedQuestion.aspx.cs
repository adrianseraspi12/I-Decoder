using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

public partial class SelectedQuestion : System.Web.UI.Page
{
    SqlCommand cmd;
    SqlDataAdapter da;
    DataSet ds;
    SqlConnection conUserAccount = new SqlConnection(ConfigurationManager.ConnectionStrings["DBUserAccount"].ConnectionString);
    SqlConnection conForums = new SqlConnection(ConfigurationManager.ConnectionStrings["DBForums"].ConnectionString);
    SqlConnection conUser = new SqlConnection(ConfigurationManager.ConnectionStrings["DBUser"].ConnectionString);

    protected void Page_Load(object sender, EventArgs e)
    {
        titleQuestion.Text = Session["Question"] as string;
        display_Question();

        if (!IsPostBack)
        {
            GetAnswers();
            insertCountedData();
        }
    }


    protected void btnPost_Click(object sender, EventArgs e)
    {
        insertSolutionTable();
        PostAnswers();   
    }

    protected void Timer1_Tick(object sender, EventArgs e)
    {
        txtboxAnswer.Text = txtAnswer.Text.Length.ToString() + "/2000";
    }

    protected void Timer2_Tick(object sender, EventArgs e)
    {
        GetAnswers();
    } 
    
    public void insertCountedData()
    {
        try
        {
            int temp = getCountedData();

            conUser.Open();

            string addQuery = "Update " + Session["User"].ToString() + " set Answered='" + temp + "'";
            SqlCommand addComm = new SqlCommand(addQuery, conUser);
            SqlDataReader dr;
            dr = addComm.ExecuteReader();
            while (dr.Read())
            {
            }
            conUser.Close();
        }

        finally { conUser.Close(); }
    }

    public int getCountedData()
    {
        conForums.Open();
        string countQuery = "Select count(*) from " + titleQuestion.Text.Replace("?", "").Replace(" ", "") + " where Username='" + Session["User"].ToString() + "'";
        SqlCommand countComm = new SqlCommand(countQuery, conForums);
        int temp = Convert.ToInt32(countComm.ExecuteScalar().ToString());
        conForums.Close();
        return temp;
    }
    
    public void display_Question()
    {
        string uname = null;
        string question = null;
        string date = null;

        try
        {
            conUserAccount.Open();
            cmd = new SqlCommand("Select Questions, Username, Date from Question where Title='" + titleQuestion.Text + "'", conUserAccount);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                question = reader[0] as string;
                uname = reader[1] as string;
                date = reader[2] as string;
                break;
            }
               personQuestion.Text = uname;
               descriptionQuestion.Text = question;
               dateQuestion.Text = date;
               conUserAccount.Close();
        }

        catch (Exception ex)
        {
            Response.Write("Error" + ex);
        }

        finally { conUserAccount.Close(); }
    }

    public void PostAnswers()
    {
        try
        {
            conForums.Open();
            cmd = new SqlCommand("insert into " + titleQuestion.Text.Replace(" ", "").Replace("?", "")
                + " (Username, Title, Answer, Date) values (@Username, @Title, @Answer, @Date)", conForums);

            cmd.Parameters.AddWithValue("@Username", Session["User"].ToString());
            cmd.Parameters.AddWithValue("@Title", titleQuestion.Text);
            cmd.Parameters.AddWithValue("@Answer", txtAnswer.Text);
            cmd.Parameters.AddWithValue("@Date", DateTime.Now);
            cmd.ExecuteNonQuery();

            conForums.Close();

            Response.Redirect("~/Users/SelectedQuestion.aspx");
        }
        finally
        {
            conForums.Close();
            conUser.Close();
        }
    }
    
    public void GetAnswers()
    {
        try
        {
            conForums.Open();
            cmd = new SqlCommand("Select Username, Title, Answer, Date from "
                + titleQuestion.Text.Replace("?", "").Replace(" ", ""), conForums);
            ds = new DataSet();
            da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            Repeater1.DataSource = ds;
            Repeater1.DataBind();

            conForums.Close();
        }

        catch (Exception ex) { Response.Write(ex); }

        finally { conForums.Close(); }
    }

    public void insertSolutionTable()
    {
        try
            {
                conUserAccount.Open();
                cmd = new SqlCommand("insert into Solution (Username, Title, Answer, Date) values (@Username, @Title, @Answer, @Date)", conUserAccount);

                cmd.Parameters.AddWithValue("@Username", Session["User"].ToString());
                cmd.Parameters.AddWithValue("@Title", titleQuestion.Text);
                cmd.Parameters.AddWithValue("@Answer", txtAnswer.Text);
                cmd.Parameters.AddWithValue("@Date", DateTime.Now);
                cmd.ExecuteNonQuery();

                conUserAccount.Close();
            }
        finally { conUserAccount.Close(); }
    }

}