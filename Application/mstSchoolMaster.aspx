<%@ Page Language="VB" MasterPageFile="~/Main.master" AutoEventWireup="false" CodeFile="mstSchoolMaster.aspx.vb"
    Inherits="mstSchoolMaster" Title="School" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <head>
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
                        <asp:Label ID="Label8" runat="server" Text="School"></asp:Label>
                        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp; &nbsp;&nbsp;&nbsp;
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                        &nbsp; &nbsp; &nbsp;&nbsp;&nbsp;&nbsp; &nbsp; <a href="Dashboard.aspx" title="Close">
                            Close</a>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow ID="TableRow9" runat="server">
                    <asp:TableCell HorizontalAlign="Justify">
                        <asp:GridView ID="gvList" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                            PageSize="8" Width="100%" AlternatingRowStyle-BackColor="LightBlue">
                            <Columns>
                                <asp:BoundField DataField="sysschoolno" HeaderText="PK" />
                                <asp:BoundField DataField="schoolname" HeaderText="Name" ItemStyle-HorizontalAlign="Center"
                                    HeaderStyle-HorizontalAlign="Center" HeaderStyle-Width="25%" />
                                <asp:BoundField DataField="fromstd" HeaderText="From Standard" ItemStyle-HorizontalAlign="Center"
                                    HeaderStyle-HorizontalAlign="Center" />
                                <asp:BoundField DataField="tostd" HeaderText="To Standard" ItemStyle-HorizontalAlign="Center"
                                    HeaderStyle-HorizontalAlign="Center" />
                                <asp:BoundField DataField="principalname" HeaderText="Principal Name" ItemStyle-HorizontalAlign="Center"
                                    HeaderStyle-HorizontalAlign="Center" />
                                <asp:BoundField DataField="phoneno" HeaderText="Telephone No." ItemStyle-HorizontalAlign="Center"
                                    HeaderStyle-HorizontalAlign="Center" />
                                <asp:TemplateField HeaderStyle-Width="68px">
                                    <ItemTemplate>
                                        <asp:LinkButton runat="server" ID="btnEdit" Text="Edit" ToolTip ="Edit" OnClick="btnEdit_Click" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderStyle-Width="68px">
                                    <ItemTemplate>
                                        <asp:LinkButton runat="server" ID="btnDelete" Text="Delete" ToolTip ="Delete" OnClick="btnDelete_Click" OnClientClick="return confirm('Are you sure you want to delete');" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </asp:TableCell>
                </asp:TableRow>
            </asp:Table>
            <br />
            <asp:Table ID="Table1" runat="server" BorderStyle="Solid" BorderWidth="1px" Width="100%"
                GridLines="Both" BorderColor="gray">
                <asp:TableRow ID="TableRow6" runat="server">
                    <asp:TableCell ID="TableCell16" runat="server" ColumnSpan="7" HorizontalAlign="Left">
                    &nbsp;  &nbsp;  &nbsp;  &nbsp;  &nbsp;
                         <asp:Label ID="Label2" runat="server" Text=" (*) Required Fields" Style="color: Red" Font-Size="Larger"></asp:Label>
                    
                  
                    <br />
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow runat="server">
                    <asp:TableCell ColumnSpan="7" HorizontalAlign="Left" BackColor="controlDarkDark">
                        <asp:Label ID="Label10" runat="server" Text="School Details" Style="color: White"></asp:Label>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow runat="server" BorderColor="Black" Width="40%">
                    <asp:TableCell runat="server" HorizontalAlign="Right">
                        <asp:Label ID="Label6" runat="server" Text="School Short Name"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell runat="server" HorizontalAlign="Left" ColumnSpan="6">
                        <asp:TextBox ID="schoolsname" runat="server" MaxLength="10" Width="30%"></asp:TextBox>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow runat="server">
                    <asp:TableCell runat="server" HorizontalAlign="Right">
                        <asp:Label ID="Label7" runat="server" Text="School Name"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell runat="server" HorizontalAlign="Left" ColumnSpan="6">
                    
                        <asp:TextBox ID="schoolname" runat="server" MaxLength="100" Style="position:static"
                            Width="40%" ValidationGroup="BtnSave"></asp:TextBox>
                            &nbsp
                             <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="schoolname"
                            Text="* required" ValidationGroup="BtnSave" SetFocusOnError="true" />
                        
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ErrorMessage=" * Only characters allowed"
                            ControlToValidate="schoolname" ValidationExpression="^[a-zA-Z''-'\s]{1,40}$"
                            EnableClientScript="true" Font-Size="Small" SetFocusOnError="true" ValidationGroup="BtnSave"></asp:RegularExpressionValidator>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell ID="TableCell10" HorizontalAlign="Right" runat="server">
                        <asp:Label ID="Label4" runat="server" Text="From Standard"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell ID="TableCell15" HorizontalAlign="Left" runat="server">
                        <asp:DropDownList ID="fromstd" runat="server" EnableTheming ="false" DataTextField="standarddesc" Width="35%"
                            AutoPostBack="true">
                        </asp:DropDownList>
                    </asp:TableCell>
                    <asp:TableCell HorizontalAlign="Right">
                        <asp:Label ID="Label15" runat="server" Text="To Standard"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell HorizontalAlign="Left">
                        <asp:DropDownList ID="tostd" runat="server" DataTextField="standarddesc" EnableTheming ="false" Width="35%"
                            AutoPostBack="true" ValidationGroup="BtnSave" >
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="* Select Standard"
                            ControlToValidate="tostd" ValidationGroup="BtnSave" Font-Size="Small"></asp:RequiredFieldValidator>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell ColumnSpan="7" HorizontalAlign="Left" BackColor="controlDarkDark">
                        <asp:Label ID="Label11" runat="server" Text="Contact Person" Style="color: White"></asp:Label>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow runat="server">
                    <asp:TableCell runat="server" HorizontalAlign="Right">
                        <asp:Label ID="Label13" runat="server" Text="Principal Name"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell runat="server" HorizontalAlign="Left" ColumnSpan="6">
                        <asp:TextBox ID="principalname" runat="server" Style="position:static" MaxLength="50"
                            Width="40%"></asp:TextBox>
                        &nbsp
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="principalname"
                            Text="* required" ValidationGroup="BtnSave" SetFocusOnError="true" />
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow runat="server">
                    <asp:TableCell runat="server" HorizontalAlign="Right">
                        <asp:Label ID="Label14" runat="server" Text="Telephone No"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell runat="server" HorizontalAlign="Left">
                        <asp:TextBox ID="phoneno" runat="server"  Style="position:static" MaxLength="12" Width="47%"></asp:TextBox>
                       
                        &nbsp
                             <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="phoneno" Text="* required" ValidationGroup="BtnSave" SetFocusOnError="true" />
                    </asp:TableCell>
                    <asp:TableCell ID="TableCell8" runat="server" HorizontalAlign="Right">
                        <asp:Label ID="Label5" runat="server" Text="Mobile No"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell ID="TableCell9" runat="server" HorizontalAlign="Left" ColumnSpan="4">
                        <asp:TextBox ID="mobileno" runat="server" MaxLength="12" Style="position:static" Width="47%" ValidationGroup="BtnSave"></asp:TextBox>
                        &nbsp
                             <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="mobileno"
                            Text="* required" ValidationGroup="BtnSave" SetFocusOnError="true" />
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow ID="TableRow3" runat="server">
                    <asp:TableCell ID="TableCell6" runat="server" HorizontalAlign="Right">
                        <asp:Label ID="Label19" runat="server" Text="Fax No"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell ID="TableCell7" runat="server" HorizontalAlign="Left" ColumnSpan="6">
                        <asp:TextBox ID="faxno" runat="server" MaxLength="50" Style="position:static"  ValidationGroup="BtnSave"></asp:TextBox>
                 
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow ID="TableRow4" runat="server">
                    <asp:TableCell ID="TableCell11" runat="server" HorizontalAlign="Right">
                        <asp:Label ID="Label20" runat="server" Text="Email ID"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell ID="TableCell12" runat="server" HorizontalAlign="Left" ColumnSpan="6">
                        <asp:TextBox ID="emailid" runat="server" MaxLength="40" Width="40%" Style="position:static"></asp:TextBox>
                       
                        <ajaxToolkit:TextBoxWatermarkExtender ID="TBWE2" runat="server" TargetControlID="emailid"
                            WatermarkText="<abc123@gmail.com>" WatermarkCssClass="watermark" />
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow ID="TableRow5" runat="server">
                    <asp:TableCell ID="TableCell13" runat="server" HorizontalAlign="Right">
                        <asp:Label ID="Label21" runat="server" Text="Web Site"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell ID="TableCell14" runat="server" HorizontalAlign="Left" ColumnSpan="6">
                        <asp:TextBox ID="website" runat="server" MaxLength="40" Width="35%" Style="position:static" ValidationGroup="BtnSave"></asp:TextBox>
                        
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator10" ControlToValidate="website"
                            ValidationExpression="^(ht|f)tp(s?)\:\/\/[0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*(:(0-9)*)*(\/?)([a-zA-Z0-9\-\.\?\,\'\/\\\+&amp;%\$#_]*)?$"
                            ErrorMessage="Invalid URL,Please type correct fromat 'http://www.microsoft.com'"
                            runat="server" ValidationGroup="BtnSave" />
                        <ajaxToolkit:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1" runat="server"
                            TargetControlID="website" WatermarkText="<http://www.microsoft.com>" WatermarkCssClass="watermark" />
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell ColumnSpan="7" HorizontalAlign="Left" BackColor="controlDarkDark">
                        <asp:Label ID="Label12" runat="server" Text="Address" Style="color: White"></asp:Label>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow runat="server">
                    <asp:TableCell runat="server" HorizontalAlign="Right">
                        <asp:Label ID="Label16" runat="server" Text="Address"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell runat="server" HorizontalAlign="Left" ColumnSpan="6">
                        <asp:TextBox ID="address1" Rows="4" TextMode="multiline"  Style="position:static" runat="server" Width="40%"
                            MaxLength="100"></asp:TextBox>
                            &nbsp
                             <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="address1"
                            Text="* required" ValidationGroup="BtnSave" SetFocusOnError="true" />
                    </asp:TableCell>
                </asp:TableRow>
                
                <asp:TableRow ID="TableRow1" runat="server">
                    <asp:TableCell ID="TableCell2" runat="server" HorizontalAlign="Right">
                        <asp:Label ID="Label1" runat="server" Text="City"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell ID="TableCell3" runat="server" HorizontalAlign="Left">
                        <asp:TextBox ID="city" runat="server" MaxLength="20" Style="position:static"  ValidationGroup="BtnSave"></asp:TextBox>
                        
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator8" runat="server" ErrorMessage=" * characters allowed"
                            ControlToValidate="city" ValidationExpression="^[a-zA-Z]*$" Font-Size="Small"
                            SetFocusOnError="true" ValidationGroup="BtnSave"></asp:RegularExpressionValidator>
                    </asp:TableCell>
                    
                    
                    <asp:TableCell ID="TableCell4" runat="server" HorizontalAlign="Right">
                        <asp:Label ID="Label3" runat="server" Text="State"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell ID="TableCell5" runat="server" HorizontalAlign="Left" ColumnSpan="4">
                        <asp:TextBox ID="state" runat="server" MaxLength="20" Style="position:static" ValidationGroup="BtnSave"></asp:TextBox>
                        
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator9" runat="server" ErrorMessage=" * Only characters allowed"
                            ControlToValidate="state" ValidationExpression="^[a-zA-Z]*$" Font-Size="Small"
                            SetFocusOnError="true" ValidationGroup="BtnSave"></asp:RegularExpressionValidator>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow runat="server">
                    <asp:TableCell runat="server" HorizontalAlign="Right">
                        <asp:Label ID="Label17" runat="server" Text="Pincode"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell runat="server" HorizontalAlign="Left" ColumnSpan="6">
                        <asp:TextBox ID="pincode" runat="server" MaxLength="8"  Style="position:static" ValidationGroup="BtnSave"></asp:TextBox>
                        
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow runat="server">
                    <asp:TableCell runat="server" HorizontalAlign="Right">
                        <asp:Label ID="Label22" runat="server" Text="status"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell runat="server" HorizontalAlign="Left" ColumnSpan="6">
                        <asp:DropDownList ID="status" runat="server" EnableTheming="false" DataValueField="gccode" DataTextField="gcname">
                        </asp:DropDownList>
                        <asp:TextBox ID="sysschoolno" runat="server" Visible="false"></asp:TextBox>
                        <asp:TextBox ID="sysstandardno" runat="server" Visible="false"></asp:TextBox>
                        <asp:TextBox ID="sysdivisionno" runat="server" Visible="false"></asp:TextBox>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow ID="TableRow2" runat="server">
                    <asp:TableCell ID="TableCell1" runat="server" HorizontalAlign="Center" ColumnSpan="7"
                        BackColor="controlDarkDark">
                        <asp:Button ID="BtnSave" runat="server" ValidationGroup="BtnSave" Text="Save" ToolTip="Save"
                           />
                        &nbsp;&nbsp
                        <asp:Button ID="BtnCancel" runat="server" Text="Cancel" ToolTip="Cancel" />
                    </asp:TableCell>
                </asp:TableRow>
            </asp:Table>
        </ContentTemplate>
    </asp1:UpdatePanel>
</asp:Content>
