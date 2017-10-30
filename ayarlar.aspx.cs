using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using System.IO;

public partial class ayarlar : System.Web.UI.Page
{
    string ID;
    string islem;
    int id2;
    OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0; DATA Source=" + HttpContext.Current.Server.MapPath("sosyal.mdb"));
    protected void Page_Load(object sender, EventArgs e)
    {


        
        try
        {
            List();

            if (Session["kullanici"] != null)
            {

            }
            else
            {
                Response.Redirect("login.aspx");
            }
            SifreDegistirmePanel.Visible = false;
            ProfilGuncellemePanel.Visible = false;
            //PaylasimSilmePanel.Visible = false;
            EthinlikSilmePanel.Visible = false;
            if (!Page.IsPostBack)
            {
                sil();
                uni_yukle(); // üniversiteler yükleme metodu

                string veri = "select * from kayit where eposta='" + Session["kullanici"] + "'";
                con.Open();
                OleDbCommand cmd = new OleDbCommand(veri, con);
                OleDbDataReader oku = cmd.ExecuteReader();

                if (oku.Read())
                {
                    txtad.Text = "" + oku["adi"];
                    txtsoyad.Text = "" + oku["soyadi"];
                    txtmemleket.Text = "" + oku["memleket"];
                    txtfakulte.Text = "" + oku["fakulte"];
                    txtbolum.Text = "" + oku["bolum"];
                    drpuniversite.SelectedValue = "" + oku["uni_adi"];
                    imgprofilresmiguncelle.ImageUrl = "" + oku["resim"];
                    con.Close();

                }
            }
        }
        catch
        {

        }





    }

    void uni_yukle()
    {
        try
        {
            con.Open();
            string veri = "select uni_adi from universite";
            OleDbCommand cmd = new OleDbCommand(veri, con);
            OleDbDataReader data = cmd.ExecuteReader();
            while (data.Read())
            {
                drpuniversite.Items.Add("" + data["uni_adi"]);
            }
            con.Close();
        }
        catch
        {
        }
    }

/*
                                 * Html olarak tanımladığım butonların yanına resim ekleyebiliyorum o nedenle html tipinde buton kullandım.
                                 * onclick yazılışı farklı sadece hepsi bu diğer herşeyi asp tipindeki butonla aynı
                                 * Html kodunun içinde onclick olayını nasıl tanımladığımı görebilirsin.
                                 * orada tanımlayınca ilk başta hata veriyor on click yordamını burda tanımlayınca hata gider.(asp ile aynı olabilir belkide bu hata)
                                   */


    protected void SifreIslemleri_OnClick(object sender, EventArgs e)
    {
        try
        {
            SifreDegistirmePanel.Visible = true;
            ProfilGuncellemePanel.Visible = false;
            PaylasimSilmePanel.Visible = false;
            EthinlikSilmePanel.Visible = false;
        }
        catch
        {
        }
    }

    protected void ProfilGuncelleme_OnClick(object sender, EventArgs e)
    {
        try
        {
            SifreDegistirmePanel.Visible = false;
            ProfilGuncellemePanel.Visible = true;
            PaylasimSilmePanel.Visible = false;
            EthinlikSilmePanel.Visible = false;
        }
        catch
        {
        }
    }

    protected void PaylasimSilme_OnClick(object sender, EventArgs e)
    {
        try
        {
            SifreDegistirmePanel.Visible = false;
            ProfilGuncellemePanel.Visible = false;
            PaylasimSilmePanel.Visible = true;
            EthinlikSilmePanel.Visible = false;
        }
        catch
        {
        }
    }

    protected void EtkinlikSilme_OnClick(object sender, EventArgs e)
    {
        try
        {
            SifreDegistirmePanel.Visible = false;
            ProfilGuncellemePanel.Visible = false;
            PaylasimSilmePanel.Visible = false;
            EthinlikSilmePanel.Visible = true;
        }
        catch
        {
        }
    }

    protected void PaylasimiSil_OnClick(object sender, EventArgs e)
    {
    }

    protected void EtkinlikSil_OnClick(object sender, EventArgs e)
    {
    }

