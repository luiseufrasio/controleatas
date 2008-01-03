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
using AcessoBanco;

public partial class PesqCatDica : System.Web.UI.Page
{
    private string nome;

    protected void DataBind(int pagina)
    {
        CDataService dados = new CDataService("controleAtas");
        string sql = "";
        
        if (nome == "")
        {
            sql = "SELECT id, nome, email, admin FROM Usuarios Order by 2";
        }
        else
        {
            sql = "SELECT id, nome, email, admin FROM Usuarios WHERE nome like'" + nome + "%' Order by 2";
        }

        GridView1.DataSource = dados.SelectSqlData(sql);
        GridView1.PageIndex = pagina;
        GridView1.DataBind();
        dados.CloseDataSource();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DataBind(0);
        }

    }

    protected void BtBusca_Click(object sender, EventArgs e)
    {
        nome = TextBox1.Text;
        GridView1.Attributes.Add("filtro", "S");
        DataBind(0);
    }

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        if (GridView1.Attributes["filtro"] == "S")
        {
            nome = TextBox1.Text;
        }
        DataBind(e.NewPageIndex);
    }
}