<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SampleTable.aspx.cs" Inherits="WebAppSample.SampleTable" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
	<title></title>
</head>
<body>
	<form id="form1" runat="server">
		<div>
			<asp:TextBox ID="TextBoxMultiLine" runat="server" TextMode="MultiLine" ReadOnly="true"></asp:TextBox>
		</div>
		<div>
			<asp:Repeater ID="RepeaterMessage" runat="server">
				<ItemTemplate>
					<div>
						<asp:Label ID="LblMsg" runat="server" Text='<%# Container.DataItem %>' />
					</div>
				</ItemTemplate>
			</asp:Repeater>
		</div>
		<div>
			<asp:Repeater ID="Repeater1" runat="server">
				<HeaderTemplate>
					<table style="border: 1px solid black; border-collapse: collapse;">
						<thead>
							<tr>
								<th style="border: 1px solid black;">
									<asp:Label ID="Label1" runat="server" Text="Label">ラベル1</asp:Label>
								</th>
								<th style="border: 1px solid black;">
									<asp:Label ID="Label2" runat="server" Text="Label">ラベル2</asp:Label>
								</th>
							</tr>
						</thead>
						<tbody>
				</HeaderTemplate>
				<ItemTemplate>
					<tr>
						<td style="border: 1px solid black;">
							<asp:TextBox ID="TextBox1" runat="server" Text='<%# Eval("col1") %>'></asp:TextBox>
						</td>
						<td style="border: 1px solid black;">
							<asp:TextBox ID="TextBox2" runat="server" Text='<%# Eval("col2") %>'></asp:TextBox>
						</td>
						<td style="border: 1px solid black;">
							<asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />
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
