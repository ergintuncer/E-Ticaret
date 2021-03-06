﻿using System;
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


    
    static int[] TilID = new int[1000];
    static int[] TilceID = new int[15000];
    static int i=0 ,j= 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        listView_yukle();
        bloke();
        if (!Page.IsPostBack)
        {
           
            tSQL = "select ilad,ilid from il_bilgi order by ilad asc";
            tCon.Open();
            tCommand.Connection = tCon;
            tCommand.CommandText = tSQL;
            tDataReader = tCommand.ExecuteReader();
            while (tDataReader.Read())
            {
                drpil.Items.Add("" + tDataReader["ilad"]);
                TilID[i] = Convert.ToInt16(tDataReader["ilid"]) ;
                //txtaciklama.Text = txtaciklama.Text + TilID[i];
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

        

        if (txtadliyeadi.Text.Length != 0)
        {
            if (drpil.SelectedIndex !=-1)
            {
                if (drpilce.SelectedIndex != -1)
                {
                    tSQL = "INSERT INTO adliye_bilgi(adliyead,aktif,ilid,ilceid) VALUES ('" + txtadliyeadi.Text.Trim() + "' , " + tAktif + "," + TilID[drpil.SelectedIndex] + "," + TilceID[drpilce.SelectedIndex] + ");";
                    tSQL += "INSERT INTO adliye_adres(adliyeid,adliyeadresad,adres,aciklama,aktif) VALUES ((select max(adliyeid) from adliye_bilgi),'" + txtadresadi.Text.Trim() + "' , '" + txtadres.Text.Trim() + "','" + txtaciklama.Text.Trim() + "',true);";
                    PublicExecuteNonQuery();
                    listView_yukle();

                    //lblacik.Visible = true;
                    //lblacik.Text = "Değişiklik gerçekleştirildi.";

                    lblacik.Text = "Kaydedildi....";
                    successalert.Visible = true;

                    txtadliyeadi.Text = "";
                    txtaciklama.Text = "";
                    txtadres.Text = "";
                    txtadresadi.Text = "";
                    drpil.SelectedIndex = 0;
                    drpilce.SelectedIndex = 0;


                }
                else
                {
                    lblacik.Text = "Lütfen İlçe Seçiniz.";
                    successalert.Visible = true;
                }
               
            }
            else
            {
                lblacik.Text = "Lütfen İl Seçiniz.";
                successalert.Visible = true;
            }
           
        }
        else
        {
            lblacik.Text = "Lütfen Adliye Adını Giriniz.";
            successalert.Visible = true;
        }

       
          
       

        //throw new NotImplementedException();
    }
    protected void Aktiflik_OnClick(object sender, EventArgs e)
    {
        //throw new NotImplementedException();
    }

   


    protected void listView_yukle()
    {

        tSQL = "select adliye_bilgi.adliyead, adliye_adres.adliyeadresad,adliye_adres.adres,adliye_adres.aciklama,adliye_bilgi.aktif,il_bilgi.ilad,ilce_bilgi.ilcead, adliye_bilgi.adliyeid,adliye_bilgi.aktif from adliye_bilgi INNER JOIN adliye_adres on adliye_bilgi.adliyeid=adliye_adres.adliyeid INNER JOIN il_bilgi on adliye_bilgi.ilid=il_bilgi.ilid INNER JOIN ilce_bilgi on adliye_bilgi.ilceid=ilce_bilgi.ilceid   ";
        tCon.Open();
        tCommand.Connection = tCon;
        tCommand.CommandText = tSQL;
        tDataReader = tCommand.ExecuteReader();
        list2.DataSource = tDataReader;
        list2.DataBind();
        tCon.Close();


    }


    

    protected void drpil_OnSelectedIndexChanged2(object sender, EventArgs e)
    {
        

        //drpilce.Items.Clear();
        //tSQL = "select ilcead,ilceid from ilce_bilgi where ilid=" + TilID[drpil.SelectedIndex];
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

    }


    string kisiid;
    string islem;
    int id2;
    bool tAktifMi;
    void bloke()
    {
        kisiid = Request.QueryString["kisiid"];
        islem = Request.QueryString["islem"];

        

       
        if (kisiid != null)
        {
            id2 = int.Parse(kisiid);


            tSQL = "select aktif  from adliye_bilgi where adliyeid=" + id2;
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


        if (islem == "bloke")
        {
            if (tAktifMi ==true)
            {
                tSQL = "UPDATE adliye_bilgi set aktif=false WHERE adliyeid=" + id2;
                PublicExecuteNonQuery();
                successalert.Visible = true;
                lblacik.Text = "Değişiklik gerçekleştirildi.";
            }
            else
            {
                tSQL = "UPDATE adliye_bilgi set aktif=true WHERE adliyeid=" + id2;
                PublicExecuteNonQuery();
                successalert.Visible = true;
                lblacik.Text = "Değişiklik gerçekleştirildi.";
            }
           

        }

        listView_yukle();
    }


    //protected void txtadliyeadi_OnTextChanged(object sender, EventArgs e)
    //{

        


    //}

    //protected void drpil_OnTextChanged(object sender, EventArgs e)
    //{
    //    throw new NotImplementedException();
    //}
    protected void txtadliyeadi_OnTextChanged(object sender, EventArgs e)
    {

        tSQL = "SELECT count(*) from adliye_bilgi WHERE adliyead='" + txtadliyeadi.Text.Trim() + "'";
       
        if (PublicExecuteScalarInteger() > (Int32)0)
        {
            lblOnTextChanged.Text = "Adliye adı daha önce kaydedilmiş...";
            lblOnTextChanged.Visible = true;
            //successalert.Visible = true;
            //lblOnTextChanged.Text = "Böyle bir baro adı bulunmaktadır..";
            //btnKaydet.Visible = true;
            //pnlProfil.Visible = true;
        }
        else
        {
            lblOnTextChanged.Text = "yok";
            lblOnTextChanged.Visible = false;
            //successalert.Visible = false;
            //lblOnTextChanged.Visible = false;
            //lblOnTextChanged.Text = "";
            //.Visible = false;
            //pnlProfil.Visible = true;
        }

        //throw new NotImplementedException();
    }

    protected void drpil_OnTextChanged(object sender, EventArgs e)
    {

        drpilce.Items.Clear();
        tSQL = "select ilcead,ilceid from ilce_bilgi where ilid=" + TilID[drpil.SelectedIndex];
        tCon.Open();
        tCommand.Connection = tCon;
        tCommand.CommandText = tSQL;
        tDataReader = tCommand.ExecuteReader();
        while (tDataReader.Read())
        {
            drpilce.Items.Add("" + tDataReader["ilcead"]);
            TilceID[j] = Convert.ToInt16(tDataReader["ilceid"]);
            j++;
        }
        tCon.Close();

    }
}