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
		<asp:Button ID="cmdToroku" runat="server" Text="登録" OnClick="CmdToroku_Click" />
		<br />
		<br />
		<asp:Label ID="Label6" runat="server" Text="年月"></asp:Label>
		<asp:TextBox ID="txtNengetsu" runat="server"></asp:TextBox>
		<asp:Button ID="cmdShow" runat="server" Text="表示" />
		<asp:Label ID="Label7" runat="server" Text="合計"></asp:Label>
		<asp:Label ID="Label8" runat="server" Text="金額"></asp:Label>
		<asp:Label ID="Label10" runat="server" Text="円"></asp:Label>
		<asp:GridView ID="GridView1" runat="server" style="margin-top: 2px">
			<Columns>
			</Columns>
		</asp:GridView>
    </form>
</body>
</html>
