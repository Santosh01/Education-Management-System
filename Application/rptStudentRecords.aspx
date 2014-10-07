<%@ Page Language="VB" MasterPageFile="~/Main.master" AutoEventWireup="false" CodeFile="rptStudentRecords.aspx.vb"
    Inherits="rptStudentRecords" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=10.2.3600.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <head id="Head1">
        <title>Student Leave Summary</title>
        <link rel="stylesheet" href="css/style.css" type="text/css" />
    </head>
    <div id="bodydiv">
        <div id="Div1" class="bodytext" align="justify">
            <table class="InnerForm" border="0">
                <tr>
                    <td>
                        <span class="orangetitle">Student Leave Summary</span> </br>
                    </td>
                    <td style="text-align: right;">
                        <a href="Dashboard.aspx" title="Close">Close</a>
                    </td>
                </tr>
            </table>
        </div>
        <table border="1" width="100%" class="InnerForm">
            <tr>
                <td>
                    <div align="justify">
                        <table border="0" width="100%">
                            <tr>
                                <td>
                                    <asp:Label ID="Label2" runat="server" Text="Standard" />
                                </td>
                                <td>
                                    <asp:DropDownList ID="sysstandardno" AutoPostBack="true" Width="200px" ToolTip="Designation"
                                        runat="server" DataTextField="standarddesc" DataValueField="sysstandardno" EnableTheming ="false" >
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label4" runat="server" Text="Division" />
                                </td>
                                <td>
                                    <asp:DropDownList ID="division" AutoPostBack="true" Width="200px" ToolTip="Division"
                                        runat="server" DataTextField="divisiondesc" DataValueField="sysdivisionno" EnableTheming ="false" >
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label5" runat="server" Text="Month" />
                                </td>
                                <td>
                                    <asp:DropDownList ID="month" Width="200px" ToolTip="Month" runat="server" DataTextField="gcname"
                                        DataValueField="gccode" EnableTheming ="false" >
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <asp:RadioButton ID="opt_std_att" runat="server" Text="Student Attendance Check "
                                        AutoPostBack="true" GroupName="G4" EnableTheming ="false" />
                                </td>
                            </tr>
                        </table>
                    </div>
                    <table style="width: 100%">
                        <tr class="tr_button">
                            <td align="center">
                                <asp:Button ID="btnprint" runat="server" Text="Print" CssClass="button" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
