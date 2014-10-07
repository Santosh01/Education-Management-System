<%@ Page Language="VB" MasterPageFile="~/Main.master" AutoEventWireup="false" CodeFile="stdStudentForm.aspx.vb"
    Inherits="stdStudentForm" Title="Student Form" %>

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
                <asp:TableRow ID="TableRow7" runat="server">
                    <asp:TableCell HorizontalAlign="Right" Width="50%" ColumnSpan="3" ForeColor="orange"
                        BackColor="LightGray">
                        <asp:Label ID="Label2" runat="server" Text="Student Registration Form"></asp:Label>
                        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp; &nbsp;&nbsp;&nbsp;
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; <a
                            href="Dashboard.aspx" title="Close">Close</a>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow ID="TableRow9" runat="server">
                    <asp:TableCell HorizontalAlign="Justify">
                        <asp:GridView ID="gvList" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                            PageSize="8" Width="100%" AlternatingRowStyle-BackColor="LightBlue">
                            <Columns>
                                <asp:BoundField DataField="sysstudentno" HeaderText="PK" />
                                <asp:BoundField DataField="sfirstname" HeaderText="Student Name" ItemStyle-HorizontalAlign="Center"
                                    HeaderStyle-HorizontalAlign="Center" />
                                <asp:BoundField DataField="mobileno" HeaderText="Mobile No" ItemStyle-HorizontalAlign="Center"
                                    HeaderStyle-HorizontalAlign="Center" />
                                <asp:BoundField DataField="resphoneno" HeaderText="Telephone No." ItemStyle-HorizontalAlign="Center"
                                    HeaderStyle-HorizontalAlign="Center" />
                                     <asp:BoundField DataField="emailid" HeaderText="Email ID" ItemStyle-HorizontalAlign="Center"
                                    HeaderStyle-HorizontalAlign="Justify" />
                                <asp:BoundField DataField="admissiondt" HeaderText="Admission Date" ItemStyle-HorizontalAlign="Center"
                                    HeaderStyle-HorizontalAlign="Justify" />
                               
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
                    <asp:TableCell ID="TableCell16" runat="server" ColumnSpan="7" HorizontalAlign="Left">
                        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                        <asp:Label ID="Label13" runat="server" Text=" (*) Required Fields" Style="color: Red"
                            Font-Size="Larger"></asp:Label>
                        <br />
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableHeaderRow>
                    <asp:TableHeaderCell ColumnSpan="6" BackColor="orange">
                        <asp:Label ID="Label3" runat="server" Text="Student Registration Form"></asp:Label>
                    </asp:TableHeaderCell>
                </asp:TableHeaderRow>
                <asp:TableRow>
                    <asp:TableCell ColumnSpan="6" HorizontalAlign="Left" BackColor="controlDarkDark">
                        <asp:Label ID="Label1" runat="server" Text="Register Details" Style="color: White"></asp:Label>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell HorizontalAlign="Right">
                        <asp:Label ID="Label4" runat="server" Text="Roll No"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell HorizontalAlign="Left" ColumnSpan="5">
                        <asp:TextBox ID="rollno" runat="server" MaxLength="20" Style="position: static"></asp:TextBox>
                        &nbsp;
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="rollno"
                            ValidationGroup="Btnsave" Text="*" SetFocusOnError="true" />
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell HorizontalAlign="Right" runat="server" ColumnSpan="1">
                        <asp:Label ID="Label5" runat="server" Text="Admission Date"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell HorizontalAlign="Left" ColumnSpan="4">
                        <asp:TextBox ID="admissiondt" runat="server" MaxLength="10" Style="position: static"></asp:TextBox>
                        &nbsp
                        <asp:ImageButton ID="Image2" runat="server" ImageUrl="Images/calendar-button.gif"
                            Width="2%" AlternateText="Click to show calendar" ImageAlign="AbsMiddle" />
                        <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="admissiondt"
                            PopupButtonID="image2" Format="dd-MM-yyyy" EnableViewState="true">
                        </ajaxToolkit:CalendarExtender>
                        &nbsp;
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="admissiondt"
                            Text="*" ValidationGroup="Btnsave" SetFocusOnError="true" />
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell HorizontalAlign="Right" runat="server">
                        <asp:Label ID="Label7" runat="server" Text="Standard"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell HorizontalAlign="Left" runat="server">
                        <asp:DropDownList ID="sysstandardno" runat="server" DataTextField="standarddesc"
                            EnableTheming="false" DataValueField="sysstandardno" Width="70%" AutoPostBack="true">
                        </asp:DropDownList>
                    </asp:TableCell>
                    <asp:TableCell HorizontalAlign="Right">
                        <asp:Label ID="Label8" runat="server" Text="Division"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell HorizontalAlign="Left">
                        <asp:DropDownList ID="sysdivisionno" runat="server" DataTextField="divisiondesc"
                            EnableTheming="false" DataValueField="sysdivisionno" Width="70%" AutoPostBack="true">
                        </asp:DropDownList>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell HorizontalAlign="Right">
                        <asp:Label ID="Label25" runat="server" Text="School"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell HorizontalAlign="Left" ColumnSpan="4">
                        <asp:DropDownList ID="schoolname" runat="server" DataTextField="schoolname" EnableTheming="false"
                            DataValueField="sysschoolno" Width="34%" AutoPostBack="true">
                        </asp:DropDownList>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell HorizontalAlign="Right">
                        <asp:Label ID="Label9" runat="server" Text="Status"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell HorizontalAlign="Left" ColumnSpan="4">
                        <asp:DropDownList ID="status" runat="server" DataValueField="gccode" EnableTheming="false"
                            DataTextField="gcname" Width="12%">
                        </asp:DropDownList>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell ColumnSpan="6" HorizontalAlign="Left" BackColor="controlDarkDark">
                        <asp:Label ID="Label10" runat="server" Text="Students Details" Style="color: White"></asp:Label>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell HorizontalAlign="Right">
                        <asp:Label ID="Label11" runat="server" Text="Student Name"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell HorizontalAlign="Left">
                        <asp:TextBox ID="sfirstname" runat="server" Style="position: static"></asp:TextBox>
                        &nbsp;
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="sfirstname"
                            Text="*" ValidationGroup="Btnsave" SetFocusOnError="true" />
                    </asp:TableCell>
                    <asp:TableCell HorizontalAlign="Center">
                        <asp:TextBox ID="smiddlename" runat="server" Style="position: static"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="smiddlename"
                            Text="*" ValidationGroup="Btnsave" SetFocusOnError="true" />
                    </asp:TableCell>
                    <asp:TableCell HorizontalAlign="Center">
                        <asp:TextBox ID="slastname" runat="server" Style="position: static"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="slastname"
                            Text="*" ValidationGroup="Btnsave" SetFocusOnError="true" />
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell HorizontalAlign="Right">
                        <asp:Label ID="Label6" runat="server" Text="Father Name"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell HorizontalAlign="Left">
                        <asp:TextBox ID="ffirstname" runat="server" Style="position: static"></asp:TextBox>
                    </asp:TableCell>
                    <asp:TableCell HorizontalAlign="Center">
                        <asp:TextBox ID="fmiddlename" runat="server" Style="position: static"></asp:TextBox>
                    </asp:TableCell>
                    <asp:TableCell HorizontalAlign="Center">
                        <asp:TextBox ID="flastname" runat="server" Style="position: static"></asp:TextBox>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow runat="server">
                    <asp:TableCell HorizontalAlign="Right">
                        <asp:Label ID="Label21" runat="server" Text="Mother Name"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell HorizontalAlign="Left">
                        <asp:TextBox ID="mfirstname" runat="server" Style="position: static"></asp:TextBox>
                    </asp:TableCell>
                    <asp:TableCell HorizontalAlign="Center">
                        <asp:TextBox ID="mmiddlename" runat="server" Style="position: static"></asp:TextBox>
                    </asp:TableCell>
                    <asp:TableCell HorizontalAlign="Center">
                        <asp:TextBox ID="mlastname" runat="server" Style="position: static"></asp:TextBox>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell HorizontalAlign="Right">
                        <asp:Label ID="Label12" runat="server" Text="Date Of Birth"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell ColumnSpan="4" HorizontalAlign="Left">
                        <asp:TextBox ID="birthdt" runat="server" MaxLength="10" Style="position: static"></asp:TextBox>
                        &nbsp
                        <asp:ImageButton ID="Image3" runat="server" ImageUrl="Images/calendar-button.gif"
                            Width="2%" AlternateText="Click to show calendar" ImageAlign="AbsMiddle" />
                        <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="birthdt"
                            PopupButtonID="image3" Format="DD-MM-yyyy" EnableViewState="true">
                        </ajaxToolkit:CalendarExtender>
                        &nbsp;
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="birthdt"
                            Text="*" ValidationGroup="Btnsave" SetFocusOnError="true" />
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell HorizontalAlign="Right">
                        <asp:Label ID="Label14" runat="server" Text="Gender"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell ColumnSpan="3" HorizontalAlign="Left">
                        <asp:DropDownList ID="gender" runat="server" DataTextField="gcname" EnableTheming="false"
                            DataValueField="gccode">
                        </asp:DropDownList>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell HorizontalAlign="Right">
                        <asp:Label ID="Label20" runat="server" Text="Email ID"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell ColumnSpan="3" HorizontalAlign="Left">
                        <asp:TextBox ID="emailid" runat="server" Width="33%" Style="position: static"></asp:TextBox>
                        &nbsp;
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="emailid"
                            Text="*" ValidationGroup="Btnsave" SetFocusOnError="true" />
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator11" ControlToValidate="emailid"
                            ValidationExpression="\b[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}\b" Display="Static"
                            EnableClientScript="true" ErrorMessage="* Invalid Email-ID" runat="server" />
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell ColumnSpan="6" HorizontalAlign="Left" BackColor="controlDarkDark">
                        <asp:Label ID="Label15" runat="server" Text="Residence Address" Style="color: White"></asp:Label>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell HorizontalAlign="Right">
                        <asp:Label ID="Label16" runat="server" Text="Residence Address"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell ColumnSpan="3" HorizontalAlign="Left">
                        <asp:TextBox ID="homeaddress1" Rows="3" TextMode="multiline" Style="position: static"
                            runat="server" Width="33%" MaxLength="40" />
                        &nbsp
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="homeaddress1"
                            Text="*" ValidationGroup="Btnsave" SetFocusOnError="true" />
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell HorizontalAlign="Right">
                        <asp:Label ID="Label17" runat="server" Text="Pin Code"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell ColumnSpan="3" HorizontalAlign="Left">
                        <asp:TextBox ID="homepincode" runat="server" MaxLength="7" Style="position: static"></asp:TextBox>
                        &nbsp
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ControlToValidate="homepincode"
                            Text="*" ValidationGroup="Btnsave" SetFocusOnError="true" />
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" ControlToValidate="homepincode"
                            ValidationExpression="\d+" Display="Static" EnableClientScript="true" ErrorMessage="* Please enter numbers only"
                            runat="server" />
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell HorizontalAlign="Right">
                        <asp:Label ID="Label18" runat="server" Text="Res Phone No"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell ColumnSpan="3" HorizontalAlign="Left">
                        <asp:TextBox ID="resphoneno" runat="server" MaxLength="12" Style="position: static"></asp:TextBox>
                        &nbsp
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ControlToValidate="resphoneno"
                            Text="*" ValidationGroup="Btnsave" SetFocusOnError="true" />
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="resphoneno"
                            ValidationExpression="\d+" Display="Static" EnableClientScript="true" ErrorMessage="* Please enter numbers only"
                            runat="server" />
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell HorizontalAlign="Right">
                        <asp:Label ID="Label22" runat="server" Text="Mobile No"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell ColumnSpan="3" HorizontalAlign="Left">
                        <asp:TextBox ID="mobileno" runat="server" MaxLength="12" Style="position: static"></asp:TextBox>
                        &nbsp
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" ControlToValidate="mobileno"
                            Text="*" ValidationGroup="Btnsave" SetFocusOnError="true" />
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" ControlToValidate="mobileno"
                            ValidationExpression="\d+" Display="Static" EnableClientScript="true" ErrorMessage="* Please enter numbers only"
                            runat="server" />
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell HorizontalAlign="Center" ColumnSpan="6" BackColor="#cccccc">
                        <asp:Button ID="Btnsave" runat="server" Text="Save" Style="position: static" ValidationGroup="Btnsave"
                            Width="15%" />&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="Btncancel" runat="server" Style="position: static" Text="Cancel"
                            Width="15%" />
                        <asp:TextBox ID="sysstudentno" runat="server" Visible="false"></asp:TextBox>
                    </asp:TableCell>
                </asp:TableRow>
            </asp:Table>
        </ContentTemplate>
    </asp1:UpdatePanel>
</asp:Content>
