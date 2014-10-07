<%@ Page Language="VB" MasterPageFile="~/Main.master" AutoEventWireup="false" 
CodeFile="rstExamTimeTableReport.aspx.vb" Inherits="rstExamTimeTableReport"  %>

<%@ Register Assembly="CrystalDecisions.Web, Version=10.2.3600.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
    
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <head id="Head1">
        <title>Exam Time Table Report</title>
        <link rel="stylesheet" href="css/style.css" type="text/css" />
    </head>
    <div id="bodydiv">
                <div id="Div1" class="bodytext" align="justify">
                    <table class="InnerForm" border="0">
                        <tr>
                            <td>
                                <span class="orangetitle">Exam Time Table Report</span> </br>
                            </td>
                            <td style="text-align: right;">
                            <a href="Dashboard.aspx" title="Close">Close</a>
                        </td>
                        </tr>
                    </table>
                </div>
        <table border="1" width="70%" class="InnerForm">
            <tr>
                <td>
                    <div align="justify">
                        <table border="0" width="100%">
                          
                            
                            
                            <tr>
                                <td>
                                    <asp:Label ID="Label2" runat="server" Text="Standard" />
                                </td>
                                <td class="td_control">
                                    <asp:DropDownList AutoPostBack="true" ID="sysstandardno" ToolTip="Standard" runat="server"
                                        DataTextField="standarddesc" DataValueField="sysstandardno" EnableTheming ="false" >
                                    </asp:DropDownList>
                                    </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label3" runat="server" Text="Division" />
                                </td>
                                <td>
                                    <asp:DropDownList ID="sysdivisionno"   Width="200px" ToolTip="Division"
                                        runat="server" DataTextField="divisiondesc" DataValueField="sysdivisionno" EnableTheming ="false" >
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label4" runat="server" Text="Exam" />
                                </td>
                                <td>
                                    <asp:DropDownList ID="sysexamno" Width="200px" ToolTip="Exam" runat="server" DataTextField="examdesc"
                                        DataValueField="sysexamno" EnableTheming ="false" >
                                    </asp:DropDownList>
                                 </td>
                            </tr>
                        </table>
                    </div>
                    <table style="width: 100%">
                        <tr class="tr_button" align="center">
                            <td align="left">
                            <br />
                               &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                               &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                               &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                               &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                               &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                               &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:Button ID="btnprint" runat="server" Text="Print" CssClass="button" />
                                
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="sysmgmtno" runat="server" Visible="false" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>

