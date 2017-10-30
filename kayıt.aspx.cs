using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;

public partial class kayıt : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
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

    OleDbConnection con =
        new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0; DATA Source=" +
                            HttpContext.Current.Server.MapPath("sosyal.mdb"));

    protected void gonder_Click(object sender, EventArgs e)
    {
        try
        {
            if (adi.Value != "" && soyadi.Value != "" && firma.Value != "" && tcno.Value != "" &&
                sicilno.Value != "" && birliksicilno.Value != "") { 
                     
            }
            else
            {
                Label1.Text = "Tüm alanları doldurmanız gerekli!!!";
            }
        }
        catch
        {
            //hata mesajı verilebilir...
        }
    }

    void kayit1()
    {
        try
        {
            string veri =
                "insert into kayit(adi,soyadi,eposta,dog_tar,sifre,uni_adi) values(@adi,@soyadi,@eposta,@dog_tar,@sifre,@uni_adi)";
            OleDbCommand cmd = new OleDbCommand(veri, con);
            cmd.Parameters.Add("@adi", adi.Value);
            cmd.Parameters.Add("@soyadi", soyadi.Value);
            cmd.Parameters.Add("@eposta", firma.Value);
            cmd.Parameters.Add("@dog_tar", sicilno.Value);
            cmd.Parameters.Add("@sifre", tcno.Value);
            cmd.Parameters.Add("@uniadi", birliksicilno.Value);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            Response.Redirect("login.aspx");
        }
        catch
        {
        }
    }
}