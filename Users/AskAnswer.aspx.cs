using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

public partial class Users_AskAnswer : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBUserAccount"].ConnectionString);
    SqlConnection con2 = new SqlConnection(ConfigurationManager.ConnectionStrings["DBForums"].ConnectionString);
    SqlConnection conUser = new SqlConnection(ConfigurationManager.ConnectionStrings["DBUser"].ConnectionString);

    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnAskNow_Click(object sender, EventArgs e)
    {
        string title = txtboxTitle.Text.Replace(" ", "").Replace("?", "");
        createTable(title);
        getCountedAnsweredQuestion();
        insertDataToQuestion();

        Response.Redirect("~/Users/Home.aspx/Username=?" + Session["User"].ToString());
    }
    protected void btnAnswerQuestions_Click(object sender, EventArgs e)
    {

        Response.Redirect("~/Users/Home.aspx/Username=?" + Session["User"].ToString());
    }

    public void createTable(string title)
    {
        try
        {
            con2.Open();
            string titlequery = "CREATE TABLE " + title + " (Username nvarchar(50), Title nvarchar(300), Answer nvarchar(2000), Date nvarchar(50))";
            SqlCommand com = new SqlCommand(titlequery, con2);
            com.ExecuteNonQuery();

        }
        finally
        {
            con2.Close();
        }
    }

    public void insertDataToQuestion()
    {
        try
            {
                con.Open();

                var month = DateTime.Now.ToString("MMM");
                var day = DateTime.Now.Day;
                var year = DateTime.Now.Year;
                string date = (month + " " + day + ", " + year).ToString();

                string insertquery = "Insert into Question (Username, Title, Questions, Date) values (@username, @title, @questions, @date)";
                SqlCommand cmd = new SqlCommand(insertquery, con);
                cmd.Parameters.AddWithValue("@username", Session["User"].ToString());
                cmd.Parameters.AddWithValue("@title", txtboxTitle.Text);
                cmd.Parameters.AddWithValue("@questions", txtboxDescription.Text);
                cmd.Parameters.AddWithValue("@date", date);
                cmd.ExecuteNonQuery();

                con.Close();
            }

        finally
        {
            con.Close();
        }
    }

    protected void Timer1_Tick(object sender, EventArgs e)
    {
        titleCharacters.Text = txtboxTitle.Text.Length.ToString() + "/200";
        descriptionCharacters.Text = txtboxDescription.Text.Length.ToString() + "/2000";
    }

    public int countAnsweredQuestions()
    {
        try
        {
            con.Open();

            string countquery = "Select count(*) from Question where Username='" + Session["User"].ToString() + "'";
            SqlCommand countcomm = new SqlCommand(countquery, con);
            int temp = Convert.ToInt32(countcomm.ExecuteScalar().ToString());
            con.Close();
            return temp;
        }
        finally { con.Close(); }
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
}