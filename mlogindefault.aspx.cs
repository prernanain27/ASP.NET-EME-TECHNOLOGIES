using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
public partial class master_page_Default : System.Web.UI.Page
{
    DataClassesDataContext md = new DataClassesDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {

        
    }
    
   
    
    protected void login_Click(object sender, EventArgs e)

    {
        

        var q = (from f in md.AdminTables where f.Name == TextBox1.Text select f.password).SingleOrDefault();
       
        if(Convert.ToString(q)==TextBox2.Text)
       
        {
            Session["authorized"] = 1;
            Session["user"] = TextBox1.Text;
            Response.Redirect("adefault1.aspx");
        }
        else
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "popup", "alert('invalid username or password');", true);
        }
    }
 
}
    