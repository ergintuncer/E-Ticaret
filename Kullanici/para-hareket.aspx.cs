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
       
        listView_yukle();
       
        //drpIslemTuru.Items.Clear();
        if (!Page.IsPostBack)
        {
            drpAlici.Items.Clear();
            drpGonderen.Items.Clear();

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
       
        
            

       
        //else if (drpIslemTuru.SelectedIndex == 1)
        //{
        //    tSQL = "SELECT bankahesapad,bankahesapid FROM banka_hesap  where banka_hesap.avukatid=(select avukatid from kisi_bilgi where kisi_bilgi.tck='" + Session["kullanici"] + "')";
        //    tCon.Open();
        //    tCommand.Connection = tCon;
        //    tCommand.CommandText = tSQL;
        //    tDataReader = tCommand.ExecuteReader();
        //    while (tDataReader.Read())
        //    {
        //        drpAlici.Items.Add("" + tDataReader["bankahesapad"]);
        //        tBankaHesapID[j] = Convert.ToInt16(tDataReader["bankahesapid"]);
        //        j++;
        //    }
        //    tCon.Close();
        //}
     



    }

    protected void drpIslemTuru_SelectedIndexChanged(object sender, EventArgs e)
    {
        //drpAlici.Items.Clear();
        //if (drpIslemTuru.SelectedIndex == 0)
        //{
        //    tSQL = "SELECT ad || ' ' || soyad as adsoyad, kisiid FROM kisi_bilgi  where kisi_bilgi.avukatid=(select avukatid from kisi_bilgi where kisi_bilgi.tck='" + Session["kullanici"] + "')";
        //    tCon.Open();
        //    tCommand.Connection = tCon;
        //    tCommand.CommandText = tSQL;
        //    tDataReader = tCommand.ExecuteReader();
        //    while (tDataReader.Read())
        //    {
        //        drpAlici.Items.Add("" + tDataReader["adsoyad"]);
        //        tKisiID[i] = Convert.ToInt16(tDataReader["kisiid"]);
        //        i++;
        //    }
        //    tCon.Close();

        //}
        //else if (drpIslemTuru.SelectedIndex == 1)
        //{
        //    tSQL = "SELECT bankahesapad,bankahesapid FROM banka_hesap  where banka_hesap.avukatid=(select avukatid from kisi_bilgi where kisi_bilgi.tck='" + Session["kullanici"] + "')";
        //    tCon.Open();
        //    tCommand.Connection = tCon;
        //    tCommand.CommandText = tSQL;
        //    tDataReader = tCommand.ExecuteReader();
        //    while (tDataReader.Read())
        //    {
        //        drpAlici.Items.Add("" + tDataReader["bankahesapad"]);
        //        tBankaHesapID[j] = Convert.ToInt16(tDataReader["bankahesapid"]);
        //        j++;
        //    }
        //    tCon.Close();
        //}

    }

    protected void drpGonderen_SelectedIndexChanged(object sender, EventArgs e)
    {
        

    }
     int deger ;
    protected void drpAlici_SelectedIndexChanged(object sender, EventArgs e)
    {

        deger = tGondericiKisiID[drpGonderen.SelectedIndex];
        
    }
 
    protected void btnKaydet_Click(object sender, EventArgs e)
    {
        //if (!Page.IsPostBack)
        //{
        //    lblacik.Text = "Kaydedildi" + deger;
        //    successalert.Visible = true;
        //    //aktif();

        //}

        //lblacik.Text = "Kaydedildi" + deger;
        //successalert.Visible = true;
        //deger = ;
        if (txtTutar.Text.Length != 0)
        {
            if (drpAlici.SelectedIndex != -1)
            {
                tSQL = "INSERT INTO para_hareket_bilgi(islemtur, harekettarihsaat, makbuzno, aciklama,kisiid, tutar,digerkisiid,tarihsaat) VALUES (" + 0 + ",'" + txtTarihSaat.Text + "','" + txtMakbuzNo.Text.Trim() + "','" + txtAciklama.Text.Trim() + "',(Select kisiid From kisi_bilgi where kisi_bilgi.tck='" + Session["kullanici"] + "'), " + txtTutar.Text.Trim() + "," + deger + ",current_timestamp); ";
                tSQL += "UPDATE kisi_bakiye set kisibakiye=kisibakiye+" + txtTutar.Text.Trim() + "where kisiid=(Select kisiid From kisi_bilgi where kisi_bilgi.tck='" + Session["kullanici"] + "');";
                tSQL += "UPDATE kisi_bakiye set kisibakiye=kisibakiye-" + txtTutar.Text.Trim() + "where kisiid=" + deger + ";";
                PublicExecuteNonQuery();
                lblacik.Text = "Kaydedildi";
                successalert.Visible = true;
                listView_yukle();
            }
            else
            {
                lblacik.Text = "Lütfen Kişi Seçiniz...";
                successalert.Visible = true;
            }
        }

        else
        {
            lblacik.Text = "Lütfen Tutarı Giriniz...";
            successalert.Visible = true;
        }
        listView_yukle();

        //aktif();

    }





    //if (txtTarihSaat.te)

    //{

    //}

    //if (drpIslemTuru.SelectedIndex == 0)
    //   {

    //     else if (drpIslemTuru.SelectedIndex == 1)
    //     {
    //        if (txtTutar.Text.Length != 0)
    //        {
    //            if (drpAlici.SelectedIndex != -1)
    //            {

    //                tSQL = "INSERT INTO para_hareket_bilgi(islemtur, harekettarihsaat, makbuzno, aciklama,kisiid, tutar,digerbankahesapid,tarihsaat) VALUES (" + drpIslemTuru.SelectedIndex + ",'" + txtTarihSaat.Text + "','" + txtMakbuzNo.Text.Trim() + "','" + txtAciklama.Text.Trim() + "',(Select kisiid From kisi_bilgi where kisi_bilgi.tck='" + Session["kullanici"] + "'), " + txtTutar.Text.Trim() + "," + tBankaHesapID[drpAlici.SelectedIndex] + ",current_timestamp) ";
    //                PublicExecuteNonQuery();
    //                lblacik.Text = "Kaydedildi.";
    //                successalert.Visible = true;
    //            }
    //            else
    //            {
    //                lblacik.Text = "Lütfen Hesap Seçiniz...";
    //                successalert.Visible = true;
    //            }
    //        }

    //        else
    //        {
    //            lblacik.Text = "Lütfen Tutarı Giriniz...";
    //            successalert.Visible = true;
    //        }
    //    }


    //}



    protected void listView_yukle()
    {

        tSQL = "SELECT para_hareket_bilgi.kasahareketid,para_hareket_bilgi.harekettarihsaat,para_hareket_bilgi.makbuzno,para_hareket_bilgi.aciklama,para_hareket_bilgi.tutar,kisi_bilgi.ad as alici,kisi_bilgi2.ad as gonderen from para_hareket_bilgi LEFT OUTER JOIN kisi_bilgi on para_hareket_bilgi.kisiid = kisi_bilgi.kisiid LEFT OUTER JOIN kisi_bilgi as kisi_bilgi2 on para_hareket_bilgi.digerkisiid = kisi_bilgi2.kisiid where para_hareket_bilgi.islemtur=0";
        tCon.Open();
        tCommand.Connection = tCon;
        tCommand.CommandText = tSQL;
        tDataReader = tCommand.ExecuteReader();
        list2.DataSource = tDataReader;
        list2.DataBind();
        tCon.Close();



    }
}