<%@ Page Language="VB" MasterPageFile="~/Main.master" AutoEventWireup="false" CodeFile="secChangePassword.aspx.vb" Inherits="secChangePassword" title="Change password" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

       <title>Change Password</title>
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
                    <asp:TableCell HorizontalAlign="Right" width="50%" ColumnSpan="3" ForeColor="orange" BackColor="LightGray">
                        <asp:Label ID="Label8" runat="server" Text="Change Password"></asp:Label>
                         &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;&nbsp;
                         &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                         &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                         &nbsp; &nbsp; &nbsp;&nbsp;&nbsp;
                         &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                         &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                         &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;&nbsp;
                         &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                         &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; 
                   
                         
                 <a href="Dashboard.aspx" title="Close">Close</a>
                    </asp:TableCell>
                   
                </asp:TableRow>   
    </asp:Table>
    
    <asp:Table ID="Table2" runat="server" BorderStyle="Solid" BorderWidth="1px" Width="100%"
                GridLines="Both" BorderColor="controlDarkDark">

        
   
        <asp:TableRow ID="TableRow4" runat="server">
            <asp:TableCell ID="TableCell6" runat="server" Width="20%">
                <asp:Label ID="Label3" runat="server" Text="User Name"></asp:Label>
            </asp:TableCell>
            <asp:TableCell ID="TableCell7" runat="server" HorizontalAlign="Left">
                <asp:TextBox ID="username" runat="server" Width="40%"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>
    
     <asp:TableRow ID="TableRow1" runat="server">
            <asp:TableCell ID="TableCell1" runat="server" >
                <asp:Label ID="Label1" runat="server" Text="New Password"></asp:Label>
            </asp:TableCell>
            <asp:TableCell ID="TableCell4" runat="server"  HorizontalAlign="Left">
                <asp:TextBox ID="password" runat="server" Width="40%" TextMode="Password"></asp:TextBox>
                 <asp:RequiredFieldValidator ID="req6" runat="server" ControlToValidate="password" Text="*" />
            </asp:TableCell>
        </asp:TableRow>
             <asp:TableRow ID="TableRow3" runat="server">
            <asp:TableCell ID="TableCell5" runat="server" >
                <asp:Label ID="Label2" runat="server" Text="Confirm Password"></asp:Label>
            </asp:TableCell>
            <asp:TableCell ID="TableCell8" runat="server"  HorizontalAlign="Left">
                <asp:TextBox ID="password1" runat="server"  Width="40%" TextMode="Password"></asp:TextBox>
            
               <asp:CompareValidator ID="Comp1" runat="server" ControlToValidate="password" ControlToCompare="password1" Text="Password mismatch" />
            </asp:TableCell>
        </asp:TableRow>   
    
     

    
    
           <asp:TableRow ID="TableRow6" runat="server" >
          
            <asp:TableCell ID="TableCell12" runat="server"  HorizontalAlign="Center" ColumnSpan="6" BackColor="controlDark">
                <asp:Button ID="Changepassword" runat="server" Text="Change Password" EnableTheming="false"/>
                &nbsp; &nbsp; 
                 <asp:Button ID="Cancel" runat="server" Text="Cancel" EnableTheming="true"/>
                 <asp:TextBox ID="sysuserno" runat="server"  Width="40%" Visible="false" ></asp:TextBox>
                   <asp:TextBox ID="TextBox1" runat="server"  Width="40%" Visible="false" ></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow> 
    
    
    
    
    
  

</asp:Table>
</ContentTemplate>
    </asp1:UpdatePanel>
</asp:Content>

