using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            string veri = "select * from etkinlik";
            con.Open();
            OleDbCommand cmd = new OleDbCommand(veri, con);
            OleDbDataReader oku = cmd.ExecuteReader();
            list.DataSource = oku;
            list.DataBind();
            con.Close();
        }
        catch
        {
        }
    }

    OleDbConnection con =
        new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0; DATA Source=" +
                            HttpContext.Current.Server.MapPath("sosyal.mdb"));
}