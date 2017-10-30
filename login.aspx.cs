using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using Npgsql;

public partial class login : System.Web.UI.Page
{

    NpgsqlConnection tCon = new NpgsqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["NpgsqlConnectionStrings"].ConnectionString);
    NpgsqlCommand tCommand = new NpgsqlCommand();
    NpgsqlDataReader tDataReader;
    String tSQL;
    protected void Page_Load(object sender, EventArgs e){
    }

    OleDbConnection con =
        new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0; DATA Source=" +
                            HttpContext.Current.Server.MapPath("sosyal.mdb"));

    protected void giris_Click(object sender, EventArgs e){

        tCon.Open();
        

        tCon.Close();


        //tSQL = "SELECT * FROM version"
        //tCommand = New NpgsqlCommand(tSQL, tCon)
        //tCon.Open()
        //tDataReader = tCommand.ExecuteReader
        //While tDataReader.Read
        //    tVersionOffline = tDataReader("offlineversion")
        //    tVersionOfflineDate = tDataReader("offlineversiondate")
        //    tVersionDB = tDataReader("dbversion")
        //End While
        //tCon.Close()
        //try{
        //    string veri = "select * from kayit where eposta='" + kullaniciadi.Text + "' and sifre='" + sifre.Text + "'";
        //    con.Open();
        //    OleDbCommand cmd = new OleDbCommand(veri, con);
        //    OleDbDataReader oku = cmd.ExecuteReader();
        //    if (oku.Read()){
        //        if (kullaniciadi.Text == "123"){
        //            Session.Add("kullanici", kullaniciadi.Text);
        //            Response.Redirect("admin.aspx");
        //        }
        //        else{

        //        }
        Session.Add("kullanici", 1);
        Response.Redirect("admin.aspx");
        //    }
        //    else{
        //        lbl1.Visible = true;
        //        lbl1.Text = "şifre veya Kullanici adı hatalı!!!";
        //    }
        //}
        //catch{
        //    lbl1.Visible = true;
        //    lbl1.Text = "Bir Hata oluştu.Lütfen tekrar deneyiniz.";
        //}
    }

    protected void kayitol_Click(object sender, EventArgs e){
        Response.Redirect("kayıt.aspx");
    }
}