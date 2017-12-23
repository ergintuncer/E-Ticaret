using System;
using Npgsql;
namespace Admin
{
    public partial class Admin_kayit: System.Web.UI.Page
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
            try
            {
                //// sesion kontolü
                //if (Session["kullanici"] != null)
                //{
                //}
                //else
                //{
                //    Response.Redirect("login.aspx");
                //}


                listView_yukle();
                //postback
                if (!Page.IsPostBack)
                {

                    sil();

                }

            }
            catch
            {
                //hata yazdırılabilir
            }
        }

        protected void listView_yukle()
        {

            tSQL = "SELECT kisi_bilgi.ad  || ' ' || kisi_bilgi.soyad as ad_soyad,kisi_bilgi.firma, kisi_bilgi.tck, kisi_bilgi.kisiid,avukat_bilgi.sicilno,avukat_bilgi.birliksicilno,baro_bilgi.baroad,kisi_giris.bloke from kisi_bilgi INNER JOIN avukat_bilgi on kisi_bilgi.kisiid = avukat_bilgi.kisiid INNER JOIN kisi_giris on kisi_bilgi.kisiid = kisi_giris.kisiid INNER JOIN baro_bilgi on avukat_bilgi.baroid = baro_bilgi.baroid  WHERE kisi_giris.bloke=false";
            tCon.Open();
            tCommand.Connection = tCon;
            tCommand.CommandText = tSQL;
            tDataReader = tCommand.ExecuteReader();
            list2.DataSource = tDataReader;
            list2.DataBind();
            tCon.Close();


            //con.Open();
            //OleDbCommand cmd = new OleDbCommand(veri, con);
            //OleDbDataReader oku = cmd.ExecuteReader();
            //list1.DataSource = oku;
            //list1.DataBind();
            //con.Close();
        }


        string kisiid;
        string islem;
        int id2;
        void sil()
        {
            try
            {
                kisiid = Request.QueryString["kisiid"];
                islem = Request.QueryString["islem"];
                if (ID != null)
                {
                    id2 = int.Parse(kisiid);
                }

                if (islem == "sil")
                {
                    tSQL = "DELETE FROM kisi_bilgi WHERE kisiid=" + id2;
                    PublicExecuteNonQuery();

                }
                else if (islem == "ekle")
                {
                    tSQL = "UPDATE kisi_giris SET bloke=True   WHERE kisiid =" + id2;
                    PublicExecuteNonQuery();
                    successalert.Visible = true;

                }

                listView_yukle();
            }
            catch
            {

            }
        }

        protected void KullaniciOnayla_OnClick(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
        }

        protected void KullaniciSil_OnClick(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
        }
    }
}