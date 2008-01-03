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

public partial class Calendario : System.Web.UI.UserControl
{
    private string m_css;

    public string Text
    {
        get
        {
            return EdCalendar.Text;
        }
        set
        {
            EdCalendar.Text = value;
        }
    }
    public string  Css
    {
        get
        {
            return this.m_css;

        }
        set
        {
            EdCalendar.CssClass=value;
        }


    }
    public string  left
    {
        get
        {
            return PanelCalendar.Style["left"];
        }
        set
        {
          //  EdCalendar.Style["positon"] = "absolute";
           // Calendar.Style["positon"] = "absolute";
           // BtCalendar.Style["positon"] = "absolute";
           // EdCalendar.Style["left"] = value.ToString() + "%";
           // Calendar.Style["left"] = value.ToString() + "%";
           // BtCalendar.Style["left"] = Convert.ToString(value + 58) + "%";
            PanelCalendar.Style["left"] = value.ToString() + "px";
        }


    }
    public string top
    {
        get
        {
            return PanelCalendar.Style["top"].ToString();
        }
        set
        {
            //EdCalendar.Style["positon"] = "absolute";
            //Calendar.Style["positon"] = "absolute";
            //BtCalendar.Style["positon"] = "absolute";
            //EdCalendar.Style["top"] = value.ToString()+"%";
            //Calendar.Style["top"] = Convert.ToString(value + 17) + "%";
            //BtCalendar.Style["top"] = Convert.ToString(value + 1) + "%";
            PanelCalendar.Style["top"] = value.ToString() + "px";
        }


    }

    public DateTime Date
    {
        get
        {
            return DateTime.Parse(EdCalendar.Text.Substring(3, 2) + "/" + EdCalendar.Text.Substring(0, 2) + "/" + EdCalendar.Text.Substring(6, 4));
        }


    }
    public string SqlData
    {
        get
        {
            return EdCalendar.Text.Substring(6, 4) + "-" + EdCalendar.Text.Substring(3, 2) + "-" + EdCalendar.Text.Substring(0, 2) + " ";
        }


    }
    public bool visible
    {
        set
        {
            EdCalendar.Visible = value;
            BtCalendar.Visible = value;
        }


    }
    protected void Calendar_SelectionChanged(object sender, EventArgs e)
    {

        this.Text  = completa(Calendar.SelectedDate.Day.ToString()) + "/" + completa(Calendar.SelectedDate.Month.ToString()) + "/" + completa(Calendar.SelectedDate.Year.ToString());
        Calendar.Visible = false;
        PanelCalendar.Style["z-index"] = "1";
    }
    protected void BtCalendar_Click(object sender, ImageClickEventArgs e)
    {
        PanelCalendar.Style["z-index"] = "10000";
        Calendar.Visible = true;
    }
    public string completa(string num)
    {
        if (num.Length == 1)
        {
            num = "0" + num;
        }
        return (num);
    }
    protected void Page_Load(object sender, EventArgs e)
    {   if (!Page.IsPostBack && this.Text==""){
            PanelCalendar.Style["z-index"] = "1";
            DateTime DataInicial = DateTime.Now;
            EdCalendar.Text = completa(DataInicial.Day.ToString()) + "/" + completa(DataInicial.Month.ToString()) + "/" + completa(DataInicial.Year.ToString());
    }
    }
}
