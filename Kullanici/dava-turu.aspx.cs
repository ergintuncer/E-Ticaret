using System;
using System.Collections.Generic;
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

    protected void Page_Load(object sender, EventArgs e)
    {
        verileriGostaer();
    }

    protected void btnKaydet_Click(object sender, EventArgs e)
    {
        try
        {
            if (txtDavaTur.Text != "" && txtDavaAciklama.Text != "")
            {
                tSQL =
                    "INSERT INTO dava_tur(avukatid,davaturad,aciklama,aktif,tarihsaat) VALUES((SELECT avukatid from kisi_bilgi Where tck = '" +
                    Session["kullanici"] + "'),'" + txtDavaTur.Text + "','" + txtDavaAciklama.Text + "','" +
                    chckDavaAktif.Checked + "',CURRENT_TIMESTAMP); ";
                PublicExecuteNonQuery();
                successalert.Visible = true;
                verileriGostaer();
            }
            else
            {
            }
        }
        catch
        {
            dangeralert.Visible = true;
        }
    }

    private void verileriGostaer()
    {
        try
        {
 tSQL = "select davaturad, aciklama,  CASE WHEN aktif = 'f' THEN 'Hayır' ELSE 'Evet' END AS aktif, to_char(tarihsaat,'dd.mm.YYYY') as tarihsaat from dava_tur  WHERE (avukatid=(SELECT avukatid from kisi_bilgi Where tck = '" +
            Session["kullanici"] + "') Or avukatid='0');";
        tCon.Open();
        tCommand.Connection = tCon;
        tCommand.CommandText = tSQL;
        tDataReader = tCommand.ExecuteReader();
        list2.DataSource = tDataReader;
        list2.DataBind();
        tCon.Close();
        }
        catch (Exception e)
        {
            dangeralert.Visible = true;
        }
       
    }
}