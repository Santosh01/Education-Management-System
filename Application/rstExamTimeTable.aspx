<%@ Page Language="VB" MasterPageFile="~/Main.master" AutoEventWireup="false" 
CodeFile="rstExamTimeTable.aspx.vb" Inherits="rstExamTimeTable"  %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <head id="Head1" >
        <title>Exam Time Table</title>
        <link rel="stylesheet" href="css/style.css" type="text/css" />
    </head>
    <asp1:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true">
    </asp1:ScriptManager>
    <asp1:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div>
                <div id="bodydiv" class="bodytext" align="justify">
                    <table class="InnerForm" border="0">
                        <tr>
                            <td>
                                <span class="orangetitle">Exam Time Table</span> </br>
                            </td>
                            <td style="text-align: right;">
                            <a href="Dashboard.aspx" title="Close">Close</a>
                        </td>
                        </tr>
                    </table>
                </div>
                <div id="bodydiv" class="bodytext" align="justify">
                    <table width="100%" class="InnerForm">
                       
                        
                        <tr>
                            <td class="td_label">
                                <asp:Label ID="Label6" runat="server" Text="Standard" />
                            </td>
                            <td class="td_control">
                                <asp:DropDownList ID="sysstandardno" ToolTip="Standard" runat="server" DataTextField="standarddesc"
                                    DataValueField="sysstandardno" AutoPostBack="true" ValidationGroup="btnsave" Width="200px" EnableTheming ="false" >
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
                                <asp:DropDownList ID="sysdivisionno" ToolTip="Division" runat="server" DataTextField="divisiondesc" EnableTheming ="false" 
                                    DataValueField="sysdivisionno" ValidationGroup="btnsave" AutoPostBack="true" Width="200px">
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
                                    DataValueField="sysexamno" 
                                    AutoPostBack="true" ValidationGroup="btnsave" Width="150px" EnableTheming ="false" >
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Select Exam"
                                    ControlToValidate="sysexamno" ValidationGroup="btnsave"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                    
                       <tr class="tr_button">
                            <td colspan="2" align="center">
                                <asp:Button ID="btnsave" runat="server" Text="Save" CssClass="button" ValidationGroup="btnsave" />
                                &nbsp; &nbsp;
                                <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="button" OnClick="btnCancel_Click" />
                           </td>
                        </tr>
                    </table>
                    
                    <table width="100%" class="InnerForm" id="ExamPortionCriteria" runat="server">
                        <tr>
                            <td>
                               
                                <table class="InnerForm" width="100%" id="ChapterList" runat="server">
                                    <tr>
                                        <td>
                                            <asp:GridView ID="gvList" runat="server"  AutoGenerateColumns="False"
                                                  Width="100%" AlternatingRowStyle-BackColor="LightBlue">
                                                <Columns>
                                                    <asp:BoundField DataField="sysexamtimetblno" HeaderText="PK" />
                                                    <asp:BoundField DataField="syssubjectno" HeaderText="PK" />
                                                    <asp:TemplateField>
                                                        <ItemTemplate>
                                                            <asp:CheckBox ID="Selected" runat="server"   />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="subjectname" HeaderText="Subject Name" />
                                                    <asp:BoundField DataField="trndt" HeaderText="Date" />
                                                    <asp:TemplateField HeaderText="Date">
                                                        <ItemTemplate>
                                                            <asp:TextBox runat="server" ToolTip='<%#Container.DataItem("trndt")%>' ID="trndt"
                                                                MaxLength="10" Columns="12"></asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField> 
                                                    <asp:BoundField DataField="fromtime" HeaderText="From Time" />                                                  
                                                    <asp:TemplateField HeaderText="From Time">
                                                        <ItemTemplate>
                                                            <asp:TextBox runat="server" ToolTip='<%#Container.DataItem("fromtime")%>' ID="fromtime"
                                                                MaxLength="10" Columns="12"></asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>                           
                                                     <asp:BoundField DataField="totime" HeaderText="To Time" />                        
                                                    <asp:TemplateField HeaderText="To Time">
                                                        <ItemTemplate>
                                                            <asp:TextBox runat="server" ToolTip='<%#Container.DataItem("totime")%>' ID="totime"
                                                                MaxLength="10" Columns="12"></asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
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
            <asp:TextBox ID="sysexamtimetblno" runat="server" Visible="false" />
        </ContentTemplate>
    </asp1:UpdatePanel>
</asp:Content>