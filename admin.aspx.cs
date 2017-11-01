using System;
using System.Web.UI;
using Npgsql;

public partial class admin : System.Web.UI.Page
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
    // -----------------------------------------------------------------------------------------------------------


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


        //if ( tCommand.ExecuteScalar() != DBNull.Value )
        //{
        // tInteger =(int)tCommand.ExecuteScalar();

        //}

        tCon.Close();
        return Convert.ToInt32(tCommand.ExecuteScalar());

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
        //int Boolean;

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
        return Convert.ToBoolean(tCommand.ExecuteScalar());

    }
    // -----------------------------------------------------------------------------------------------------------

    protected void Page_Load(object sender, EventArgs e)
    {
      
        try {
            // sesion kontolü
            if (Session["kullanici"] != null)
            {
            }
            else
            {
                Response.Redirect("login.aspx");
            }



        //postback
        if (!Page.IsPostBack)
        {
                listView_yukle();

            }

        }
        catch
        {
            //hata yazdırılabilir
        }

    }

    protected void Profil_OnClick(object sender, EventArgs e)
    {
    }

    protected void Profil_Cikis_OnClick(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect("login.aspx");
        }
        catch
        {

        }
    }

    protected void Analiz_OnClick(object sender, EventArgs e)
    {
      //kayit
    }

    protected void KullaniciAyarlari_OnClick(object sender, EventArgs e)
    {
        

    }

    protected void EtkinlikAyarlari_OnClick(object sender, EventArgs e)
    {

    }

    protected void PaylasimAyarlari_OnClick(object sender, EventArgs e)
    {
    }
    protected void PaylasimiSil_OnClick(object sender, EventArgs e)
    {
    }

    protected void listView_yukle()
    {

       tSQL = "select ad  || ' ' || soyad as ad_soyad,firma, tck from kisi_bilgi";
        tCon.Open();
        tCommand.Connection = tCon;
        tCommand.CommandText = tSQL;
        tDataReader = tCommand.ExecuteReader();
        list2.DataSource = tDataReader;
        list2.DataBind();
        tCon.Close();

        
        //con.Open();
        //OleDbCommand cmd = new OleDbCommand(veri, con);
        //OleDbDataReader oku = cmd.ExecuteReader();
        //list1.DataSource = oku;
        //list1.DataBind();
        //con.Close();
    }

    protected void Onayla_OnClick(object sender, EventArgs e)
    {
        Response.Redirect("kayıt.aspx");
        //throw new NotImplementedException();
    }

    protected void sil_OnClick(object sender, EventArgs e)
    {
        Response.Redirect("login.aspx");
        //throw new NotImplementedException();
    }
}