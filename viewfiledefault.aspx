﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="viewfiledefault.aspx.cs" Inherits="viewfiledefault" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
     <object classid="clsid:D27CDB6E-AE6D-11cf-96B8-444553540000" codebase="http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=7,0,19,0"
                                    width="200" height="100">
                                    <param name="movie" value="<% =swfFileName%>" />
                                    <param name="quality" value="high" />
                                    <embed src="<% =swfFileName%>" quality="high" pluginspage="http://www.macromedia.com/go/getflashplayer"
                                        type="application/x-shockwave-flash" width="1100" height="900"></embed>
                                </object>

    
    </div>
    </form>
</body>
</html>
