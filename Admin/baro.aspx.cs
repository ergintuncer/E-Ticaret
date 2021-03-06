﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Npgsql;
public partial class Admin_Baro : System.Web.UI.Page
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
        int tInteger = 0;
        if (tCon.State == System.Data.ConnectionState.Open)
        {
            tCon.Close();
        }
        tCon.Open();
        tCommand.CommandType = System.Data.CommandType.Text;
        tCommand.CommandTimeout = 60000;
        tCommand.CommandText = tSQL;
        if (tCommand.ExecuteScalar() != DBNull.Value)
        {
            tInteger = Convert.ToInt32(tCommand.ExecuteScalar());
        }
        tCon.Close();
        return tInteger;
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


    protected void Page_Load(object sender, EventArgs e)
    {
        listView_yukle();

        if (!Page.IsPostBack)
        {

            aktif();

        }
       


    }
    protected void btnKaydet_Onclick(object sender, EventArgs e)
    {
        Boolean tAktif = false;

        if (CheckBox1.Checked == true)
        {
            tAktif = true;
        }

        if (txtbaroadi.Text != "")
        {
           tSQL= "INSERT INTO baro_bilgi(baroad,aktif) VALUES ('" + txtbaroadi.Text.Trim()  + "' , "+ tAktif +");";
            PublicExecuteNonQuery();
            //lblMesaj.Text = "Kaydedildi...";
            //lblMesaj.Visible = true;
            txtbaroadi.Text = "";
            successalert.Visible = true;
            lblacik.Text = "Kaydedildi";
        }
        else
        {
           
            successalert.Visible = true;
            lblacik.Text = "Lütfen Baro Adını Giriniz";

        }
      
        //throw new NotImplementedException();
    }
    protected void Aktiflik_OnClick(object sender, EventArgs e)
    {
        //throw new NotImplementedException();
    }


    protected void listView_yukle()
    {

        tSQL = "select baroid,baroad,aktif from baro_bilgi order by baroad asc";
        tCon.Open();
        tCommand.Connection = tCon;
        tCommand.CommandText = tSQL;
        tDataReader = tCommand.ExecuteReader();
        list2.DataSource = tDataReader;
        list2.DataBind();
        tCon.Close();


      
    }

    string baroid;
    string islem;
    int id2;
    bool tAktifMi;
    void aktif()
    {
        
            baroid = Request.QueryString["baroid"];
            islem = Request.QueryString["islem"];


            if (baroid != null)
            {
                id2 = int.Parse(baroid);

            tSQL = "select aktif  from baro_bilgi where baroid=" + id2;
            tCon.Open();
            tCommand.Connection = tCon;
            tCommand.CommandText = tSQL;
            object tAktifMiObj = tCommand.ExecuteScalar();
            var testAktif = tAktifMiObj as bool?;
            if (testAktif.HasValue)
            {
                tAktifMi = testAktif.Value;
            }

            tCon.Close();
            

            }

        if (islem == "aktif")
        {
            if (tAktifMi == true)
            {
                tSQL = "UPDATE baro_bilgi set aktif=false where baroid=" + id2;
                PublicExecuteNonQuery();
                successalert.Visible = true;
                lblacik.Text = "değişiklik gerçelştirildi";
            }
            else
            {
                tSQL = "UPDATE baro_bilgi set aktif=true where baroid=" + id2;
                PublicExecuteNonQuery();
                successalert.Visible = true;
                lblacik.Text = "değişiklik gerçelştirildi";
            }
        }
       
                

            
           

            listView_yukle();
       

        
    }


    //protected void baroAdi_OnTextChanged(object sender, EventArgs e)
    //{
        
    //}


    public void txtbaroadi_TextChanged(object sender, EventArgs e)
    {
        tSQL = "SELECT count(*) from baro_bilgi WHERE baroad='" + txtbaroadi.Text.Trim() + "'";
       
        if (PublicExecuteScalarInteger() > (Int32)0)
        {
            lblOnTextChanged.Visible = true;
            lblOnTextChanged.Text = "Böyle bir baro adı bulunmaktadır..";
            //btnKaydet.Visible = true;
            //pnlProfil.Visible = true;
        }
        else
        {
            lblOnTextChanged.Visible = false;
            lblOnTextChanged.Text = "";
            //.Visible = false;
            //pnlProfil.Visible = true;
        }
    }
}