using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using Npgsql;

public partial class kayıt : System.Web.UI.Page
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
            if (Session["kullanici"] != null)
            {
            }
            else
            {
               // Response.Redirect("login.aspx");
            }
            if (!Page.IsPostBack)
            {
                con.Open();
                string veri = "select uni_adi from universite";
                OleDbCommand cmd = new OleDbCommand(veri, con);
                OleDbDataReader data = cmd.ExecuteReader();
                while (data.Read())
                {
                    universite.Items.Add("" + data["uni_adi"]);
                }
                con.Close();
            }
        }
        catch
        {
            //hata mesajı verilebilir
        }
    }


    protected void gonder_Click(object sender, EventArgs e)
    {
        try
        {
            if (adi.Value != "" && soyadi.Value != "" && firma.Value != "" && tcno.Value != "" &&
                sicilno.Value != "" && birliksicilno.Value != "") { 
                     
            }
            else
            {
                lbl1.Text = "Tüm alanları doldurmanız gerekli!!!";
            }
        }
        catch
        {
            //hata mesajı verilebilir...
        }
    }
}