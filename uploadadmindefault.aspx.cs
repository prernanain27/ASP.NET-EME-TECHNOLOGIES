using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

public partial class master_page_Default : System.Web.UI.Page
{
    DataClassesDataContext md = new DataClassesDataContext();
    studentdataupload sd = new studentdataupload();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Convert.ToInt32(Session["authorized"]) != 1)
        {
            Session.Clear();
            Application.Clear();
            Response.Redirect("default.aspx");
        }
        if (!IsPostBack)
        {
            var q = from f in md.TechLists
                    select new
                    {
                        f.iTechId,
                        f.sTechnology
                    };
            if (q.Count() <= 0)
            { }
            else
            {
                DropDownList1.DataSource = q;
                DropDownList1.DataBind();
            }
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        
        

        try
        {
            string filename = "";
            if (FileUpload1.HasFile == false)
            {
                throw new Exception("Please choose a swf file");
            }
            else
            {
                string ext = Path.GetExtension(FileUpload1.FileName);


                if (ext == ".swf" || ext == ".SWF")
                {
                    int value = 0;
                    var n = from g in md.studentdatauploads select g.fId;
                  if (n.Count() > 0)
                    {

                        var m = (from g in md.studentdatauploads select g.fId).Max();
                        value = Convert.ToInt32(m);
                   
                  }
                    else
                    {

                        value = value + 1;
                    }
                    if (TextBox2.Text == "")
                    {

                        filename = Convert.ToString(value + 1) + FileUpload1.FileName;
                        sd.fName = filename;

                    }
                    else
                    {

                        filename = TextBox2.Text + Convert.ToString(value + 1) + ".swf";
                        sd.fName = filename;
                    }

                }
                else
                {
                    throw new Exception("Please choose a swf file.");
                }



                FileUpload1.SaveAs(Server.MapPath("Myfile\\") + filename);
                if (TextBox1.Text == "")
                {
                       sd.fPath = "No Description";
                }
                else
                {
                    sd.fPath = TextBox1.Text;
                }

                sd.iTechId = Convert.ToInt32(DropDownList1.SelectedValue);
                sd.fDate = Convert.ToDateTime(DateTime.Now.ToShortDateString()).ToString("dd/MM/yyyy");
                md.studentdatauploads.InsertOnSubmit(sd);
                md.SubmitChanges();

                ScriptManager.RegisterStartupScript(Page, typeof(Page), "Popup", "alert('Submitted sucessfully');", true);

            }
        }
        catch(Exception ex)
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "Popup", "alert('"+ex.Message+"');", true);
        }

        TextBox1.Text = "";
        TextBox2.Text = "";
        DropDownList1.SelectedValue = "--select--";
        
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
       
    }
}