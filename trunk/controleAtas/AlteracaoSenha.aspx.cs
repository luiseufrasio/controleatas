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

    protected void preencher()
    {
        CDataService dados = new CDataService("controleAtas");
        SqlDataReader dr = dados.SelectSqlReader("Select * from usuarios where id = " + Session["id"].ToString());
        if (dr.Read())
        {
            txtLogin.Text = dr["login"].ToString().Trim();
            txtNome.Text = dr["nome"].ToString().Trim();
            txtEmail.Text = dr["email"].ToString().Trim();
        }
        dr.Close();
        dados.CloseDataSource();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            preencher();
        }
    }

    protected void Button7_Click(object sender, EventArgs e)
    {
        CDataService dados = new CDataService("controleAtas");

        // Verificar senha atual
        SqlDataReader dr = dados.SelectSqlReader("Select senha from usuarios where id = " + Session["id"].ToString());
        if (dr.Read())
        {
            if (!TxtSenha.Text.Equals(dr["senha"].ToString()))
            {
                dr.Close();
                dados.CloseDataSource();
                Response.Write("<script>alert('A Senha Atual está incorreta. Tente novamente!')</script>");
                return;
            }
        }
        dr.Close();

        // Verificar novas senhas
        if (!TxtNovaSenha.Text.Equals(TxtNovaSenha2.Text))
        {
            dados.CloseDataSource();
            Response.Write("<script>alert('A nova senha está diferente da confirmação de senha. Tente novamente!')</script>");
            return;
        }

        try
        {
            string sql = "update usuarios set senha = " + Util.SQLString(TxtNovaSenha.Text) +
                " where id = " + Session["id"].ToString();
            dados.UpdateSQLData(sql);

            Response.Write("<script>alert('Senha Atualizada com Sucesso!')</script>");
        }
        catch (Exception ex)
        {
            Response.Write("<script>alert('Erro ao tentar atualizar a senha. Contate o responsável pelo sistema!')</script>");
        }
        finally
        {
            dados.CloseDataSource();
        }

        preencher();
    }
}