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
        Session["kullanici"] = null;
        if (!Page.IsPostBack)
        {
        }
    }

    protected void giris_Click(object sender, EventArgs e)
    {
        tSQL = "SELECT count(*) from kisi_bilgi WHERE tck='" + txtTcNo.Value.Trim() + "' and tck='" +
               txtSifre.Value.Trim() + "'";
        if (PublicExecuteScalarInteger() > 0) //Öle bi kullanici var ise
        {
            tSQL =
                "select kisi_giris.bloke from  kisi_bilgi Inner Join kisi_giris ON kisi_bilgi.kisiid=kisi_giris.kisiid WHERE kisi_bilgi.tck='" +
                txtTcNo.Value.Trim() + "';";
            if (PublicExecuteScalarBoolean()) //Bloke edilmemişse
            {
                Session.Add("kullanici", txtTcNo.Value.Trim());
                tSQL = "SELECT kisiturid from kisi_bilgi WHERE tck = '" + txtTcNo.Value.Trim() + "';";
                tCon.Open();
                tCommand.Connection = tCon;
                tCommand.CommandText = tSQL;
                tDataReader = tCommand.ExecuteReader();
                while (tDataReader.Read())
                {
                    if (Convert.ToUInt64(tDataReader["kisiturid"]) == 0) //Admin demek
                    {
                        tCon.Close();
                        Response.Redirect("/Admin/kisiler.aspx");
                    }
                    else if (Convert.ToUInt64(tDataReader["kisiturid"]) == 1) //Avukat demek
                    {
                        tCon.Close();
                        Response.Redirect("Kullanici/profil.aspx");
                    }
                    else //Normal kullanici demek
                    {
                        tCon.Close();
                        Response.Redirect("Kisiler/profil.aspx");
                    }
                }
            }
            else
            {
                lblHata.Text = "Şuan Bloke Edilmişsiniz";
                dangeralert.Visible = true;
            }
        }
        else
        {
            lblHata.Text = "Kullanıcı Adınız ve/veya Şifreniz Yanlış Girilşmiştir. <br/>Lütfen Kontrol Ediniz";
            dangeralert.Visible = true;
        }
    }

    protected void kayitol_Click(object sender, EventArgs e)
    {
        Response.Redirect("kayit.aspx");
    }

    protected void sifremiUnuttum_Click(object sender, EventArgs e)
    {
        Response.Redirect("/Sayfalar/sifremiunuttum.aspx");
    }
}