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

    protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
    {
        CDataService dados = new CDataService("controleAtas");
        SqlDataReader dr = dados.SelectSqlReader("Select * from usuarios where login = " + Util.SQLString(Login1.UserName) + " and senha = " + Util.SQLString(Login1.Password));
        if (dr.Read())
        {
            Session["id"] = dr["id"].ToString();
            Session["admin"] = dr["admin"].ToString();
            e.Authenticated = true;

            if (Session["page"] != null)
            {
                string forward = Session["page"].ToString();
                Session["page"] = null;
                Response.Redirect(forward);
            }
            else
            {
                Response.Redirect("Inicio.aspx");
            }
        }
        else
        {
            Session["id"] = "";
            Session["admin"] = "";
            e.Authenticated = false;
        }

        dr.Close();
        dados.CloseDataSource();
    }
}