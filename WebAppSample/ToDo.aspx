<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ToDo.aspx.cs" Inherits="WebAppSample.ToDo1" EnableEventValidation="false"  %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
	<link href="css/todo.css" rel="stylesheet" />
	<script type="text/javascript" src="./js/jquery.js"></script>
	<script type="text/javascript" src="./js/ToDo.js"></script>
</head>
<body>
    <form id="form1" runat="server">
			<asp:Repeater ID="MainRepeater" runat="server">
				<HeaderTemplate>
					<table class="todo-table">
						<thead>
                        <tr>
                            <th>状態</th>
                            <th>タスク</th>
                            <th>備考</th>
                            <th>削除</th>
                        </tr>
						</thead>
						<tbody>
				</HeaderTemplate>
				<ItemTemplate>
					<tr>
						<td class="status">
							<asp:TextBox ID="StatusBox" runat="server" CommandArgument='<%# Eval("Id") %>' Text='<%# Eval("StatusBox") %>' readonly/>
						</td>
						<td class="todo">
							<asp:TextBox ID="TaskBox" runat="server" CommandArgument='<%# Eval("Id") %>' Text='<%# Eval("TaskBox") %>' readonly/>
						</td>
						<td class="doing">
							<asp:TextBox ID="RemarksBox" runat="server" CommandArgument='<%# Eval("Id") %>' Text='<%# Eval("RemarksBox") %>' readonly/>
						</td>
						<td class="delete">
							<asp:Button ID="EditButton" runat="server" CommandArgument='<%# Eval("Id") %>' CssClass="edit-button" Text='編集' OnClick="EditButton_Click"/>
						</td>
					</tr>
				</ItemTemplate>
				<FooterTemplate>
					</tbody>
					</table>
				</FooterTemplate>
			</asp:Repeater>
    </form>
</body>
</html>
