using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using Npgsql;

public partial class login : System.Web.UI.Page
{
    NpgsqlConnection tCon = new NpgsqlConnection(System.Configuration.ConfigurationManager
        .ConnectionStrings["NpgsqlConnectionStrings"].ConnectionString);

    NpgsqlCommand tCommand = new NpgsqlCommand();
    NpgsqlDataReader tDataReader;
    String tSQL;


    // İnsert - Update - Delete işlemleri için
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
        bool Bool = false;

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
            Bool = Convert.ToBoolean(tCommand.ExecuteScalar());
        }

        tCon.Close();
        return Bool;
        //return tCommand.ExecuteScalar();
    }
    // -----------------------------------------------------------------------------------------------------------
    
   
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
        }
    }
    
    protected void giris_Click(object sender, EventArgs e)
    {
        tSQL =
            "select kisi_giris.bloke from  kisi_bilgi Inner Join kisi_giris ON kisi_bilgi.kisiid=kisi_giris.kisiid WHERE kisi_bilgi.tck='" +
            kullaniciadi.Text + "'";
        if (PublicExecuteScalarBoolean())
        {
            tSQL = "SELECT count(*) from kisi_bilgi WHERE tck='" + kullaniciadi.Text + "' and tck='" + sifre.Text +
                   "'";
            if (PublicExecuteScalarInteger() > 0)
            {
                Session.Add("kullanici", kullaniciadi.Text);
                Response.Redirect("admin.aspx");
            }
            else
            {
                lbl1.Text = "Kullanıcı Adınız ve/veya Şifreniz Yanlış Girişmiştir. Lütfen Kontrol Ediniz";
            }
        }
        else
        {
            lbl1.Visible = true;

            lbl1.Text = "Şuan Bloke Edilmişsiniz";
        }
    }

    protected void kayitol_Click(object sender, EventArgs e)
    {
        Response.Redirect("kayıt.aspx");
    }
    protected void sifremiUnuttum_Click(object sender, EventArgs e)
    {
        Response.Redirect("/Sayfalar/sifremiunuttum.aspx");
    }
}