using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.IO;
using System.Web.UI.WebControls;

public partial class master_page_Default : System.Web.UI.Page
{
    DataClassesDataContext md = new DataClassesDataContext();
    studentdataupload sd = new studentdataupload();
    int flag = 0;
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
           
            if (Convert.ToInt32(Session["authorized"]) != 1)
            {
                Session.Clear();
                Application.Clear();
                Response.Redirect("mlogindefault.aspx");
            }

            else
            {

                if (DropDownList1.SelectedItem.Text == "--SelectAll--")
                {
                    var p = from f in md.studentdatauploads
                            join k in md.TechLists on f.iTechId equals k.iTechId
                            orderby f.fId descending

                            select new
                            {

                                f.fName,
                                f.fDate,
                                f.fId,
                                f.fPath,
                                k.sTechnology

                            };
                    if (p.Count() <= 0)
                    {
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "popup", "alert('NO FIES IN TECHNOLOGIES');", true);
                    }
                    else
                    {
                        GridView1.DataSource = p;
                        GridView1.DataBind();

                    }

                }
                
      

      
                    var q = from f in md.TechLists select f;

                    DropDownList1.DataSource = q;
                    DropDownList1.DataBind();
             
            }

                 
        }
               
    }


   
   
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Session["id"] = (sender as LinkButton).CommandArgument;
        Session["swffilename"] = "MyFile/" + Session["id"];

         ScriptManager.RegisterStartupScript(Page, typeof(Page), "popup", "window.open('viewfiledefault.aspx');", true);
      
       
         
    }
    protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
    {
            foreach (GridViewRow row in GridView1.Rows)
            {
                if (((CheckBox)row.FindControl("CheckBox1")).Checked)
                {
                    flag = 1;
                }
                else
                {
                    flag = 0;
                    break;
                }
            }
            if (flag == 0)
            {
                ((CheckBox)GridView1.HeaderRow.FindControl("CheckBox2")).Checked = false;
            }
            else
            {
                ((CheckBox)GridView1.HeaderRow.FindControl("CheckBox2")).Checked = true;
            }
        
    }
    protected void CheckBox2_CheckedChanged(object sender, EventArgs e)
    {
            if (((CheckBox)GridView1.HeaderRow.FindControl("CheckBox2")).Checked)
            {
                foreach (GridViewRow row in GridView1.Rows)
                {
                    ((CheckBox)row.FindControl("CheckBox1")).Checked = true;
                }
            }
            else
            {
                foreach (GridViewRow row in GridView1.Rows)
                {
                    ((CheckBox)row.FindControl("CheckBox1")).Checked = false;
                }
            }
        
    }
   
   


    protected void deletebtn_Click(object sender, EventArgs e)
    {
            foreach (GridViewRow row in GridView1.Rows)
            {
                if (((CheckBox)row.FindControl("CheckBox1")).Checked)
                {
                    studentdataupload sd = md.studentdatauploads.First(p => p.fId == Convert.ToInt32(((Label)row.FindControl("Label5")).Text));
                           System.IO.File.Delete(Server.MapPath("Myfile\\") + sd.fName);
                    md.studentdatauploads.DeleteOnSubmit(sd);
                    md.SubmitChanges();


                }

            }

            if (DropDownList1.SelectedItem.Text == "--SelectAll--")
            {
                var p = from f in md.studentdatauploads
                        join k in md.TechLists on f.iTechId equals k.iTechId
                        orderby f.fId descending

                        select new
                        {

                            f.fName,
                            f.fDate,
                            f.fId,
                            f.fPath,
                            k.sTechnology

                        };
               
                
                if (p.Count() <= 0)
                {
                    GridView1.Visible = false;
                    //ScriptManager.RegisterStartupScript(Page, typeof(Page), "popup", "alert('No files found.');", true);
                }
                else
                {
                    
                    
                    GridView1.Visible = true;
                    GridView1.DataSource = p;
                    GridView1.DataBind();

                }
            }

            else
            {
                var p = from f in md.studentdatauploads
                        join k in md.TechLists on f.iTechId equals k.iTechId
                        where k.sTechnology == DropDownList1.SelectedItem.Text
                        orderby f.fId descending

                        select new
                        {

                            f.fName,
                            f.fDate,
                            f.fId,
                            f.fPath,
                            k.sTechnology

                        };
                if (p.Count() <= 0)
                {
                    GridView1.Visible = false;
                }
                else
                {
                    GridView1.Visible = true;
                    GridView1.DataSource = p;
                    GridView1.DataBind();

                }


            }
        
    }

    protected void deletelinkbtn_Click(object sender, EventArgs e)
    {
            string id = (sender as LinkButton).CommandArgument;
            studentdataupload sd = md.studentdatauploads.First(p => p.fId == Convert.ToInt32(id));
            System.IO.File.Delete(Server.MapPath("Myfile\\") + sd.fName);
            md.studentdatauploads.DeleteOnSubmit(sd);
            md.SubmitChanges();

            ScriptManager.RegisterStartupScript(Page, typeof(Page), "popup", "alert('deleted successfully');", true);
            if (DropDownList1.SelectedItem.Text == "--SelectAll--")
            {
                var p = from f in md.studentdatauploads
                        join k in md.TechLists on f.iTechId equals k.iTechId
                        orderby f.fId descending

                        select new
                        {

                            f.fName,
                            f.fDate,
                            f.fId,
                            f.fPath,
                            k.sTechnology

                        };
                if (p.Count() <= 0)
                {
                   // ScriptManager.RegisterStartupScript(Page, typeof(Page), "popup", "alert('Deleted successfully');", true);
                }
                else
                {
                    GridView1.DataSource = p;
                    GridView1.DataBind();

                }
            }

            else
            {
                var p = from f in md.studentdatauploads
                        join k in md.TechLists on f.iTechId equals k.iTechId
                        where k.sTechnology == DropDownList1.SelectedItem.Text
                        orderby f.fId descending

                        select new
                        {

                            f.fName,
                            f.fDate,
                            f.fId,
                            f.fPath,
                            k.sTechnology

                        };
                if (p.Count() <= 0)
                {
                }
                else
                {
                    GridView1.DataSource = p;
                    GridView1.DataBind();

                }


            }
    
        
    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        var q = from f in md.studentdatauploads orderby f.fId descending select f;

        GridView1.DataSource = q;
        GridView1.DataBind();

    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {

        if (DropDownList1.SelectedItem.Text == "--SelectAll--")
        {
            var p = from f in md.studentdatauploads
                    join k in md.TechLists on f.iTechId equals k.iTechId
                    orderby f.fId descending

                    select new
                    {

                        f.fName,
                        f.fDate,
                        f.fId,
                        f.fPath,
                        k.sTechnology

                    };
            if (p.Count() <= 0)
         
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "popup", "alert('NO FIES IN THIS TECHNOLOGY');", true);
            }
            else
            {
                GridView1.DataSource = p;
                GridView1.DataBind();

            }

        }
        else
        {


            var p = from f in md.studentdatauploads
                    join k in md.TechLists on f.iTechId equals k.iTechId
                    orderby f.fId descending
                    where f.iTechId == Convert.ToInt32(DropDownList1.SelectedValue)
                    select new
                    {

                        f.fName,
                        f.fDate,
                        f.fId,
                        f.fPath,
                        k.sTechnology

                    };
            if (p.Count() <= 0)
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "popup", "alert('NO FIES IN THIS TECHNOLOGY');", true);
            }
            else
            {
                GridView1.DataSource = p;
                GridView1.DataBind();

            }
        }
        
    }
    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    {
            if (DropDownList2.SelectedItem.Text == "Name")
            {
                TextBox1.Text = "";

                TextBox1.Visible = true;
            }

            if (DropDownList2.SelectedItem.Text == "Keyword")
            {
                TextBox1.Text = "";
                TextBox1.Visible = true;
            }
        
    }
    protected void TextBox1_TextChanged(object sender, EventArgs e)
    {
        if (DropDownList2.SelectedItem.Text == "Name")
        {

            if (DropDownList1.SelectedItem.Text == "--SelectAll--")
            {
                var p = from f in md.studentdatauploads
                        join k in md.TechLists on f.iTechId equals k.iTechId
                        orderby f.fId descending

                        select new
                        {

                            f.fName,
                            f.fDate,
                            f.fId,
                            f.fPath,
                            k.iTechId,
                            k.sTechnology

                        };


                p = p.Where(x => x.fName.Contains(TextBox1.Text)).OrderByDescending(o => o.iTechId);

                if (p.Count() <= 0)
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "popup", "alert('NO FIES IN TECHNOLOGIES');", true);
                }
                else
                {
                    GridView1.DataSource = p;
                    GridView1.DataBind();

                }

            }
            else
            {
                var p = from f in md.studentdatauploads
                        join k in md.TechLists on f.iTechId equals k.iTechId
                        where k.iTechId==Convert.ToInt32( DropDownList1.SelectedValue)
                        orderby f.fId descending

                        select new
                        {

                            f.fName,
                            f.fDate,
                            f.fId,
                            f.fPath,
                            k.iTechId,
                            k.sTechnology

                        };


                p = p.Where(x => x.fName.Contains(TextBox1.Text)).OrderByDescending(o => o.iTechId);

                if (p.Count() <= 0)
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "popup", "alert('NO FIES IN TECHNOLOGIES');", true);
                }
                else
                {
                    GridView1.DataSource = p;
                    GridView1.DataBind();

                }


            }

          /*  var p = from f in md.studentdatauploads where f.iTechId == Convert.ToInt32(DropDownList1.SelectedValue) select f;
            p = p.Where(x => x.fName.Contains(TextBox1.Text)).OrderByDescending(o => o.iTechId);
            GridView1.DataSource = p;
            GridView1.DataBind();*/
        }

       /* else
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "popup", "alert('NO FIES FOUND');", true);
        }*/





        if (DropDownList2.SelectedItem.Text == "Keyword")
        {

            if (DropDownList1.SelectedItem.Text == "--SelectAll--")
            {
                var p = from f in md.studentdatauploads
                        join k in md.TechLists on f.iTechId equals k.iTechId
                        orderby f.fId descending

                        select new
                        {

                            f.fName,
                            f.fDate,
                            f.fId,
                            f.fPath,
                            k.iTechId,
                            k.sTechnology

                        };


                p = p.Where(x => x.fPath.Contains(TextBox1.Text)).OrderByDescending(o => o.iTechId);

                if (p.Count() <= 0)
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "popup", "alert('NO FIES IN TECHNOLOGIES');", true);
                }
                else
                {
                    GridView1.DataSource = p;
                    GridView1.DataBind();

                }

            }
            else
            {
                var p = from f in md.studentdatauploads
                        join k in md.TechLists on f.iTechId equals k.iTechId
                        where k.iTechId == Convert.ToInt32(DropDownList1.SelectedValue)
                        orderby f.fId descending

                        select new
                        {

                            f.fName,
                            f.fDate,
                            f.fId,
                            f.fPath,
                            k.iTechId,
                            k.sTechnology

                        };


                p = p.Where(x => x.fPath.Contains(TextBox1.Text)).OrderByDescending(o => o.iTechId);

                if (p.Count() <= 0)
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "popup", "alert('NO FIES IN TECHNOLOGIES');", true);
                }
                else
                {
                    GridView1.DataSource = p;
                    GridView1.DataBind();

                }

            }

          /*  var p = from f in md.studentdatauploads where f.iTechId == Convert.ToInt32(DropDownList1.SelectedValue) select f;
            p = p.Where(x => x.fPath.Contains(TextBox1.Text)).OrderByDescending(o => o.iTechId);
            GridView1.DataSource = p;
            GridView1.DataBind();*/
        }
        /*else 
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "popup", "alert('NO FIES FOUND');", true);
        }*/
    }
}