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


    string kulemail;

    protected void Page_Load(object sender, EventArgs e)
    {
        //kulemail = "";
        //txtTcNo.Value = "";
    }

    private void MailGonder(string emailAdres)
    {
        if (kulemail.Length > 1)
        {
            try
            {
                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
                smtpClient.Credentials = new System.Net.NetworkCredential("avukatbook@gmail.com", "Avuakt.Book.0107");
                smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtpClient.EnableSsl = true;
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress("avukatbook@gmail.com");
                mail.To.Add(new MailAddress(emailAdres));
                mail.Subject = "AvukatBook Şifre Sıfırlama İsteği";
                mail.Body = "Merhaba Şifreniz " + txtTcNo.Value + " Olarak değiştirilmiştir";
                smtpClient.Send(mail);
                txtTcNo.Value = "";
                kulemail = "";
                successalert.Visible = true;
            }
            catch (Exception ex)
            {
                lblHata.Text = "Mail Gönderilemedi...";
                dangeralert.Visible = true;
            }
        }
        else
        {
            lblHata.Text = "Kullanıcı Bulunamadı...";
            dangeralert.Visible = true;
        }
    }

    protected void SifreyiSifirla_Click(object sender, EventArgs e)
    {
        try
        {
            tSQL =
                "SELECT DISTINCT(TRIM(mail)) as mail FROM kisi_mail INNER JOIN kisi_bilgi ON kisi_mail.kisiid=kisi_bilgi.kisiid WHERE tck='" +
                txtTcNo.Value.Trim() + "';";
            tCon.Open();
            tCommand.Connection = tCon;
            tCommand.CommandText = tSQL;
            tDataReader = tCommand.ExecuteReader();
            while (tDataReader.Read())
            {
                kulemail = (String) tDataReader["mail"];
            }
            tCon.Close();
            MailGonder(kulemail);
        }
        catch (Exception exception)
        {
            lblHata.Text = "Bağlantı hatası...";
            dangeralert.Visible = true;
        }
    }

    protected void GirisYap_Click(object sender, EventArgs e)
    {
        
        Response.Redirect("~/login.aspx");
    }
}