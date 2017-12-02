using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Npgsql;
public partial class AnaSayfaMasterPage : System.Web.UI.MasterPage
{

    protected void Profil_OnClick(object sender, EventArgs e)
    {
    }


    protected void btnProfil_Onclick(object sender, EventArgs e)
    {
        Response.Redirect("/Kullanici/profil.aspx");
    }

    protected void btnDavaTuru_OnClick(object sender, EventArgs e)
    {
        Response.Redirect("/Kullanici/dava-turu.aspx");
    }

    protected void btnKisiler_Onclick(object sender, EventArgs e)
    {
        Response.Redirect("/Kullanici/kisiler.aspx");
    }
    protected void Yonetici_OnClick(object sender, EventArgs e)
    {
    }


    protected void Profil_Cikis_OnClick(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect("/login.aspx");
        }
        catch
        {

        }
    }
    NpgsqlConnection tCon = new NpgsqlConnection(System.Configuration.ConfigurationManager
        .ConnectionStrings["NpgsqlConnectionStrings"].ConnectionString);

    NpgsqlCommand tCommand = new NpgsqlCommand();
    NpgsqlDataReader tDataReader;
    String tSQL, kullaniciTcNo;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["kullanici"] != null)
            {
                kullaniciTcNo = (String)Session["kullanici"];
            }
            else
            {
                //kullaniciTcNo = "123";
                Response.Redirect("/login.aspx");
            }

           
            if (!IsPostBack)
            {
               
            }
            tSQL = "SELECT ad,soyad " +
                   "FROM kisi_bilgi " +
                   "WHERE kisi_bilgi.tck = '" + Session["kullanici"] + "'";
            
            tCon.Open();
            tCommand.Connection = tCon;
            tCommand.CommandText = tSQL;
            tDataReader = tCommand.ExecuteReader();
            if (tDataReader.Read())
            {
                lblAdminAdi.Text = (String)tDataReader["ad"] +" "+ (String)tDataReader["soyad"];
            }
            tCon.Close();
        }
        catch
        {
        }
    }

    protected void btnBankaHesapTur_OnClick(object sender, EventArgs e)
    {
        Response.Redirect("/Kullanici/banka-hesap-tur.aspx");

    }

    protected void btnBankaHesap_OnClick(object sender, EventArgs e)
    {
        Response.Redirect("/Kullanici/banka-hesap.aspx");

    }

    protected void btnBankaBilgi_OnClick(object sender, EventArgs e)
    {
        Response.Redirect("/Kullanici/bankabilgi.aspx");
    }

    protected void btnDava_OnClick(object sender, EventArgs e)
    {
        Response.Redirect("/Kullanici/dava.aspx");

    }
}
