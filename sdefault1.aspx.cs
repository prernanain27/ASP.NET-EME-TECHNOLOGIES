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
        if (Convert.ToInt32(Session["authorized"]) != 1)
        {
            Session.Clear();
            Application.Clear();
            Response.Redirect("studentlogindefault.aspx");
        }
        
       if (!IsPostBack)
        {
            var q = from f in md.TechLists
                    join k in md.StuTeches on f.iTechId equals k.iTechId
                    where k.sSID == Session["user"].ToString()
                    select new
                    {
                        
                        f.iTechId,
                        f.sTechnology,
                        k.sSID
                    };

            DropDownList1.DataSource = q;
            DropDownList1.DataBind();
            var p = from f in md.studentdatauploads
                    join k in md.TechLists on f.iTechId equals k.iTechId
                    where k.sTechnology == DropDownList1.SelectedItem.Text
                    orderby f.fId descending

                    select new
                    {

                        f.fName,
                        f.fDate,
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
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        var p = from f in md.studentdatauploads
                join k in md.TechLists on f.iTechId equals k.iTechId
                where k.sTechnology == DropDownList1.SelectedItem.Text
                orderby f.fId descending

                select new
                {

                    f.fName,
                    f.fDate,
               
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
    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DropDownList2.SelectedItem.ToString() == "Name")
        {
            TextBox1.Text = "";
           
            TextBox1.Visible = true;
        }
       
        if (DropDownList2.SelectedItem.ToString() == "Keyword")
        {
            TextBox1.Text = "";
            TextBox1.Visible = true;
        }
    }
    protected void TextBox1_TextChanged(object sender, EventArgs e)
    {
        if (DropDownList2.SelectedItem.ToString() == "Name")
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



           /* var p = from f in md.studentdatauploads where f.iTechId == Convert.ToInt32(DropDownList1.SelectedValue) select f;
            p = p.Where(x => x.fName.Contains(TextBox1.Text)).OrderByDescending(o => o.iTechId);
            GridView1.DataSource = p;
            GridView1.DataBind();*/
        }
       
    
    
       

        if (DropDownList2.SelectedItem.ToString() == "Keyword")
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

            
           /* var p = from f in md.studentdatauploads where f.iTechId == Convert.ToInt32(DropDownList1.SelectedValue) select f;
            p = p.Where(x => x.fPath.Contains(TextBox1.Text)).OrderByDescending(o => o.iTechId);
            GridView1.DataSource = p;
            GridView1.DataBind(); */
        }
       
}

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        var p = from f in md.studentdatauploads orderby f.fId descending where f.iTechId == Convert.ToInt32(DropDownList1.SelectedValue) select f;
        GridView1.DataSource = p;
        GridView1.DataBind();
      

    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Session["id"] = (sender as LinkButton).CommandArgument;
        Session.Remove("swffilename");
        Session["swffilename"] = "MyFile/" + Session["id"];
     //   Response.Redirect("aview2Default.aspx");
        ScriptManager.RegisterStartupScript(Page, typeof(Page), "popup", "window.open('viewfiledefault.aspx');", true);
    }
}
