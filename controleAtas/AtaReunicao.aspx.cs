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
using System.Data;
using System.Data.SqlClient;
using AcessoBanco;
using System.Text;

public partial class AtaReunicao : System.Web.UI.Page
{
    String idreuniao;
    Color[] color = new Color[]{
			Color.Blue,
			Color.Brown,
			Color.DarkBlue,
		    Color.DarkGreen,
		    Color.DarkRed,
			Color.Green,
			Color.Red,
			Color.Silver,
			Color.SkyBlue,
			Color.Teal,
			Color.Yellow,
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

    protected void Page_Load(object sender, EventArgs e)
    {
        //BtVisualiza.Attributes.Add("onclick", "desabilita()");
       // BtGrava.Attributes.Add("onclick", "desabilita()");
            
        Session["id"] = "5";
        idreuniao = Request["id"].ToString();
        Session["usuario"] = "Thaigo Barcelos";
        //Response.Write(DateTime.Now.Hour.ToString());
        //Response.End();
        string inicio = "(" + Session["usuario"].ToString() + ")" + "(" + DateTime.Today.Day.ToString() + "/" + DateTime.Today.Month.ToString() + "/" + DateTime.Today.Year.ToString() + " " + DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString() + ":" + DateTime.Now.Second.ToString() + ")<br>";
       // Response.Write(inicio);
        //Response.End();
        TxtInsere.Attributes.Add("inicio", inicio);
        if (!IsPostBack)
        {
            insere();
        }
    }
    protected void BtGrava_Click(object sender, EventArgs e)
    {
        String texto = TxtInsere.Attributes["inicio"].ToString().Trim().Normalize() + TxtInsere.Text;
        CDataService dados = new CDataService("atas");
        String teste="select * from atas where idreuniao = " + idreuniao;
        SqlDataReader dr = dados.SelectSqlReader("select * from atas where idreuniao = " + idreuniao);
        String sql = "";
        if (dr.HasRows)
        {
            sql = "update atas set texto = texto+" + Util.SQLString(texto) + " where idreuniao = " + idreuniao;
        }
        else
        {
            sql = "insert into atas(idreuniao,texto,datahora)values(" +idreuniao +","+ Util.SQLString(texto) +", getdate())";
        }
        dr.Close();
        dados.InsertSqlDataVoid(sql);
        visualiza();
        
    }
    public void visualiza()
    {
        TxtInsere.Visible = true;
        TxtInsere.Enabled = false;
        BtInsere.Enabled = true;
        BtGrava.Enabled = false;
        BtVisualiza.Enabled = false;
        CDataService dados = new CDataService("atas");
        SqlDataReader dr = dados.SelectSqlReader("select texto from atas where idreuniao="+idreuniao);
        if(dr.Read())
        {
            TxtInsere.Text="<font color = '" + color[int.Parse(Session["id"].ToString())].ToKnownColor().ToString() + "'>"+dr[0].ToString();
        }
        else
        {
            TxtInsere.Text="";
        }

        pagina.Attributes.Add("onload", "RTFEdit_TxtInsere.document.designMode='off';");

    }
    public void insere()
    {
        
        TxtInsere.Visible = true;
        TxtInsere.Enabled = true;
        BtInsere.Enabled = false;
        BtGrava.Enabled = true;
        BtVisualiza.Enabled = true;
        TxtInsere.Text = "";

        pagina.Attributes.Add("onload", "RTFEdit_TxtInsere.document.designMode='on';");
        
    }
    protected void BtInsere_Click(object sender, EventArgs e)
    {
        insere();
    }
    protected void BtVisualiza_Click(object sender, EventArgs e)
    {
        visualiza();
    }
}
