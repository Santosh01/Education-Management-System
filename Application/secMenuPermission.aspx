<%@ Page Language="VB" MasterPageFile="~/Main.master" AutoEventWireup="false" CodeFile="secMenuPermission.aspx.vb"
    Inherits="secMenuPermission" Title="Menu-Permission" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <head id="Head1">
        <title>Menu Permission</title>
        <link rel="stylesheet" href="css/style.css" type="text/css" />
    </head>
    <asp1:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true">
    </asp1:ScriptManager>
    <asp1:UpdatePanel ID="updPanel1" runat="server">
        <ContentTemplate>
            <table border="1" width="100%" class="MainTable" style="border-color:Black">
                <tr>
                    <td class="td_label">
                        <asp:Label runat="server" Text="Group Code"></asp:Label>
                    </td>
                    <td class="td_control">
                        <asp:DropDownList ID="Groupcode" runat="server" EnableTheming="false" DataTextField="description" DataValueField="groupcode">
                        </asp:DropDownList></td>
                    <td class="button">
                        <asp:Button runat="server" ID="Show" Text="Show" />
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                        <asp:GridView ID="gvMenupermission" ShowHeader="true" runat="server" Width="100%"
                            AutoGenerateColumns="false" AlternatingRowStyle-BackColor="LIGHTBLUE" AllowPaging="true"
                            PageSize="15">
                            <Columns>
                                <asp:TemplateField Visible="false">
                                    <HeaderTemplate>
                                        GroupCode</HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="groupcode" runat="server" Text='<%# Eval("groupcode")  %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField Visible="true">
                                    <HeaderTemplate>
                                        Menu ID</HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="menuid" runat="server" Text='<%# Eval("menuid")  %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField Visible="false">
                                    <HeaderTemplate>
                                        permission</HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="permission" runat="server" Text='<%# Eval("permission")  %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField Visible="true">
                                    <HeaderTemplate>
                                        Menu Caption</HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblMenucaption" runat="server" Text='<%# Eval("menucaption")  %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField Visible="true">
                                    <HeaderTemplate>
                                        Visible</HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="visible" runat="server" Checked='<%# Eval("view_access") %>' Width="10%"
                                            AutoPostBack="false" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblParent" Visible="false" runat="server" Text='<%# Eval("parent") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: center" colspan="3">
                        <asp:Button ID="selectall" Text="Select All" Width="15%" OnClientClick="CheckUncheckAll(this.form,1);return false;"
                            runat="server" />&nbsp;
                        <asp:Button ID="unselectall" Text="Unselect All" Width="15%" OnClientClick="CheckUncheckAll(this.form,0);return false;"
                            runat="server" />&nbsp;
                        <asp:Button ID="done" Text="Done" runat="server" />
                        <asp:Button ID="btnClose" Text="Close" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
                        <asp:TextBox ID="chkid" runat="server" Style="display: none" /></td>
                </tr>
            </table>
        </ContentTemplate>
    </asp1:UpdatePanel>

    <script language="javascript" type="text/javascript">
function cheKUnK(chk,indx)
{  
      var chkid = document.getElementById('<%=chkid.UniqueId %>').value;
      var val = chkid.split(';')
      var data=  val[parseInt(indx)].split('|')
      var len = data.length;
      var i;
       
        for( i=0; i<len; i++)
        {
          if (data[i] !='')
          { document.getElementById(data[i]).checked = chk.checked; }
        }

}
    
function CheckUncheckAll(frm,val)
{
       var len = frm.elements.length;
       var i;
       for( i=0; i<len; i++)
       {
        switch (frm.elements[i].type)
        {
         case 'checkbox':
              if (val=='0')
              {frm.elements[i].checked = false;}
              else
              {frm.elements[i].checked = true;}
              break;
         default:
              break;
        }     
      }
}
    </script>

</asp:Content>
