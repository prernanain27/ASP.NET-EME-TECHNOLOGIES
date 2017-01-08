<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="mlogindefault.aspx.cs" Inherits="master_page_Default" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <center>
<form id="Form1" runat="server">
<marquee>Welcome To EME Technologies Admin login</marquee>
<div class="grid_5">

<h2 class="head1 h1">
                Welcome Administrator</h2>
               
                
    <img src="images/anigif.gif" />
    
    </div>

    <br />
<br />
<br />
<br />
<br />
<br />
<br />
<br />
<br />
<br />
<br />


<asp:Label ID="Label1" runat="server" Text="Admin LogIn" Font-Bold="True" 
    Font-Italic="False" Font-Size="Medium"></asp:Label>
<br />
<br />
<asp:Label ID="adminid" runat="server" Text="Admin" Font-Bold="True" 
    Font-Italic="False" Font-Size="Medium"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<asp:TextBox ID="TextBox1" runat="server" Height="25px" Width="194px" Font-Bold="True"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
        ControlToValidate="TextBox1" ErrorMessage="Enter username" Font-Size="XX-Large" 
        ForeColor="Red">*</asp:RequiredFieldValidator>
<br />
<br />
<asp:Label ID="passid" runat="server" Text="Password" Font-Bold="True" 
    Font-Size="Medium"></asp:Label>
&nbsp;&nbsp;
<asp:TextBox ID="TextBox2" runat="server" TextMode="Password" Height="24px" Width="194px"></asp:TextBox>
<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
        ControlToValidate="TextBox2" ErrorMessage="Enter password" Font-Bold="True" 
        Font-Italic="True" Font-Size="XX-Large" ForeColor="Red">*</asp:RequiredFieldValidator>
<br />
<br />


&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<asp:Button ID="login" runat="server" Height="34px" Text="LogIn" 
    Width="105px" Font-Bold="True" Font-Size="Medium" onclick="login_Click"  />
<br />
    </form>
    </center>
</asp:Content>

