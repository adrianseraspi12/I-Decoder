using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Web.UI.HtmlControls;

public partial class Users_Default : System.Web.UI.Page
{   
    /// <summary>
    /// Remember add/copy the title in Answer and Question database so that it will read it
    /// </summary>

    SqlCommand cmd;
    SqlDataAdapter da;
    DataSet ds;
    SqlConnection conUserAccount = new SqlConnection(ConfigurationManager.ConnectionStrings["DBUserAccount"].ConnectionString);

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["User"] != null)
        {
            if (!IsPostBack)
            {
                GetData();
            }
        }
        else { Response.Redirect("~/SignUp.aspx"); }

    }

    protected void QuestionRepeater_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        LinkButton hlTitle = e.Item.FindControl("hlTitle") as LinkButton;
        Session["Question"] = hlTitle.Text;
        Response.Redirect("~/Users/SelectedQuestion.aspx/Username=?" + Session["User"].ToString());
    }

    protected void btnAsk_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Users/AskAnswer.aspx/Username=?" + Session["User"].ToString());
    }
    protected void QuestionRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (QuestionRepeater.Items.Count < 1)
        {
            if (e.Item.ItemType == ListItemType.Footer)
            {
                Label lblfooter = (Label)e.Item.FindControl("lblEmptyData");
                lblfooter.Visible = true;
                helpText.Visible = false;
            }
        }
    }
    
    public void GetData()
    {
        conUserAccount.Open();
        cmd = new SqlCommand("Select Username, Title, Questions, Date from Question", conUserAccount);
        ds = new DataSet();
        da = new SqlDataAdapter(cmd);
        da.Fill(ds);
        QuestionRepeater.DataSource = ds;
        QuestionRepeater.DataBind();
        conUserAccount.Close();
    }
}