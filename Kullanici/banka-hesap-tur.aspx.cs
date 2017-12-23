using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Npgsql;

public partial class Kullanici_banka_hesap_tur : System.Web.UI.Page
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
    static int i = 0, j = 0, k = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        listView_yukle();
        if (!Page.IsPostBack)
        {
            drpAlici.Items.Clear();
            drpGonderen.Items.Clear();
            tSQL =
                "SELECT ad || ' ' || soyad as adsoyad, kisiid FROM kisi_bilgi  where kisi_bilgi.avukatid=(select avukatid from kisi_bilgi where kisi_bilgi.tck='" +
                Session["kullanici"] + "')";

            tCon.Open();
            tCommand.Connection = tCon;
            tCommand.CommandText = tSQL;
            tDataReader = tCommand.ExecuteReader();
            while (tDataReader.Read())
            {
                drpGonderen.Items.Add("" + tDataReader["adsoyad"]);
                tKisiID[i] = Convert.ToInt16(tDataReader["kisiid"]);
                i++;
            }
            tCon.Close();


            tSQL =
                "SELECT bankahesapad,bankahesapid FROM banka_hesap  where banka_hesap.avukatid=(select avukatid from kisi_bilgi where kisi_bilgi.tck='" +
                Session["kullanici"] + "')";
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
    }


    //alici=hesap
    int tAlici;

    int tGonderen;
   
    //protected void drpAlici_OnSelectedIndexChanged(object sender, EventArgs e)
    //{
        
    //    //lblacik.Text = "Kaydedildi.";
    //    // successalert.Visible = true;
    //    //throw new NotImplementedException();
    //}
    //göndereh ise kişidir

    //protected void drpGonderen_OnSelectedIndexChanged(object sender, EventArgs e)
    //{
        
    //    //lblacik.Text = "Kaydedildi.";
    //    //successalert.Visible = true;
    //    //throw new NotImplementedException();
    //}


    //protected void btnKaydet_Click(object sender, EventArgs e)
    //{
    //    tSQL =
    //        "INSERT INTO para_hareket_bilgi(islemtur, harekettarihsaat, makbuzno, aciklama,bankahesapid, tutar,digerkisiid,tarihsaat) VALUES (" +
    //        1 + ",'" + txtTarihSaat.Text + "','" + txtMakbuzNo.Text.Trim() + "','" + txtAciklama.Text.Trim() + "'," +
    //        tAlici + ", " + txtTutar.Text.Trim() + "," + tGonderen + ",current_timestamp) ";
    //    PublicExecuteNonQuery();
    //    lblacik.Text = "Kaydedildi.";
    //    successalert.Visible = true;
    //}


    protected void listView_yukle()
    {
        tSQL =
            "SELECT para_hareket_bilgi.kasahareketid,para_hareket_bilgi.harekettarihsaat,para_hareket_bilgi.makbuzno,para_hareket_bilgi.aciklama,para_hareket_bilgi.tutar,kisi_bilgi.ad as gonderici,banka_hesap.bankahesapad from para_hareket_bilgi  LEFT OUTER JOIN kisi_bilgi on para_hareket_bilgi.digerkisiid = kisi_bilgi.kisiid  LEFT OUTER JOIN banka_hesap on para_hareket_bilgi.bankahesapid = banka_hesap.bankahesapid where para_hareket_bilgi.islemtur=1";
        tCon.Open();
        tCommand.Connection = tCon;
        tCommand.CommandText = tSQL;
        tDataReader = tCommand.ExecuteReader();
        list2.DataSource = tDataReader;
        list2.DataBind();
        tCon.Close();
    }


    //protected void btnKaydet_OnServerClick(object sender, EventArgs e)
    //{
    //    tSQL =
    //        "INSERT INTO para_hareket_bilgi(islemtur, harekettarihsaat, makbuzno, aciklama,bankahesapid, tutar,digerkisiid,tarihsaat) VALUES (" +
    //        1 + ",'" + txtTarihSaat.Text + "','" + txtMakbuzNo.Text.Trim() + "','" + txtAciklama.Text.Trim() + "'," +
    //        tAlici + ", " + txtTutar.Text.Trim() + "," + tGonderen + ",current_timestamp) ";
    //    PublicExecuteNonQuery();
    //    lblacik.Text = "Kaydedildi.";
    //    successalert.Visible = true;

    //    listView_yukle();

    //    throw new NotImplementedException();
    //}

    protected void btnkayit_OnClick(object sender, EventArgs e)
    {
        tSQL ="INSERT INTO para_hareket_bilgi(islemtur, harekettarihsaat, makbuzno, aciklama,bankahesapid, tutar,digerkisiid,tarihsaat) VALUES (" +
            1 + ",'" + txtTarihSaat.Text + "','" + txtMakbuzNo.Text.Trim() + "','" + txtAciklama.Text.Trim() + "'," +
            tAlici + ", " + txtTutar.Text.Trim() + "," + tGonderen + ",current_timestamp) ";
            
        PublicExecuteNonQuery();
        lblacik.Text = "Kaydedildi.";
        successalert.Visible = true;

        listView_yukle();
    }

    //protected void drpGonderen_OnTextChanged(object sender, EventArgs e)
    //{
    //    
    //    //throw new NotImplementedException();
    //}

    //protected void drpGonderen_OnTextChanged(object sender, EventArgs e)
    //{
    //    
    //    tAlici = tBankaHesapID[drpAlici.SelectedIndex];
    //}

    protected void drpGonderen_OnTextChanged(object sender, EventArgs e)
    {
        tGonderen = tKisiID[drpGonderen.SelectedIndex];
        //throw new NotImplementedException();
    }

    protected void drpAlici_OnTextChanged(object sender, EventArgs e)
    {
        tAlici = tBankaHesapID[drpAlici.SelectedIndex];
        //throw new NotImplementedException();
    }
}