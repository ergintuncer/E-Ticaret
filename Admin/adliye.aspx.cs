using System;
using System.Activities.Expressions;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Npgsql;
public partial class Admin_Adliye : System.Web.UI.Page
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


    
    int[] TilID = new int[81];
    int[] TilceID = new int[81];
    private int i=0 ,j= 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        listView_yukle();

        if (!Page.IsPostBack)
        {
            tSQL = "select ilad,ilid from il_bilgi";
            tCon.Open();
            tCommand.Connection = tCon;
            tCommand.CommandText = tSQL;
            tDataReader = tCommand.ExecuteReader();
            while (tDataReader.Read())
            {
                drpil.Items.Add("" + tDataReader["ilad"]);
                TilID[i] = Convert.ToInt16(tDataReader["ilid"]) ;
                i++;
            }
            tCon.Close();
        }

    }
    protected void btnKaydet_Onclick(object sender, EventArgs e)
    {

        Boolean tAktif = false;

        if (ctxAktif.Checked == true)
        {
            tAktif = true;
        }

        if (txtadliyeadi.Text != "")
        {
            tSQL = "INSERT INTO adliye_bilgi(adliyead,aktif,ilid,ilceid) VALUES ('" + txtadliyeadi.Text.Trim() + "' , " + tAktif + ",1,1);";
            PublicExecuteNonQuery();
        }

        //throw new NotImplementedException();
    }
    protected void Aktiflik_OnClick(object sender, EventArgs e)
    {
        //throw new NotImplementedException();
    }

    protected void drpil_OnSelectedIndexChanged(object sender, EventArgs e)
    {

        //tSQL = "select ilcead,ilceid from ilce_bilgi";
        //tCon.Open();
        //tCommand.Connection = tCon;
        //tCommand.CommandText = tSQL;
        //tDataReader = tCommand.ExecuteReader();
        //while (tDataReader.Read())
        //{
        //    drpilce.Items.Add("" + tDataReader["ilcead"]);
        //    TilceID[j] = Convert.ToInt16(tDataReader["ilceid"]);
        //    j++;
        //}
        //tCon.Close();
        //txtaciklama.Text = ""+ drpil.SelectedValue;
        //drpil.Items.Add("");
        txtaciklama.Text = "asass";
        //throw new NotImplementedException();
    }

    protected void drpil_OnTextChanged(object sender, EventArgs e)
    {
        txtaciklama.Text = "asass";
        throw new NotImplementedException();
    }


    protected void listView_yukle()
    {

        tSQL = "select adliye_bilgi.adliyead, adliye_adres.adliyeadresad,adliye_adres.adres,adliye_adres.aciklama,adliye_bilgi.aktif,il_bilgi.ilad,ilce_bilgi.ilcead from adliye_bilgi INNER JOIN adliye_adres on adliye_bilgi.adliyeid=adliye_adres.adliyeid INNER JOIN il_bilgi on adliye_bilgi.ilid=il_bilgi.ilid INNER JOIN ilce_bilgi on il_bilgi.ilid=ilce_bilgi.ilid  ";
        tCon.Open();
        tCommand.Connection = tCon;
        tCommand.CommandText = tSQL;
        tDataReader = tCommand.ExecuteReader();
        list2.DataSource = tDataReader;
        list2.DataBind();
        tCon.Close();


    }


}