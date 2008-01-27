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

public partial class ManutencaoOrcamento : System.Web.UI.Page
{
    private string id;
    private string idCriador;

    protected void preencher()
    {
        CDataService dados = new CDataService("controleAtas");
        string sql =" SELECT r.*,convert(varchar(10),datahora,103) as data, p.idUsuario as usu, u.nome as nomeCriador " +
            " FROM Reunioes r, Participantes p, Usuarios u " +
            " WHERE r.id = p.idReuniao AND " +
            " r.idCriador = u.id AND " +
            " r.id = " + id;
       // Response.Write(sql);
       // Response.End();

        SqlDataReader dr = dados.SelectSqlReader(sql);
        int i = 0;
        while (dr.Read())
        {
            i++;
            if (i == 1)
            {
                txtAssunto.Text = dr["assunto"].ToString().Trim();
                txtLocal.Text = dr["local"].ToString().Trim();
                DtReuniao.Text = dr["data"].ToString().Trim();
                //lblCriador.Visible = true;
                //txtCriador.Visible = true;
                txtCriador.Text = dr["nomeCriador"].ToString().Trim();
            }

            // Marcando os participantes
            //lstParticipantes.Items.FindByValue(dr["usu"].ToString().Trim()).Selected = true;
            CheckBoxList1.Items.FindByValue(dr["usu"].ToString().Trim()).Selected = true;
        }
        dr.Close();
        dados.CloseDataSource();
    }

    protected void preencherParticipantes()
    {
        CDataService dados = new CDataService("controleAtas");
        string sql =
            " SELECT id, nome FROM Usuarios Order By 2";

        SqlDataReader dr = dados.SelectSqlReader(sql);
        while (dr.Read())
        {
            ListItem li = new ListItem(dr["nome"].ToString().Trim(), dr["id"].ToString());
           // lstParticipantes.Items.Add(li);
            CheckBoxList1.Items.Add(li);
        }
        dr.Close();
        dados.CloseDataSource();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString.HasKeys())
        {
            id = Request["cod"].ToString();
        }
        else
        {
            id = "";
        }
        if (!IsPostBack)
        {
            preencherParticipantes();

            if (id != "")
            {
                preencher();
                CDataService dados = new CDataService("controleAtas");

                string sql = " Select * From Reunioes Where id = " + id;
                SqlDataReader dr = dados.SelectSqlReader(sql);
                if (dr.Read())
                {
                    idCriador = dr["idCriador"].ToString();
                    BtExcluir.Enabled = true;
                    lblCriador.Visible = true;
                    txtCriador.Visible = true;
                }
                dados.CloseDataSource();
            }
        }
    }

    protected void Button7_Click(object sender, EventArgs e)
    {
        CDataService dados = new CDataService("controleAtas");

        try
        {
            dados.OpenDataSourceTransaction();

            if (id == "")
            {
                string sql = " INSERT INTO Reunioes (assunto,dataHora,local,idCriador) VALUES";
                sql = sql + "(" + Util.SQLString(txtAssunto.Text) + "," +
                    Util.SQLString(DtReuniao.SqlData) + "," +
                    Util.SQLString(txtLocal.Text) + "," +
                    Session["id"].ToString() + ")";
                id = dados.InsertSqlDatatransacao(sql).ToString();

                // Inserindo os participantes da reunião
                for (int i = 0; i <= CheckBoxList1.Items.Count - 1; i++)
                {
                   // ListItem li = lstParticipantes.Items[i];
                   // if (li.Selected)
                   // {
                   //     sql = " INSERT INTO Participantes(idReuniao,idUsuario) " +
                   //         " VALUES(" + id + "," + Util.SQLString(li.Value.ToString()) + ")";
                   //     dados.InsertSqlDatatransacao(sql);
                   // }
                    ListItem li = CheckBoxList1.Items[i];
                    if (li.Selected)
                    {
                        
                        sql = " INSERT INTO Participantes(idReuniao,idUsuario) " +
                            " VALUES(" + id + "," + Util.SQLString(li.Value.ToString()) + ")";
                        dados.InsertSqlDatatransacao(sql);
                    }
                }

                Response.Write("<script>alert('Cadastro Realizado com Sucesso!');document.location.href='reunioes.aspx?cod=" + id + "';</script>");
            }
            else
            {
                string sql = " UPDATE Reunioes SET assunto = " +
                    Util.SQLString(txtAssunto.Text) + ",dataHora=" +
                    Util.SQLString(DtReuniao.SqlData) + ",local=" +
                    Util.SQLString(txtLocal.Text) +
                    " WHERE id = " + id;
                dados.UpdateSQLDatatransacao(sql);

                // Removendo os participantes antigos
                sql = " DELETE FROM Participantes WHERE idReuniao = " + id;
                dados.DeleteSQLDataTransaction(sql);

                // Inserindo os novos participantes da reunião
                for (int i = 0; i <= CheckBoxList1.Items.Count - 1; i++)
                {
                    ListItem li = CheckBoxList1.Items[i];
                    if (li.Selected)
                    {
                        sql = " INSERT INTO Participantes(idReuniao,idUsuario) " +
                            " VALUES(" + id + "," + li.Value.ToString() + ")";
                        dados.InsertSqlDatatransacao(sql);
                    }
                }

                Response.Write("<script>alert('Cadastro Atualizado com Sucesso!')</script>");
            }

            dados.committransacao();
            preencher();
        }
        catch (Exception ex)
        {
            dados.rollbacktransacao();
            Response.Write("<script>alert('Não foi possível realizar a operação, favor entre em contato com o responsável pelo sistema!')</script>");
        }
        finally
        {
            dados.CloseDataSource();
        }
    }

    protected void BtExcluir_Click(object sender, EventArgs e)
    {
        CDataService dados = new CDataService("controleAtas");

        if (idCriador == null || idCriador.Equals(""))
        {
            string sql = " Select * From Reunioes Where id = " + id;
            SqlDataReader dr = dados.SelectSqlReader(sql);
            if (dr.Read())
            {
                idCriador = dr["idCriador"].ToString();
            }
            dados.CloseDataSource();
        }

        if (!idCriador.Equals(Session["id"].ToString()))
        {
            Response.Write("<script>alert('Somente o criador da Reunião pode excluí-la!');</script>");
        }
        else
        {
            try
            {
                dados.OpenDataSource();
                dados.DeleteSQLData("Update Reunioes Set excluida = 1 Where id = " + id);

                Response.Write("<script>alert('Cadastro Excluído com Sucesso!');document.location.href='reunioes.aspx';</script>");
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Não foi possível realizar a operação, favor entre em contato com o responsável pelo sistema!')</script>");
            }
            finally
            {
                dados.CloseDataSource();
            }
        }
    }

    protected void Button5_Click1(object sender, EventArgs e)
    {
        Response.Redirect("PesquisarReunioes.aspx");
    }

    protected void Button6_Click(object sender, EventArgs e)
    {
        Response.Redirect("reunioes.aspx");
    }
}