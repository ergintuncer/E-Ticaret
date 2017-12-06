﻿using System;
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
        Session["kullanici"] = null;
        if (!Page.IsPostBack)
        {
            tSQL = "select baroAd from baro_bilgi";
            tCon.Open();
            tCommand.Connection = tCon;
            tCommand.CommandText = tSQL;
            tDataReader = tCommand.ExecuteReader();
            while (tDataReader.Read())
            {
                baro.Items.Add("" + tDataReader["baroAd"]);
            }
            tCon.Close();
        }
    }


    protected void gonder_Click(object sender, EventArgs e)
    {
        try
        {
            if (adi.Value.Trim() != "" && soyadi.Value.Trim() != "" && firma.Value.Trim() != "" && tcno.Value.Trim() != "" &&
                baro.SelectedValue.Trim() != "" && sicilno.Value.Trim() != "" && birliksicilno.Value.Trim() != "")
            {
                tSQL = "INSERT INTO kisi_bilgi(kisiturid,ad,soyad,firma,tck) VALUES ('" + "0" + "','" + adi.Value.Trim() +
                       "','" + soyadi.Value.Trim() + "','" + firma.Value.Trim() + "','" + tcno.Value.Trim() + "'); " +
                      
                       "INSERT INTO avukat_bilgi(kisiid,baroid,sicilno,birliksicilno) VALUES ((select max(kisiid) from kisi_bilgi), (select baroid from baro_bilgi where baroad='" +
                       baro.SelectedValue.Trim() + "'),'" + sicilno.Value.Trim() + "','" + birliksicilno.Value.Trim() + "'); " +
                      
                       "INSERT INTO kisi_giris(kisiid,sifre,bloke) VALUES ((select max(kisiid) from kisi_bilgi),(select tck from kisi_bilgi where tck='" +
                       tcno.Value.Trim() + "')::bytea,false);";

                PublicExecuteNonQuery();
                Response.Redirect("login.aspx");
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
}