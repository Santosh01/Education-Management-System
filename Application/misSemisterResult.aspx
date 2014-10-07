<%@ Page Language="VB" MasterPageFile="~/Main.master" AutoEventWireup="false" CodeFile="misSemisterResult.aspx.vb" Inherits="misSemisterResult" %>


<%@ Register Assembly="CrystalDecisions.Web, Version=10.2.3600.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
    
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <head id="Head1">
        <title>Semester Result</title>
        <link rel="stylesheet" href="css/style.css" type="text/css" />
    </head>

  <asp1:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true">
        <Scripts>
            <asp1:ScriptReference Path="~/JavaScripts/Script.js" />
        </Scripts>
    </asp1:ScriptManager>
      

  <div id="bodydiv">
        <div  align="justify">
            <table>
                <tr>
                    <td>
                        <span class="orangetitle">Semester Result</span>
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
                                    <asp:DropDownList ID="sysdivisionno" ToolTip="Division" runat="server" DataTextField="divisiondesc"
                                        DataValueField="sysdivisionno" EnableTheming ="false" >
                                    </asp:DropDownList>
                                </td>
                            </tr>

                            <tr>
                                <td>
                                    <asp:Label ID="Label34" runat="server" Text="Roll No" />
                                </td>
                                <td>
                                    <asp:TextBox ID="rollno" ToolTip="Roll No" MaxLength="10" runat="server" Columns="15" />
                                </td>
                            </tr>
                        </table>
                        
                        <table class="InnerForm">
                        <tr>
                            <td>
                                <asp:GridView ID="gvList" runat="server" AutoGenerateColumns="False" Width="100%">
                                    <Columns>
                                        <asp:BoundField DataField="sysstdexamno" HeaderText="PK" />
                                        <asp:BoundField DataField="sysexamno" HeaderText="PK" />
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:CheckBox ID="Selected" runat="server" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="examcode" HeaderText="Exam Code" />
                                        <asp:BoundField DataField="examdesc" HeaderText="Exam Name" />
                                    </Columns>
                                </asp:GridView>
                            </td>
                        </tr>
                    </table>
                    </div>
                    <table style="width: 100%">
                        <tr class="tr_button" align="center">
                            <td align="center">
                                <asp:Button ID="btnprint" runat="server" Text="Print" CssClass="button" />
                                &nbsp;&nbsp;
                                <asp:Button ID="btnClose" runat="server" Text="Close" CssClass="button"></asp:Button>
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

