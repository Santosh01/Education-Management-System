<%@ Page Language="VB" MasterPageFile="~/Main.master" AutoEventWireup="false" CodeFile="rstMarksEntry.aspx.vb"
    Inherits="rstMarksEntry" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <head id="Head1">
        <title>Marks Entry</title>
        <link rel="stylesheet" href="css/style.css" type="text/css" />
    </head>
    <%-- <asp1:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true">
    </asp1:ScriptManager>
    <asp1:UpdatePanel ID="UpdatePanel1" runat="server"> 
        <ContentTemplate>--%>
    <div>
        <div id="bodydiv" class="bodytext" align="justify">
            <table class="InnerForm" border="0">
                <tr>
                    <td>
                        <span class="orangetitle">Marks Entry</span> </br>
                    </td>
                    <td style="text-align: right;">
                        <a href="Dashboard.aspx" title="Close">Close</a>
                    </td>
                </tr>
            </table>
        </div>
        <div id="Div1" class="bodytext" align="justify">
            <table width="100%" class="InnerForm" border="0">
                
                
                <tr>
                    <td class="td_label">
                        <asp:Label ID="Label6" runat="server" Text="Standard" />
                    </td>
                    <td class="td_control">
                        <asp:DropDownList ID="sysstandardno" ToolTip="Standard" runat="server" DataTextField="standarddesc"
                            DataValueField="sysstandardno" AutoPostBack="true" ValidationGroup="btnsave"
                            Width="200px" EnableTheming ="false" >
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Select Standard"
                            ControlToValidate="sysstandardno" ValidationGroup="btnsave"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="td_label">
                        <asp:Label ID="Label12" runat="server" Text="Division" />
                    </td>
                    <td class="td_control">
                        <asp:DropDownList ID="sysdivisionno" ToolTip="Division" runat="server" DataTextField="divisiondesc"
                            DataValueField="sysdivisionno" ValidationGroup="btnsave" AutoPostBack="true" EnableTheming ="false" >
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Select Division"
                            ControlToValidate="sysdivisionno" ValidationGroup="btnsave"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="td_label">
                        <asp:Label ID="Label13" runat="server" Text="Exam" />
                    </td>
                    <td class="td_control">
                        <asp:DropDownList ID="sysexamno" ToolTip="Exam" runat="server" DataTextField="examdesc"
                            DataValueField="sysexamno" AutoPostBack="true" ValidationGroup="btnsave" Width="250px" EnableTheming ="false" >
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Select Exam"
                            ControlToValidate="sysexamno" ValidationGroup="btnsave"></asp:RequiredFieldValidator>
                        <asp:Label ID="lblwritten" runat="server" Text=" " />
                    </td>
                </tr>
                <tr>
                    <td class="td_label">
                        <asp:Label ID="Label21" runat="server" Text="Subject" />
                    </td>
                    <td class="td_control">
                        <asp:DropDownList ID="syssubjectno" ToolTip="Subject" runat="server" DataTextField="subjectname"
                            DataValueField="syssubjectno" AutoPostBack="true" ValidationGroup="btnsave" Width="250px" EnableTheming ="false" >
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Select Subject"
                            ControlToValidate="syssubjectno" ValidationGroup="btnsave"></asp:RequiredFieldValidator>
                        <asp:Label ID="lbloral" runat="server" Text=" " />
                    </td>
                </tr>
                <tr class="tr_button">
                    <td colspan="2" align="center">
                        <asp:Button ID="btnsave" runat="server" Text="Save" CssClass="button" ValidationGroup="btnsave" OnClick="btnSAVE_Click" />
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="button" OnClick="btnCancel_Click" />
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="btnRemoveAttendance" runat="server" Text="Remove Marks" EnableTheming ="false" />
                    </td>
                </tr>
            </table>
            <table class="InnerForm" width="100%" id="MarksList" runat="server">
                <tr>
                    <td>
                        <asp:GridView ID="gvList" runat="server" AutoGenerateColumns="False" Width="100%" AllowPaging="false"
                            Height="100%" AlternatingRowStyle-BackColor="LightBlue">
                            <Columns>
                                <asp:BoundField DataField="standarddesc" HeaderText="Standard" />
                                <asp:BoundField DataField="divisiondesc" HeaderText="Division" />
                                <asp:BoundField DataField="subjectname" HeaderText="Subject">
                                 <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" width="300px" />
                                     </asp:BoundField>
                                <asp:BoundField DataField="noofstudents" HeaderText="Marks Enterd For Students" >
                                 <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" width="20px" />
                                     </asp:BoundField>
                                <asp:BoundField DataField="marksentered" HeaderText="Marks Enterd"  >
                                 <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" width="20px" />
                                     </asp:BoundField>
                                <asp:BoundField DataField="zeromarks" HeaderText="Zero Marks " >
                                 <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" width="20px" />
                                     </asp:BoundField>
                            </Columns>
                        </asp:GridView>
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

    <%--</asp1:UpdatePanel>--%>
</asp:Content>
