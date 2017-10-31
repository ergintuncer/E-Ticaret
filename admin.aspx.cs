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
        try { 
        
        }
        catch
        {

        }
    }

    //protected void KullaniciAyarlari_OnClick(object sender, EventArgs e)
    //{
       
    //}

    //protected void EtkinlikAyarlari_OnClick(object sender, EventArgs e)
    //{
       
    //}

    //protected void PaylasimAyarlari_OnClick(object sender, EventArgs e)
    //{
    //}
    //protected void PaylasimiSil_OnClick(object sender, EventArgs e)
    //{
    //}

    protected void listView_yukle()
    {

       tSQL ="SELECT adi &' ' & soyadi as adi_soyadi ,resim,etkinlik_bas,etkinlik_tarih,etkinlik_saat,etkinlik_resim,etkinlik_konum,etkinlik_icerik FROM kayit, etkinlik where kayit.eposta = etkinlik.etkinlik_kullanici order by etkinlik_tarih DESC";
        tCon.Open();
        tCommand.Connection = tCon;
        tCommand.CommandText = tSQL;
        tDataReader = tCommand.ExecuteReader();


        con.Open();
        OleDbCommand cmd = new OleDbCommand(veri, con);
        OleDbDataReader oku = cmd.ExecuteReader();
        list1.DataSource = oku;
        list1.DataBind();
        con.Close();
    }

}