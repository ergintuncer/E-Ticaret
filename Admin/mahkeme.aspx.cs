using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Npgsql;
public partial class Admin_Mahkeme : System.Web.UI.Page
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


    static int[] tAdliyeID = new int[1000];
    static int[] tMahkemeTurID = new int[15000];
    static int i = 0, j = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        listView_yukle();
        aktif();
        if (!Page.IsPostBack)
        {

            tSQL = "select mahkemeturid,mahkemeturad from mahkeme_tur order by mahkemeturad asc";
            tCon.Open();
            tCommand.Connection = tCon;
            tCommand.CommandText = tSQL;
            tDataReader = tCommand.ExecuteReader();
            while (tDataReader.Read())
            {
                drpMahkemeTuru.Items.Add("" + tDataReader["mahkemeturad"]);
                tMahkemeTurID[i] = Convert.ToInt16(tDataReader["mahkemeturid"]);
                i++;
            }
            tCon.Close();



            tSQL = "select adliyead, adliyeid from adliye_bilgi order by adliyead asc";
            tCon.Open();
            tCommand.Connection = tCon;
            tCommand.CommandText = tSQL;
            tDataReader = tCommand.ExecuteReader();
            while (tDataReader.Read())
            {
                drpAdliye.Items.Add("" + tDataReader["adliyead"]);
                tAdliyeID[j] = Convert.ToInt16(tDataReader["adliyeid"]);
                j++;
            }
            tCon.Close();

        }

    }
    protected void btnKaydet_Onclick(object sender, EventArgs e)
    {

        Boolean tAktif = false;

        if (ctxAktif.Checked == true)
        {
            tAktif = true;
        }

        tSQL = "INSERT INTO mahkeme_bilgi(adliyeid,mahkemeturid,mahkemead,aktif) VALUES (" + tAdliyeID[drpAdliye.SelectedIndex] + " , " + tMahkemeTurID[drpMahkemeTuru.SelectedIndex] + ",'" + txtMahkemeAdi.Text.Trim() + "'," + tAktif + ");";

        PublicExecuteNonQuery();
        //throw new NotImplementedException();
    }

    protected void Aktiflik_OnClick(object sender, EventArgs e)
    {
        //throw new NotImplementedException();
    }


    protected void listView_yukle()
    {

        tSQL = "select mahkeme_bilgi.mahkemeid,mahkeme_bilgi.mahkemead, adliye_bilgi.adliyead, mahkeme_bilgi.aktif,mahkeme_tur.mahkemeturad from mahkeme_bilgi INNER JOIN adliye_bilgi on mahkeme_bilgi.adliyeid = adliye_bilgi.adliyeid INNER JOIN mahkeme_tur on mahkeme_bilgi.mahkemeturid = mahkeme_tur.mahkemeturid  ";
        tCon.Open();
        tCommand.Connection = tCon;
        tCommand.CommandText = tSQL;
        tDataReader = tCommand.ExecuteReader();
        list2.DataSource = tDataReader;
        list2.DataBind();
        tCon.Close();


    }

    string mahkemeid;
    string islem;
    int id2;
    void aktif()
    {
        try
        {
            mahkemeid = Request.QueryString["mahkemeid"];
            islem = Request.QueryString["islem"];
            if (ID != null)
            {
                id2 = int.Parse(mahkemeid);
            }

            if (islem == "aktif")
            {
                tSQL = "UPDATE mahkeme_bilgi set aktif=false where mahkemeid=" + id2;
                PublicExecuteNonQuery();

            }


            listView_yukle();
        }
        catch
        {

        }
    }


}