<%@ Page Language="VB" MasterPageFile="~/Main.master" AutoEventWireup="false" CodeFile="secUserGroups.aspx.vb"
    Inherits="secUserGroups" Title="User-Groups" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <head id="H2">
        <title>Untitled Page</title>
        <link rel="stylesheet" href="css/style.css" type="text/css" />
    </head>
    <asp1:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true">
        <Scripts>
            <asp1:ScriptReference Path="~/JavaScripts/Script.js" />
        </Scripts>
    </asp1:ScriptManager>
    <asp1:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:Table ID="Table3" runat="server" BorderStyle="Solid" BorderWidth="1px" Width="100%"
                GridLines="Both" BorderColor="controlDarkDark">
                <asp:TableRow ID="TableRow1" runat="server">
                    <asp:TableCell HorizontalAlign="Right" Width="50%" ColumnSpan="3" ForeColor="orange"
                        BackColor="LightGray">
                        <asp:Label ID="Label8" runat="server" Text="Users"></asp:Label>
                        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp; &nbsp;&nbsp;&nbsp;
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; <a
                            href="Dashboard.aspx" title="Close">Close</a>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow ID="TableRow6" runat="server" Width="100%">
                    <asp:TableCell ID="TableCell9" runat="server" HorizontalAlign="Center" BorderStyle="Solid">
                        <asp:GridView ID="gvList" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                            PageSize="5" Width="100%" AlternatingRowStyle-BackColor="LIGHTBLUE">
                            <Columns>
                                <asp:BoundField DataField="sysgroupno" HeaderText="PK" />
                                <asp:BoundField DataField="groupcode" HeaderText="Code" ItemStyle-HorizontalAlign="center"
                                    HeaderStyle-HorizontalAlign="Center" HeaderStyle-Width="75px" />
                                <asp:BoundField DataField="description" HeaderText="Standard" ItemStyle-HorizontalAlign="Center"
                                    HeaderStyle-HorizontalAlign="Center" />
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:LinkButton runat="server" ID="btnEdit" Text="Edit" ToolTip="Edit" OnClick="btnEdit_Click" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:LinkButton runat="server" ID="btnDelete" Text="Delete" ToolTip="Delete"  OnClientClick="return confirm('Are you sure you want to delete');" OnClick="btnDelete_Click" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </asp:TableCell>
                </asp:TableRow>
            </asp:Table>
            <asp:Table ID="Table2" runat="server" BorderStyle="Solid" BorderWidth="1px" Width="100%"
                GridLines="Both" BorderColor="controlDarkDark">
                <asp:TableRow ID="TableRow3" runat="server">
                    <asp:TableCell ID="TableCell4" runat="server" ColumnSpan="1" HorizontalAlign="Right">
                        <asp:Label ID="Label2" runat="server" Text="Group Code"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell ID="TableCell5" runat="server" ColumnSpan="3"  HorizontalAlign="Left" Width="85%">
                        <asp:TextBox ID="groupcode" runat="server" Width="40%"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="groupcode"
                            Text="* required" ValidationGroup="Btnsave" SetFocusOnError="true" />
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow ID="TableRow4" runat="server">
                    <asp:TableCell ID="TableCell6" runat="server" ColumnSpan="1" Width="20%" HorizontalAlign="Right">
                        <asp:Label ID="Label3" runat="server" Text="Description"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell ID="TableCell7" runat="server" ColumnSpan="3"  Width="20%" HorizontalAlign="Left">
                        <asp:TextBox ID="description" runat="server" Width="40%"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="description"
                            Text="* required" ValidationGroup="Btnsave" SetFocusOnError="true" />
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow ID="TableRow5" runat="server">
                    <asp:TableCell ID="TableCell8" runat="server" ColumnSpan="1" HorizontalAlign="Right">
                        <asp:Label ID="Label4" runat="server" Text="Comment"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell ID="TableCell10" runat="server" ColumnSpan="3"  Width="20%"  HorizontalAlign="Left">
                        <asp:TextBox ID="comment" runat="server" Width="40%"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="comment"
                            Text="* required" ValidationGroup="Btnsave" SetFocusOnError="true" />
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow ID="TableRow7" runat="server">
                    <asp:TableCell ID="TableCell11" runat="server" ColumnSpan="1" HorizontalAlign="Right">
                        <asp:Label ID="Label5" runat="server" Text="Status"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell ID="TableCell12" runat="server" ColumnSpan="3" Width="60%" HorizontalAlign="Left">
                        <asp:DropDownList ID="status" runat="server" Width="15%" EnableTheming="false" DataValueField="gccode" DataTextField="gcname">
                        </asp:DropDownList>
                        <asp:TextBox ID="sysgroupno" runat="server" Visible="false"></asp:TextBox>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow ID="TableRow8" runat="server">
                    <asp:TableCell ID="TableCell13" runat="server" HorizontalAlign="Center" ColumnSpan="4"
                        BackColor="controlDarkDark">
                        <asp:Button ID="btnSave" runat="server" Text="Save" ValidationGroup="Btnsave" />
                        &nbsp; &nbsp;
                        <asp:Button ID="btnCancel" runat="server" Text="cancel" />
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow ID="TableRow9" runat="server">
                </asp:TableRow>
            </asp:Table>
        </ContentTemplate>
    </asp1:UpdatePanel>
</asp:Content>
