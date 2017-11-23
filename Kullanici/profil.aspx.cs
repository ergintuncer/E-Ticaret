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
        tCon.Close();
    }
    // -----------------------------------------------------------------------------------------------------------


    // Select sorugular için İteger
    public int PublicExecuteScalarInteger()
    {
        NpgsqlCommand tCommand = new NpgsqlCommand(tSQL, tCon);
        //int tInteger;

        if (tCon.State == System.Data.ConnectionState.Open)
        {
            tCon.Close();
        }

        tCon.Open();
        tCommand.CommandType = System.Data.CommandType.Text;
        tCommand.CommandTimeout = 60000;
        tCommand.CommandText = tSQL;


        //if ( tCommand.ExecuteScalar() != DBNull.Value )
        //{
        // tInteger =(int)tCommand.ExecuteScalar();

        //}

        tCon.Close();
        return Convert.ToInt32(tCommand.ExecuteScalar());
    }
    // -----------------------------------------------------------------------------------------------------------


    // Select sorugular için Double
    public double PublicExecuteScalarDouble()
    {
        NpgsqlCommand tCommand = new NpgsqlCommand(tSQL, tCon);
        //int double;

        if (tCon.State == System.Data.ConnectionState.Open)
        {
            tCon.Close();
        }

        tCon.Open();
        tCommand.CommandType = System.Data.CommandType.Text;
        tCommand.CommandTimeout = 60000;
        tCommand.CommandText = tSQL;


        //if ( tCommand.ExecuteScalar() != DBNull.Value )
        //{
        // tInteger =(int)tCommand.ExecuteScalar();

        //}

        tCon.Close();
        return Convert.ToDouble(tCommand.ExecuteScalar());
    }
    // -----------------------------------------------------------------------------------------------------------

    // Select sorugular için String
    public string PublicExecuteScalarString()
    {
        NpgsqlCommand tCommand = new NpgsqlCommand(tSQL, tCon);
        //int string;

        if (tCon.State == System.Data.ConnectionState.Open)
        {
            tCon.Close();
        }

        tCon.Open();
        tCommand.CommandType = System.Data.CommandType.Text;
        tCommand.CommandTimeout = 60000;
        tCommand.CommandText = tSQL;


        //if ( tCommand.ExecuteScalar() != DBNull.Value )
        //{
        // tInteger =(int)tCommand.ExecuteScalar();

        //}

        tCon.Close();
        return Convert.ToString(tCommand.ExecuteScalar());
    }
    // -----------------------------------------------------------------------------------------------------------

    // Select sorugular için Boolean
    public Boolean PublicExecuteScalarBoolean()
    {
        NpgsqlCommand tCommand = new NpgsqlCommand(tSQL, tCon);
        //int Boolean;

        if (tCon.State == System.Data.ConnectionState.Open)
        {
            tCon.Close();
        }

        tCon.Open();
        tCommand.CommandType = System.Data.CommandType.Text;
        tCommand.CommandTimeout = 60000;
        tCommand.CommandText = tSQL;


        //if ( tCommand.ExecuteScalar() != DBNull.Value )
        //{
        // tInteger =(int)tCommand.ExecuteScalar();

        //}

        tCon.Close();
        return Convert.ToBoolean(tCommand.ExecuteScalar());
    }

    // -----------------------------------------------------------------------------------------------------------
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
               //  kullaniciTcNo = "123";
                Response.Redirect("/login.aspx");
            }
            if (!Page.IsPostBack)
            {
                pnlProfilDuzenle.Visible = false;
           
            tSQL = "SELECT * " +
                   "FROM kisi_bilgi " +
                   "INNER JOIN kisi_bakiye on kisi_bilgi.kisiid = kisi_bakiye.kisiid  " +
                   "INNER JOIN kisi_kimlik on kisi_bilgi.kisiid = kisi_kimlik.kisiid " +
                   "INNER JOIN kisi_adres on kisi_bilgi.kisiid = kisi_adres.kisiid " +
                   "INNER JOIN kisi_telefon on kisi_bilgi.kisiid = kisi_telefon.kisiid " +
                   "INNER JOIN kisi_mail on kisi_bilgi.kisiid = kisi_mail.kisiid " +
                   "INNER JOIN kisi_web on kisi_bilgi.kisiid = kisi_web.kisiid " +
                   "WHERE kisi_bilgi.tck = '" + Session["kullanici"] + "'";

            tCon.Open();
            tCommand.Connection = tCon;
            tCommand.CommandText = tSQL;
            tDataReader = tCommand.ExecuteReader();
            if (tDataReader.Read())
            {
                lblkuladi.Text = (String) tDataReader["ad"];
                lblkulsoyadi.Text = (String) tDataReader["soyad"];
                lblkuldogumtarihi.Text = "" + tDataReader["dogumtarih"];
                lblkulFirma.Text = (String) tDataReader["firma"];
                lblkulTcKimlikNo.Text = (String) tDataReader["tck"];
                lblkulTelNo.Text = (String) tDataReader["telefon"];
                lblkulMail.Text = (String) tDataReader["mail"];
                lblkulWebAdresi.Text = (String) tDataReader["web"];

                txtAdi.Text = (String) tDataReader["ad"];
                txtSoyadi.Text = (String) tDataReader["soyad"];
                txtTck.Text = (String) tDataReader["tck"];
                txtFirma.Text = (String) tDataReader["firma"];
                txtVergiNo.Text = (String) tDataReader["vergino"];
                txtVergiDaire.Text = (String) tDataReader["vergidaire"];
                txtAnneAdi.Text = (String) tDataReader["anneadi"];
                txtBabaAdi.Text = (String) tDataReader["babaadi"];
                txtDogumYeri.Text = (String) tDataReader["dogumyeri"];
                //txtDogumTarihi.Text =(DateTime)tDataReader["dogumtarih"];
                txtMedeniHal.Text = (String) tDataReader["medenihal"];
                txtDin.Text = (String) tDataReader["din"];
                txtCinsiyet.Text = (String) tDataReader["cinsiyet"];
                txtUyruk.Text = (String) tDataReader["uyruk"];
                txtKanGrubu.Text = (String) tDataReader["kangrubu"];
                txtIl.Text = (String) tDataReader["il"];
                txtIlce.Text = (String) tDataReader["ilce"];
                txtMahalle.Text = (String) tDataReader["mahkoy"];
                txtCiltNo.Text = (String) tDataReader["ciltno"];
                txtAileSiraNo.Text = (String) tDataReader["ailesirano"];
                txtSiraNo.Text = (String) tDataReader["sirano"];
                txtVerildigiYer.Text = (String) tDataReader["verildigiyer"];
                txtVerilisNedeni.Text = (String) tDataReader["verilisnedeni"];
                txtKayitNo.Text = (String) tDataReader["kayitno"];
                // txtVerilisTarih.Text = (String)tDataReader["verilistarih"];
                txtVerenMakam.Text = (String) tDataReader["verenmakam"];
                //  txtGecerlilikTarih.Text = (String)tDataReader["gecerliliktarihi"];
                txtAciklama.Text = (String) tDataReader["aciklama"];
                txtAdresAdi.Text = (String) tDataReader["adresad"];
                txtAdres.Text = (String) tDataReader["adres"];
                txtTelefonAdi.Text = (String) tDataReader["telefonad"];
                txtTelefon.Text = (String) tDataReader["telefon"];
                txtMailAdi.Text = (String) tDataReader["mailad"];
                txtMailadresi.Text = (String) tDataReader["mail"];
                txtWebAdresiAdi.Text = (String) tDataReader["webad"];
                txtWebAdresi.Text = (String) tDataReader["web"];
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
        pnlProfilDuzenle.Visible = true;
    }

    protected void btnKaydet_Click(object sender, EventArgs e)
    {
        tSQL = "UPDATE kisi_bilgi SET ad = '" + txtAdi.Text + "',  soyad ='" + txtSoyadi.Text + "' , firma= '" +
               txtFirma.Text + "', tck = '" + txtTck.Text + "', vergino='" + txtVergiNo.Text + "', vergidaire='" +
               txtVergiDaire.Text + "' WHERE tck='" + kullaniciTcNo + "' ; " +
               "UPDATE kisi_kimlik SET babaadi='" + txtBabaAdi.Text + "', anneadi='" + txtAnneAdi.Text +
               "', dogumyeri='" + txtDogumYeri.Text + "', medenihal='" + txtMedeniHal.Text + "', din='" + txtDin.Text +
               "', cinsiyet='" + txtCinsiyet.Text + "', uyruk='" + txtUyruk.Text + "', kangrubu='" + txtKanGrubu.Text +
               "', il='" + txtIl.Text + "', ilce='" + txtIlce.Text + "', mahkoy='" + txtMahalle.Text + "', ciltno='" +
               txtCiltNo.Text + "', ailesirano='" + txtAileSiraNo.Text + "', sirano='" + txtSiraNo.Text +
               "', verildigiyer='" + txtVergiDaire.Text + "', verilisnedeni='" + txtVerilisNedeni.Text +
               "', kayitno='" + txtKayitNo.Text + "', verenmakam='" + txtVerenMakam.Text +
               "' WHERE kisiid=(SELECT kisiid FROM kisi_bilgi WHERE tck='" + kullaniciTcNo + "'); " +
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
}