<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="GraphDraw_webpage._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>GraphDraw</title>
</head>
<body style="background-color: Black">
    <form id="form1" runat="server">
    <div style="text-align: center">
        <span style="background-color: #000000; color: #ff0000;"><span style="font-size: 32pt" title="GraphDraw">
            <asp:Label ID="Label1" runat="server" Style="font-size: 100px" Text="GraphDraw"></asp:Label><br />
            <br />
            &nbsp;<asp:Image ID="Image1" runat="server" ImageUrl="images/image01.jpg" /><br />
            <span style="color: #ffcc33">GraphDraw 1.0.0 30-day trial</span>
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="setup.exe">Download</asp:HyperLink><br />
            <br />
            <span style="color: #ffff33">To get an <span style="color: #ff0033">Activation Code</span>
                contact:</span>
            <asp:HyperLink ID="HyperLink2" runat="server" style="color: blue">mdavid626@gmail.com</asp:HyperLink><br />
        </span>
        </span></div>
    </form>
</body>
</html>
