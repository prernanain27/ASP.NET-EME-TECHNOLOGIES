using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class viewfiledefault : System.Web.UI.Page
{
    public string swfFileName = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Convert.ToInt32(Session["authorized"]) != 1)
        {
            Session.Clear();
            Application.Clear();
            Response.Redirect("default.aspx");
        }
        string id = Session["id"].ToString();
        string s = Session["swffilename"].ToString();
        swfFileName = s;

    }

}