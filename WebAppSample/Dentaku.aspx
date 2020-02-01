<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Dentaku.aspx.cs" Inherits="WebAppSample.Dentaku" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="labelTitle" runat="server" Text="Web 電卓"></asp:Label>
            <br />
            <asp:Label ID="labelZei" runat="server" Text="税率"></asp:Label>
            <asp:TextBox ID="textBoxZei" runat="server" MaxLength="3" Width="30px"></asp:TextBox>
            <asp:Label ID="labelZeiTani" runat="server" Text="%"></asp:Label>
        </div>
            <asp:Label ID="labelCalc" runat="server" Text="0" Width="200px" Style="text-align:right"></asp:Label>
        <div>
        </div>
        <asp:HiddenField ID="hiddenAction" runat="server" Value="" />
        <asp:Table ID="tbl" runat="server">
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Button ID="btnPar" runat="server" Text="％" Width="45px" />
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Button ID="btnCE" runat="server" Text="CE" Width="45px" />
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Button ID="btnClear" runat="server" Text="C" Width="45px" OnClick="btnClear_Click" />
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Button ID="btnDiv" runat="server" Text="÷" Width="45px" />
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Button ID="btn7" runat="server" Text="7" Width="45px" OnClick="btnNum_Click" />
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Button ID="btn8" runat="server" Text="8" Width="45px" OnClick="btnNum_Click" />
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Button ID="btn9" runat="server" Text="9" Width="45px" OnClick="btnNum_Click" />
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Button ID="btnMul" runat="server" Text="×" Width="45px" />
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Button ID="btn4" runat="server" Text="4" Width="45px" OnClick="btnNum_Click" />
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Button ID="btn5" runat="server" Text="5" Width="45px" OnClick="btnNum_Click" />
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Button ID="btn6" runat="server" Text="6" Width="45px" OnClick="btnNum_Click" />
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Button ID="btnSub" runat="server" Text="－" Width="45px" />
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Button ID="btn1" runat="server" Text="1" Width="45px" OnClick="btnNum_Click" />
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Button ID="btn2" runat="server" Text="2" Width="45px" OnClick="btnNum_Click" />
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Button ID="btn3" runat="server" Text="3" Width="45px" OnClick="btnNum_Click" />
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Button ID="btnAdd" runat="server" Text="＋" Width="45px" />
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell ColumnSpan="2">
                    <asp:Button ID="btn0" runat="server" Text="0" Width="95px" OnClick="btnNum_Click" />
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Button ID="btnDot" runat="server" Text="." Width="45px" OnClick="btnDot_Click" />
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Button ID="btnEq" runat="server" Text="＝" Width="45px" />
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
        <asp:Label ID="labelMessage" runat="server" Text=""></asp:Label>
    </form>
</body>
</html>
