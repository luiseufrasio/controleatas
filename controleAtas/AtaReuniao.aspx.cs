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
using System.Drawing;
using System.Data.SqlClient;
using AcessoBanco;

public partial class AtaReuniao : System.Web.UI.Page
{
    String idreuniao;
    String inicio;
    Color[] color = new Color[]{
			Color.Blue,
            Color.Yellow,
			Color.Brown,
			Color.DarkBlue,
		    Color.DarkGreen,		    
			Color.Green,
			Color.Red,
			Color.Silver,
			Color.SkyBlue,
			Color.Teal,
            Color.DarkRed,
			Color.YellowGreen,
            Color.DarkOrange,
            Color.DarkOliveGreen,
            Color.LightBlue,
            Color.MediumSeaGreen,
            Color.MidnightBlue,
            Color.Navy,
            Color.AliceBlue,
			Color.AntiqueWhite,
			Color.Aqua,
			Color.Aquamarine,
			Color.Azure,
			Color.Beige,
			Color.Bisque,
			Color.Black,
			Color.BlanchedAlmond,
			Color.Brown,
			Color.BurlyWood,
			Color.CadetBlue,
			Color.Chartreuse,
			Color.Chocolate,
			Color.Coral,
			Color.Cornsilk,
			Color.Crimson,
			Color.Cyan,
			Color.DarkCyan,
			Color.DarkGoldenrod,
			Color.DarkGray,
			Color.DarkKhaki,
			Color.DarkMagenta,
			Color.DarkOliveGreen,
			Color.DarkOrange,
			Color.DarkOrchid,
			Color.DarkSalmon,
			Color.DarkSlateBlue,
			Color.DarkSlateGray,
			Color.DarkTurquoise,
			Color.DarkViolet,
			Color.DeepSkyBlue,
			Color.DimGray,
			Color.DodgerBlue,
			Color.Firebrick,
			Color.FloralWhite,
			Color.ForestGreen,
			Color.Gainsboro,
			Color.GhostWhite,
			Color.Gold,
			Color.Goldenrod,
			Color.Gray,
			Color.Green,
			Color.GreenYellow,
			Color.Honeydew,
			Color.IndianRed,
			Color.Indigo,
			Color.Ivory,
			Color.Khaki,
			Color.Lavender,
			Color.LavenderBlush,
			Color.LawnGreen,
			Color.LemonChiffon,
			Color.LightBlue,
			Color.LightCoral,
			Color.LightCyan,
			Color.LightGoldenrodYellow,
			Color.LightGray,
			Color.LightGreen,
			Color.LightSalmon,
			Color.LightSeaGreen,
			Color.LightSkyBlue,
			Color.LightSlateGray,
			Color.LightSteelBlue,
			Color.LightYellow,
			Color.Lime,
			Color.LimeGreen,
			Color.Linen,
			Color.Magenta,
			Color.Maroon,
			Color.MediumAquamarine,
			Color.MediumBlue,
			Color.MediumOrchid,
			Color.MediumPurple,
			Color.MediumSeaGreen,
			Color.MediumSlateBlue,
			Color.MediumSpringGreen,
			Color.MediumTurquoise,
			Color.MediumVioletRed,
			Color.MidnightBlue,
			Color.MintCream,
			Color.MistyRose,
			Color.Moccasin,
			Color.NavajoWhite,
			Color.OldLace,
			Color.Olive,
			Color.OliveDrab,
			Color.Orange,
			Color.OrangeRed,
			Color.Orchid,
			Color.PaleGoldenrod,
			Color.PaleGreen,
			Color.PaleTurquoise,
			Color.PaleVioletRed,
			Color.PapayaWhip,
			Color.PeachPuff,
			Color.Peru,
			Color.Plum,
			Color.PowderBlue,
			Color.Red,
			Color.RosyBrown,
			Color.RoyalBlue,
			Color.SaddleBrown,
			Color.Salmon,
			Color.SandyBrown,
			Color.SeaGreen,
			Color.SeaShell,
			Color.Sienna,
			Color.Silver,
			Color.SkyBlue,
			Color.SlateBlue,
			Color.SlateGray,
			Color.Snow,
			Color.SpringGreen,
			Color.SteelBlue,
			Color.Tan,
			Color.Teal,
			Color.Thistle,
			Color.Tomato,
			Color.Transparent,
			Color.Turquoise,
			Color.Violet,
			Color.Wheat,
			Color.White,
			Color.WhiteSmoke,
			Color.Yellow,
			Color.YellowGreen
			};

    protected void preencher()
    {
        CDataService dados = new CDataService("controleAtas");
        string sql = " select texto from atas where idreuniao = " + idreuniao;

        SqlDataReader dr = dados.SelectSqlReader(sql);
        if (dr.Read())
        {
            Editor2.Text = dr["texto"].ToString();
        }
        dr.Close();
        dados.CloseDataSource();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString.HasKeys())
        {
            idreuniao = Request["cod"].ToString();
        }
        else
        {
            idreuniao = "";
        }

        inicio = "[";
        CDataService dados = new CDataService("controleAtas");
        string sql = " SELECT nome " +
            " FROM Usuarios u " +
            " WHERE id = " + Session["id"].ToString();

        SqlDataReader dr = dados.SelectSqlReader(sql);
        if (dr.Read())
        {
            inicio += dr["nome"].ToString().Trim() + "]";
        }
        dr.Close();
        dados.CloseDataSource();
        inicio += " em (" + DateTime.Today.Day.ToString() + "/" + DateTime.Today.Month.ToString() + "/" + DateTime.Today.Year.ToString() + " " + DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString() + ":" + DateTime.Now.Second.ToString() + ")";

        if (!IsPostBack)
        {
            preencher();
        }
    }

    protected void salvar(object sender, CommandEventArgs e)
    {
        String texto = "<font color=" + color[int.Parse(Session["id"].ToString())].ToKnownColor().ToString() + ">"
            + inicio + "<br>" + Editor1.Text + "<br></font>";
        Editor2.Text += texto;
        Editor2.Text.Replace("<p>", "");
        Editor2.Text.Replace("</p>", "");
        Editor2.Text.Replace("<div>", "");
        Editor2.Text.Replace("</div>", ""); 
        
        CDataService dados = new CDataService("atas");
        SqlDataReader dr = dados.SelectSqlReader("select * from atas where idreuniao = " + idreuniao);
        string sql = "";
        if (dr.HasRows)
        {
            sql = "update atas set texto = " + Util.SQLString(Editor2.Text) + " where idreuniao = " + idreuniao;
        }
        else
        {
            sql = "insert into atas(idreuniao,texto,datahora)values(" + idreuniao + "," + Util.SQLString(Editor2.Text) + ", getdate())";
        }
        dr.Close();
        dados.InsertSqlDataVoid(sql);
    }
}