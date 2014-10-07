<%@ Page Language="VB" MasterPageFile="~/Main.master" AutoEventWireup="false" CodeFile="dlpFacultyAttendance.aspx.vb"
    Inherits="dlpFacultyAttendance" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <head id="Head1">
        <title>Faculty Attendance Entry</title>
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
                    <table class="InnerForm" border="0">
                        <tr>
                            <td>
                                <span class="orangetitle">Faculty Attendance Entry</span> </br>
                            </td>
                            <td style="text-align: right;">
                                <a href="Dashboard.aspx" title="Close">Close</a>
                            </td>
                        </tr>
                    </table>
                </div>
                <div id="bodydiv" class="bodytext" align="justify">
                    <table width="100%" border="1" class="InnerForm">
                        <tr>
                            <td class="td_label">
                                <asp:Label ID="Label5" runat="server" Text="Date" />
                            </td>
                            <td class="td_control" colspan="3">
                                <asp:TextBox ID="trndt" AutoPostBack="true" runat="server" MaxLength="10" Columns="12"
                                    EnableTheming="false"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                    <table class="InnerForm">
                        <tr>
                            <td class="td_control">
                                <asp:Button ID="btnRemoveAttendance" runat="server" Text="Remove Attendance" EnableTheming="false" />
                            </td>
                            <td class="td_control">
                                <asp:Button ID="btnSave" runat="server" Text="Save" ValidationGroup="btnSave" />
                            </td>
                        </tr>
                    </table>
                    <table width="100%" class="InnerForm" id="AttendanceSummeryTable" runat="server">
                        <tr>
                            <td>
                                <table class="InnerForm" width="100%" id="Table2" runat="server">
                                    <tr>
                                        <td>
                                            <asp:GridView ID="gvattsummery" runat="server" AllowPaging="True" AutoGenerateColumns="false" 
                                                PageSize="15" Width="100%" EmptyDataText="No attendence saved yet" AlternatingRowStyle-BackColor="LightBlue">
                                                <Columns>
                                                    <asp:BoundField DataField="Present" HeaderText="Present" HeaderStyle-HorizontalAlign="Center"
                                                        ItemStyle-HorizontalAlign="Center" NullDisplayText="0" />
                                                    <asp:BoundField DataField="Absent" HeaderText="Absent" HeaderStyle-HorizontalAlign="Center"
                                                        ItemStyle-HorizontalAlign="Center" NullDisplayText="0" />
                                                    <asp:BoundField DataField="Sick" HeaderText="Sick" HeaderStyle-HorizontalAlign="Center"
                                                        ItemStyle-HorizontalAlign="Center" NullDisplayText="0" />
                                                    <asp:BoundField DataField="Sports" HeaderText="Sports" HeaderStyle-HorizontalAlign="Center"
                                                        ItemStyle-HorizontalAlign="Center" NullDisplayText="0" />
                                                    <asp:BoundField DataField="Total" HeaderText="Total" HeaderStyle-HorizontalAlign="Center"
                                                        ItemStyle-HorizontalAlign="Center" NullDisplayText="0" />
                                                </Columns>
                                            </asp:GridView>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                    <table width="100%" class="InnerForm" id="AttendanceEntryTable" runat="server">
                        <tr>
                            <td>
                                <table class="InnerForm" width="100%" id="ChapterList" runat="server">
                                    <tr>
                                        <td>
                                            <asp:GridView ID="gvfacultyList" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                                Width="100%" PageSize="200" AlternatingRowStyle-BackColor="LightBlue">
                                                <Columns>
                                                    <asp:BoundField DataField="sysfacultyattno" HeaderText="PK" />
                                                    <asp:BoundField DataField="sysfacultyno" HeaderText="PK" />
                                                    <asp:BoundField DataField="facultycode" HeaderText="Roll No." HeaderStyle-HorizontalAlign="Center"
                                                        ItemStyle-HorizontalAlign="Center" />
                                                    <asp:BoundField DataField="facultyname" HeaderText="Student Name" HeaderStyle-HorizontalAlign="Center" />
                                                    <asp:TemplateField HeaderText="Attendance Status" HeaderStyle-HorizontalAlign="Center"
                                                        ItemStyle-HorizontalAlign="Center">
                                                        <ItemTemplate>
                                                            <asp:DropDownList runat="server" ID="attstatus" DataTextField="gcname" DataValueField="gccode" EnableTheming ="false"
                                                                ToolTip='<%#Container.DataItem("attstatus")%>'>
                                                            </asp:DropDownList>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="attstatus" HeaderText="Attendance Status" />
                                                </Columns>
                                            </asp:GridView>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
            <asp:TextBox ID="systeacherno" runat="server" Visible="false" />
            <asp:TextBox ID="monthdesc" runat="server" Visible="false" />
            <asp:TextBox ID="monthdays" runat="server" Visible="false" />

            <script type="text/javascript">
        //variable that will store the id of the last clicked row
        var previousRow;
        
        function ChangeRowColor(row)
        {
            //If last clicked row and the current clicked row are same
            if (previousRow == row)
                return;//do nothing
            //If there is row clicked earlier
            else if (previousRow != null)
                //change the color of the previous row back to white
                document.getElementById(previousRow).style.backgroundColor = "#ffffff";
            
            //change the color of the current row to light yellow

            document.getElementById(row).style.backgroundColor = "#ced2bf";            
            //assign the current row id to the previous row id 
            //for next row to be clicked
            previousRow = row;
        }
            </script>

        </ContentTemplate>
    </asp1:UpdatePanel>
</asp:Content>
