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

    protected void preencher()
    {
        CDataService dados = new CDataService("controleAtas");
        SqlDataReader dr = dados.SelectSqlReader("Select * from usuarios where id = " + id);
        if (dr.Read())
        {
            txtLogin.Text = dr["login"].ToString().Trim();
            txtNome.Text = dr["nome"].ToString().Trim();
            TxtSenha.Text = dr["senha"].ToString().Trim();
            txtEmail.Text = dr["email"].ToString().Trim();
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
            if (id != "")
            {
                TxtSenha.Enabled = false;
                RequiredFieldValidator4.Enabled = false;
                preencher();
                CDataService dados = new CDataService("controleAtas");

                string sql =
                    " Select * From Usuarios Where id = " + id +
                    " and id not in ((select idUsuario From Participantes) " +
                    " union (select idSolicitante From Atas)) ";

                if (dados.SelectSqlReader(sql).Read())
                {
                    BtExcluir.Enabled = true;
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
                string sql = "INSERT INTO usuarios (nome,login,senha,email,admin) values";
                sql = sql + "(" + Util.SQLString(txtNome.Text) + "," +
                    Util.SQLString(txtLogin.Text) + "," +
                    Util.SQLString(TxtSenha.Text) + "," +
                    Util.SQLString(txtEmail.Text) + "," +
                    Util.SQLString(chkAdmin.Checked.ToString()) + ")";
                id = dados.InsertSqlData(sql).ToString();

                dados.committransacao();
                Response.Write("<script>alert('Cadastro Realizado com Sucesso!');document.location.href='usuarios.aspx?cod=" + id + "';</script>");
            }
            else
            {
                string sql = "update usuarios set nome = " +
                    Util.SQLString(txtNome.Text) + ",idcasa = " +
                    Util.SQLString(listCasas.SelectedValue) + ",idnivel = " +
                    Util.SQLString(listNiveis.SelectedValue) + ",login=" +
                    Util.SQLString(txtLogin.Text) + ",email=" +
                    Util.SQLString(txtEmail.Text) +
                    " where id = " + id;
                dados.UpdateSQLData(sql);
                sql = "delete from usuariosdepartamentos where idusuario = " + id;
                dados.DeleteSQLData(sql);
                // departamentos
                for (int i = 0; i <= CbDeptos.Items.Count - 1; i++)
                //  foreach(ListItem  cb in CbDeptos )
                {
                    ListItem cb = CbDeptos.Items[i];
                    if (cb.Selected)
                    {
                        sql = "INSERT INTO usuariosdepartamentos(idusuario,iddepartamento) values";
                        sql = sql + "(" + id + "," + Util.SQLString(cb.Value.ToString()) + ")";
                        dados.InsertSqlData(sql);
                    }
                }

                dados.committransacao();
                Response.Write("<script>alert('Cadastro Atualizado com Sucesso!')</script>");

                preencher();
            }
        }
        catch
        {
            dados.rollbacktransacao();
            Response.Write("<script>alert('Não foi possível realizar a operação, favor entre em contato com o responsável pelo sistema!')</script>");
        }
    }

    protected void BtExcluir_Click(object sender, EventArgs e)
    {
        CDataService dados = new CDataService("controleAtas");

        try
        {
            dados.OpenDataSourceTransaction();
            dados.DeleteSQLData("delete from usuariosdepartamentos where idusuario =" + id);
            dados.DeleteSQLData("delete from usuarios where id =" + id);

            dados.committransacao();
            Response.Write("<script>alert('Cadastro Excluído com Sucesso!');document.location.href='Usuarios.aspx';</script>");
        }
        catch
        {
            dados.rollbacktransacao();
            Response.Write("<script>alert('Não foi possível realizar a operação, favor entre em contato com o responsável pelo sistema!')</script>");
        }
    }

    protected void Button5_Click1(object sender, EventArgs e)
    {
        Response.Redirect("PesquisarUsuarios.aspx");
    }

    protected void Button6_Click(object sender, EventArgs e)
    {
        Response.Redirect("usuarios.aspx");
    }
}