<%@ Page Language="VB" MasterPageFile="~/Main.master" AutoEventWireup="false" CodeFile="mstStandardWiseExam.aspx.vb"
    Inherits="mstStandardWiseExam" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <head id="Head1">
        <title>Standardwise Examination</title>
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
               
               
                <div id="bodydiv" class="bodytext" align="justify">
                    <table width="100%" class="InnerForm">
                        <tr>
                         <td>
                                <span class="orangetitle">Standardwise Examination</span> </br>
                            </td>
                            <td style="text-align: right;">
                                <a href="Dashboard.aspx" title="Close">Close</a>
                            </td>
                        </tr>
                    </table>
                    <table width="100%" class="InnerForm" runat="server" id="tblstdExam" border="1">

                        <tr>
                            <td class="td_label">
                                <asp:Label ID="lblbrname" runat="server" Text="Standard" />
                            </td>
                            <td class="td_control">
                                <asp:DropDownList ID="sysstandardno" runat="server" AutoPostBack="true" DataTextField="standarddesc" EnableTheming="false" 
                                    DataValueField="sysstandardno" ValidationGroup="btnsave" OnSelectedIndexChanged="sysstandardno_SelectedIndexChanged">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Select Standard"
                                    ControlToValidate="sysstandardno" ValidationGroup="btnsave"></asp:RequiredFieldValidator>
                            </td>
                            
                                       <td>
                                <asp:CheckBox ID="chkAllSelected" runat="server" Checked="true" Text="Selected Exam Only"
                                    AutoPostBack="true" />
                            </td>
                        </tr>
            
                    </table>
                    <table class="InnerForm">
                        <tr>
                            <td>
                                <asp:GridView ID="gvList" runat="server" AutoGenerateColumns="False" Width="100%" AlternatingRowStyle-BackColor="LightBlue">
                                    <Columns>
                                        <asp:BoundField DataField="sysstdexamno" HeaderText="PK" />
                                        <asp:BoundField DataField="sysexamno" HeaderText="PK" />
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:CheckBox ID="Selected" runat="server" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="examcode" HeaderText="Exam Code" />
                                        <asp:BoundField DataField="examdesc" HeaderText="Exam Name" />
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
            <asp:TextBox ID="sysstdexamno" runat="server" Visible="false" />
        </ContentTemplate>
    </asp1:UpdatePanel>
</asp:Content>
