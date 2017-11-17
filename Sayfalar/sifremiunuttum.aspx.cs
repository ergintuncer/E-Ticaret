using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.OleDb;
using System.Net;
using System.Net.Mail;
using Npgsql;
public partial class Sayfalar_sifremiunuttum : System.Web.UI.Page
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


    private static int tSayilarToplami;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
        }
    }


    //protected void giris_Click(object sender, EventArgs e)
    //{
    //    tSQL =
    //        "select kisi_giris.bloke from  kisi_bilgi Inner Join kisi_giris ON kisi_bilgi.kisiid=kisi_giris.kisiid WHERE kisi_bilgi.tck='" +
    //        kullaniciadi.Text + "'";
    //    if (PublicExecuteScalarBoolean())
    //    {
    //        tSQL = "SELECT count(*) from kisi_bilgi WHERE tck='" + kullaniciadi.Text + "' and tck='" + sifre.Text +
    //               "'";
    //        if (PublicExecuteScalarInteger() > 0)
    //        {
    //            Session.Add("kullanici", kullaniciadi.Text);
    //            Response.Redirect("admin.aspx");
    //        }
    //        else
    //        {
    //            lbl1.Text = "Kullanıcı Adınız ve/veya Şifreniz Yanlış Girişmiştir. Lütfen Kontrol Ediniz";
    //        }
    //    }
    //    else
    //    {
    //        lbl1.Visible = true;

    //        lbl1.Text = "Şuan Bloke Edilmişsiniz";
    //    }
    //}

    protected void sifreyiSifirlaClick(object sender, EventArgs e)
    {


        //Veritabanı bağlantısı başarılı ise(email)mevcut ise
        if (true)
        {
            MailMessage o = new MailMessage("ergin.tuncer@hotmail.com", "To", "Subject", "Body");
            NetworkCredential netCred = new NetworkCredential("Sender Email", "Sender Password");
            SmtpClient smtpobj = new SmtpClient("smtp.live.com", 587);
            smtpobj.EnableSsl = true;
            smtpobj.Credentials = netCred;
            smtpobj.Send(o);



            MailMessage mesaj = new MailMessage();
            mesaj.To.Add(new MailAddress(txtemail.Text));
            mesaj.From = new MailAddress(txtemail.Text, "tuncer_ergn@hotmail.com");
            //mesaj.Body = "E-mail =" + dr["EMail"].ToString() + "\n" + "Kullanıcı Adı:" + dr["KullaniciAdi"].ToString() + "\n" + "Şifre:" + dr["Sifre"].ToString() + "\n";
            mesaj.Body = "E-mail = Sıfırlama Talebi";
            SmtpClient client = new SmtpClient();
            client.Host = "smtp.gmail.com";
            client.Port = 587;
            client.Credentials = new NetworkCredential("tuncer_ergn@hotmail.com", "Tuncer.07");
            client.EnableSsl = true;
            try
            {
                client.Send(mesaj);
                lbl1.Visible = true;
              lbl1.Text="Şifreniz E-Mail adresinize gönderilmiştir. Teşekkür ederiz !";
            }
            catch
            {
                lbl1.Visible = true;
                lbl1.Text = "Mesaj Gönderilirken bir hata oluştu";
               }

        }
        else
        {
        }
        //Response.Redirect("/login.aspx");
    }
}