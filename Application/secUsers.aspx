<%@ Page Language="VB" MasterPageFile="~/Main.master" AutoEventWireup="false" CodeFile="secUsers.aspx.vb"
    Inherits="secUsers" Title="Users" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <head id="H2">
        <title>Users</title>
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
                <asp:TableRow ID="TableRow7" runat="server">
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
                                <asp:BoundField DataField="sysuserno" HeaderText="PK" />
                                <asp:BoundField DataField="userid" HeaderText="User ID" ItemStyle-HorizontalAlign="Center"
                                    HeaderStyle-HorizontalAlign="Center" HeaderStyle-Width="75px" />
                                <asp:BoundField DataField="username" HeaderText="User Name" ItemStyle-HorizontalAlign="Center"
                                    HeaderStyle-HorizontalAlign="Center" />
                                <asp:BoundField DataField="groupcode" HeaderText="Group Code" ItemStyle-HorizontalAlign="Center"
                                    HeaderStyle-HorizontalAlign="Center" />
                                <asp:BoundField DataField="SecretQuestion" HeaderText="Secret Question" ItemStyle-HorizontalAlign="Center"
                                    HeaderStyle-HorizontalAlign="Center" Visible="false" />
                                <asp:BoundField DataField="SecretAnswer" HeaderText="Secret Answer" ItemStyle-HorizontalAlign="Center"
                                    HeaderStyle-HorizontalAlign="Center" Visible="false" />
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:LinkButton runat="server" ID="btnEdit" Text="Edit" ToolTip ="Edit" OnClick="btnEdit_Click" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:LinkButton runat="server" ID="btnDelete"  Text="delete" ToolTip ="Delete" CommandName="delete" OnClientClick="return confirm('Are you sure you want to delete');" OnClick="btnDelete_Click" />
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
                    <asp:TableCell ID="TableCell4" runat="server" HorizontalAlign="Right">
                        <asp:Label ID="Label2" runat="server" Text="User ID"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell ID="TableCell5" runat="server" ColumnSpan="6" HorizontalAlign="Left" Width="85%">
                        <asp:TextBox ID="userid" runat="server" Width="40%"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="userid"
                            Text="* required" ValidationGroup="Btnsave" SetFocusOnError="true" />
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow ID="TableRow4" runat="server">
                    <asp:TableCell ID="TableCell6" runat="server"  HorizontalAlign="Right">
                        <asp:Label ID="Label3" runat="server" Text="User Name"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell ID="TableCell7" runat="server" ColumnSpan="6" HorizontalAlign="Left">
                        <asp:TextBox ID="username" runat="server" Width="40%"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="username"
                            Text="* required" ValidationGroup="Btnsave" SetFocusOnError="true" />
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow ID="TableRow2" runat="server">
                    <asp:TableCell ID="TableCell2" runat="server"  HorizontalAlign="Right">
                        <asp:Label ID="Label4" runat="server" Text="Password"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell ID="TableCell3" runat="server" ColumnSpan="6" HorizontalAlign="Left">
                        <asp:TextBox ID="password" runat="server" Width="40%"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="password"
                            Text="* required" ValidationGroup="Btnsave" SetFocusOnError="true" />
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow ID="TableRow1" runat="server">
                    <asp:TableCell ID="TableCell1" runat="server"  HorizontalAlign="Right">
                        <asp:Label ID="Label1" runat="server" Text="Secret Question"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell ID="TableCell11" runat="server" ColumnSpan="6" HorizontalAlign="Left">
                        <asp:TextBox ID="SecretQuestion" runat="server" Width="40%"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="SecretQuestion"
                            Text="* required" ValidationGroup="Btnsave" SetFocusOnError="true" />
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow ID="TableRow8" runat="server">
                    <asp:TableCell ID="TableCell12" runat="server"  HorizontalAlign="Right">
                        <asp:Label ID="Label6" runat="server" Text="Secret  Answer"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell ID="TableCell13" runat="server" ColumnSpan="6" HorizontalAlign="Left">
                        <asp:TextBox ID="SecretAnswer" runat="server" Width="40%"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="SecretAnswer"
                            Text="* required" ValidationGroup="Btnsave" SetFocusOnError="true" />
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell ID="TableCell8" runat="server"  HorizontalAlign="Right">
                        <asp:Label ID="Label5" runat="server" Text="Group Code"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell ID="TableCell10" runat="server" HorizontalAlign="Left">
                        <asp:DropDownList ID="groupcode" runat="server" DataTextField="description" DataValueField="groupcode"
                            AutoPostBack="true" EnableTheming="false">
                        </asp:DropDownList>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell ID="TableCell19" runat="server"  HorizontalAlign="Right">
                        <asp:Label ID="Label9" runat="server" Text="Status"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell ID="TableCell20" runat="server" ColumnSpan="6" HorizontalAlign="Left">
                        <asp:DropDownList ID="userstatus" runat="server" DataValueField="gccode" DataTextField="gcname"
                            Width="20%" EnableTheming="false" AutoPostBack="true">
                        </asp:DropDownList>
                        <asp:TextBox ID="sysuserno" runat="server" Visible="false"></asp:TextBox>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow ID="TableRow5" runat="server">
                    <asp:TableCell ID="TableCell21" runat="server" HorizontalAlign="Center" ColumnSpan="8"
                        BackColor="controlDarkDark">
                        <asp:Button ID="btnSave" runat="server" Text="Save" ValidationGroup="Btnsave" />
                        &nbsp;&nbsp;&nbsp;&nbsp
                        <asp:Button ID="btnCancel" runat="server" Text="cancel" />
                    </asp:TableCell>
                </asp:TableRow>
            </asp:Table>
        </ContentTemplate>
    </asp1:UpdatePanel>
</asp:Content>
