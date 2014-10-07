<%@ Page Language="VB" MasterPageFile="~/Main.master" AutoEventWireup="false" CodeFile="rptStaffListing.aspx.vb" Inherits="rptStaffListing" title="Staff List" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  <head id="Head1">
        <title>Staff List</title>
        <link rel="stylesheet" href="css/style.css" type="text/css" />
    </head>
      <asp1:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true">
        <Scripts>
            <asp1:ScriptReference Path="~/JavaScripts/Script.js" />
        </Scripts>
    </asp1:ScriptManager>
    <asp1:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
    
    <asp:Table ID="Table1" runat="server" BorderStyle="Outset" BorderWidth="1px" Width="80%"
        GridLines="Both" BorderColor="controlDarkDark">
        <asp:TableHeaderRow ID="TableRow1" runat="server" BorderStyle="Solid">
            <asp:TableCell ID="TableCell2" runat="server" HorizontalAlign="Center" BorderStyle='Ridge'
                BackColor="Orange"  ColumnSpan="2">
                <asp:Label ID="Label6" runat="server" Text="Staff List"></asp:Label>
            </asp:TableCell>
            
        </asp:TableHeaderRow>
        <asp:TableRow runat="server">
        <asp:TableCell runat="server" HorizontalAlign="Center" Width="20%">
            <asp:Label ID="Label1" runat="server" Text="Staff Team"></asp:Label>
        </asp:TableCell>
        <asp:TableCell runat="server" HorizontalAlign="Left">
            <asp:DropDownList ID="sysfacultyno" runat="server" Width="50%" DataTextField="facultyname" DataValueField="sysfacultyno">
            </asp:DropDownList>
        </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow runat="server">
            <asp:TableCell ColumnSpan="2" HorizontalAlign="Center" BackColor="LightGray">
                <asp:Button ID="btnPrint" runat="server" Text="Print" Width="114px" />
                &nbsp;&nbsp;
                <asp:Button ID="BtnClose" runat="server" Text="Close" Width="102px" />
            </asp:TableCell>
        </asp:TableRow>
        </asp:Table>
        </ContentTemplate>
        </asp1:UpdatePanel>
</asp:Content>

