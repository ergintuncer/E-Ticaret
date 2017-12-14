using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Npgsql;

public partial class Kisiler_profil : System.Web.UI.Page
{
    NpgsqlConnection tCon = new NpgsqlConnection(System.Configuration.ConfigurationManager
        .ConnectionStrings["NpgsqlConnectionStrings"].ConnectionString);

    NpgsqlCommand tCommand = new NpgsqlCommand();
    NpgsqlDataReader tDataReader;
    String tSQL;


    public void PublicExecuteNonQuery()
    {
        NpgsqlCommand tCommand = new NpgsqlCommand(tSQL, tCon);

        if (tCon.State == System.Data.ConnectionState.Open)
        {
            tCon.Close();
        }
        try
        {
            tCommand.Connection = tCon;
            tCommand.CommandType = System.Data.CommandType.Text;
            tCommand.CommandTimeout = 60000;
            tCommand.CommandText = tSQL;
            tCon.Open();

            tCommand.ExecuteNonQuery();
        }
        catch (Exception e)
        {
        }

        tCon.Close();
    }

    private String kullaniciTcNo;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["kullanici"] != null)
            {
                kullaniciTcNo = (String) Session["kullanici"];
            }
            else
            {
                Response.Redirect("/login.aspx");
            }
            verileriGoster();
            pnlProfil.Visible = false;
        }
        catch
        {
        }
    }

    private void verileriGoster()
    {
        try
        {
            if (Page.Buffer)
            {
                tSQL = " SELECT ilcead as Ilce FROM ilce_bilgi WHERE ilid =" +
                       " (Select ilid from il_bilgi where ilad = " +
                       "(Select il from kisi_kimlik JOIN kisi_bilgi on kisi_kimlik.kisiid = kisi_bilgi.kisiid " +
                       "WHERE tck = '" + Session["kullanici"] + "')); ";
                tCon.Open();
                tCommand.Connection = tCon;
                tCommand.CommandText = tSQL;
                tDataReader = tCommand.ExecuteReader();
                while (tDataReader.Read())
                {
                    drpIlce.Items.Add("" + tDataReader["Ilce"]);
                }
                tCon.Close();
            }

            if (!Page.IsPostBack)
            {
                tSQL = "SELECT ilad as Il FROM il_bilgi;" +
                       " SELECT ilcead as Ilce FROM ilce_bilgi WHERE ilid =" +
                       " (Select ilid from il_bilgi where ilad = " +
                       "(Select il from kisi_kimlik JOIN kisi_bilgi on kisi_kimlik.kisiid = kisi_bilgi.kisiid " +
                       "WHERE tck = '" + Session["kullanici"] + "')); ";
                tCon.Open();
                tCommand.Connection = tCon;
                tCommand.CommandText = tSQL;
                tDataReader = tCommand.ExecuteReader();
                while (tDataReader.Read())
                {
                    drpIl.Items.Add("" + tDataReader["Il"]);
                }
                tCon.Close();


                tSQL = "SELECT * ,to_char(kisi_kimlik.dogumtarih,'dd.mm.YYYY') AS dogumtarihi " +
                       "FROM kisi_bilgi " +
                       "LEFT OUTER JOIN kisi_bakiye on kisi_bilgi.kisiid = kisi_bakiye.kisiid  " +
                       "LEFT OUTER JOIN kisi_kimlik on kisi_bilgi.kisiid = kisi_kimlik.kisiid " +
                       "LEFT OUTER JOIN kisi_adres on kisi_bilgi.kisiid = kisi_adres.kisiid " +
                       "LEFT OUTER JOIN kisi_telefon on kisi_bilgi.kisiid = kisi_telefon.kisiid " +
                       "LEFT OUTER JOIN kisi_mail on kisi_bilgi.kisiid = kisi_mail.kisiid " +
                       "LEFT OUTER JOIN kisi_web on kisi_bilgi.kisiid = kisi_web.kisiid " +
                       "WHERE kisi_bilgi.tck = '" + Session["kullanici"] + "'";

                tCon.Open();
                tCommand.Connection = tCon;
                tCommand.CommandText = tSQL;
                tDataReader = tCommand.ExecuteReader();
                if (tDataReader.Read())
                {
                    if (tDataReader["ad"] != null)
                    {
                        lblkuladi.Text = (String)tDataReader["ad"];
                        txtAdi.Text = (String)tDataReader["ad"];
                    }
                    else
                    {
                        lblkuladi.Text = "";
                        txtAdi.Text = "";
                    }
                    if (tDataReader["soyad"] != null)
                    {
                        txtSoyadi.Text = (String)tDataReader["soyad"];
                        lblkulsoyadi.Text = (String)tDataReader["soyad"];
                    }
                    else
                    {
                        lblkulsoyadi.Text = "";
                        txtSoyadi.Text = "";
                    }
                    if (tDataReader["dogumtarihi"] != null)
                    {
                        txtDogumTarihi.Text = "" + tDataReader["dogumtarih"];
                        lblkuldogumtarihi.Text = "" + tDataReader["dogumtarihi"];
                    }
                    else
                    {
                        txtDogumTarihi.Text = "";
                        lblkuldogumtarihi.Text = "";
                    }
                    if (tDataReader["firma"] != null)
                    {
                        txtFirma.Text = (String)tDataReader["firma"];
                        lblkulFirma.Text = (String)tDataReader["firma"];
                    }
                    else
                    {
                        txtFirma.Text = "";
                        lblkulFirma.Text = "";
                    }
                    if (tDataReader["tck"] != null)
                    {
                        lblkulTcKimlikNo.Text = (String)tDataReader["tck"];
                        txtTcNo.Value = (String)tDataReader["tck"];
                    }
                    else
                    {
                        txtTcNo.Value = "";
                        lblkulTcKimlikNo.Text = "";
                    }
                    if (tDataReader["telefon"] != null)
                    {
                        txtTelefon.Text = (String)tDataReader["telefon"];
                        lblkulTelNo.Text = (String)tDataReader["telefon"];
                    }
                    else
                    {
                        txtTelefon.Text = "";
                        lblkulTelNo.Text = "";
                    }
                    if (tDataReader["mail"] != null)
                    {
                        lblkulMail.Text = (String)tDataReader["mail"];
                        txtMailadresi.Text = (String)tDataReader["mail"];
                    }
                    else
                    {
                        lblkulMail.Text = "";
                        txtMailadresi.Text = "";
                    }
                    if (tDataReader["web"] != null)
                    {
                        lblkulWebAdresi.Text = (String)tDataReader["web"];
                        txtWebAdresi.Text = (String)tDataReader["web"];
                    }
                    else
                    {
                        lblkulWebAdresi.Text = "";
                        txtWebAdresi.Text = "";
                    }
                    if (tDataReader["vergino"] != null)
                    {
                        txtVergiNo.Text = (String)tDataReader["vergino"];
                    }
                    else
                    {
                        txtVergiNo.Text = "";
                    }
                    if (tDataReader["vergidaire"] != null)
                    {
                        txtVergiDaire.Text = "" + tDataReader["vergidaire"];
                    }
                    else
                    {
                        txtVergiDaire.Text = "";
                    }
                    if (tDataReader["anneadi"] != null)
                    {
                        txtAnneAdi.Text = (String)tDataReader["anneadi"];
                    }
                    else
                    {
                        txtAnneAdi.Text = "";
                    }
                    if (tDataReader["babaadi"] != null)
                    {
                        txtBabaAdi.Text = "" + tDataReader["babaadi"];
                    }
                    else
                    {
                        txtBabaAdi.Text = "";
                    }
                    if (tDataReader["dogumyeri"] != null)
                    {
                        txtDogumYeri.Text = (String)tDataReader["dogumyeri"];
                    }
                    else
                    {
                        txtDogumYeri.Text = "";
                    }
                    if (tDataReader["din"] != null)
                    {
                        txtDin.Text = (String)tDataReader["din"];
                    }
                    else
                    {
                        txtDin.Text = "";
                    }
                    if (tDataReader["cinsiyet"] != null)
                    {
                        drpCinsiyet.SelectedValue = (String)tDataReader["cinsiyet"];
                    }
                    else
                    {
                        drpCinsiyet.SelectedIndex = 0;
                    }
                    if (tDataReader["medenihal"] != null)
                    {
                        drpMedeniHal.SelectedValue = (String)tDataReader["medenihal"];
                    }
                    else
                    {
                        drpMedeniHal.SelectedIndex = 0;
                    }
                    if (tDataReader["uyruk"] != null)
                    {
                        txtUyruk.Text = (String)tDataReader["uyruk"];
                    }
                    else
                    {
                        txtUyruk.Text = "";
                    }
                    if (tDataReader["kangrubu"] != null)
                    {
                        drpKanGrubu.SelectedValue = (String)tDataReader["kangrubu"];
                    }
                    else
                    {
                        drpKanGrubu.SelectedIndex = 0;
                    }
                    if (tDataReader["il"] != null)
                    {
                        drpIl.SelectedValue = (String)tDataReader["il"];
                    }
                    else
                    {
                        drpIl.SelectedIndex = 0;
                    }
                    if (tDataReader["ilce"] != null)
                    {
                        drpIlce.SelectedValue = (String)tDataReader["ilce"];
                    }
                    else
                    {
                        drpIlce.SelectedIndex = 0;
                    }
                    if (tDataReader["mahkoy"] != null)
                    {
                        txtMahalle.Text = (String)tDataReader["mahkoy"];
                    }
                    else
                    {
                        txtMahalle.Text = "";
                    }
                    if (tDataReader["ciltno"] != null)
                    {
                        txtCiltNo.Text = (String)tDataReader["ciltno"];
                    }
                    else
                    {
                        txtCiltNo.Text = "";
                    }
                    if (tDataReader["ailesirano"] != null)
                    {
                        txtAileSiraNo.Text = (String)tDataReader["ailesirano"];
                    }
                    else
                    {
                        txtAileSiraNo.Text = "";
                    }
                    if (tDataReader["sirano"] != null)
                    {
                        txtSiraNo.Text = (String)tDataReader["sirano"];
                    }
                    else
                    {
                        txtSiraNo.Text = "";
                    }
                    if (tDataReader["verildigiyer"] != null)
                    {
                        txtVerildigiYer.Text = (String)tDataReader["verildigiyer"];
                    }
                    else
                    {
                        txtVerildigiYer.Text = "";
                    }
                    if (tDataReader["verilisnedeni"] != null)
                    {
                        txtVerilisNedeni.Text = (String)tDataReader["verilisnedeni"];
                    }
                    else
                    {
                        txtVerilisNedeni.Text = "";
                    }
                    if (tDataReader["kayitno"] != null)
                    {
                        txtKayitNo.Text = (String)tDataReader["kayitno"];
                    }
                    else
                    {
                        txtKayitNo.Text = "";
                    }
                    if (tDataReader["verilistarih"] != null)
                    {
                        txtVerilisTarih.Text = "" + tDataReader["verilistarih"];
                    }
                    else
                    {
                        txtVerilisTarih.Text = "";
                    }
                    if (tDataReader["verenmakam"] != null)
                    {
                        txtVerenMakam.Text = (String)tDataReader["verenmakam"];
                    }
                    else
                    {
                        txtVerenMakam.Text = "";
                    }
                    if (tDataReader["gecerliliktarih"] != null)
                    {
                        txtGecerlilikTarih.Text = "" + tDataReader["gecerliliktarih"];
                    }
                    else
                    {
                        txtGecerlilikTarih.Text = "";
                    }
                    if (tDataReader["aciklama"] != null)
                    {
                        txtAciklama.Text = (String)tDataReader["aciklama"];
                    }
                    else
                    {
                        txtAciklama.Text = "";
                    }
                    if (tDataReader["adresad"] != null)
                    {
                        txtAdresAdi.Text = (String)tDataReader["adresad"];
                    }
                    else
                    {
                        txtAdresAdi.Text = "";
                    }
                    if (tDataReader["adres"] != null)
                    {
                        txtAdres.Text = (String)tDataReader["adres"];
                    }
                    else
                    {
                        txtAdres.Text = "";
                    }
                    if (tDataReader["telefonad"] != null)
                    {
                        txtTelefonAdi.Text = (String)tDataReader["telefonad"];
                    }
                    else
                    {
                        txtTelefonAdi.Text = "";
                    }
                    if (tDataReader["mailad"] != null)
                    {
                        txtMailAdi.Text = (String)tDataReader["mailad"];
                    }
                    else
                    {
                        txtMailAdi.Text = "";
                    }
                    if (tDataReader["webad"] != null)
                    {
                        txtWebAdresiAdi.Text = (String)tDataReader["webad"];
                    }
                    else
                    {
                        txtWebAdresiAdi.Text = "";
                    }
                }
                tCon.Close();
            }
        }
        catch (Exception e)
        {
        }
    }

    protected void btnDuzenle_Click(object sender, EventArgs e)
    {
        pnlProfil.Visible = true;
        successalert.Visible = false;
    }

    protected void btnKaydet_Click(object sender, EventArgs e)
    {
        tSQL = "UPDATE kisi_bilgi SET " +
               "ad = '" + txtAdi.Text.Trim() + "'," +
               "soyad ='" + txtSoyadi.Text.Trim() + "' , " +
               "firma= '" + txtFirma.Text.Trim() + "', " +
               "tck = '" + txtTcNo.Value.Trim() + "', " +
               "vergino='" + txtVergiNo.Text.Trim() + "', " +
               "vergidaire='" + txtVergiDaire.Text.Trim() + "' " +
               "WHERE tck='" + kullaniciTcNo + "' ; " +
               "UPDATE kisi_kimlik SET " +
               "babaadi='" + txtBabaAdi.Text.Trim() + "'," +
               "dogumtarih='" + txtDogumTarihi.Text.Trim() + "', " +
               "anneadi='" + txtAnneAdi.Text.Trim() + "', " +
               "dogumyeri='" + txtDogumYeri.Text.Trim() + "', " +
               "medenihal='" + drpMedeniHal.SelectedValue + "', " +
               "din='" + txtDin.Text.Trim() + "', " +
               "cinsiyet='" + drpCinsiyet.SelectedValue + "', " +
               "uyruk='" + txtUyruk.Text.Trim() + "', " +
               "kangrubu='" + drpKanGrubu.SelectedValue + "', " +
               "il='" + drpIl.SelectedValue + "', " +
               "ilce='" + drpIlce.SelectedValue + "', " +
               "mahkoy='" + txtMahalle.Text.Trim() + "', " +
               "ciltno='" + txtCiltNo.Text.Trim() + "'," +
               "ailesirano='" + txtAileSiraNo.Text.Trim() + "', " +
               "sirano='" + txtSiraNo.Text.Trim() + "', " +
               "verildigiyer='" + txtVergiDaire.Text.Trim() + "', " +
               "verilisnedeni='" + txtVerilisNedeni.Text.Trim() + "', " +
               "kayitno='" + txtKayitNo.Text.Trim() + "', " +
               "verilistarih='" + txtVerilisTarih.Text.Trim() + "', " +
               "verenmakam='" + txtVerenMakam.Text.Trim() + "', " +
               "aciklama='" + txtAciklama.Text.Trim() + "', " +
               "gecerliliktarih='" + txtGecerlilikTarih.Text.Trim() + "', tarihsaat=CURRENT_TIMESTAMP" +
               " WHERE kisiid=(SELECT kisiid FROM kisi_bilgi WHERE tck='" + kullaniciTcNo + "'); " +
               "UPDATE kisi_adres SET adresad='" + txtAdresAdi.Text.Trim() + "', adres='" + txtAdres.Text.Trim() +
               "' WHERE kisiid=(SELECT kisiid FROM kisi_bilgi WHERE tck='" + kullaniciTcNo + "'); " +
               "UPDATE kisi_telefon SET telefonad='" + txtTelefonAdi.Text.Trim() + "', telefon='" +
               txtTelefon.Text.Trim() +
               "' WHERE kisiid=(SELECT kisiid FROM kisi_bilgi WHERE tck='" + kullaniciTcNo + "'); " +
               "UPDATE kisi_mail SET mailad='" + txtMailAdi.Text.Trim() + "', mail='" + txtMailadresi.Text.Trim() +
               "' WHERE kisiid=(SELECT kisiid FROM kisi_bilgi WHERE tck='" + kullaniciTcNo + "'); " +
               "UPDATE kisi_web  SET webad='" + txtWebAdresiAdi.Text.Trim() + "', web='" + txtWebAdresi.Text.Trim() +
               "' WHERE kisiid=(SELECT kisiid FROM kisi_bilgi WHERE tck='" + kullaniciTcNo + "'); ";

        PublicExecuteNonQuery();
        pnlProfil.Visible = false;
        verileriGoster();
        successalert.Visible = true;
        //Response.Redirect("~/Kisiler/Profil.aspx");
    }

    protected void drpIl_OnTextChanged(object sender, EventArgs e)
    {
        pnlProfil.Visible = true;
        drpIlce.Items.Clear();
        tSQL = "SELECT * FROM ilce_bilgi WHERE ilid=(SELECT ilid FROM il_bilgi WHERE ilad='" + drpIl.SelectedValue +
               "')";
        tCon.Open();
        tCommand.Connection = tCon;
        tCommand.CommandText = tSQL;
        tDataReader = tCommand.ExecuteReader();
        while (tDataReader.Read())
        {
            drpIlce.Items.Add("" + tDataReader["ilcead"]);
        }
        tCon.Close();
    }
}