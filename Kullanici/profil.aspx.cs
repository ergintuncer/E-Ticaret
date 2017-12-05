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

        tCommand.Connection = tCon;
        tCommand.CommandType = System.Data.CommandType.Text;
        tCommand.CommandTimeout = 60000;
        tCommand.CommandText = tSQL;
        tCon.Open();
        
 tCommand.ExecuteNonQuery();
       try
        { }
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
                kullaniciTcNo = (String)Session["kullanici"];
            }
            else
            {
                Response.Redirect("/login.aspx");
            }
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


                pnlProfil.Visible = true;


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
                    lblkuladi.Text = (String)tDataReader["ad"];
                    lblkulsoyadi.Text = (String)tDataReader["soyad"];
                    lblkuldogumtarihi.Text = "" + tDataReader["dogumtarihi"];
                    lblkulFirma.Text = (String)tDataReader["firma"];
                    lblkulTcKimlikNo.Text = (String)tDataReader["tck"];
                    lblkulTelNo.Text = (String)tDataReader["telefon"];
                    lblkulMail.Text = (String)tDataReader["mail"];
                    lblkulWebAdresi.Text = (String)tDataReader["web"];

                    txtAdi.Text = (String)tDataReader["ad"];
                    txtSoyadi.Text = (String)tDataReader["soyad"];
                    txtTck.Text = (String)tDataReader["tck"];
                    txtFirma.Text = (String)tDataReader["firma"];
                    txtVergiNo.Text = (String)tDataReader["vergino"];
                    txtVergiDaire.Text = (String)tDataReader["vergidaire"];
                    txtAnneAdi.Text = (String)tDataReader["anneadi"];
                    txtBabaAdi.Text = (String)tDataReader["babaadi"];
                    txtDogumYeri.Text = (String)tDataReader["dogumyeri"];
                    txtDin.Text = (String)tDataReader["din"];
                    txtDogumTarihi.Text = "" + tDataReader["dogumtarih"];
                    if ((String)tDataReader["cinsiyet"] == "Erkek")
                    {
                        radioBTNCinsiyet.SelectedValue = "Erkek";
                    }
                    else if ((String)tDataReader["cinsiyet"] == "Kadın")
                    {
                        radioBTNCinsiyet.SelectedValue = "Kadın";
                    }

                    if ((String)tDataReader["medenihal"] == "Bekar")
                    {
                        radioBtnMedeniHal.SelectedValue = "Bekar";
                    }
                    else if ((String)tDataReader["medenihal"] == "Evli")
                    {
                        radioBtnMedeniHal.SelectedValue = "Evli";
                    }
                    txtUyruk.Text = (String)tDataReader["uyruk"];

                    if ((String)tDataReader["kangrubu"] == "A(+)")
                    {
                        radioBtnKanGrubu.SelectedValue = "A(+)";
                    }
                    else if ((String)tDataReader["kangrubu"] == "A(-)")
                    {
                        radioBtnKanGrubu.SelectedValue = "A(-)";
                    }
                    else if ((String)tDataReader["kangrubu"] == "B(+)")
                    {
                        radioBtnKanGrubu.SelectedValue = "B(+)";
                    }
                    else if ((String)tDataReader["kangrubu"] == "B(-)")
                    {
                        radioBtnKanGrubu.SelectedValue = "B(-)";
                    }
                    else if ((String)tDataReader["kangrubu"] == "AB(+)")
                    {
                        radioBtnKanGrubu.SelectedValue = "AB(+)";
                    }
                    else if ((String)tDataReader["kangrubu"] == "AB(-)")
                    {
                        radioBtnKanGrubu.SelectedValue = "AB(-)";
                    }
                    else if ((String)tDataReader["kangrubu"] == "0(+)")
                    {
                        radioBtnKanGrubu.SelectedValue = "0(+)";
                    }
                    else if ((String)tDataReader["kangrubu"] == "0(-)")
                    {
                        radioBtnKanGrubu.SelectedValue = "0(-)";
                    }
                    drpIl.SelectedValue = (String)tDataReader["il"];
                    drpIlce.SelectedValue = (String)tDataReader["ilce"];
                    txtMahalle.Text = (String)tDataReader["mahkoy"];
                    txtCiltNo.Text = (String)tDataReader["ciltno"];
                    txtAileSiraNo.Text = (String)tDataReader["ailesirano"];
                    txtSiraNo.Text = (String)tDataReader["sirano"];
                    txtVerildigiYer.Text = (String)tDataReader["verildigiyer"];
                    txtVerilisNedeni.Text = (String)tDataReader["verilisnedeni"];
                    txtKayitNo.Text = (String)tDataReader["kayitno"];
                    txtVerilisTarih.Text = "" + tDataReader["verilistarih"];
                    txtVerenMakam.Text = (String)tDataReader["verenmakam"];
                    txtGecerlilikTarih.Text = "" + tDataReader["gecerliliktarih"];
                    txtAciklama.Text = (String)tDataReader["aciklama"];
                    txtAdresAdi.Text = (String)tDataReader["adresad"];
                    txtAdres.Text = (String)tDataReader["adres"];
                    txtTelefonAdi.Text = (String)tDataReader["telefonad"];
                    txtTelefon.Text = (String)tDataReader["telefon"];
                    txtMailAdi.Text = (String)tDataReader["mailad"];
                    txtMailadresi.Text = (String)tDataReader["mail"];
                    txtWebAdresiAdi.Text = (String)tDataReader["webad"];
                    txtWebAdresi.Text = (String)tDataReader["web"];
                }
                tCon.Close();
            }
        }
        catch
        {
        }
    }

    protected void btnDuzenle_Click(object sender, EventArgs e)
    {
        pnlProfil.Visible = true;
    }

    protected void btnKaydet_Click(object sender, EventArgs e)
    {
        tSQL = "UPDATE kisi_bilgi SET " +
               "ad = '" + txtAdi.Text + "'," +
               "soyad ='" + txtSoyadi.Text + "' , " +
               "firma= '" + txtFirma.Text + "', " +
               "tck = '" + txtTck.Text + "', " +
               "vergino='" + txtVergiNo.Text + "', " +
               "vergidaire='" + txtVergiDaire.Text + "' " +
               "WHERE tck='" + kullaniciTcNo + "' ; " +

               "UPDATE kisi_kimlik SET " +
               "babaadi='" + txtBabaAdi.Text + "'," +
               "dogumtarih='" + txtDogumTarihi.Text + "', " +
               "anneadi='" + txtAnneAdi.Text + "', " +
               "dogumyeri='" + txtDogumYeri.Text + "', " +
               "medenihal='" + radioBtnMedeniHal.SelectedValue.ToString() + "', " +
               "din='" + txtDin.Text + "', " +
               "cinsiyet='" + radioBTNCinsiyet.SelectedValue.ToString() + "', " +
               "uyruk='" + txtUyruk.Text + "', " +
               "kangrubu='" + radioBtnKanGrubu.SelectedValue.ToString() + "', " +
               "il='" + drpIl.SelectedValue + "', " +
               "ilce='" + drpIlce.SelectedValue + "', " +
               "mahkoy='" + txtMahalle.Text + "', " +
               "ciltno='" + txtCiltNo.Text + "'," +
               "ailesirano='" + txtAileSiraNo.Text + "', " +
               "sirano='" + txtSiraNo.Text +
               "', verildigiyer='" + txtVergiDaire.Text + "', " +
               "verilisnedeni='" + txtVerilisNedeni.Text + "', " +
               "kayitno='" + txtKayitNo.Text + "', " +
               "verilistarih='" + txtVerilisTarih.Text + "', " +
               "verenmakam='" + txtVerenMakam.Text + "', " +
               "aciklama='" + txtAciklama.Text + "', " +
               "gecerliliktarih='" + txtGecerlilikTarih.Text + "', tarihsaat=CURRENT_TIMESTAMP" +
               " WHERE kisiid=(SELECT kisiid FROM kisi_bilgi WHERE tck='" + kullaniciTcNo + "'); " +
               "UPDATE kisi_adres SET adresad='" + txtAdresAdi.Text + "', adres='" + txtAdres.Text +
               "' WHERE kisiid=(SELECT kisiid FROM kisi_bilgi WHERE tck='" + kullaniciTcNo + "'); " +
               "UPDATE kisi_telefon SET telefonad='" + txtTelefonAdi.Text + "', telefon='" + txtTelefon.Text +
               "' WHERE kisiid=(SELECT kisiid FROM kisi_bilgi WHERE tck='" + kullaniciTcNo + "'); " +
               "UPDATE kisi_mail SET mailad='" + txtMailAdi.Text + "', mail='" + txtMailadresi.Text +
               "' WHERE kisiid=(SELECT kisiid FROM kisi_bilgi WHERE tck='" + kullaniciTcNo + "'); " +
               "UPDATE kisi_web  SET webad='" + txtWebAdresiAdi.Text + "', web='" + txtWebAdresi.Text +
               "' WHERE kisiid=(SELECT kisiid FROM kisi_bilgi WHERE tck='" + kullaniciTcNo + "'); ";

        PublicExecuteNonQuery();
        Response.Redirect("Profil.aspx");
    }

    protected void drpIl_OnTextChanged(object sender, EventArgs e)
    {
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