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
using System.Data.SqlClient;

public partial class PesqCatDica : System.Web.UI.Page
{
    protected void preencherParticipantes()
    {
        CDataService dados = new CDataService("ControleAtas");
        SqlDataReader dr = dados.SelectSqlReader("Select id, nome From Usuarios");

        while (dr.Read())
        {
            ListItem item = new ListItem();
            item.Value = dr["id"].ToString().Trim();
            item.Text = dr["nome"].ToString().Trim();
            listParticipantes.Items.Add(item);
        }
        dados.CloseDataSource();
    }

    protected void DataBind(int pagina)
    {
        CDataService dados = new CDataService("controleAtas");
        string sql = "";
        
        if (dtFim.Text == "" || dtInicio.Text == "")
        {
            sql = " SELECT r.id, datahora as data, assunto, local " +
                  " FROM Reunioes r, Participantes p " +
                  " WHERE r.id = p.idReuniao AND p.idUsuario = " + Session["id"].ToString() +
                  " AND r.dataHora BETWEEN (GETDATE() - 30) AND GETDATE() " +
                  " AND r.excluida = 0 " +
                  " Order by 2";
        }
        else
        {
            sql = " SELECT r.id, datahora as data, assunto, local " +
                  " FROM Reunioes r, Participantes p " +
                  " WHERE r.id = p.idReuniao AND p.idUsuario = " + listParticipantes.SelectedValue +
                  " AND r.dataHora BETWEEN " + Util.SQLString(dtInicio.SqlData) +
                  " AND " + Util.SQLString(dtFim.SqlData) +
                  " AND r.excluida = 0 " +
                  " Order by 2";
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
            preencherParticipantes();

            DataBind(0);
        }

    }

    protected void BtBusca_Click(object sender, EventArgs e)
    {
        DataBind(0);
    }

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        DataBind(e.NewPageIndex);
    }
}