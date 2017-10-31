using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Profil : System.Web.UI.Page
{
    string ID;
    string islem;
    int id2;
    OleDbConnection con =
        new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0; DATA Source=" +
                            HttpContext.Current.Server.MapPath("sosyal.mdb"));

    protected void Page_Load(object sender, EventArgs e)
    {
        try { 
        ID = Request.QueryString["ID"];
        islem = Request.QueryString["islem"];
        if (ID != null)
        {
            id2 = int.Parse(ID);
        }

        if (islem == "sil")
        {
            string veri = "delete  from paylasim where ID=" + id2 + "";
            con.Open();
            OleDbCommand cmd = new OleDbCommand(veri, con);
            cmd.ExecuteNonQuery();
            con.Close();

        }

        if (Session["kullanici"] != null)
        {
            string veri = "select * from kayit where eposta='" + Session["kullanici"] + "'";
            con.Open();
            OleDbCommand cmd = new OleDbCommand(veri, con);
            IDataReader oku = cmd.ExecuteReader();

            if (oku.Read())
            {
                lbladi.Text = "" + oku["adi"];
                lblsoyadi.Text = "" + oku["soyadi"];
                lbluniversitesi.Text = "" + oku["uni_adi"];
                profilresmi.ImageUrl = "" + oku["resim"];
                lblsehir.Text = "" + oku["memleket"];
                lblyasi.Text = "" + oku["dog_tar"];
                lblfakultesi.Text = "" + oku["fakulte"];
                lblbolumu.Text = "" + oku["bolum"];

                Session.Add("adi", oku["adi"]);

                Session.Add("soyadi", oku["soyadi"]);
            }

            con.Close();
        }
        else
        {
            Response.Redirect("login.aspx");
        }
        List();
        }
        catch
        {

        }
    }
    private string ToInt32(string v)
    {
        throw new NotImplementedException();
    }

    void List()
    {
        try { 
        string veri = "SELECT adi &' ' & soyadi as adi_soyadi, resim,ID,icerik,p_resim,tarih &' ' & saat as tarih_saat,begenmesayisi  FROM kayit, paylasim where kayit.eposta=paylasim.kul_adi and kayit.eposta='" +Session["kullanici"] + "' order by tarih desc,saat desc";
        con.Open();
        OleDbCommand cmd = new OleDbCommand(veri, con);
        OleDbDataReader oku = cmd.ExecuteReader();
        list1.DataSource = oku;
        list1.DataBind();
        con.Close();
        }
        catch
        {

        }
    }

    protected void imgPaylasimiBegenButton_Click(object sender, ImageClickEventArgs e)
    {
    }
}