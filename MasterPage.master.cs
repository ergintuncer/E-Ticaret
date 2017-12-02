using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using Npgsql;
public partial class MasterPage : System.Web.UI.MasterPage
{
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
                lblAdminAdi.Text ="Admin<br/>"+ (String)tDataReader["ad"] + " " + (String)tDataReader["soyad"];

            }


            tCon.Close();
        }
        catch
        {
        }
    }

    protected void btnBlokeliKullanici_Onclick(object sender, EventArgs e)
    {
        Response.Redirect("/Admin/blokelikullanici.aspx");
    }

    protected void btnKisiler_OnClick(object sender, EventArgs e)
    {
        Response.Redirect("/Admin/kisiler.aspx");
    }

    protected void btnBaro_OnClick(object sender, EventArgs e)
    {
        Response.Redirect("/Admin/baro.aspx");
    }

    protected void btnAdliye_Onclick(object sender, EventArgs e)
    {
        Response.Redirect("/Admin/adliye.aspx");
    }
    protected void btnMahkeme_Onclick(object sender, EventArgs e)
    {
        Response.Redirect("/Admin/mahkeme.aspx");

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

    
}