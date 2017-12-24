using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Npgsql;

public partial class Kullanici_Profil : System.Web.UI.Page
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
            dangeralert.Visible = true;
        }

        tCon.Close();
    }

    // Select sorugular için İteger
    public int PublicExecuteScalarInteger()
    {
        NpgsqlCommand tCommand = new NpgsqlCommand(tSQL, tCon);
        int tInteger = 0;
        if (tCon.State == System.Data.ConnectionState.Open)
        {
            tCon.Close();
        }
        tCon.Open();
        tCommand.CommandType = System.Data.CommandType.Text;
        tCommand.CommandTimeout = 60000;
        tCommand.CommandText = tSQL;
        if (tCommand.ExecuteScalar() != DBNull.Value)
        {
            tInteger = Convert.ToInt32(tCommand.ExecuteScalar());
        }
        tCon.Close();
        return tInteger;
    }

    private String kullaniciTcNo;
    private int yuzde = 1;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            txtDogumTarihi.Attributes["max"] = DateTime.Now.ToString("yyyy-MM-dd");
            txtVerilisTarih.Attributes["max"] = DateTime.Now.ToString("yyyy-MM-dd");
            txtGecerlilikTarih.Attributes["min"] = DateTime.Now.ToString("yyyy-MM-dd");
            if (Session["kullanici"].ToString().Length > 1)
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

                try
                {
                    tSQL = "SELECT * ,to_char(kisi_kimlik.dogumtarih,'dd.mm.YYYY') AS dogumtarihi , kisi_bilgi.aciklama AS kisiaciklama " +
                           "FROM kisi_bilgi " +
                           "LEFT OUTER JOIN kisi_bakiye on kisi_bilgi.kisiid = kisi_bakiye.kisiid  " +
                           "LEFT OUTER JOIN kisi_kimlik on kisi_bilgi.kisiid = kisi_kimlik.kisiid " +
                           "LEFT OUTER JOIN kisi_adres on kisi_bilgi.kisiid = kisi_adres.kisiid " +
                           "LEFT OUTER JOIN kisi_telefon on kisi_bilgi.kisiid = kisi_telefon.kisiid " +
                           "LEFT OUTER JOIN kisi_mail on kisi_bilgi.kisiid = kisi_mail.kisiid " +
                           "LEFT OUTER JOIN kisi_web on kisi_bilgi.kisiid = kisi_web.kisiid " +
                           "WHERE kisi_bilgi.tck = '" + Session["kullanici"] + "';";

                    tCon.Open();
                    tCommand.Connection = tCon;
                    tCommand.CommandText = tSQL;
                    tDataReader = tCommand.ExecuteReader();
                    if (tDataReader.Read())
                    {
                        if (tDataReader["ad"].ToString().Length > 1)
                        {
                            lblkuladi.Text = "" + tDataReader["ad"];
                            txtAdi.Text = "" + tDataReader["ad"];
                            yuzde++;
                        }
                        else
                        {
                            lblkuladi.Text = "";
                            txtAdi.Text = "";
                        }
                        if (tDataReader["soyad"].ToString().Length > 1)
                        {
                            txtSoyadi.Text = "" + tDataReader["soyad"];
                            lblkulsoyadi.Text = "" + tDataReader["soyad"];
                            yuzde++;
                        }
                        else
                        {
                            lblkulsoyadi.Text = "";
                            txtSoyadi.Text = "";
                        }
                        if (tDataReader["dogumtarihi"].ToString().Length > 1)
                        {
                            txtDogumTarihi.Text = "" + tDataReader["dogumtarih"];
                            lblkuldogumtarihi.Text = "" + tDataReader["dogumtarihi"];
                            yuzde++;
                        }
                        else
                        {
                            txtDogumTarihi.Text = "";
                            lblkuldogumtarihi.Text = "";
                        }
                        if (tDataReader["firma"].ToString().Length > 1)
                        {
                            txtFirma.Text = "" + tDataReader["firma"];
                            lblkulFirma.Text = "" + tDataReader["firma"];
                            yuzde++;
                        }
                        else
                        {
                            txtFirma.Text = "";
                            lblkulFirma.Text = "";
                        }
                        if (tDataReader["tck"].ToString().Length > 1)
                        {
                            lblkulTcKimlikNo.Text = "" + tDataReader["tck"];
                            txtTck.Text = "" + tDataReader["tck"];
                            yuzde++;
                        }
                        else
                        {
                            txtTck.Text = "";
                            lblkulTcKimlikNo.Text = "";
                        }
                        if (tDataReader["telefon"].ToString().Length > 1)
                        {
                            txtTelefon.Text = "" + tDataReader["telefon"];
                            lblkulTelNo.Text = "" + tDataReader["telefon"];
                            yuzde++;
                        }
                        else
                        {
                            txtTelefon.Text = "";
                            lblkulTelNo.Text = "";
                        }
                        if (tDataReader["mail"].ToString().Length > 1)
                        {
                            lblkulMail.Text = "" + tDataReader["mail"];
                            txtMailadresi.Text = "" + tDataReader["mail"];
                            yuzde++;
                        }
                        else
                        {
                            lblkulMail.Text = "";
                            txtMailadresi.Text = "";
                        }
                        if (tDataReader["web"].ToString().Length > 1)
                        {
                            lblkulWebAdresi.Text = "" + tDataReader["web"];
                            txtWebAdresi.Text = "" + tDataReader["web"];
                            yuzde++;
                        }
                        else
                        {
                            lblkulWebAdresi.Text = "";
                            txtWebAdresi.Text = "";
                        }
                        if (tDataReader["vergino"].ToString().Length > 1)
                        {
                            txtVergiNo.Text = "" + tDataReader["vergino"];
                            yuzde++;
                        }
                        else
                        {
                            txtVergiNo.Text = "";
                        }
                        if (tDataReader["vergidaire"].ToString().Length > 1)
                        {
                            txtVergiDaire.Text = "" + tDataReader["vergidaire"];
                            yuzde++;
                        }
                        else
                        {
                            txtVergiDaire.Text = "";
                        }
                        if (tDataReader["anneadi"].ToString().Length > 1)
                        {
                            txtAnneAdi.Text = "" + tDataReader["anneadi"];
                            yuzde++;
                        }
                        else
                        {
                            txtAnneAdi.Text = "";
                        }
                        if (tDataReader["babaadi"].ToString().Length > 1)
                        {
                            txtBabaAdi.Text = "" + tDataReader["babaadi"];
                            yuzde++;
                        }
                        else
                        {
                            txtBabaAdi.Text = "";
                        }
                        if (tDataReader["dogumyeri"].ToString().Length > 1)
                        {
                            txtDogumYeri.Text = "" + tDataReader["dogumyeri"];
                            yuzde++;
                        }
                        else
                        {
                            txtDogumYeri.Text = "";
                        }
                        if (tDataReader["din"].ToString().Length > 1)
                        {
                            txtDin.Text = "" + tDataReader["din"];
                            yuzde++;
                        }
                        else
                        {
                            txtDin.Text = "";
                        }
                        if (tDataReader["cinsiyet"].ToString().Length > 1)
                        {
                            drpCinsiyet.SelectedValue = "" + tDataReader["cinsiyet"];
                            yuzde++;
                        }
                        else
                        {
                            drpCinsiyet.SelectedIndex = 0;
                        }
                        if (tDataReader["medenihal"].ToString().Length > 1)
                        {
                            drpMedeniHal.SelectedValue = "" + tDataReader["medenihal"];
                            yuzde++;
                        }
                        else
                        {
                            drpMedeniHal.SelectedIndex = 0;
                        }
                        if (tDataReader["uyruk"].ToString().Length > 1)
                        {
                            txtUyruk.Text = "" + tDataReader["uyruk"];
                            yuzde++;
                        }
                        else
                        {
                            txtUyruk.Text = "";
                        }
                        if (tDataReader["kangrubu"].ToString().Length > 1)
                        {
                            drpKanGrubu.SelectedValue = "" + tDataReader["kangrubu"];
                            yuzde++;
                        }
                        else
                        {
                            drpKanGrubu.SelectedIndex = 0;
                        }
                        if (tDataReader["il"].ToString().Length > 1)
                        {
                            drpIl.SelectedValue = "" + tDataReader["il"];
                            yuzde++;
                        }
                        else
                        {
                            drpIl.SelectedIndex = 0;
                        }
                        if (tDataReader["ilce"].ToString().Length > 1)
                        {
                            drpIlce.SelectedValue = "" + tDataReader["ilce"];
                            yuzde++;
                        }
                        else
                        {
                            drpIlce.SelectedIndex = 0;
                        }
                        if (tDataReader["mahkoy"].ToString().Length > 1)
                        {
                            txtMahalle.Text = "" + tDataReader["mahkoy"];
                            yuzde++;
                        }
                        else
                        {
                            txtMahalle.Text = "";
                        }
                        if (tDataReader["ciltno"].ToString().Length > 1)
                        {
                            txtCiltNo.Text = "" + tDataReader["ciltno"];
                            yuzde++;
                        }
                        else
                        {
                            txtCiltNo.Text = "";
                        }
                        if (tDataReader["ailesirano"].ToString().Length > 1)
                        {
                            txtAileSiraNo.Text = "" + tDataReader["ailesirano"];
                            yuzde++;
                        }
                        else
                        {
                            txtAileSiraNo.Text = "";
                        }
                        if (tDataReader["sirano"].ToString().Length > 1)
                        {
                            txtSiraNo.Text = "" + tDataReader["sirano"];
                            yuzde++;
                        }
                        else
                        {
                            txtSiraNo.Text = "";
                        }
                        if (tDataReader["verildigiyer"].ToString().Length > 1)
                        {
                            txtVerildigiYer.Text = "" + tDataReader["verildigiyer"];
                            yuzde++;
                        }
                        else
                        {
                            txtVerildigiYer.Text = "";
                        }
                        if (tDataReader["verilisnedeni"].ToString().Length > 1)
                        {
                            txtVerilisNedeni.Text = "" + tDataReader["verilisnedeni"];
                            yuzde++;
                        }
                        else
                        {
                            txtVerilisNedeni.Text = "";
                        }
                        if (tDataReader["kayitno"].ToString().Length > 1)
                        {
                            txtKayitNo.Text = "" + tDataReader["kayitno"];
                            yuzde++;
                        }
                        else
                        {
                            txtKayitNo.Text = "";
                        }
                        if (tDataReader["verilistarih"].ToString().Length > 1)
                        {
                            txtVerilisTarih.Text = "" + tDataReader["verilistarih"];
                            yuzde++;
                        }
                        else
                        {
                            txtVerilisTarih.Text = "";
                        }
                        if (tDataReader["verenmakam"].ToString().Length > 1)
                        {
                            txtVerenMakam.Text = "" + tDataReader["verenmakam"];
                            yuzde++;
                        }
                        else
                        {
                            txtVerenMakam.Text = "";
                        }
                        if (tDataReader["gecerliliktarih"].ToString().Length > 1)
                        {
                            txtGecerlilikTarih.Text = "" + tDataReader["gecerliliktarih"];
                            yuzde++;
                        }
                        else
                        {
                            txtGecerlilikTarih.Text = "";
                        }
                        if (tDataReader["kisiaciklama"].ToString().Length > 0)
                        {
                            txtAciklama.Text = "" + tDataReader["kisiaciklama"];
                            yuzde++;
                        }
                        else
                        {
                            txtAciklama.Text = "";
                        }
                        if (tDataReader["adresad"].ToString().Length > 1)
                        {
                            txtAdresAdi.Text = "" + tDataReader["adresad"];
                            yuzde++;
                        }
                        else
                        {
                            txtAdresAdi.Text = "";
                        }
                        if (tDataReader["adres"].ToString().Length > 1)
                        {
                            txtAdres.Text = "" + tDataReader["adres"];
                            yuzde++;
                        }
                        else
                        {
                            txtAdres.Text = "";
                        }
                        if (tDataReader["telefonad"].ToString().Length > 1)
                        {
                            txtTelefonAdi.Text = "" + tDataReader["telefonad"];
                            yuzde++;
                        }
                        else
                        {
                            txtTelefonAdi.Text = "";
                        }
                        if (tDataReader["mailad"].ToString().Length > 1)
                        {
                            txtMailAdi.Text = "" + tDataReader["mailad"];
                            yuzde++;
                        }
                        else
                        {
                            txtMailAdi.Text = "";
                        }
                        if (tDataReader["webad"].ToString().Length > 1)
                        {
                            txtWebAdresiAdi.Text = "" + tDataReader["webad"];
                            yuzde++;
                        }
                        else
                        {
                            txtWebAdresiAdi.Text = "";
                        }
                    }
                    tCon.Close();

                    float yeniyuzde = ((float) yuzde / (float) 37) * (float) 100;
                    progress.Style.Add("width", ((int) yeniyuzde).ToString() + "%");
                    lblProfilDolulukYuzesi.Text = "Profiliniz " + (int) yeniyuzde + "% Tamamlandı";
                }
                catch (Exception e)
                {
                    dangeralert.Visible = true;
                    lblHata.Text = e.ToString();
                }
            }
        }
        catch (Exception e)
        {
        }
    }

    protected void tcNo_OnTextChanged(object sender, EventArgs e)
    {
        tSQL = "SELECT count(*) from kisi_bilgi WHERE tck='" + txtTck.Text.Trim().Replace("'", "") + "'";

        if (PublicExecuteScalarInteger() > (Int32) 0) //Öle bi tc var ise
        {
            lblOnTextChanged.Visible = true;
            lblOnTextChanged.Text = "Tc Kimlik Numarası Sistemde Mevcut.";
            btnKaydet.Visible = false;
            pnlProfil.Visible = true;
        }
        else
        {
            lblOnTextChanged.Visible = false;
            lblOnTextChanged.Text = "";
            btnKaydet.Visible = true;
            pnlProfil.Visible = true;
        }
    }

    protected void btnDuzenle_Click(object sender, EventArgs e)
    {
        pnlProfil.Visible = true;
        successalert.Visible = false;
    }

    protected void btnKaydet_Click(object sender, EventArgs e)
    {
        try
        {
            tSQL = "UPDATE kisi_bilgi SET " +
                   "ad = '" + txtAdi.Text.Trim().Replace("'", "") + "'," +
                   "soyad ='" + txtSoyadi.Text.Trim().Replace("'", "") + "' , " +
                   "firma= '" + txtFirma.Text.Trim().Replace("'", "") + "', " +
                   "tck = '" + txtTck.Text.Trim().Replace("'", "") + "', " +
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
        catch (Exception exception)
        {
            dangeralert.Visible = true;
        }
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