using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class master_page_Default2 : System.Web.UI.Page
{
    DataClassesDataContext md = new DataClassesDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void login_Click(object sender, EventArgs e)
    {
        var q = (from f in md.StuTables where f.sSID == TextBox1.Text select f.sPassword).SingleOrDefault();

        if (Convert.ToString(q) == TextBox2.Text)
        {
            Session["authorized"] = 1;
            Session["user"] = TextBox1.Text;
          Response.Redirect("sdefault.aspx");
         //   ScriptManager.RegisterStartupScript(Page, typeof(Page), "popup", "window.open('sdefault.aspx');", true);
        }
        else
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "popup", "alert('invalid username or password');", true);
        }
    }
}