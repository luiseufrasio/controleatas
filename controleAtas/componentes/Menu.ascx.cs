using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class Menu : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["id"] == null)
        {
            Session["msg"] = "Sessão expirada! Favor entrar novamento com usuário e senha.";
            Session["page"] = Request.Path.Substring(Request.Path.LastIndexOf("/") + 1);
            Response.Redirect("default.aspx");
        }
    }
}