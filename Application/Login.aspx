<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Login.aspx.vb" Inherits="Login"
    Title="Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="css/style.css" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <asp1:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true">
            <Scripts>
                <asp1:ScriptReference Path="~/JavaScripts/Script.js" />
            </Scripts>
        </asp1:ScriptManager>
        <div id="page" align="center">
            <div id="toppage" align="center">
                <div id="date">
                    <div class="smalltext" style="padding: 13px;">
                        <strong>
                            <asp:Label ID="currentdt" runat="server" Text="Label" EnableTheming="false"></asp:Label></strong></div>
                </div>
                <div id="topbar">
                    <div align="right" style="padding: 12px;" class="smallwhitetext">
                        <marquee>“Climbing to the top demands strength, whether it is to the top of Mount Everest or to the top of your career.”&nbsp &nbsp  by &nbsp Dr.&nbsp A. &nbsp P. &nbsp J. &nbsp Abdul Kalam &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp  "To teach is to learn twice"&nbsp &nbsp by Joseph Joubert &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp  "The secret in education lies in respecting the student" &nbsp &nbsp Ralph Waldo Emerson</marquee>
                    </div>
                </div>
            </div>
            <div id="header" align="center">
                <div id="pagetitle">
                    <div id="title" class="titletext" align="right">
                    </div>
                </div>
                <div id="topmenu" align="center">
                    <div id="linksmenu" align="center">
                        <asp:Menu ID="Menu1" runat="server" Orientation="Horizontal">
                        </asp:Menu>
                    </div>
                </div>
            </div>
            <div id="content" align="center">
                <div id="sidelinksmenu" align="left">
                    <asp:Menu ID="Menu2" runat="server">
                    </asp:Menu>
                </div>
                <div id="bodydiv2" class="bodytext" style="height: 400PX;">
                    <div>
                        <table runat="server" id="tblLogin" border="0" width="100%">
                            <tr style="height: 100PX;">
                                <td style="width: 695px; height: 40px" colspan="1">
                                    &nbsp;</td>
                                <td align="left">
                                    <br />
                                    <br />
                                    <br />
                                    <br />
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: Right; width: 695px;">
                                    <asp:Label ID="Label1" runat="server" Text="User ID" EnableTheming="false" Font-Names="Sans-Serif"
                                        Font-Underline="false" ForeColor="#000000" Font-Size="10pt"></asp:Label>
                                </td>
                                <td style="text-align: left; width: 693px">
                                    <asp:TextBox ID="userid" runat="server" Columns="20"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: Right; width: 695px;">
                                    <asp:Label ID="Label2" runat="server" Text="Password" EnableTheming="False" Font-Names="Sans-Serif"
                                        Font-Underline="False" ForeColor="Black" Font-Size="10pt" Width="79px"></asp:Label></td>
                                <td style="text-align: left;">
                                    <asp:TextBox ID="Password" TextMode="Password" runat="server" Columns="20"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                            </tr>
                            <tr>
                            </tr>
                            <tr>
                            </tr>
                            <tr>
                            </tr>
                            <tr>
                            </tr>
                            <tr>
                                <td align="left" colspan="3" style="width: 693px">
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                                    &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                                    &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                                    <asp:Button ID="btnLogin" runat="server" CommandName="Login" Text="Log In" ValidationGroup="lgMyLogin" />
                                    &nbsp;&nbsp
                                    <asp:Button ID="btnCancel" runat="server" CommandName="Cancel" Text="Cancel" ValidationGroup="lgMyLogin"
                                        OnClientClick="javascript:self.close()" />
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
            </div>
            <br />
            <div id="footer" class="smallgraytext" align="center">
                Project By Santosh Dubey & Almin Pogalva<br />
            </div>
        </div>
    </form>
</body>
</html>