    string resim_adi;

    protected void btnkaydet_Click(object sender, EventArgs e)
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
                resim_adi = "image/" + dosyaBilgisi.Name;
                txtveri.Text = resim_adi;

                string veri = "UPDATE kayit SET resim=@resim where eposta='" + Session["kullanici"] + "'";
                OleDbCommand cmd = new OleDbCommand(veri, con);
                cmd.Parameters.AddWithValue("@resim", txtveri.Text);

                con.Open();

                cmd.ExecuteNonQuery();
                con.Close();

                imgprofilresmiguncelle.ImageUrl = resim_adi;
            }
        }
        catch
        {
        }
    }

    protected void btn2_Click(object sender, EventArgs e)
    {
        try
        {
            string veri =
                "UPDATE kayit SET adi=@adi,soyadi=@soyadi,uni_adi=@uni_adi,memleket=@memleket,fakulte=@fakulte,bolum=@bolumm where eposta=@eposta";
            OleDbCommand cmd = new OleDbCommand(veri, con);
            cmd.Parameters.AddWithValue("@adi", txtad.Text);
            cmd.Parameters.AddWithValue("@soyadi", txtsoyad.Text);
            cmd.Parameters.AddWithValue("@uni_adi", drpuniversite.Text);
            cmd.Parameters.AddWithValue("@memleket", txtmemleket.Text);
            cmd.Parameters.AddWithValue("@fakulte", txtfakulte.Text);
            cmd.Parameters.AddWithValue("@bolum", txtbolum.Text);
            cmd.Parameters.AddWithValue("@eposta", Session["kullanici"]);
            //cmd.Parameters.AddWithValue("@resim", resim_adi);
            con.Open();

            cmd.ExecuteNonQuery();
            con.Close();
        }
        catch
        {
        }
    }

    protected void gonder_Click(object sender, EventArgs e)
    {
        //imgprofilresmiguncelle.ImageUrl = resim_adi;
    }

    protected void btnsifredegistir_Click(object sender, EventArgs e)
    {
        try
        {
            string veri = "select sifre from kayit where eposta='" + Session["kullanici"] + "' and sifre='" +
                          txteskisifre.Text + "'";
            con.Open();
            OleDbCommand cmd = new OleDbCommand(veri, con);
            OleDbDataReader oku = cmd.ExecuteReader();
            string s1 = txtyenisifre.Text;
            string s2 = txtyenisifretekrar.Text;
            string eski = txteskisifre.Text;

            if (oku.Read())
            {
                string veri2 = "UPDATE kayit SET sifre=@sifre where eposta='" + Session["kullanici"] + "'";
                OleDbCommand cmd2 = new OleDbCommand(veri2, con);
                cmd2.Parameters.AddWithValue("@sifre", txtyenisifre.Text);
                cmd2.ExecuteNonQuery();
            }

            con.Close();
        }
        catch
        {
        }
    }

    void List()//etkinlik listele
    {
        try { 
        string veri = "SELECT adi &' ' & soyadi as adi_soyadi ,resim,etkinlik_bas,etkinlik_tarih,etkinlik_saat,etkinlik_resim,etkinlik_konum,etkinlik_icerik,ID FROM kayit, etkinlik where kayit.eposta=etkinlik.etkinlik_kullanici and kayit.eposta='" + Session["kullanici"] + "' order by etkinlik_tarih DESC";
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

    void sil()
    {
        try { 
        ID = Request.QueryString["ID"];
        islem = Request.QueryString["islem"];
        if (ID != null)
        {
            id2 = int.Parse(ID);
        }

        if (islem == "sil")
        {
            string veri = "delete  from etkinlik where ID=" + id2 + "";
            con.Open();
            OleDbCommand cmd = new OleDbCommand(veri, con);
            cmd.ExecuteNonQuery();
            con.Close();
            SifreDegistirmePanel.Visible = false;
            ProfilGuncellemePanel.Visible = false;
            //PaylasimSilmePanel.Visible = false;
            EthinlikSilmePanel.Visible = true;

        }
        }
        catch
        {

        }
    }
}