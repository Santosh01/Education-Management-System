<%@ Page Language="VB" AutoEventWireup="false" CodeFile="rptStudentRecordsBrowse.aspx.vb" Inherits="rptStudentRecordsBrowse" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=10.2.3600.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" >
    <title>Student List</title>
</head>
<body>
    <form id="form1" runat="server">
            <div>
                <table>
                    <tr>
                        <td>
                            <div>
                                <%--<asp:Panel ID="pnlReport" ScrollBars="Both" Height="100%" Width="100%" runat="server" Style="position: absolute;">--%>
                                <CR:CrystalReportViewer ID="CrystalReportViewer1" Width="100%" Height="100%" BestFitPage="True"
                                    BorderWidth="1px" BorderStyle="NotSet" BorderColor="MediumPurple" runat="server"
                                    AutoDataBind="true" EnableDatabaseLogonPrompt="False" />
                                <%--</asp:Panel>--%>
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

