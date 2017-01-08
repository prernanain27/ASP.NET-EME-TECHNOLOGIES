using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class master_page_Default3 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Convert.ToInt32(Session["authorized"]) != 1)
        {
            Session.Clear();
            Application.Clear();
            Response.Redirect("studentlogindefault.aspx");
        }
        
    }
}