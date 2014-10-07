<%@ Page Language="VB" MasterPageFile="~/Main.master" AutoEventWireup="false" CodeFile="mstQualification.aspx.vb"
    Inherits="mstQualification" Title="Qualification" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <head id="Student">
        <title>Student</title>
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
                        <asp:Label ID="Label8" runat="server" Text="Qualification"></asp:Label>
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
                        
 
                 <a href="Dashboard.aspx" title="Close">Close</a>
                    </asp:TableCell>
                   
                </asp:TableRow>
                <asp:TableRow ID="TableRow7" runat="server">
                    <asp:TableCell HorizontalAlign="Justify">
                        <asp:GridView ID="gvList" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                            PageSize="10" Width="100%" AlternatingRowStyle-BackColor="LightBlue">
                            <Columns>
                                <asp:BoundField DataField="sysqulno" HeaderText="PK" />
                                <asp:BoundField DataField="qulcode" HeaderText="Code" ItemStyle-HorizontalAlign="Center"
                                    HeaderStyle-HorizontalAlign="Center" HeaderStyle-Width="75px" />
                                <asp:BoundField DataField="quldesc" HeaderText="Qualification" ItemStyle-HorizontalAlign="Center"
                                    HeaderStyle-HorizontalAlign="Center" />
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:LinkButton runat="server" ID="btnEdit" Text="Edit" ToolTip="Edit" OnClick="btnEdit_Click" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:LinkButton runat="server" ID="btnDelete" Text="Delete" ToolTip="Delete" OnClientClick="return confirm('Are you sure you want to delete');" OnClick="btnDelete_Click" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </asp:TableCell>
                </asp:TableRow>
            </asp:Table>
            <asp:Table ID="Table1" runat="server" Width="100%" BorderColor="Black" BackColor="White"
                GridLines="Both">
                <asp:TableRow ID="TableRow3" runat="server">
                    <asp:TableCell ID="TableCell4" runat="server" HorizontalAlign="Right">
                        <asp:Label ID="Label2" runat="server" Text="Qualification Code"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell ID="TableCell5" runat="server" HorizontalAlign="left" Width="80%">
                        <asp:TextBox ID="qulcode" runat="server" Width="38%" ValidationGroup="btnsave"></asp:TextBox>
                        &nbsp;&nbsp
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="* Qualification code can not be Blank"
                            Font-Size="Small" ControlToValidate="qulcode" ValidationGroup="btnsave"></asp:RequiredFieldValidator>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow ID="TableRow4" runat="server">
                    <asp:TableCell ID="TableCell6" runat="server" HorizontalAlign="Right">
                        <asp:Label ID="Label3" runat="server" Text="Qualification Description"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell ID="TableCell7" runat="server" HorizontalAlign="left">
                        <asp:TextBox ID="quldesc" runat="server" Width="38%" ValidationGroup="btnsave"></asp:TextBox>
                        &nbsp;&nbsp
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="* Description can not be Blank"
                            Font-Size="Small" ControlToValidate="quldesc" ValidationGroup="btnsave"></asp:RequiredFieldValidator>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow ID="TableRow5" runat="server">
                    <asp:TableCell ID="TableCell8" ColumnSpan="2" runat="server" HorizontalAlign="Center"
                        BackColor="controlDarkDark">
                        <asp:Button ID="btnSave" runat="server" Text="Save" Width="80px" ValidationGroup="btnsave" />
                        &nbsp;&nbsp;&nbsp
                        <asp:Button ID="btnCancel" runat="server" Text="Cancel" Width="80px" />
                        <asp:TextBox ID="sysqulno" runat="server" Width="38%" Visible="false"></asp:TextBox>
                    </asp:TableCell>
                </asp:TableRow>
            </asp:Table>
        </ContentTemplate>
    </asp1:UpdatePanel>
</asp:Content>
