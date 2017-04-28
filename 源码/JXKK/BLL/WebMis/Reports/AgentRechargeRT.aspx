<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AgentRechargeRT.aspx.cs"
    Inherits="Com.ZY.JXKK.WebMis.Reports.AgentRechargeRT" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="../WebPage/themes/system.css" rel="stylesheet" type="text/css" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <table width="100%" border="0" cellspacing="0" cellpadding="0">
        <tr>
            <td>
                <table width="100%" border="0" cellspacing="1" cellpadding="1" bgcolor="#C3E9E6">
                    <tr>
                        <td height="30" align="right" bgcolor="#FBFBEF" width="16%">
                            代理商名称
                        </td>
                        <td bgcolor="#FBFBEF" align="left">
                            <asp:TextBox ID="tbAgentName" runat="server" Width="110px"></asp:TextBox>
                        </td>
                        <td height="30" align="right" bgcolor="#FBFBEF" width="16%">
                            起始时间
                        </td>
                        <td bgcolor="#FBFBEF" align="right">
                            <asp:TextBox ID="txtStartDate" runat="server" Width="110px" class="easyui-datebox" data-options="validType:'date'" ></asp:TextBox>
                        </td>
                         <td height="30" align="center" bgcolor="#FBFBEF" width="4%">
                            至
                        </td>
                        <td bgcolor="#FBFBEF" align="left">
                            <asp:TextBox ID="txtEndDate" runat="server" Width="110px" class="easyui-datebox" data-options="validType:'date'"></asp:TextBox>
                        </td>
                        <td align="center" bgcolor="#FBFBEF" width="16%">
                            <asp:Button ID="btnSearch" runat="server" Text="查询" onclick="btnSearch_Click" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <table width="100%" border="0" cellspacing="0" cellpadding="0" align="center">
        <tr>
            <td style="text-align: center">
                    <rsweb:ReportViewer ID="ReportViewer1" runat="server" Width="100%" >
                    </rsweb:ReportViewer>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
