using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using System.Data;

public partial class admin : System.Web.UI.Page
{
    string ID;
    string islem;
    int id2;
    OleDbConnection con =
        new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0; DATA Source=" +
                            HttpContext.Current.Server.MapPath("sosyal.mdb"));
    protected void Page_Load(object sender, EventArgs e)
    {
        try {
            // sesion kontolü
            if (Session["kullanici"] != null)
            {
            }
            else
            {
                Response.Redirect("login.aspx");
            }



        //postback
        if (!Page.IsPostBack)
        {AnalizPanel.Visible = false;
       

        }

        }
        catch
        {
            //hata yazdırılabilir
        }

    }

    protected void Profil_OnClick(object sender, EventArgs e)
    {
    }

    protected void Profil_Cikis_OnClick(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect("login.aspx");
        }
        catch
        {

        }
    }

    protected void Analiz_OnClick(object sender, EventArgs e)
    {
        try { 
        AnalizPanel.Visible = true;
        }
        catch
        {

        }
    }

    protected void KullaniciAyarlari_OnClick(object sender, EventArgs e)
    {
       
    }

    protected void EtkinlikAyarlari_OnClick(object sender, EventArgs e)
    {
       
    }

    protected void PaylasimAyarlari_OnClick(object sender, EventArgs e)
    {
    }
    protected void PaylasimiSil_OnClick(object sender, EventArgs e)
    {
    }


}