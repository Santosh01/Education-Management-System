<%@ Page Language="VB" MasterPageFile="~/Main.master" AutoEventWireup="false" CodeFile="mstDesignation.aspx.vb"
    Inherits="mstDesignation" Title="Designation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <head id="Head1">
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
                    <asp:TableCell HorizontalAlign="Right" width="50%" ColumnSpan="3" ForeColor="orange" BackColor="LightGray">
                        <asp:Label ID="Label8" runat="server" Text="Designation"></asp:Label>
                         &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;&nbsp;
                         &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                         &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                         &nbsp; &nbsp; &nbsp;&nbsp;&nbsp;
                         &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                         &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                         &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;&nbsp;
                         &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                         &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; 
                            &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp;
                            &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp;&nbsp; 
                        
 
                 <a href="Dashboard.aspx" title="Close">Close</a>
                    </asp:TableCell>
                   
                </asp:TableRow>
                <asp:TableRow ID="TableRow9" runat="server">
                    <asp:TableCell HorizontalAlign="Justify">
                        <asp:GridView ID="gvList" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                            PageSize="10" Width="100%" AlternatingRowStyle-BackColor="LightBlue">
                            <Columns>
                                <asp:BoundField DataField="sysdesignationno" HeaderText="PK" />
                                <asp:BoundField DataField="desgcode" HeaderText="Code" ItemStyle-HorizontalAlign="Center"
                                    HeaderStyle-HorizontalAlign="Center" HeaderStyle-Width="75px" />
                                <asp:BoundField DataField="designationname" HeaderText="Name" ItemStyle-HorizontalAlign="Center"
                                    HeaderStyle-HorizontalAlign="Center" />
                                <asp:BoundField DataField="designationdesc" HeaderText="Designation" ItemStyle-HorizontalAlign="Center"
                                    HeaderStyle-HorizontalAlign="Center" />
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:LinkButton runat="server" ID="btnEdit" Text="Edit" ToolTip="Edit" OnClick="btnEdit_Click" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:LinkButton runat="server" ID="btnDelete" Text="Delete" ToolTip="Cancel" OnClientClick="return confirm('Are you sure you want to delete');" OnClick="btnDelete_Click" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </asp:TableCell>
                </asp:TableRow>
            </asp:Table>
            <asp:Table ID="Table1" runat="server" BorderStyle="Solid" BorderWidth="1px" Width="100%"
                GridLines="Both" BorderColor="controlDarkDark">
                <asp:TableRow ID="TableRow3" runat="server">
                    <asp:TableCell ID="TableCell4" HorizontalAlign="Right" runat="server">
                        <asp:Label ID="Label2" runat="server" Text="Designation code"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell ID="TableCell5" HorizontalAlign="Left" runat="server">
                        <asp:TextBox ID="desgcode" runat="server" ValidationGroup="btnsave"></asp:TextBox>
                        &nbsp;&nbsp
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="* Designation code can not be Blank"
                            Font-Size="Small" ControlToValidate="desgcode" ValidationGroup="btnsave"></asp:RequiredFieldValidator>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow ID="TableRow4" runat="server">
                    <asp:TableCell ID="TableCell6" HorizontalAlign="Right" runat="server">
                        <asp:Label ID="Label3" runat="server" Text="Designation name"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell ID="TableCell7" HorizontalAlign="Left" runat="server">
                        <asp:TextBox ID="designationname" runat="server" Width="40%" ValidationGroup="btnsave"></asp:TextBox>
                        &nbsp;&nbsp
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="* Designation name can not be Blank"
                            Font-Size="Small" ControlToValidate="designationname" ValidationGroup="btnsave"></asp:RequiredFieldValidator>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow ID="TableRow5" runat="server">
                    <asp:TableCell ID="TableCell8" HorizontalAlign="Right" runat="server">
                        <asp:Label ID="Label4" runat="server" Text="Designation description"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell ID="TableCell9" HorizontalAlign="Left" runat="server">
                        <asp:TextBox ID="designationdesc" runat="server" Width="40%" ValidationGroup="btnsave"></asp:TextBox>
                        &nbsp;&nbsp
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="* Description can not be Blank"
                            Font-Size="Small" ControlToValidate="designationdesc" ValidationGroup="btnsave"></asp:RequiredFieldValidator>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow ID="TableRow6" runat="server">
                    <asp:TableCell ID="TableCell10" HorizontalAlign="Right" runat="server">
                        <asp:Label ID="Label7" runat="server" Text="Status"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell ID="TableCell11" HorizontalAlign="Left" runat="server">
                        <asp:DropDownList ID="status"  EnableTheming="false" runat="server" DataValueField="gccode" DataTextField="gcname">
                        </asp:DropDownList>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow ID="TableRow7" runat="server">
                    <asp:TableCell ID="TableCell12" ColumnSpan="2" HorizontalAlign="Center" runat="server"
                        BackColor="controlDarkDark">
                        <asp:Button ID="btnsave" runat="server" Text="Save" ValidationGroup="btnsave" />
                        &nbsp;&nbsp;&nbsp
                        <asp:Button ID="btncancel" runat="server" Text="Cancel" />
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow ID="TableRow10" runat="server">
                    <asp:TableCell HorizontalAlign="Center" ColumnSpan="2">
                        <asp:TextBox ID="sysdesignationno" runat="server" Visible="false"></asp:TextBox>
                    </asp:TableCell>
                </asp:TableRow>
            </asp:Table>
        </ContentTemplate>
    </asp1:UpdatePanel>
</asp:Content>
