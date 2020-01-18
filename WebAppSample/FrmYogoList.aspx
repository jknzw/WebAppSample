<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FrmYogoList.aspx.cs" Inherits="YogoList.FrmYogoList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <style>
        p {
            background-color: lightskyblue;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="btnMenu" runat="server" Text="メニュー" />
            <div style="display: block; text-align: right;">
                <asp:Button ID="btnLogout" runat="server" Text="ログアウト" />
            </div>
            <br />
            <table>
                <tr>
                    <td>
                        <asp:Label ID="lblName" runat="server" Text="名称"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtNameItem" runat="server" Text="Label"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblBiko" runat="server" Text="備考"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtBikoItem" runat="server" Text="Label"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblUrl" runat="server" Text="URL"></asp:Label>
                    </td>
                    <td class=" autostyle1">
                        <asp:TextBox ID="txtUrlItem" runat="server" Text="Label"></asp:TextBox>
                    </td>
                </tr>
            </table>
            <div style="display: block; text-align: center;">
                <asp:Button ID="btnInsert" runat="server" Text="登録" />
            </div>
            <br />
            <br />
            <asp:Repeater ID="Repeater1" runat="server">
                <HeaderTemplate>
                    <table style="border: 1px solid black; border-collapse: collapse;">
                        <thead>
                            <tr>
                                <th>
                                    <p>
                                        <asp:Label ID="lblNo" runat="server" Text="Label">No.</asp:Label>
                                    </p>
                                </th>
                                <th>
                                    <p>
                                        <asp:Label ID="lblName" runat="server" Text="Label">名称</asp:Label>
                                    </p>
                                </th>
                                <th>
                                    <p>
                                        <asp:Label ID="lblBiko" runat="server" Text="Label">備考</asp:Label>
                                    </p>
                                </th>
                                <th>
                                    <p>
                                        <asp:Label ID="lblUrl" runat="server" Text="Label">URL</asp:Label>
                                    </p>
                                </th>
                                <th colspan="2"></th>
                            </tr>
                        </thead>
                        <tbody>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td style="border: 1px solid black;">
                            <asp:TextBox ID="TextBox1" runat="server" Text='<%# Eval("No") %>'></asp:TextBox>
                        </td>
                        <td style="border: 1px solid black;">
                            <asp:TextBox ID="TextBox2" runat="server" Text='<%# Eval("名称") %>'></asp:TextBox>
                        </td>
                        <td style="border: 1px solid black;">
                            <asp:TextBox ID="TextBox3" runat="server" Text='<%# Eval("備考") %>'></asp:TextBox>
                        </td>
                        <td style="border: 1px solid black;">
                            <asp:TextBox ID="TextBox4" runat="server" Text='<%# Eval("URL") %>'></asp:TextBox>
                        </td>
                        <td style="border: 1px solid black;">
                            <asp:Button ID="btnUpd" runat="server" Text="更新" />
                        </td>
                        <td style="border: 1px solid black;">
                            <asp:Button ID="btnDel" runat="server" Text="削除" />
                        </td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </tbody>
					</table>
                </FooterTemplate>
            </asp:Repeater>
        </div>
    </form>
</body>
</html>
