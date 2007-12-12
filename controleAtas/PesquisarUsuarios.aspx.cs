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
    protected void DataBind( int pagina)
    {
            CDataService dados = new CDataService("controleAtas");
            if (nome == "")
            {
                GridView1.DataSource = dados.SelectSqlData("select u.id, u.nome, c.nome as nomeCasa, n.nivel as nivel from usuarios u, casas c, niveis n where u.idCasa = c.id and u.idNivel = n.id Order by 2");
            }
            else
            {
                GridView1.DataSource = dados.SelectSqlData("select u.id, u.nome, c.nome as nomeCasa, n.nivel as nivel from usuarios u, casas c, niveis n where u.idCasa = c.id and u.idNivel = n.id and u.nome like'" + nome + "%' Order by 2");
            }
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
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

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