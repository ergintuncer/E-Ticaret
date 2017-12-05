using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Npgsql;
public partial class Kullanici_banka_hesap : System.Web.UI.Page
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

    static int[] tBankaID = new int[1000];
    static int[] tBakiyeTurID = new int[1000];
    static int[] tHesapTurID = new int[1000];
    static int i=0,j=0,k=0;
    protected void Page_Load(object sender, EventArgs e)
    {
        listView_yukle();

        if (!Page.IsPostBack)
        {

            //aktif();

        }

        drpBanka.Items.Clear();
        drpHesapTuru.Items.Clear();
        drpBakiyeTur.Items.Clear();

        tSQL = "select bankaid,bankaad from banka_bilgi INNER JOIN kisi_bilgi on banka_bilgi.avukatid=kisi_bilgi.avukatid where kisi_bilgi.tck='" + Session["kullanici"]+"'";
        tCon.Open();
        tCommand.Connection = tCon;
        tCommand.CommandText = tSQL;
        tDataReader = tCommand.ExecuteReader();
        while (tDataReader.Read())
        {
            drpBanka.Items.Add("" + tDataReader["bankaad"]);
            tBankaID[i] = Convert.ToInt16(tDataReader["bankaid"]);
            i++;
        }
        tCon.Close();


        tSQL = "select bankahesapturid,bankahesapturad from banka_hesap_tur INNER JOIN kisi_bilgi on banka_hesap_tur.avukatid=kisi_bilgi.avukatid where kisi_bilgi.tck='" + Session["kullanici"] + "'";
        tCon.Open();
        tCommand.Connection = tCon;
        tCommand.CommandText = tSQL;
        tDataReader = tCommand.ExecuteReader();
        while (tDataReader.Read())
        {
            drpHesapTuru.Items.Add("" + tDataReader["bankahesapturad"]);
            tHesapTurID[j] = Convert.ToInt16(tDataReader["bankahesapturid"]);
            j++;
        }
        tCon.Close();


        tSQL = "select bakiyeturid,bakiyeturad from bakiye_tur";
        tCon.Open();
        tCommand.Connection = tCon;
        tCommand.CommandText = tSQL;
        tDataReader = tCommand.ExecuteReader();
        while (tDataReader.Read())
        {
            drpBakiyeTur.Items.Add("" + tDataReader["bakiyeturad"]);
            tBakiyeTurID[k] = Convert.ToInt16(tDataReader["bakiyeturid"]);
            k++;
        }
        tCon.Close();





    }

    protected void btnKaydet_Click(object sender, EventArgs e)
    {

        tSQL =
            "INSERT INTO banka_hesap(avukatid,bankaid,bankahesapturid,bakiyeturid,bankahesapad,bankahesapno,bankahesapiban,hesapbakiye,aciklama,kisiid,aktif,tarihsaat) VALUES ((select avukatid from kisi_bilgi where kisi_bilgi.tck='" + Session["kullanici"] +"')," +tBankaID[drpBanka.SelectedIndex]+ "," + tHesapTurID[drpHesapTuru.SelectedIndex]+ "," +tBakiyeTurID[drpBakiyeTur.SelectedIndex]+ ", '" + txtHesapAdi.Text.Trim() +"','" +txtHesapNo.Text.Trim()+ "','" + txtIbanNo.Text.Trim() + "'," + txtBakiye.Text.Trim() + ",'" + txtHesapAciklama.Text.Trim() + "',(select kisiid from kisi_bilgi where kisi_bilgi.tck='" + Session["kullanici"] + "'),true,current_timestamp  ); ";
        PublicExecuteNonQuery();


    }

    protected void drpBanka_SelectedIndexChanged(object sender, EventArgs e)
    {
        

    }

    protected void drpHesapTuru_SelectedIndexChanged(object sender, EventArgs e)
    {
        

    }

    protected void drpBakiyeTur_SelectedIndexChanged(object sender, EventArgs e)
    {
        

    }

    protected void listView_yukle()
    {

        tSQL = "select banka_bilgi.bankaad,banka_hesap_tur.bankahesapturad, bakiye_tur.bakiyeturad,banka_hesap.bankahesapad,banka_hesap.bankahesapno,banka_hesap.bankahesapiban,banka_hesap.hesapbakiye,banka_hesap.aciklama,banka_hesap.aktif from banka_hesap inner join banka_bilgi on banka_hesap.bankaid=banka_bilgi.bankaid inner join banka_hesap_tur on banka_hesap.bankahesapturid=banka_hesap_tur.bankahesapturid inner join bakiye_tur on banka_hesap.bakiyeturid=bakiye_tur.bakiyeturid inner join kisi_bilgi on banka_hesap.avukatid=kisi_bilgi.avukatid where kisi_bilgi.tck='"+ Session["kullanici"] + "'";
        tCon.Open();
        tCommand.Connection = tCon;
        tCommand.CommandText = tSQL;
        tDataReader = tCommand.ExecuteReader();
        list2.DataSource = tDataReader;
        list2.DataBind();
        tCon.Close();



    }


}