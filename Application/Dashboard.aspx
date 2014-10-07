<%@ Page Language="VB" MasterPageFile="~/Main.master" AutoEventWireup="false" CodeFile="Dashboard.aspx.vb"
    Inherits="Dashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp1:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true">
        <Scripts>
            <asp1:ScriptReference Path="~/JavaScripts/Script.js" />
        </Scripts>
    </asp1:ScriptManager>
    <link rel="stylesheet" href="css/style.css" type="text/css" />
    <asp1:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
        </ContentTemplate>
    </asp1:UpdatePanel>
</asp:Content>
