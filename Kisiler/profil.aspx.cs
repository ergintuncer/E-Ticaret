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
            txtDogumTarihi.Attributes["max"] = DateTime.Now.ToString("yyyy-MM-dd");
            txtVerilisTarih.Attributes["max"] = DateTime.Now.ToString("yyyy-MM-dd");
            txtGecerlilikTarih.Attributes["min"] = DateTime.Now.ToString("yyyy-MM-dd");
            if (Session["kullanici"] != null)
            {
                kullaniciTcNo = "" + Session["kullanici"];
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
                        lblkuladi.Text = "" + tDataReader["ad"];
                        txtAdi.Text = "" + tDataReader["ad"];
                    }
                    else
                    {
                        lblkuladi.Text = "";
                        txtAdi.Text = "";
                    }
                    if (tDataReader["soyad"] != null)
                    {
                        txtSoyadi.Text = "" + tDataReader["soyad"];
                        lblkulsoyadi.Text = "" + tDataReader["soyad"];
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
                        txtFirma.Text = "" + tDataReader["firma"];
                        lblkulFirma.Text = "" + tDataReader["firma"];
                    }
                    else
                    {
                        txtFirma.Text = "";
                        lblkulFirma.Text = "";
                    }
                    if (tDataReader["tck"] != null)
                    {
                        lblkulTcKimlikNo.Text = "" + tDataReader["tck"];
                        txtTcNo.Value = "" + tDataReader["tck"];
                    }
                    else
                    {
                        txtTcNo.Value = "";
                        lblkulTcKimlikNo.Text = "";
                    }
                    if (tDataReader["telefon"] != null)
                    {
                        txtTelefon.Text = "" + tDataReader["telefon"];
                        lblkulTelNo.Text = "" + tDataReader["telefon"];
                    }
                    else
                    {
                        txtTelefon.Text = "";
                        lblkulTelNo.Text = "";
                    }
                    if (tDataReader["mail"] != null)
                    {
                        lblkulMail.Text = "" + tDataReader["mail"];
                        txtMailadresi.Text = "" + tDataReader["mail"];
                    }
                    else
                    {
                        lblkulMail.Text = "";
                        txtMailadresi.Text = "";
                    }
                    if (tDataReader["web"] != null)
                    {
                        lblkulWebAdresi.Text = "" + tDataReader["web"];
                        txtWebAdresi.Text = "" + tDataReader["web"];
                    }
                    else
                    {
                        lblkulWebAdresi.Text = "";
                        txtWebAdresi.Text = "";
                    }
                    if (tDataReader["vergino"] != null)
                    {
                        txtVergiNo.Text = "" + tDataReader["vergino"];
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
                        txtAnneAdi.Text = "" + tDataReader["anneadi"];
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
                        txtDogumYeri.Text = "" + tDataReader["dogumyeri"];
                    }
                    else
                    {
                        txtDogumYeri.Text = "";
                    }
                    if (tDataReader["din"] != null)
                    {
                        txtDin.Text = "" + tDataReader["din"];
                    }
                    else
                    {
                        txtDin.Text = "";
                    }
                    if (tDataReader["cinsiyet"] != null)
                    {
                        drpCinsiyet.SelectedValue = "" + tDataReader["cinsiyet"];
                    }
                    else
                    {
                        drpCinsiyet.SelectedIndex = 0;
                    }
                    if (tDataReader["medenihal"] != null)
                    {
                        drpMedeniHal.SelectedValue = "" + tDataReader["medenihal"];
                    }
                    else
                    {
                        drpMedeniHal.SelectedIndex = 0;
                    }
                    if (tDataReader["uyruk"] != null)
                    {
                        txtUyruk.Text = "" + tDataReader["uyruk"];
                    }
                    else
                    {
                        txtUyruk.Text = "";
                    }
                    if (tDataReader["kangrubu"] != null)
                    {
                        drpKanGrubu.SelectedValue = "" + tDataReader["kangrubu"];
                    }
                    else
                    {
                        drpKanGrubu.SelectedIndex = 0;
                    }
                    if (tDataReader["il"] != null)
                    {
                        drpIl.SelectedValue = "" + tDataReader["il"];
                    }
                    else
                    {
                        drpIl.SelectedIndex = 0;
                    }
                    if (tDataReader["ilce"] != null)
                    {
                        drpIlce.SelectedValue = "" + tDataReader["ilce"];
                    }
                    else
                    {
                        drpIlce.SelectedIndex = 0;
                    }
                    if (tDataReader["mahkoy"] != null)
                    {
                        txtMahalle.Text = "" + tDataReader["mahkoy"];
                    }
                    else
                    {
                        txtMahalle.Text = "";
                    }
                    if (tDataReader["ciltno"] != null)
                    {
                        txtCiltNo.Text = "" + tDataReader["ciltno"];
                    }
                    else
                    {
                        txtCiltNo.Text = "";
                    }
                    if (tDataReader["ailesirano"] != null)
                    {
                        txtAileSiraNo.Text = "" + tDataReader["ailesirano"];
                    }
                    else
                    {
                        txtAileSiraNo.Text = "";
                    }
                    if (tDataReader["sirano"] != null)
                    {
                        txtSiraNo.Text = "" + tDataReader["sirano"];
                    }
                    else
                    {
                        txtSiraNo.Text = "";
                    }
                    if (tDataReader["verildigiyer"] != null)
                    {
                        txtVerildigiYer.Text = "" + tDataReader["verildigiyer"];
                    }
                    else
                    {
                        txtVerildigiYer.Text = "";
                    }
                    if (tDataReader["verilisnedeni"] != null)
                    {
                        txtVerilisNedeni.Text = "" + tDataReader["verilisnedeni"];
                    }
                    else
                    {
                        txtVerilisNedeni.Text = "";
                    }
                    if (tDataReader["kayitno"] != null)
                    {
                        txtKayitNo.Text = "" + tDataReader["kayitno"];
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
                        txtVerenMakam.Text = "" + tDataReader["verenmakam"];
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
                        txtAciklama.Text = "" + tDataReader["aciklama"];
                    }
                    else
                    {
                        txtAciklama.Text = "";
                    }
                    if (tDataReader["adresad"] != null)
                    {
                        txtAdresAdi.Text = "" + tDataReader["adresad"];
                    }
                    else
                    {
                        txtAdresAdi.Text = "";
                    }
                    if (tDataReader["adres"] != null)
                    {
                        txtAdres.Text = "" + tDataReader["adres"];
                    }
                    else
                    {
                        txtAdres.Text = "";
                    }
                    if (tDataReader["telefonad"] != null)
                    {
                        txtTelefonAdi.Text = "" + tDataReader["telefonad"];
                    }
                    else
                    {
                        txtTelefonAdi.Text = "";
                    }
                    if (tDataReader["mailad"] != null)
                    {
                        txtMailAdi.Text = "" + tDataReader["mailad"];
                    }
                    else
                    {
                        txtMailAdi.Text = "";
                    }
                    if (tDataReader["webad"] != null)
                    {
                        txtWebAdresiAdi.Text = "" + tDataReader["webad"];
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
               "ad = '" + txtAdi.Text.Trim().Replace("'", "") + "'," +
               "soyad ='" + txtSoyadi.Text.Trim().Replace("'", "") + "' , " +
               "firma= '" + txtFirma.Text.Trim().Replace("'", "") + "', " +
               "tck = '" + txtTcNo.Value.Trim().Replace("'", "") + "', " +
               "vergino='" + txtVergiNo.Text.Trim().Replace("'", "") + "', " +
               "vergidaire='" + txtVergiDaire.Text.Trim().Replace("'", "") + "' " +
               "WHERE tck='" + kullaniciTcNo + "' ; " +
               "UPDATE kisi_kimlik SET " +
               "babaadi='" + txtBabaAdi.Text.Trim().Replace("'", "") + "'," +
               "dogumtarih='" + txtDogumTarihi.Text.Trim().Replace("'", "") + "', " +
               "anneadi='" + txtAnneAdi.Text.Trim().Replace("'", "") + "', " +
               "dogumyeri='" + txtDogumYeri.Text.Trim().Replace("'", "") + "', " +
               "medenihal='" + drpMedeniHal.SelectedValue + "', " +
               "din='" + txtDin.Text.Trim().Replace("'", "") + "', " +
               "cinsiyet='" + drpCinsiyet.SelectedValue + "', " +
               "uyruk='" + txtUyruk.Text.Trim().Replace("'", "") + "', " +
               "kangrubu='" + drpKanGrubu.SelectedValue + "', " +
               "il='" + drpIl.SelectedValue + "', " +
               "ilce='" + drpIlce.SelectedValue + "', " +
               "mahkoy='" + txtMahalle.Text.Trim().Replace("'", "") + "', " +
               "ciltno='" + txtCiltNo.Text.Trim().Replace("'", "") + "'," +
               "ailesirano='" + txtAileSiraNo.Text.Trim().Replace("'", "") + "', " +
               "sirano='" + txtSiraNo.Text.Trim().Replace("'", "") + "', " +
               "verildigiyer='" + txtVergiDaire.Text.Trim().Replace("'", "") + "', " +
               "verilisnedeni='" + txtVerilisNedeni.Text.Trim().Replace("'", "") + "', " +
               "kayitno='" + txtKayitNo.Text.Trim().Replace("'", "") + "', " +
               "verilistarih='" + txtVerilisTarih.Text.Trim().Replace("'", "") + "', " +
               "verenmakam='" + txtVerenMakam.Text.Trim().Replace("'", "") + "', " +
               "aciklama='" + txtAciklama.Text.Trim().Replace("'", "") + "', " +
               "gecerliliktarih='" + txtGecerlilikTarih.Text.Trim().Replace("'", "") +
               "', tarihsaat=CURRENT_TIMESTAMP" +
               " WHERE kisiid=(SELECT kisiid FROM kisi_bilgi WHERE tck='" + kullaniciTcNo + "'); " +
               "UPDATE kisi_adres SET adresad='" + txtAdresAdi.Text.Trim().Replace("'", "") + "', adres='" +
               txtAdres.Text.Trim().Replace("'", "") +
               "' WHERE kisiid=(SELECT kisiid FROM kisi_bilgi WHERE tck='" + kullaniciTcNo + "'); " +
               "UPDATE kisi_telefon SET telefonad='" + txtTelefonAdi.Text.Trim().Replace("'", "") + "', telefon='" +
               txtTelefon.Text.Trim().Replace("'", "") +
               "' WHERE kisiid=(SELECT kisiid FROM kisi_bilgi WHERE tck='" + kullaniciTcNo + "'); " +
               "UPDATE kisi_mail SET mailad='" + txtMailAdi.Text.Trim().Replace("'", "") + "', mail='" +
               txtMailadresi.Text.Trim().Replace("'", "") +
               "' WHERE kisiid=(SELECT kisiid FROM kisi_bilgi WHERE tck='" + kullaniciTcNo + "'); " +
               "UPDATE kisi_web  SET webad='" + txtWebAdresiAdi.Text.Trim().Replace("'", "") + "', web='" +
               txtWebAdresi.Text.Trim().Replace("'", "") +
               "' WHERE kisiid=(SELECT kisiid FROM kisi_bilgi WHERE tck='" + kullaniciTcNo + "'); ";

        PublicExecuteNonQuery();
        pnlProfil.Visible = false;
        verileriGoster();
        successalert.Visible = true;
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