using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Npgsql;
public partial class Admin_kisiler : System.Web.UI.Page
{
    NpgsqlConnection tCon = new NpgsqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["NpgsqlConnectionStrings"].ConnectionString);
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
        tCon.Close();
        return Convert.ToInt32(tCommand.ExecuteScalar());
    }

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
        tCon.Close();
        return Convert.ToDouble(tCommand.ExecuteScalar());
    }
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
        tCon.Close();
        return Convert.ToString(tCommand.ExecuteScalar());
    }
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
        tCon.Close();
        return Convert.ToBoolean(tCommand.ExecuteScalar());
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            //// sesion kontolü
            //if (Session["kullanici"] != null)
            //{
            //}
            //else
            //{
            //    Response.Redirect("login.aspx");
            //}
            listView_yukle();
            //postback
            if (!Page.IsPostBack)
            {
                bloke();
            }
        }
        catch
        {
        }
    }

    protected void listView_yukle()
    {
        tSQL = "SELECT kisi_bilgi.ad  || ' ' || kisi_bilgi.soyad as ad_soyad,kisi_bilgi.firma, kisi_bilgi.tck, kisi_bilgi.kisiid,avukat_bilgi.sicilno,avukat_bilgi.birliksicilno,baro_bilgi.baroad from kisi_bilgi INNER JOIN avukat_bilgi on kisi_bilgi.kisiid = avukat_bilgi.kisiid INNER JOIN kisi_giris on kisi_bilgi.kisiid = kisi_giris.kisiid INNER JOIN baro_bilgi on avukat_bilgi.baroid = baro_bilgi.baroid";
        tCon.Open();
        tCommand.Connection = tCon;
        tCommand.CommandText = tSQL;
        tDataReader = tCommand.ExecuteReader();
        list2.DataSource = tDataReader;
        list2.DataBind();
        tCon.Close();
    }
    
    string kisiid;
    string islem;
    int id2;
    void bloke()
    {
        
            kisiid = Request.QueryString["kisiid"];
            islem = Request.QueryString["islem"];
            if (kisiid != null)
            {
                id2 = int.Parse(kisiid);
            }

            if (islem == "bloke")
            {
                tSQL = "UPDATE kisi_giris set bloke=false WHERE kisiid=" + id2;
                PublicExecuteNonQuery();

            }
           
            listView_yukle();
        }
      
    

    protected void KullaniciOnayla_OnClick(object sender, EventArgs e)
    {
        //throw new NotImplementedException();
    }

    protected void KullaniciSil_OnClick(object sender, EventArgs e)
    {
    }

    protected void btnAra_Click(object sender, EventArgs e)
    {
        

    }
}