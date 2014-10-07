<%@ Page Language="VB" AutoEventWireup="false" CodeFile="misSemisterResultBrowse.aspx.vb"  Inherits="misSemisterResultBrowse" %>


<%@ Register Assembly="CrystalDecisions.Web, Version=10.2.3600.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" >
    <title>Student Result Reports</title>
</head>

 
<body>
    <form id="form1" runat="server">
       <asp1:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true">
        <Scripts>
            <asp1:ScriptReference Path="~/JavaScripts/Script.js" />
        </Scripts>
    </asp1:ScriptManager>
            <div>
                <table>
                    <tr>
                        <td>
                            <div>
                                <CR:CrystalReportViewer ID="CrystalReportViewer1" Width="100%" Height="100%" BestFitPage="True"
                                    BorderWidth="1px" BorderStyle="NotSet" BorderColor="MediumPurple" runat="server"
                                    AutoDataBind="true" EnableDatabaseLogonPrompt="False" />
                            </div>
                        </td>
                    </tr>
                </table>
            </div>
        <triggers>
            <asp1:AsyncPostBackTrigger ControlID="btnprint" EventName="Click" />
            <asp1:PostBackTrigger ControlID="CrystalReportViewer1" />
        </triggers>
    </form>
    
</body>
</html>


