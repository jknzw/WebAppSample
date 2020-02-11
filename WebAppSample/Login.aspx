<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebAppSample.Login" %>

<%-- <%@ Register TagPrefix="cc1" Namespace="WebCustomControl" Assembly="WebCustomControl" %> --%>
<%-- <%@ Register Src="~/custom/WebFooterControl.ascx" TagPrefix="uc1" TagName="WebFooterControl" %> --%>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" style="height: 95%;">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body style="height: 100%;">
    <form id="form1" runat="server" style="height: 100%;">
        <div style="height: 100%; display: flex; justify-content: center; align-items: center;">
            <div style="display: block; text-align: center;">
                <table>
                    <tr>
                        <td>
                            <asp:Label ID="LabelId" runat="server" Text="ユーザーID"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="TextBoxId" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="LabelPw" runat="server" Text="パスワード"></asp:Label>
                        </td>
                        <td>
                            <cc1:CPasswordTextBox runat="server" ID="TextBoxPw"></cc1:CPasswordTextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:Button ID="ButtonLogin" runat="server" Text="ログイン" OnClick="ButtonLogin_Click" style="margin-left: 71px; margin-right: 13px" Width="110px" />
                            <asp:Button ID="ButtonInsert" runat="server" Text="新規登録" OnClick="ButtonInsert_Click" style="margin-left: 71px; margin-right: 13px" Width="110px" />
                        </td>
                    </tr>
                </table>
                <asp:Label ID="LabelMessage" runat="server" Text="" style="display:block; min-height:20px;"></asp:Label>
            </div>
        </div>
		<uc1:WebFooterControl runat="server" ID="WebFooterControl1" />
    </form>
</body>
</html>
