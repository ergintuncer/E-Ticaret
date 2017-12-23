using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Npgsql;

public partial class AnaSayfaMaster : System.Web.UI.MasterPage
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
        try
        {
            tCommand.Connection = tCon;
            tCommand.CommandType = System.Data.CommandType.Text;
            tCommand.CommandTimeout = 60000;
            tCommand.CommandText = tSQL;
            tCon.Open();

            tCommand.ExecuteNonQuery();
        }
        catch (Exception e)
        {
        }

        tCon.Close();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["kullanici"] != null)
            {
                tSQL = "SELECT kisiturid FROM kisi_bilgi WHERE tck = '" + Session["kullanici"] + "'; ";
                tCon.Open();
                tCommand.Connection = tCon;
                tCommand.CommandText = tSQL;
                tDataReader = tCommand.ExecuteReader();
                while (tDataReader.Read())
                {
                    if ((Int64) tDataReader["kisiturid"] != 1)
                    {
                        Response.Redirect("/Sayfalar/error.html");
                    }
                }
                tCon.Close();
            }
            else
            {
                Response.Redirect("/login.aspx");
            }
        }
        catch (Exception exception)
        {
        }
    }
}