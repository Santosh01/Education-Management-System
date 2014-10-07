<%@ Page Language="VB" MasterPageFile="~/Main.master" AutoEventWireup="false" CodeFile="mstExamMaster.aspx.vb"
    Inherits="mstExamMaster" Title="Exam" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <head id="Exam Master">
        <title>Exam Master</title>
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
                        <asp:Label ID="Label8" runat="server" Text="Exam Series"></asp:Label>
                         &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;&nbsp;
                         &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                         &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                         &nbsp; &nbsp; &nbsp;&nbsp;&nbsp;
                         &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                         &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                         &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;&nbsp;
                         &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                         &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; 
                            &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
                           
                        
 
                 <a href="Dashboard.aspx" title="Close">Close</a>
                    </asp:TableCell>
                   
                </asp:TableRow>
                <asp:TableRow ID="TableRow3" runat="server">
                    <asp:TableCell HorizontalAlign="Justify">
                        <asp:GridView ID="gvList" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                            PageSize="8" Width="100%" AlternatingRowStyle-BackColor="LightBlue">
                            <Columns>
                                <asp:BoundField DataField="sysexamno" HeaderText="PK" />
                                <asp:BoundField DataField="examcode" HeaderText="Code" ItemStyle-HorizontalAlign="Center"
                                    HeaderStyle-HorizontalAlign="Center" HeaderStyle-Width="75px" />
                                <asp:BoundField DataField="examdesc" HeaderText="Exam Name" ItemStyle-HorizontalAlign="Center"
                                    HeaderStyle-HorizontalAlign="Center" />
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:LinkButton runat="server" ID="btnEdit" Text="Edit" ToolTip ="Edit" OnClick="btnEdit_Click" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:LinkButton runat="server" ID="btnDelete" Text="Delete" ToolTip ="Delete" OnClick="btnDelete_Click" OnClientClick="return confirm('Are you sure you want to delete');"/>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </asp:TableCell>
                </asp:TableRow>
            </asp:Table>
            <asp:Table ID="Table2" runat="server" BorderStyle="Solid" BorderWidth="1px" Width="100%"
                GridLines="Both" BorderColor="controlDarkDark">
                <asp:TableRow ID="TableRow2" runat="server">
                    <asp:TableCell HorizontalAlign="Right">
                        <asp:Label ID="Label5" runat="server" Text="Code"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell HorizontalAlign="Left">
                        <asp:TextBox ID="examcode" runat="server" ValidationGroup="btnsave"></asp:TextBox>
                        &nbsp;&nbsp
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="* Exam code can not be Blank"
                            Font-Size="Small" ControlToValidate="examcode" ValidationGroup="btnsave"></asp:RequiredFieldValidator>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow ID="TableRow4" runat="server">
                    <asp:TableCell HorizontalAlign="Right">
                        <asp:Label ID="Label6" runat="server" Text="Exam Name"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell HorizontalAlign="Left">
                        <asp:TextBox ID="examdesc" runat="server" ValidationGroup="btnsave" Width="45%"></asp:TextBox>
                        &nbsp;&nbsp
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="* Discription can not be Blank"
                            Font-Size="Small" ControlToValidate="examdesc" ValidationGroup="btnsave"></asp:RequiredFieldValidator>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow ID="TableRow5" runat="server">
                    <asp:TableCell HorizontalAlign="Right">
                        <asp:Label ID="Label7" runat="server" Text="Status"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell HorizontalAlign="Left">
                        <asp:DropDownList ID="status" runat="server" DataValueField="gccode" DataTextField="gcname" EnableTheming ="false" >
                        </asp:DropDownList>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow ID="TableRow6" runat="server">
                    <asp:TableCell HorizontalAlign="Center" ColumnSpan="3">
                        <asp:Button ID="BtnSave" runat="server" Text="Save" ValidationGroup="btnsave" />
                        &nbsp;&nbsp;&nbsp;&nbsp
                        <asp:Button ID="BtnCancel" runat="server" Text="Cancel" />
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow ID="TableRow7" runat="server">
                    <asp:TableCell HorizontalAlign="Center" ColumnSpan="3">
                        <asp:TextBox ID="sysexamno" runat="server" Visible="false"></asp:TextBox>
                    </asp:TableCell>
                </asp:TableRow>
            </asp:Table>
        </ContentTemplate>
    </asp1:UpdatePanel>
</asp:Content>
