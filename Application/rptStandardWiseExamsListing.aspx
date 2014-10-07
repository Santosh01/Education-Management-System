<%@ Page Language="VB" MasterPageFile="~/Main.master" AutoEventWireup="false" CodeFile="rptStandardWiseExamsListing.aspx.vb" Inherits="rptStandardWiseExamsListing" title="Standardwise Exam List" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<head id="CheckListForExams">
<title>Check List For Exams</title>
<link rel="stylesheet" href="css/style.css" type="text/css" />
</head>
  <asp1:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true">
        <Scripts>
            <asp1:ScriptReference Path="~/JavaScripts/Script.js" />
        </Scripts>
    </asp1:ScriptManager>
    <asp1:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
<asp:Table ID="Table4" runat="server" BorderStyle="Solid" BorderWidth="1px" Width="80%"
        GridLines="Both" BorderColor="controlDarkDark" Height="85px">
        <asp:TableRow ID="TableRow1" runat="server">
            <asp:TableCell ID="TableCell1" Width="50%" ColumnSpan="3" ForeColor="Orange" BackColor="LightGray" runat="server">
                <asp:Label ID="Label8" runat="server" Text="Check List For Exams"></asp:Label>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow ID="tablerow20" runat="server">
            <asp:TableCell ID="TableCell2" HorizontalAlign="Left" runat="server" Width="10%">
                <asp:Label ID="Label7" runat="server" Text="Standard"></asp:Label>
            </asp:TableCell>
            <asp:TableCell ID="TableCell3" HorizontalAlign="Left" runat="server">
                <asp:DropDownList ID="sysstandardno" runat="server" Width="10%" DataTextField="standarddesc"
                    DataValueField="sysstandardno">
                </asp:DropDownList>
            </asp:TableCell>
         </asp:TableRow>
         <asp:TableRow ID="tablerow21" runat ="server">  
          <asp:TableCell ID="TableCell4" HorizontalAlign="Left" runat="server">
                <asp:Label ID="Label1" runat="server" Text="Division"></asp:Label>
            </asp:TableCell>
            <asp:TableCell ID="TableCell5" HorizontalAlign="Left" runat="server">
                <asp:DropDownList ID="sysdivisionno" runat="server" Width="30%" DataTextField="divisiondesc"
                    DataValueField="sysdivisionno">
                </asp:DropDownList>
                </asp:TableCell>
          </asp:TableRow>
          <asp:TableRow ID="tablerow22" runat="server">
          <asp:TableCell ID="tablecell6" HorizontalAlign="Left" runat="server">
              <asp:Label ID="Label2" runat="server" Text="Exam"></asp:Label>
          </asp:TableCell>
          <asp:TableCell ID="tablecell7" HorizontalAlign="Left" runat="server">
              <asp:DropDownList ID="sysexamno" runat="server" Width="30%" DataTextField="examdesc"
                  DataValueField="sysexamno" >
              </asp:DropDownList>
          </asp:TableCell>
          </asp:TableRow>
          <asp:TableRow ID="table23" runat="server" BackColor="LightGray">
              <asp:TableCell ID="TableCell8" HorizontalAlign="Center" runat="server" ColumnSpan="2">
                  <asp:Button ID="btnPrint" runat="server" Text="Print" Width="60px" />
                  &nbsp;&nbsp;&nbsp
                  <asp:Button ID="btnClose" runat="server" Text="Close" Width="60px" />
              </asp:TableCell>
         </asp:TableRow>
    </asp:Table>
    </ContentTemplate>
    </asp1:UpdatePanel>
</asp:Content>

