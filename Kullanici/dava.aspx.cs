using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Npgsql;

public partial class Kullanici_dava : System.Web.UI.Page
{
    NpgsqlConnection tCon = new NpgsqlConnection(System.Configuration.ConfigurationManager
        .ConnectionStrings["NpgsqlConnectionStrings"].ConnectionString);

    NpgsqlCommand tCommand = new NpgsqlCommand();
    NpgsqlDataReader tDataReader;
    String tSQL;


    public void PublicExecuteNonQuery()
    {
        try
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
        catch (Exception e)
        {
            dangeralert.Visible = true;
        }
    }
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
    static int[] tKisiId = new int[1000];
    static int i = 0;
    static int[] tMahkemeId = new int[1000];
    static int MahkemeSayisi = 0;
    static int[] tDavaTurId = new int[1000];
    static int davaTurSayisi = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            drpDavaTuru.Items.Clear();
            tSQL = " SELECT davaturid, davaturad FROM dava_tur WHERE avukatid =" +
                   "(Select avukatid from kisi_bilgi WHERE tck ='" + Session["kullanici"] + "'); ";
            tCon.Open();
            tCommand.Connection = tCon;
            tCommand.CommandText = tSQL;
            tDataReader = tCommand.ExecuteReader();
            while (tDataReader.Read())
            {
                drpDavaTuru.Items.Add("" + tDataReader["davaturad"]);
                tDavaTurId[davaTurSayisi] = Int32.Parse("" + tDataReader["davaturid"]);
                davaTurSayisi++;
            }
            tCon.Close();

            drpMahkeme.Items.Clear();
            tSQL = "SELECT mahkemeid, mahkemead FROM mahkeme_bilgi;";
            tCon.Open();
            tCommand.Connection = tCon;
            tCommand.CommandText = tSQL;
            tDataReader = tCommand.ExecuteReader();
            while (tDataReader.Read())
            {
                drpMahkeme.Items.Add("" + tDataReader["mahkemead"]);
                tMahkemeId[MahkemeSayisi] = Int32.Parse("" + tDataReader["mahkemeid"]);
                MahkemeSayisi++;
            }
            tCon.Close();

            drpTarafTur.Items.Clear();
            tSQL = "SELECT davatarafturad FROM dava_taraf_tur;";
            tCon.Open();
            tCommand.Connection = tCon;
            tCommand.CommandText = tSQL;
            tDataReader = tCommand.ExecuteReader();
            while (tDataReader.Read())
            {
                drpTarafTur.Items.Add("" + tDataReader["davatarafturad"]);
            }
            tCon.Close();


