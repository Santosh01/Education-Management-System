<%@ Page Language="VB" AutoEventWireup="false" CodeFile="rstMarksEntryBrowse.aspx.vb"
    Inherits="rstMarksEntryBrowse" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1">
    <title>Marks Entry</title>
    <link rel="stylesheet" href="css/style.css" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <asp1:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true">
        <Scripts>
            <asp1:ScriptReference Path="~/JavaScripts/Script.js" />
        </Scripts>
    </asp1:ScriptManager>
    <asp1:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div id="pnlPopup" class="PrProgress" style="display: none;">
                <div id="innerPopup" class="PrContainer">
                    <div class="PrHeader">
                        Loading, please wait...</div>
                    <div class="PrBody">
                        <img width="220px" height="19px" src="Images/activity.gif" alt="loading..." />
                    </div>
                </div>
            </div>
            <div>
                <div id="bodydiv" class="bodytext" align="justify">
                    <table class="InnerForm" border="0">
                        <tr>
                            <td>
                                <span class="orangetitle">Marks Entry</span>
                                <br>
                            </td>
                            <td style="text-align: right;">
                                <asp:LinkButton ID="LinkButton1" runat="server">Close</asp:LinkButton>
                            </td>
                        </tr>
                    </table>
                </div>
                <div id="bodydiv11" class="bodytext" align="left">
                    <table width="100%" class="InnerForm" border="0">
                        <tr>
                            <td class="td_label" style="text-align: left;">
                                <asp:Label ID="Label6" runat="server" Text="Standard" />
                                <asp:DropDownList ID="sysstandardno" ToolTip="Standard" runat="server" DataTextField="standarddesc"
                                    DataValueField="sysstandardno" Enabled="false">
                                </asp:DropDownList>
                                <asp:Label ID="Label12" runat="server" Text="Division" />
                                <asp:DropDownList ID="sysdivisionno" ToolTip="Division" runat="server" DataTextField="divisiondesc"
                                    DataValueField="sysdivisionno" Enabled="false">
                                </asp:DropDownList>
                                <asp:Label ID="Label13" runat="server" Text="Exam" />
                                <asp:DropDownList ID="sysexamno" ToolTip="Exam" runat="server" DataTextField="examdesc"
                                    DataValueField="sysexamno" Enabled="false">
                                </asp:DropDownList>
                                <asp:Label ID="Label21" runat="server" Text="Subject" />
                                <asp:DropDownList ID="syssubjectno" ToolTip="Subject" runat="server" DataTextField="subjectname"
                                    DataValueField="syssubjectno" Enabled="false">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr class="tr_button">
                            <td align="center">
                                <asp:Button ID="btnsave" runat="server" Text="Save" CssClass="button" ValidationGroup="btnsave" />
                            </td>
                        </tr>
                      
                    </table>
                    <table width="100%" class="InnerForm" id="ExamMarksEntry" runat="server">
                        <tr>
                            <td>
                                <table class="InnerForm" width="100%" id="MarksList" runat="server">
                                    <tr>
                                        <td>
                                            <asp:CheckBox ID="chkSelectAll" runat="server" Text="Select All" AutoPostBack="true" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:GridView ID="gvList" runat="server" AutoGenerateColumns="False" Width="100%"
                                                Height="100%" AlternatingRowStyle-BackColor="LightBlue">
                                                <Columns>
                                                    <asp:BoundField DataField="sysmarksno" HeaderText="PK" />
                                                    <asp:BoundField DataField="sysstudentno" HeaderText="PK" />
                                                    <asp:TemplateField>
                                                        <ItemTemplate>
                                                            <asp:CheckBox ID="Selected" runat="server" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="rollno" HeaderText="Roll No." />
                                                    <asp:BoundField DataField="fullname" HeaderText="Student Name" />
                                                    <asp:BoundField DataField="writtenmark" HeaderText="Written Marks" />
                                                    <asp:TemplateField HeaderText="Written Marks">
                                                        <ItemTemplate>
                                                            <asp:TextBox runat="server" ToolTip='<%#Container.DataItem("writtenmark")%>' ID="writtenmark"
                                                                MaxLength="10" Columns="5" EnableTheming="true"></asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="oralmark" HeaderText="Oral" />
                                                    <asp:TemplateField HeaderText="Oral Marks">
                                                        <ItemTemplate>
                                                            <asp:TextBox runat="server" ToolTip='<%#Container.DataItem("oralmark")%>' ID="oralmark"
                                                                MaxLength="10" Columns="5" OnTextChanged="oralmark_TextChanged"></asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="gracemark" HeaderText="Grace" />
                                                    <asp:TemplateField HeaderText="Grace Marks">
                                                        <ItemTemplate>
                                                            <asp:TextBox runat="server" ToolTip='<%#Container.DataItem("gracemark")%>' ID="gracemark"
                                                                MaxLength="10" Columns="5"></asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="preabsstatus" HeaderText="Status" />
                                                    <asp:TemplateField HeaderText="Status" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                                        <ItemTemplate>
                                                            <asp:DropDownList runat="server" ID="preabsstatus" ToolTip='<%#Container.DataItem("preabsstatus")%>'
                                                                AutoPostBack="true" OnSelectedIndexChanged="preabsstatus_SelectedIndexChanged">
                                                                <asp:ListItem Text="Present" Value="01"></asp:ListItem>
                                                                <asp:ListItem Text="Absent" Value="02"></asp:ListItem>
                                                                <asp:ListItem Text="Sick" Value="03"></asp:ListItem>
                                                                <asp:ListItem Text="Sports" Value="04"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="description" HeaderText="Reason" />
                                                    <asp:TemplateField HeaderText="Reason" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="description" ToolTip="Reason" MaxLength="200" runat="server" Columns="25"
                                                                TextMode="MultiLine" Rows="1"></asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField>
                                                        <ItemTemplate>
                                                            <asp:LinkButton runat="server" ID="btnDelete" Text="Delete" OnClick="btnDelete_Click" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                          <tr>
                            <td colspan="5">
                                <asp:Label ID="lblwritten" runat="server" Text=" " /><br />
                                <asp:Label ID="lbloral" runat="server" Text="" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:TextBox ID="sysmarksno" runat="server" Visible="false" />
                                <asp:TextBox ID="WEM" runat="server" Visible="false" />
                                <asp:TextBox ID="OEM" runat="server" Visible="false" />
                                <asp:TextBox ID="written" runat="server" Visible="false" />
                                <asp:TextBox ID="oral" runat="server" Visible="false" />
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
        </ContentTemplate>
    </asp1:UpdatePanel>

    <script type="text/javascript">
        Sys.Application.add_load(applicationLoadHandler);
        Sys.Application.add_unload(applicationUnloadHandler);
        Sys.WebForms.PageRequestManager.getInstance().add_endRequest(endRequestHandler);
        Sys.WebForms.PageRequestManager.getInstance().add_beginRequest(beginRequestHandler);
    </script>
    </form>
</body>
</html>
