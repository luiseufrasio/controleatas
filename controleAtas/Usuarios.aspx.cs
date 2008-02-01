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

            if ("True".Equals(dr["admin"].ToString().Trim()))
            {
                chkAdmin.Checked = true;
            }
            else
            {
                chkAdmin.Checked = false;
            }
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
                    " and id not in (select idUsuario From Participantes)";

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
            dados.OpenDataSource();

            if (id == "")
            {
                string sql = "INSERT INTO usuarios (nome,login,senha,email,admin) values";
                sql = sql + "(" + Util.SQLString(txtNome.Text) + "," +
                    Util.SQLString(txtLogin.Text) + "," +
                    Util.SQLString(TxtSenha.Text) + "," +
                    Util.SQLString(txtEmail.Text) + "," +
                    Util.SQLString(chkAdmin.Checked.ToString()) + ")";
                id = dados.InsertSqlData(sql).ToString();

                Response.Write("<script>alert('Cadastro Realizado com Sucesso!');document.location.href='usuarios.aspx?cod=" + id + "';</script>");
            }
            else
            {
                string sql = "update usuarios set nome = " +
                    Util.SQLString(txtNome.Text) + ",login=" +
                    Util.SQLString(txtLogin.Text) + ",email=" +
                    Util.SQLString(txtEmail.Text) + ",admin=" +
                    Util.SQLString(chkAdmin.Checked.ToString()) +
                    " where id = " + id;
                dados.UpdateSQLData(sql);

                Response.Write("<script>alert('Cadastro Atualizado com Sucesso!')</script>");
                preencher();
            }
        }
        catch
        {
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

        try
        {
            dados.OpenDataSource();
            dados.DeleteSQLData("delete from usuarios where id =" + id);

            Response.Write("<script>alert('Cadastro Excluído com Sucesso!');document.location.href='Usuarios.aspx';</script>");
        }
        catch
        {
            Response.Write("<script>alert('Não foi possível realizar a operação, favor entre em contato com o responsável pelo sistema!')</script>");
        }
        finally
        {
            dados.CloseDataSource();
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