<%@ Page Language="VB" MasterPageFile="~/Main.master" AutoEventWireup="false" CodeFile="mstFacultyMaster.aspx.vb"
    Inherits="mstFacultyMaster" Title="Faculty" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <head id="Head1">
        <title>Faculty</title>
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
                <asp:TableRow ID="TableRow4" runat="server">
                    <asp:TableCell Width="50%" ColumnSpan="3" ForeColor="orange" BackColor="LightGray">
                        <asp:Label ID="Label23" runat="server" Text="Faculty"></asp:Label>
                        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp &nbsp; &nbsp; &nbsp;
                        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                        &nbsp; &nbsp; &nbsp &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp<asp:LinkButton
                            ID="btnclose" runat="server" ToolTip="Close">Close</asp:LinkButton>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow ID="TableRow9" runat="server">
                    <asp:TableCell HorizontalAlign="Justify">
                        <asp:GridView ID="gvList" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                            PageSize="8" Width="100%" AlternatingRowStyle-BackColor="LightBlue">
                            <Columns>
                                <asp:BoundField DataField="sysfacultyno" HeaderText="PK" />
                                <asp:BoundField DataField="facultyname" HeaderText="Faculty Name" ItemStyle-HorizontalAlign="Center"
                                    HeaderStyle-HorizontalAlign="Center" />
                                <asp:BoundField DataField="mobileno" HeaderText="Mobile No" ItemStyle-HorizontalAlign="Center"
                                    HeaderStyle-HorizontalAlign="Center" />
                                <asp:BoundField DataField="telno" HeaderText="Telephone No" ItemStyle-HorizontalAlign="Center"
                                    HeaderStyle-HorizontalAlign="Center" />
                                <asp:BoundField DataField="joineddt" HeaderText="Joining Date" ItemStyle-HorizontalAlign="Center"
                                    HeaderStyle-HorizontalAlign="Center" />
                                <asp:TemplateField HeaderStyle-Width="68px">
                                    <ItemTemplate>
                                        <asp:LinkButton runat="server" ID="btnEdit" Text="Edit" ToolTip="Edit" OnClick="btnEdit_Click" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderStyle-Width="68px">
                                    <ItemTemplate>
                                        <asp:LinkButton runat="server" ID="btnDelete" Text="Delete" ToolTip="Delete" OnClick="btnDelete_Click"
                                            OnClientClick="return confirm('Are you sure you want to delete');" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </asp:TableCell>
                </asp:TableRow>
            </asp:Table>
            <asp:Table ID="Table1" runat="server" BorderStyle="Solid" BorderWidth="1px" Width="100%"
                GridLines="Both" BorderColor="controlDarkDark">
                <asp:TableRow ID="TableRow6" runat="server">
                    <asp:TableCell ID="TableCell1" runat="server" ColumnSpan="7" HorizontalAlign="Left">
                        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                        <asp:Label ID="Label1" runat="server" Text=" (*) Required Fields" Style="color: Red"
                            Font-Size="Larger"></asp:Label>
                        <br />
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableHeaderRow ID="TableRow1" runat="server" BorderStyle="Solid">
                    <asp:TableCell ID="TableCell2" runat="server" HorizontalAlign="Center" BorderStyle="Inset"
                        BackColor="Orange" ColumnSpan="4">
                        <asp:Label ID="Label6" runat="server" Text="Faculty Form"></asp:Label>
                    </asp:TableCell>
                </asp:TableHeaderRow>
                <asp:TableRow>
                    <asp:TableCell ColumnSpan="6" HorizontalAlign="Left" BackColor="controlDarkDark">
                        <asp:Label ID="Label7" runat="server" Text="Register Details" Style="color: White"></asp:Label>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow ID="TableHeaderRow3" runat="server">
                    <asp:TableCell ID="TableCell6" runat="server" Width="150px" HorizontalAlign="Right">
                        <asp:Label ID="Label2" runat="server" Text="Code"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell ID="TableCell7" runat="server" HorizontalAlign="Left" ColumnSpan="3">
                        <asp:TextBox ID="facultycode" runat="server" Width="25%"></asp:TextBox>
                        &nbsp;
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="facultycode"
                            ValidationGroup="Btnsave" Text="*" SetFocusOnError="true" />
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow ID="TableRow11" runat="server">
                    <asp:TableCell ID="TableCell26" runat="server" HorizontalAlign="Right">
                        <asp:Label ID="Label14" runat="server" Text="Joining Date"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell ID="TableCell27" runat="server" HorizontalAlign="Left" ColumnSpan="3">
                        <asp:TextBox ID="joineddt" runat="server" Width="25%" MaxLength="10"></asp:TextBox>
                        &nbsp;
                        <asp:ImageButton ID="Image1" runat="server" ImageUrl="Images/calendar-button.gif"
                            Width="2%" AlternateText="Click to show calendar" ImageAlign="AbsMiddle" />
                        <ajaxToolkit:CalendarExtender ID="CalendarButtonExtender1" runat="server" TargetControlID="joineddt"
                            PopupButtonID="image1" Format="dd/MM/yyyy">
                        </ajaxToolkit:CalendarExtender>
                        &nbsp
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="joineddt"
                            ValidationGroup="Btnsave" Text="*" SetFocusOnError="true" />
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow ID="TableRow15" runat="server">
                    <asp:TableCell ID="TableCell34" runat="server" HorizontalAlign="Right">
                        <asp:Label ID="Label18" runat="server" Text="School Name"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell ID="TableCell35" runat="server" HorizontalAlign="Left" ColumnSpan="3">
                    <asp:DropDownList ID="sysschoolno" runat="server" Width="45%" DataValueField="sysschoolno"
                            EnableTheming="false" DataTextField="schoolname">
                        </asp:DropDownList>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow ID="TableRow14" runat="server">
                    <asp:TableCell ID="TableCell32" runat="server" HorizontalAlign="Right">
                        <asp:Label ID="Label17" runat="server" Text="Status"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell ID="TableCell33" runat="server" HorizontalAlign="Left" ColumnSpan="3">
                        <asp:DropDownList ID="status" runat="server" Width="20%" DataValueField="gccode"
                            DataTextField="gcname">
                        </asp:DropDownList>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell ColumnSpan="6" HorizontalAlign="Left" BackColor="controlDarkDark">
                        <asp:Label ID="Label21" runat="server" Text="Faculty Details" Style="color: White"></asp:Label>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow ID="TableRow2" runat="server">
                    <asp:TableCell ID="TableCell8" runat="server" HorizontalAlign="Right">
                        <asp:Label ID="Label4" runat="server" Text="Faculty Name"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell ID="TableCell9" runat="server" HorizontalAlign="Left" ColumnSpan="3">
                        <asp:DropDownList ID="facultyname1" runat="server" DataValueField="gcname" EnableTheming="false">
                        </asp:DropDownList>
                        &nbsp
                        <asp:TextBox ID="facultyname" runat="server" Width="33%"></asp:TextBox>
                        &nbsp;
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="facultyname"
                            ValidationGroup="Btnsave" Text="*" SetFocusOnError="true" />
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow ID="TableRow8" runat="server">
                    <asp:TableCell ID="TableCell20" runat="server" HorizontalAlign="Right">
                        <asp:Label ID="Label11" runat="server" Text="Birth Date"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell ID="TableCell21" runat="server" HorizontalAlign="Left" ColumnSpan="3">
                        <asp:TextBox ID="birthdt" runat="server" Width="25%" MaxLength="10"></asp:TextBox>
                        &nbsp
                        <asp:ImageButton ID="Image2" runat="server" ImageUrl="Images/calendar-button.gif"
                            Width="2%" AlternateText="Click to show calendar" ImageAlign="AbsMiddle" />
                        <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="birthdt"
                            PopupButtonID="image2" Format="dd/MM/yyyy">
                        </ajaxToolkit:CalendarExtender>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow ID="TableRow3" runat="server">
                    <asp:TableCell ID="TableCell10" runat="server" HorizontalAlign="Right">
                        <asp:Label ID="Label5" runat="server" Text="Gender"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell ID="TableCell11" runat="server" HorizontalAlign="Left">
                        <asp:DropDownList ID="gender" runat="server" DataValueField="gccode" DataTextField="gcname"
                            EnableTheming="false">
                        </asp:DropDownList>
                    </asp:TableCell>
                    <asp:TableCell ID="TableCell24" runat="server" HorizontalAlign="Right">
                        <asp:Label ID="Label13" runat="server" Text="Marital Status"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell ID="TableCell25" runat="server" HorizontalAlign="Left">
                        <asp:DropDownList ID="maritalstatus" runat="server" DataValueField="gccode" DataTextField="gcname"
                            EnableTheming="false">
                        </asp:DropDownList>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow ID="TableRow13" runat="server">
                    <asp:TableCell ID="TableCell30" runat="server" HorizontalAlign="Right">
                        <asp:Label ID="Label16" runat="server" Text="Qualification"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell ID="TableCell31" runat="server" HorizontalAlign="Left" ColumnSpan="3">
                        <asp:TextBox ID="qualification" runat="server" Width="43%"></asp:TextBox>
                        &nbsp;
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="qualification"
                            ValidationGroup="Btnsave" Text="*" SetFocusOnError="true" />
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow ID="TableRow7" runat="server">
                    <asp:TableCell ID="TableCell18" runat="server" HorizontalAlign="Right">
                        <asp:Label ID="Label10" runat="server" Text="Email ID"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell ID="TableCell19" runat="server" HorizontalAlign="Left" ColumnSpan="3">
                        <asp:TextBox ID="emailid" runat="server" Width="43%"></asp:TextBox>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell ColumnSpan="6" HorizontalAlign="Left" BackColor="controlDarkDark">
                        <asp:Label ID="Label12" runat="server" Text="Residence Address" Style="color: White"></asp:Label>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow ID="TableRow5" runat="server">
                    <asp:TableCell ID="TableCell14" runat="server" HorizontalAlign="Right">
                        <asp:Label ID="Label8" runat="server" Text="Telephone No"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell ID="TableCell15" runat="server" HorizontalAlign="Left">
                        <asp:TextBox ID="telno" runat="server" MaxLength="12"></asp:TextBox>
                        &nbsp;
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="telno"
                            ValidationGroup="Btnsave" Text="*" SetFocusOnError="true" />
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" ControlToValidate="telno"
                            ValidationExpression="\d+" Display="Static" EnableClientScript="true" ErrorMessage="* enter numbers only"
                            runat="server" />
                    </asp:TableCell>
                    <asp:TableCell ID="TableCell16" runat="server" HorizontalAlign="Right">
                        <asp:Label ID="Label9" runat="server" Text="Mobile No"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell ID="TableCell17" runat="server" HorizontalAlign="Left">
                        <asp:TextBox ID="mobileno" runat="server" MaxLength="12"></asp:TextBox>
                        &nbsp;
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="mobileno"
                            ValidationGroup="Btnsave" Text="*" SetFocusOnError="true" />
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="mobileno"
                            ValidationExpression="\d+" Display="Static" EnableClientScript="true" ErrorMessage="* enter numbers only"
                            runat="server" />
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow ID="TableRow16" runat="server">
                    <asp:TableCell ID="TableCell36" runat="server" HorizontalAlign="Right">
                        <asp:Label ID="Label19" runat="server" Text="Address"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell ID="TableCell37" runat="server" HorizontalAlign="Left" ColumnSpan="3">
                        <asp:TextBox ID="address1" Rows="4" TextMode="multiline" runat="server" Width="27%"
                            MaxLength="100" />
                        &nbsp;
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="address1"
                            ValidationGroup="Btnsave" Text="*" SetFocusOnError="true" />
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow ID="TableRow18" runat="server">
                    <asp:TableCell ID="TableCell40" runat="server" HorizontalAlign="Right">
                        <asp:Label ID="Label20" runat="server" Text="Pin Code"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell ID="TableCell41" runat="server" HorizontalAlign="Left" ColumnSpan="3">
                        <asp:TextBox ID="pincode" runat="server" MaxLength="6"></asp:TextBox>
                        &nbsp;
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="pincode"
                            ValidationGroup="Btnsave" Text="*" SetFocusOnError="true" />
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" ControlToValidate="pincode"
                            ValidationExpression="\d+" Display="Static" ErrorMessage="Please enter numbers only"
                            runat="server" SetFocusOnError="true" />
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell ID="button" HorizontalAlign="Center" ColumnSpan="4">
                        <asp:Button ID="btnsave" runat="server" Text="Save" Width="114px" ValidationGroup="Btnsave" />
                        &nbsp;&nbsp;&nbsp;
                        <asp:Button ID="btnCancel" runat="server" Text="Cancel" Width="102px" />
                        <asp:TextBox ID="sysfacultyno" runat="server" Width="43%" Visible="false"></asp:TextBox>
                    </asp:TableCell>
                </asp:TableRow>
            </asp:Table>
        </ContentTemplate>
    </asp1:UpdatePanel>
</asp:Content>
