using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Npgsql;
public partial class Kullanici_paratransferi : System.Web.UI.Page
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



    protected void Page_Load(object sender, EventArgs e)
    {
        listView_yukle();
        bloke();
    }

    protected void btnKaydet_Click(object sender, EventArgs e)
    {
        if (txtBankaAdi.Text.Length!=0)
        {
            if (txtBankaSube.Text.Length != 0)
            {
                tSQL =
                "INSERT INTO banka_bilgi(bankaad,bankasubead,bankasubekod,bankasubetel1,bankasubetel2,bankasubeadres,aciklama,aktif,avukatid) VALUES ('" +
                txtBankaAdi.Text.Trim() + "' , '" + txtBankaSube.Text.Trim() + "','" + txtBankaSubeKodu.Text.Trim() +
                "','" + txtBankaTelefonNo.Text.Trim() + "','" + txtBankaTelefonKodu.Text.Trim() + "','" + txtBankaAdres.Text.Trim() + "','" + txtBankaAciklama.Text.Trim() + "',true,(Select avukatid from kisi_bilgi where tck='" + Session["kullanici"] + "'));";
                PublicExecuteNonQuery();
                lblacik.Text = "Kaydedildi.";
                successalert.Visible = true;
            }
            else
            {
               
                lblacik.Text = "Lütfen Şube Adı Giriniz...";
                successalert.Visible = true;
            }
        }
        else
        {
            lblacik.Text = "Lütfen Banka Adı Giriniz...";
            successalert.Visible = true;
        }
       

    }


    protected void listView_yukle()
    {

        tSQL = "select bankaad,bankasubead,bankasubekod,bankasubetel1,bankasubeadres,aciklama,bankaid,aktif from banka_bilgi order by bankaad asc ";
        tCon.Open();
        tCommand.Connection = tCon;
        tCommand.CommandText = tSQL;
        tDataReader = tCommand.ExecuteReader();
        list2.DataSource = tDataReader;
        list2.DataBind();
        tCon.Close();


    }

    protected void Aktiflik_OnClick(object sender, EventArgs e)
    {
        throw new NotImplementedException();

    }


    /////////////////////////////////////////////////

    string kisiid;
    string islem;
    int id2;
    bool tAktifMi;
    void bloke()
    {
        kisiid = Request.QueryString["kisiid"];
        islem = Request.QueryString["islem"];




        if (kisiid != null)
        {
            id2 = int.Parse(kisiid);


            tSQL = "select aktif  from banka_bilgi where bankaid=" + id2;
            tCon.Open();
            tCommand.Connection = tCon;
            tCommand.CommandText = tSQL;
            object tAktifMiObj = tCommand.ExecuteScalar();
            var testAktif = tAktifMiObj as bool?;
            if (testAktif.HasValue)
            {
                tAktifMi = testAktif.Value;
            }

            tCon.Close();


        }


        if (islem == "bloke")
        {
            if (tAktifMi == true)
            {
                tSQL = "UPDATE banka_bilgi set aktif=false WHERE bankaid=" + id2;
                PublicExecuteNonQuery();
                lblacik.Text = "Değişiklik Gerçekleşti.";
                successalert.Visible = true;
            }
            else
            {
                tSQL = "UPDATE banka_bilgi set aktif=true WHERE bankaid=" + id2;
                PublicExecuteNonQuery();
                lblacik.Text = "Değişiklik Gerçekleşti.";
                successalert.Visible = true;
            }


        }

        listView_yukle();
    }


    /////////////////////////////////////////////////////



}