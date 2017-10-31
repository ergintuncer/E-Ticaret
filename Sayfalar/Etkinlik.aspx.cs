using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using System.IO;

public partial class Etkinlik : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["kullanici"] != null)
            {
            }
            else
            {
                Response.Redirect("login.aspx");
            }
            etkinlik_yenile();
        }
        catch
        {

        }

        }

    OleDbConnection con =
        new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0; DATA Source=" +
                            HttpContext.Current.Server.MapPath("sosyal.mdb"));

    string resimAdi = "";

    protected void btn_etkinlik_olustur_Click(object sender, EventArgs e)
    {
        try
        {
            HttpPostedFile yuklenecekDosya = fluDosya.PostedFile;
            if (yuklenecekDosya != null)
            {
                FileInfo dosyaBilgisi = new FileInfo(yuklenecekDosya.FileName);
                string klasor = "image";
                string yuklemeYeri = Server.MapPath("~/" + klasor + "/" + dosyaBilgisi.Name);
                fluDosya.SaveAs(yuklemeYeri);
                resimAdi = "image/" + dosyaBilgisi.Name;
            }
            img_etkinlikresmi.ImageUrl = resimAdi;

            string veri =
                "insert into etkinlik(etkinlik_bas,etkinlik_icerik,etkinlik_tarih,etkinlik_konum,etkinlik_resim,etkinlik_saat,etkinlik_kullanici) values(@etkinlik_bas,@etkinlik_icerik,@etkinlik_tarih,@etkinlik_konum,@etkinlik_resim,@etkinlik_saat,@etkinlik_kullanici)";
            OleDbCommand cmd = new OleDbCommand(veri, con);
            cmd.Parameters.Add("@etkinlik_bas", txt_baslik.Text);
            cmd.Parameters.Add("@etkinlik_iceri", txt_aciklama.Text);
            cmd.Parameters.Add("@etkinlik_tarih", txt_tarih.Text);
            cmd.Parameters.Add("@etkinlik_konum", txt_konum.Text);
            cmd.Parameters.Add("@etkinlik_resim", resimAdi + "");
            cmd.Parameters.Add("@etkinlik_saat", txt_saat.Text);

            cmd.Parameters.Add("@etkinlik_kullanici", Session["kullanici"]);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            etkinlik_yenile();
        }
        catch
        {
        }
    }


    void etkinlik_yenile()
    {
        try
        {
            string veri =
                "SELECT adi &' ' & soyadi as adi_soyadi ,resim,etkinlik_bas,etkinlik_tarih,etkinlik_saat,etkinlik_resim,etkinlik_konum,etkinlik_icerik FROM kayit, etkinlik where kayit.eposta = etkinlik.etkinlik_kullanici order by etkinlik_tarih DESC";
            con.Open();
            OleDbCommand cmd = new OleDbCommand(veri, con);
            OleDbDataReader oku = cmd.ExecuteReader();
            list1.DataSource = oku;
            list1.DataBind();
            con.Close();
        }
        catch
        {
        }
    }
}