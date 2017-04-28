<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AgentAccDetailRT.aspx.cs"
    Inherits="Com.ZY.JXKK.WebMis.Reports.AgentAccDetailRT" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
        <table width="100%" border="0" cellspacing="0" cellpadding="0" align="center">
            <tr>
                <td>
                    <rsweb:ReportViewer ID="ReportViewer1" runat="server" Width="100%" Height="100%"
                        ZoomMode="PageWidth" ShowBackButton="true" SizeToReportContent="True" 
                        PageCountMode="Actual" />
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
