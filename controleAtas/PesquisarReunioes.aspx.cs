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
    protected void DataBind(int pagina)
    {
        CDataService dados = new CDataService("controleAtas");
        string sql = "";

        if (dtFim.Text == "" || dtInicio.Text == "")
        {
            sql = " SELECT DISTINCT r.id, convert(varchar(10),datahora,103) as data, assunto, local " +
                  " FROM Reunioes r, Participantes p " +
                  " WHERE r.id = p.idReuniao " +
                  " AND r.dataHora BETWEEN (GETDATE() - 30) AND GETDATE() " +
                  " AND r.excluida = 0 ";
            if (Session["admin"].ToString().Equals("False"))
            {
                sql += "AND p.idUsuario = " + Session["id"].ToString();
            }

            sql += " Order by 2";
        }
        else
        {
            sql = " SELECT DISTINCT r.id, convert(varchar(10),datahora,103) as data, assunto, local " +
                  " FROM Reunioes r, Participantes p " +
                  " WHERE r.id = p.idReuniao " +
                  " AND r.dataHora BETWEEN " + Util.SQLString(dtInicio.SqlData) +
                  " AND " + Util.SQLString(dtFim.SqlData) +
                  " AND r.excluida = 0 ";
            if (Session["admin"].ToString().Equals("False"))
            {
                sql += "AND p.idUsuario = " + Session["id"].ToString();
            }

            sql += " Order by 2";
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
        DataBind(0);
    }

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        DataBind(e.NewPageIndex);
    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        // Caso venha do item Escrever ata => encaminhar para atareuniao.aspx

        if (e.Row.RowType == DataControlRowType.DataRow && Request["ea"] != null)
        {
            HyperLink h = (HyperLink)e.Row.Cells[1].Controls[0];
            h.NavigateUrl = "atareuniao.aspx?cod=" + e.Row.Cells[0].Text;

            h = (HyperLink)e.Row.Cells[2].Controls[0];
            h.NavigateUrl = "atareuniao.aspx?cod=" + e.Row.Cells[0].Text;

            h = (HyperLink)e.Row.Cells[3].Controls[0];
            h.NavigateUrl = "atareuniao.aspx?cod=" + e.Row.Cells[0].Text;
        }
    }
}