            drpKisiAdiSoyadi.Items.Clear();
            tSQL =
                "SELECT kisiid,ad, soyad FROM kisi_bilgi Where avukatid = (SELECT avukatid FROM kisi_bilgi WHERE tck = '" +
                Session["kullanici"] + "'); ";
            tCon.Open();
            tCommand.Connection = tCon;
            tCommand.CommandText = tSQL;
            tDataReader = tCommand.ExecuteReader();
            while (tDataReader.Read())
            {
                drpKisiAdiSoyadi.Items.Add("" + tDataReader["ad"] + " " + tDataReader["soyad"]);
                tKisiId[i] = Int32.Parse("" + tDataReader["kisiid"]);
                i++;
            }
            tCon.Close();
        }


        verileriGostaer("");
    }

    private void verileriGostaer(String davaNo)
    {
        tSQL =
            "SELECT mahkeme_bilgi.mahkemead, kisi_bilgi.ad  || ' ' || kisi_bilgi.soyad as ad_soyad, dava_tur.davaturad, dava_bilgi.davano, dava_bilgi.dosyaurl, CASE WHEN dava_bilgi.aktif  = 'f' THEN 'Hayır' ELSE 'Evet' END AS davaaktif , dava_taraf_tur.davatarafturad, to_char(durusma_bilgi.tarihsaat,'dd.mm.YYYY') as tarihsaat ,dava_bilgi.aciklama as davaaciklama,durusma_bilgi.aciklama, CASE WHEN durusma_bilgi.aktif  = 'f' THEN 'Hayır' ELSE 'Evet' END AS aktif" +
            " FROM dava_bilgi" +
            " INNER JOIN dava_tur ON dava_bilgi.davaturid = dava_tur.davaturid" +
            " INNER JOIN dava_mahkeme ON dava_mahkeme.davaid = dava_bilgi.davaid" +
            " INNER JOIN dava_taraf ON dava_taraf.davaid = dava_bilgi.davaid" +
            " INNER JOIN dava_taraf_tur ON dava_taraf_tur.davatarafturid = dava_taraf.davatarafturid" +
            " INNER JOIN durusma_bilgi ON durusma_bilgi.davaid = dava_bilgi.davaid" +
            " INNER JOIN kisi_bilgi ON kisi_bilgi.kisiid = dava_taraf.kisiid" +
            " INNER JOIN mahkeme_bilgi ON mahkeme_bilgi.mahkemeid = dava_mahkeme.mahkemeid" +
            " WHERE LOWER(dava_bilgi.davano) LIKE'%" + davaNo.ToLower() + "%' AND dava_bilgi.avukatid = (SELECT avukatid FROM kisi_bilgi WHERE tck = '" + Session["kullanici"] + "') ORDER BY dava_bilgi.davano";
        tCon.Open();
        tCommand.Connection = tCon;
        tCommand.CommandText = tSQL;
        tDataReader = tCommand.ExecuteReader();
        list2.DataSource = tDataReader;
        list2.DataBind();
        tCon.Close();
    }

    protected void drpDavaTuru_SelectedIndexChanged(object sender, EventArgs e)
    {
    }

    protected void drpMahkeme_SelectedIndexChanged(object sender, EventArgs e)
    {
    }

    protected void btnKaydet_Click(object sender, EventArgs e)
    {
        try
        {
            String dosyaUrl = "";
            HttpPostedFile yuklenecekDosya = fileUpload_Dosya.PostedFile;
            if (yuklenecekDosya != null)
            {
                FileInfo dosyaBilgisi = new FileInfo(yuklenecekDosya.FileName);
                string yuklemeYeri = Server.MapPath("~/dosyalar/" + dosyaBilgisi.Name);
                fileUpload_Dosya.SaveAs(yuklemeYeri);
                dosyaUrl = "/dosyalar/" + dosyaBilgisi.Name;
            }


            tSQL = "INSERT INTO dava_bilgi(davaturid,avukatid,davano,aciklama,aktif,tarihsaat,dosyaurl) VALUES (" +
                   tDavaTurId[drpDavaTuru.SelectedIndex] + ",(SELECT avukatid FROM kisi_bilgi WHERE tck='" +
                   Session["kullanici"] + "'),'" + txtDavaNo.Text.Replace("'", "") + "','" + txtDavaAciklama.Text.Replace("'", "") + "','" +
                   chckDavaAktif.Checked + "',CURRENT_TIMESTAMP,'" + dosyaUrl + "');";

            tSQL += " INSERT INTO dava_mahkeme(davaid, mahkemeid, tarihsaat)VALUES(" +
                    "(SELECT MAX(davaid) FROM dava_bilgi WHERE avukatid = (SELECT avukatid FROM kisi_bilgi WHERE tck = '" +
                    Session["kullanici"] + "')),'" + tMahkemeId[drpMahkeme.SelectedIndex] + "',CURRENT_TIMESTAMP);";
            tSQL += " INSERT INTO dava_taraf(davaid, davatarafturid, kisiid,  tarihsaat) VALUES(" +
                    "(SELECT MAX(davaid) FROM dava_bilgi WHERE avukatid = (SELECT avukatid FROM kisi_bilgi WHERE tck = '" +
                    Session["kullanici"] + "'))," +
                    "(SELECT davatarafturid from dava_taraf_tur WHERE davatarafturad = '" +
                    drpTarafTur.SelectedValue + "')," +
                    "'" + tKisiId[drpKisiAdiSoyadi.SelectedIndex] + "',CURRENT_TIMESTAMP); ";
            tSQL +=
                "INSERT INTO durusma_bilgi(davaid, tarihsaat, aciklama, aktif,islemtarihsaat)" +
                " VALUES((SELECT MAX(davaid) FROM dava_bilgi WHERE avukatid = (SELECT avukatid FROM kisi_bilgi WHERE tck = '" +
                Session["kullanici"] + "'))," +
                "'" + txtDurusmaTarihi.Text.Replace("'", "") + "','" + txtDurusmaAciklama.Text.Replace("'", "") + "','" + chckDurusmaAktif.Checked +
                "',CURRENT_TIMESTAMP); ";

            PublicExecuteNonQuery();
            successalert.Visible = true;
            verileriGostaer("");
            txtDavaAciklama.Text = "";
            txtDavaNo.Text = "";
            txtDurusmaAciklama.Text = "";
        }
        catch (Exception exception)
        {
            dangeralert.Visible = true;
        }
    }

    protected void btnAra_Click(object sender, EventArgs e)
    {
        
        verileriGostaer(txtAra.Value.ToLower());
    }

    protected void txtDavaNo_OnTextChanged(object sender, EventArgs e)
    {
        tSQL = "SELECT count(*) from dava_bilgi WHERE davano='" + txtDavaNo.Text.Trim().Replace("'", "") + "'";

        if (PublicExecuteScalarInteger() > (Int32)0) //Öle bi dava var ise
        {
            lblOnTextChanged.Visible = true;
            lblOnTextChanged.Text = "Bu Dava Numarası Sistemde Mevcut.";
            btnKaydet.Visible = false;
        }
        else
        {
            lblOnTextChanged.Visible = false;
            lblOnTextChanged.Text = "";
            btnKaydet.Visible = true;
        }
    }
}