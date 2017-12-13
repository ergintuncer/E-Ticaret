using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Npgsql;
public partial class Kullanici_para_hareket : System.Web.UI.Page
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



    static int[] tKisiID = new int[1000];
    static int[] tBankaHesapID = new int[1000];
    static int[] tGondericiKisiID = new int[1000];
    static int i = 0, j = 0,k=0;

    protected void Page_Load(object sender, EventArgs e)
    {

        drpAlici.Items.Clear();
        drpGonderen.Items.Clear();
        //drpIslemTuru.Items.Clear();
        if (!Page.IsPostBack)
        {

            //aktif();

        }

        if (drpIslemTuru.SelectedIndex==0)
        {
            tSQL = "SELECT ad || ' ' || soyad as adsoyad, kisiid FROM kisi_bilgi  where kisi_bilgi.avukatid=(select avukatid from kisi_bilgi where kisi_bilgi.tck='" + Session["kullanici"] + "')";
            tCon.Open();
            tCommand.Connection = tCon;
            tCommand.CommandText = tSQL;
            tDataReader = tCommand.ExecuteReader();
            while (tDataReader.Read())
            {
                drpAlici.Items.Add("" + tDataReader["adsoyad"]);
                tKisiID[i] = Convert.ToInt16(tDataReader["kisiid"]);
                i++;
            }
            tCon.Close();

        }
        else if (drpIslemTuru.SelectedIndex == 1)
        {
            tSQL = "SELECT bankahesapad,bankahesapid FROM banka_hesap  where banka_hesap.avukatid=(select avukatid from kisi_bilgi where kisi_bilgi.tck='" + Session["kullanici"] + "')";
            tCon.Open();
            tCommand.Connection = tCon;
            tCommand.CommandText = tSQL;
            tDataReader = tCommand.ExecuteReader();
            while (tDataReader.Read())
            {
                drpAlici.Items.Add("" + tDataReader["bankahesapad"]);
                tBankaHesapID[j] = Convert.ToInt16(tDataReader["bankahesapid"]);
                j++;
            }
            tCon.Close();
        }
        tSQL = "SELECT ad || ' ' || soyad as adsoyad, kisiid FROM kisi_bilgi  where kisi_bilgi.avukatid=(select avukatid from kisi_bilgi where kisi_bilgi.tck='" + Session["kullanici"] + "')";
        tCon.Open();
        tCommand.Connection = tCon;
        tCommand.CommandText = tSQL;
        tDataReader = tCommand.ExecuteReader();
        while (tDataReader.Read())
        {
            drpGonderen.Items.Add("" + tDataReader["adsoyad"]);
            tGondericiKisiID[k] = Convert.ToInt16(tDataReader["kisiid"]);
            k++;
        }
        tCon.Close();


    }

    protected void drpIslemTuru_SelectedIndexChanged(object sender, EventArgs e)
    {
        

    }

    protected void drpGonderen_SelectedIndexChanged(object sender, EventArgs e)
    {
        

    }

    protected void drpAlici_SelectedIndexChanged(object sender, EventArgs e)
    {
        

    }

    protected void btnKaydet_Click(object sender, EventArgs e)
    {
        //if (txtTarihSaat.te)

        //{
            
        //}
     
         if (drpIslemTuru.SelectedIndex == 0)
            {
            if (txtTutar.Text.Length != 0)
            {
                if (drpAlici.SelectedIndex != -1)
                {
                    tSQL = "INSERT INTO para_hareket_bilgi(islemtur, harekettarihsaat, makbuzno, aciklama,kisiid, tutar,digerkisiid,tarihsaat) VALUES (" + drpIslemTuru.SelectedIndex + ",'" + txtTarihSaat.Text + "','" + txtMakbuzNo.Text.Trim() + "','" + txtAciklama.Text.Trim() + "',(Select kisiid From kisi_bilgi where kisi_bilgi.tck='" + Session["kullanici"] + "'), " + txtTutar.Text.Trim() + "," + tKisiID[drpAlici.SelectedIndex] + ",current_timestamp) ";
                    PublicExecuteNonQuery();
                }
                else
                {
                    lblMesaj.Text = "Lütfen Kişi Seçiniz...";
                    lblMesaj.Visible = true;
                }
            }

            else
            {
                lblMesaj.Text = "Lütfen Tutarı Giriniz...";
                lblMesaj.Visible = true;
            }
         }
         else if (drpIslemTuru.SelectedIndex == 1)
         {
            if (txtTutar.Text.Length != 0)
            {
                if (drpAlici.SelectedIndex != -1)
                {

                    tSQL = "INSERT INTO para_hareket_bilgi(islemtur, harekettarihsaat, makbuzno, aciklama,kisiid, tutar,digerbankahesapid,tarihsaat) VALUES (" + drpIslemTuru.SelectedIndex + ",'" + txtTarihSaat.Text + "','" + txtMakbuzNo.Text.Trim() + "','" + txtAciklama.Text.Trim() + "',(Select kisiid From kisi_bilgi where kisi_bilgi.tck='" + Session["kullanici"] + "'), " + txtTutar.Text.Trim() + "," + tBankaHesapID[drpAlici.SelectedIndex] + ",current_timestamp) ";
                    PublicExecuteNonQuery();
                }
                else
                {
                    lblMesaj.Text = "Lütfen Hesap Seçiniz...";
                    lblMesaj.Visible = true;
                }
            }

            else
            {
                lblMesaj.Text = "Lütfen Tutarı Giriniz...";
                lblMesaj.Visible = true;
            }
        }
           
           
    }
}