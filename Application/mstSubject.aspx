<%@ Page Language="VB" MasterPageFile="~/Main.master" AutoEventWireup="false" CodeFile="mstSubject.aspx.vb"
    Inherits="mstSubject" Title="Subject" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <head id="Head1">
        <title>Subject</title>
        <link rel="stylesheet" href="css/style.css" type="text/css" />
    </head>
    <asp1:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true">
        <Scripts>
            <asp1:ScriptReference Path="~/JavaScripts/Script.js" />
        </Scripts>
    </asp1:ScriptManager>
    <asp1:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div>
            </div>
            <div id="bodydiv" class="bodytext" align="justify">
                <table class="InnerForm" border="0">
                    <tr>
                        <td>
                            <span class="orangetitle">Subjects</span> </br>
                        </td>
                        <td style="text-align: right;">
                            <a href="Dashboard.aspx" title="Close">Close</a>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:GridView ID="gvList" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                PageSize="10" Width="100%" AlternatingRowStyle-BackColor="LightBlue">
                                <Columns>
                                    <asp:BoundField DataField="syssubjectno" HeaderText="PK" />
                                    <asp:BoundField DataField="subjectcode" HeaderText="Code" ItemStyle-HorizontalAlign="Center"    
                                        HeaderStyle-HorizontalAlign="Center" HeaderStyle-Width="75px" />
                                    <asp:BoundField DataField="subjectname" HeaderText="Standard" ItemStyle-HorizontalAlign="Center" 
                                        HeaderStyle-HorizontalAlign="Center"  />
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:LinkButton runat="server" ID="btnEdit" Text="Edit" ToolTip="Edit" OnClick="btnEdit_Click" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:LinkButton runat="server" ID="btnDelete" Text="Delete" ToolTip="Delete" OnClick="btnDelete_Click" OnClientClick="return confirm('Are you sure you want to delete');" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </td>
                    </tr>
                </table>
                <table class="InnerForm" border="1">
                    <tr>
                        <td class="td_label">
                            <asp:Label ID="lblbrname" runat="server" Text="Subject Code" />
                        </td>
                        <td class="td_control">
                            <asp:TextBox ID="subjectcode" ToolTip="Subject Code" MaxLength="10" runat="server"
                                Columns="15" ValidationGroup="btnsave" />
                            &nbsp;&nbsp
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="* Subject Code can not be Blank"
                                ControlToValidate="subjectcode" ValidationGroup="btnsave"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="td_label">
                            <asp:Label ID="Label27" runat="server" Text="Description" />
                        </td>
                        <td class="td_control">
                            <asp:TextBox ID="subjectname" ToolTip="subject Description" MaxLength="50" runat="server"
                                Columns="50" ValidationGroup="btnsave" />
                            &nbsp;&nbsp
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="* Description can not be Blank"
                                ControlToValidate="subjectname" ValidationGroup="btnsave"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr class="tr_button">
                        <%--style="background-color: #00357b"--%>
                        <td colspan="2" align="center">
                            <asp:Button ID="btnsave" runat="server" Text="Save" CssClass="button" ValidationGroup="btnsave" />
                            <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="button" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:TextBox ID="syssubjectno" runat="server" Visible="false" />
                        </td>
                    </tr>
                </table>
            </div>
        </ContentTemplate>
    </asp1:UpdatePanel>
</asp:Content>
