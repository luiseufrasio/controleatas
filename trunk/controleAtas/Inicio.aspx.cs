using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using AcessoBanco;
using System.Data.SqlClient;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Session.LCID = 1046;
 
        if (Session["msg"] != null)
        {
            Response.Write("<script>alert('" + Session["msg"].ToString() + "')</script>");
            Session["msg"] = null;
        }
    }
}