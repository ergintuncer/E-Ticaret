using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using System.IO;

public partial class _Default : System.Web.UI.Page
{
    OleDbConnection con =
        new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0; DATA Source=" +
                            HttpContext.Current.Server.MapPath("sosyal.mdb"));
    
    protected void Page_Load(object sender, EventArgs e)
    {
        

        try
        {
            like();

            if (Session["kullanici"] != null)
            {
            }
            else
            {
                Response.Redirect("login.aspx");
            }

            List();
        }
        catch
        {
        }
    }

    public void List()
    {
        try
        {
            string veri =
                "SELECT adi &' ' & soyadi as adi_soyadi ,tarih  &' ' & saat as tarih_saat ,icerik,begenmesayisi,p_resim,resim ,ID FROM kayit, paylasim where kayit.eposta=paylasim.kul_adi  order by tarih DESC,saat DESC ";
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

    string resimAdi;

    protected void paylas_Click(object sender, EventArgs e)
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
            imgPaylasimResimOnizleme.ImageUrl = resimAdi;

            string tarih = DateTime.Now.ToString("dd MMMM yyyy ddddd");
            string saat = DateTime.Now.ToString("HH:mm");
            string veri =
                "insert into paylasim(icerik,kul_adi,tarih,p_resim,saat) values(@icerik,@kul_adi,@tarih,@p_resim,@saat)";
            OleDbCommand cmd = new OleDbCommand(veri, con);
            cmd.Parameters.Add("@icerik", txt_paylasimIcerik.Text);
            cmd.Parameters.Add("@kul_adi", Session["kullanici"]);
            cmd.Parameters.Add("@tarih", tarih + "");
            cmd.Parameters.Add("@p_resim", resimAdi + "");
            cmd.Parameters.Add("@tarih", saat + "");

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            txt_paylasimIcerik.Text = "";
            List();
        }
        catch
        {
        }
    }
    string ID;
    string islem;
    int id2;
     void like()
    {
        try { 
        ID = Request.QueryString["ID"];
        islem = Request.QueryString["islem"];
        if (ID != null)
        {
            id2 = int.Parse(ID);
        }
        if (islem == "like")
        {
            string veri = "UPDATE paylasim SET begenmesayisi=begenmesayisi + 1  where ID=" + id2 + "";
            con.Open();
            OleDbCommand cmd = new OleDbCommand(veri, con);
            cmd.ExecuteNonQuery();
            con.Close();
           


        }
        }
        catch
        {

        }
    }
    protected void begen_Click(object sender, EventArgs e)
    {
        
    }
    }