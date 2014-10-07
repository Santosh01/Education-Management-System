<%@ Page Language="VB" MasterPageFile="~/Main.master" AutoEventWireup="false" CodeFile="mstStandardWiseSubject.aspx.vb"
    Inherits="mstStandardWiseSubject" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <head id="Head1">
        <title>Standard Wise Subjects</title>
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
                <div >
                    <table>
                        <tr>
                            <td>
                                <span class="orangetitle">Standard Wise Subjects</span> &nbsp; &nbsp; &nbsp; &nbsp;
                                &nbsp; &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp; &nbsp;&nbsp;&nbsp;
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
                                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
                                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                &nbsp; <a href="Dashboard.aspx" title="Close">Close</a>
                            </td>
                        </tr>
                    </table>
                </div>
                <div id="bodydiv" class="bodytext" align="justify">
                    <table width="100%" class="InnerForm" runat="server" id="tblstdSubject" border="1">
                        <tr>
                            <td class="td_label">
                                <asp:Label ID="Label17" runat="server" Text="Standard" />
                            </td>
                            <td class="td_control">
                                <asp:DropDownList ID="sysstandardno" EnableTheming="false" ToolTip="Standard" runat="server"
                                    DataTextField="standarddesc" DataValueField="sysstandardno" ValidationGroup="btnsave"
                                    AutoPostBack="true" OnSelectedIndexChanged="sysstandardno_SelectedIndexChanged">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Select Standard"
                                    ControlToValidate="sysstandardno" ValidationGroup="btnsave"></asp:RequiredFieldValidator>
                            </td>
                            <td class="td_label">
                                <asp:Label ID="Label4" runat="server" Text="Division" />
                            </td>
                            <td class="td_control">
                                <asp:DropDownList ID="sysdivisionno" ToolTip="Division" runat="server" DataTextField="divisiondesc"
                                    EnableTheming="false" DataValueField="sysdivisionno" ValidationGroup="btnsave"
                                    AutoPostBack="true">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Select Division"
                                    ControlToValidate="sysdivisionno" ValidationGroup="btnsave"></asp:RequiredFieldValidator>
                            </td>
                            <td>
                                <asp:CheckBox ID="chkAllSelected" runat="server" Checked="true" Text="Selected Subject Only"
                                    AutoPostBack="true" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="6" align="center">
                            </td>
                        </tr>
                    </table>
                    <table width="100%" class="SearchBar">
                        <tr>
                            <td colspan="6">
                                <asp:GridView ID="gvList" runat="server" AutoGenerateColumns="False" Width="100%"
                                    AlternatingRowStyle-BackColor="LightBlue">
                                    <Columns>
                                        <asp:BoundField DataField="sysstdsubjectno" HeaderText="PK" />
                                        <asp:BoundField DataField="syssubjectno" HeaderText="PK" />
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:CheckBox ID="Selected" runat="server" AutoPostBack="true" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="subjectcode" HeaderText="Subject Code" ItemStyle-HorizontalAlign="Left"
                                            HeaderStyle-HorizontalAlign="Left" />
                                        <asp:BoundField DataField="subjectname" HeaderText="Name" ItemStyle-HorizontalAlign="Left"
                                            HeaderStyle-HorizontalAlign="Left" />
                                    </Columns>
                                </asp:GridView>
                            </td>
                        </tr>
                        <tr class="tr_button">
                            <td colspan="6" align="center">
                                <asp:Button ID="btnsave" runat="server" Text="Save" CssClass="button" ValidationGroup="btnsave" />
                                &nbsp;&nbsp;
                                <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="button" OnClick="btnCancel_Click" />
                                &nbsp;&nbsp;
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
            <asp:TextBox ID="sysstdsubjectno" runat="server" Visible="false" />
        </ContentTemplate>
    </asp1:UpdatePanel>
</asp:Content>
