<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Kotsuhi.aspx.cs" Inherits="WebAppSample.Kotsuhi" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server" aria-required="False">
        <div>
        	<asp:Button ID="Button1" runat="server" Text="メニュー" />
			<asp:Button ID="Button2" runat="server" Text="ログアウト" />
        	<br />
        </div>
    	<asp:Calendar ID="cdrDate" runat="server"></asp:Calendar>
		<br />
		<br />
		<asp:Label ID="Label3" runat="server" Text="交通機関"></asp:Label>
		<asp:TextBox ID="txtKikan" runat="server"></asp:TextBox>
		<asp:Label ID="Label4" runat="server" Text="駅名"></asp:Label>
		<asp:TextBox ID="txtFrom" runat="server"></asp:TextBox>
		<asp:Label ID="Label9" runat="server" Text="～"></asp:Label>
		<asp:TextBox ID="txtTo" runat="server"></asp:TextBox>
		<br />
		<br />
		<asp:Label ID="Label5" runat="server" Text="片道金額"></asp:Label>
		<asp:TextBox ID="txtKingaku" runat="server"></asp:TextBox>
		<asp:DropDownList ID="drpIkoKbn" runat="server">
			<asp:ListItem Selected="True">往復</asp:ListItem>
			<asp:ListItem>片道</asp:ListItem>
		</asp:DropDownList>
		<asp:Button ID="cmdToroku" runat="server" Text="登録" OnClick="cmdToroku_Click" />
		<br />
		<br />
		<asp:Label ID="Label6" runat="server" Text="年月"></asp:Label>
		<asp:TextBox ID="txtNengetsu" runat="server"></asp:TextBox>
		<asp:Button ID="cmdShow" runat="server" Text="表示" OnClick="cmdShow_Click" />
		<asp:Label ID="Label7" runat="server" Text="合計"></asp:Label>
		<asp:Label ID="Label8" runat="server" Text="金額"></asp:Label>
		<asp:Label ID="Label10" runat="server" Text="円"></asp:Label>
		<table>
			<tr>
				<td>No.</td>
				<td>日付</td>
				<td>曜日</td>
				<td>交通機関</td>
				<td colspan="3">駅名</td>
				<td>片道金額</td>
				<td></td>
				<td>金額</td>
				<td></td>
			</tr>
			<asp:Repeater ID="MeisaiData" runat ="server">
				<ItemTemplate>
                    <tr>
                        <td><%# Container.ItemIndex + 1 %></td>
                        <td><%# Eval("target_date") %></td>
                        <td><%# Eval("day") %></td>
                        <td><%# Eval("transport") %></td>
                        <td><%# Eval("station_from") %></td>
						<td><%# Eval("station_nyoro") %></td>
                        <td><%# Eval("station_to") %></td>
                        <td><%# Eval("oneway_cost") %></td>
                        <td><%# Eval("ido_kbn") %></td>
                        <td><%# Eval("cost") %></td>
						<td><%# Eval("data_id") %></td>
                        <td><button type="button" name="del" value="<%# DataBinder.Eval(Container, "ItemIndex") %>">削除</button></td>
                    </tr>
                </ItemTemplate>

			</asp:Repeater>
		</table>
    </form>
</body>
</html>
