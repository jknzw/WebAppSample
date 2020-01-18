<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ToDo.aspx.cs" Inherits="WebAppSample.ToDo1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
	<link href="css/todo.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
			<asp:Repeater ID="MainRepeater" runat="server">
				<HeaderTemplate>
					<table class="todo-table">
						<thead>
                        <tr>
                            <th class="status">状態</th>
                            <th class="task">タスク</th>
                            <th class="remarks">備考</th>
                            <th class="delete">削除</th>
                        </tr>
						</thead>
						<tbody>
				</HeaderTemplate>
				<ItemTemplate>
					<tr>
						<td class="status">
							<asp:TextBox ID="StatusBox" runat="server" CssClass="status-input" Text='<%# Eval("StatusBox") %>'></asp:TextBox>
						</td>
						<td class="todo">
							<asp:TextBox ID="TaskBox" runat="server" CssClass="todo-input" Text='<%# Eval("TaskBox") %>'></asp:TextBox>
						</td>
						<td class="doing">
							<asp:TextBox ID="RemarksBox" runat="server" CssClass="doing-input" Text='<%# Eval("RemarksBox") %>'></asp:TextBox>
						</td>
						<td class="delete">
							<asp:Button ID="DeleteButton"  runat="server" CssClass="delete-button" Text='<%# Eval("DeleteButton") %>' />
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
