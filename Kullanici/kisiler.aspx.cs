using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Npgsql;

public partial class Kullanici_kisiler : System.Web.UI.Page
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
        try
        {
        }
        catch (Exception e)
        {
        }

        tCon.Close();
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

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            try
            {
                tSQL = "SELECT ilad as Il FROM il_bilgi; ";
                tCon.Open();
                tCommand.Connection = tCon;
                tCommand.CommandText = tSQL;
                tDataReader = tCommand.ExecuteReader();
                while (tDataReader.Read())
                {
                    drpIl.Items.Add("" + tDataReader["Il"]);
                }
                tCon.Close();

                tSQL = "SELECT kisiturad as kisitur FROM kisi_tur; ";
                tCon.Open();
                tCommand.Connection = tCon;
                tCommand.CommandText = tSQL;
                tDataReader = tCommand.ExecuteReader();
                while (tDataReader.Read())
                {
                    drpKisiTuru.Items.Add("" + tDataReader["kisitur"]);
                }
                tCon.Close();
            }
            catch (Exception exception)
            {
            }
        }
        if (Page.Buffer && drpIl.SelectedValue != null)
        {
            try
            {
                drpIlce.Items.Clear();
                tSQL = " SELECT ilcead as Ilce FROM ilce_bilgi WHERE ilid =" +
                       " (Select ilid from il_bilgi WHERE ilad = '" + drpIl.SelectedValue + "'); ";
                tCon.Open();
                tCommand.Connection = tCon;
                tCommand.CommandText = tSQL;
                tDataReader = tCommand.ExecuteReader();
                while (tDataReader.Read())
                {
                    drpIlce.Items.Add("" + tDataReader["Ilce"]);
                }
                tCon.Close();
            }
            catch (Exception exception)
            {
            }
        }

        verileriGoster("");
    }

    private void verileriGoster(String aranacakKisi)
    {
        try
        {
            //Kişilerin Gösterilmesi
            tSQL =
                "SELECT ad,soyad,tck, kisiturad,il,ilce,telefonad,telefon,mail,kisibakiye,kisi_adres.adresad,kisi_adres.adres " +
                "FROM kisi_bilgi " +
                "LEFT OUTER JOIN kisi_bakiye ON kisi_bilgi.kisiid = kisi_bakiye.kisiid " +
                "LEFT OUTER JOIN kisi_kimlik ON kisi_bilgi.kisiid = kisi_kimlik.kisiid " +
                "LEFT OUTER JOIN kisi_adres ON kisi_bilgi.kisiid = kisi_adres.kisiid " +
                "LEFT OUTER JOIN kisi_telefon ON kisi_bilgi.kisiid = kisi_telefon.kisiid " +
                "LEFT OUTER JOIN kisi_mail ON kisi_bilgi.kisiid = kisi_mail.kisiid " +
                "LEFT OUTER JOIN kisi_tur ON kisi_bilgi.kisiturid = kisi_tur.kisiturid " +
                "WHERE LOWER(kisi_bilgi.ad) LIKE'%" + aranacakKisi.ToLower() +
                "%' AND avukatid = (Select avukatid from kisi_bilgi WHERE tck = '" + Session["kullanici"] +
                "')  ORDER BY kisi_bilgi.kisiid";
            tCon.Open();
            tCommand.Connection = tCon;
            tCommand.CommandText = tSQL;
            tDataReader = tCommand.ExecuteReader();
            list2.DataSource = tDataReader;
            list2.DataBind();
            if (""+ tDataReader["kisiturad"] != "Avukat")
            {
                Response.Redirect("Profil.aspx");
                list2.Style.Add("background-color", "red");
            }
            tCon.Close();
        }
        catch (Exception e)
        {
        }
    }

    protected void drpIl_SelectedIndexChanged(object sender, EventArgs e)
    {
    }

    protected void btnKaydet_Click(object sender, EventArgs e)
    {
        try
        {
            tSQL = "INSERT INTO kisi_bilgi(ad,soyad,tck,kisiturid,avukatid) VALUES('" +
                   txtAdi.Text.Trim().Replace("'", "") + "','" +
                   txtSoyadi.Text.Trim().Replace("'", "") + "','" + txtTcNo.Text.Trim().Replace("'", "") + "','" +
                   drpKisiTuru.SelectedIndex +
                   "',(Select avukatid from kisi_bilgi WHERE tck = '" + Session["kullanici"] + "')); " +
                   "INSERT INTO kisi_kimlik(kisiid, il, ilce, tarihsaat) VALUES((SELECT MAX(kisiid) FROM kisi_bilgi WHERE avukatid = (SELECT avukatid FROM kisi_bilgi WHERE tck = '" +
                   Session["kullanici"] + "')), '" + drpIl.SelectedValue + "', '" + drpIlce.SelectedValue +
                   "', CURRENT_TIMESTAMP); " +
                   "INSERT INTO kisi_adres(kisiid, adresad, adres, tarihsaat) VALUES((SELECT MAX(kisiid) FROM kisi_bilgi WHERE avukatid = (SELECT avukatid FROM kisi_bilgi WHERE tck = '" +
                   Session["kullanici"] + "')), '" + txtAdresAdi.Text.Trim().Replace("'", "") + "', '" +
                   txtAdres.Text.Trim().Replace("'", "") +
                   "', CURRENT_TIMESTAMP); " +
                   "INSERT INTO kisi_telefon(kisiid, telefonad, telefon, tarihsaat) VALUES((SELECT MAX(kisiid) FROM kisi_bilgi WHERE avukatid = (SELECT avukatid FROM kisi_bilgi WHERE tck = '" +
                   Session["kullanici"] + "')), '" + txtTelefonAdi.Text.Trim().Replace("'", "") + "', '" +
                   txtTelefonNo.Text.Trim().Replace("'", "") +
                   "', CURRENT_TIMESTAMP); " +
                   "INSERT INTO kisi_mail(kisiid, mail, tarihsaat) VALUES((SELECT MAX(kisiid) FROM kisi_bilgi WHERE avukatid = (SELECT avukatid FROM kisi_bilgi WHERE tck = '" +
                   Session["kullanici"] + "')), '" + txtMail.Text.Trim().Replace("'", "") + "', CURRENT_TIMESTAMP); " +
                   "INSERT INTO kisi_bakiye(kisiid, bakiyeturid, kisibakiye) VALUES((SELECT MAX(kisiid) FROM kisi_bilgi WHERE avukatid = (SELECT avukatid FROM kisi_bilgi WHERE tck = '" +
                   Session["kullanici"] + "')), '1', '" + txtBakiye.Text.Trim().Replace("'", "") + "');" +
                   "INSERT INTO kisi_web(kisiid) VALUES((SELECT MAX(kisiid) FROM kisi_bilgi WHERE avukatid = (SELECT avukatid FROM kisi_bilgi WHERE tck = '" +
                   Session["kullanici"] + "')));";
            tSQL +=
                " INSERT INTO kisi_giris(kisiid,bloke) VALUES ((SELECT MAX(kisiid) FROM kisi_bilgi WHERE avukatid = (SELECT avukatid FROM kisi_bilgi WHERE tck = '" +
                Session["kullanici"] + "')),true);";
            PublicExecuteNonQuery();

            successalert.Visible = true;
            verileriGoster("");
        }
        catch (Exception exception)
        {
            dangeralert.Visible = true;
        }
    }

    protected void btnAra_Click(object sender, EventArgs e)
    {
        verileriGoster(txtAra.Value);
    }

    protected void tcNo_OnTextChanged(object sender, EventArgs e)
    {
        tSQL = "SELECT count(*) from kisi_bilgi WHERE tck='" + txtTcNo.Text.Trim() + "'";

        if (PublicExecuteScalarInteger() > (Int32) 0) //Öle bi tc var ise
        {
            lblOnTextChanged.Visible = true;
            lblOnTextChanged.Text = "Tc Kimlik Numarası Sistemde Mevcut.";
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