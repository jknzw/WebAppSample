<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Yontaku.aspx.cs" Inherits="WebAppSample.Yontaku.Yontaku" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>四択</title>
    <script src="../js/jquery-3.3.0.js"></script>
    <script src="../js/bootstrap.js"></script>
    <link href="../css/bootstrap.css" rel="stylesheet" />
    <link href="css/Yontaku.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container-fluid">
            <div class="row">
                <div class="col-xs-12 mx-auto card border-primary mb-3">
                    <asp:Label CssClass="card-header" ID="LabelQuestionTitle" runat="server" Text=""></asp:Label>
                    <asp:Label CssClass="card-text font-question mx-auto" ID="LabelQuestion" runat="server" Text=""></asp:Label>
                </div>
            </div>
            <div class="row">
                <asp:Button CssClass="col-lg-6 col-xs-12 btn-sticky font-answer red" ID="Button1" runat="server" Text="1" OnClick="ButtonAnswer_Click" />
                <asp:Button CssClass="col-lg-6 col-xs-12 btn-sticky font-answer yellow" ID="Button2" runat="server" Text="2" OnClick="ButtonAnswer_Click" />
                <asp:Button CssClass="col-lg-6 col-xs-12 btn-sticky font-answer green" ID="Button3" runat="server" Text="3" OnClick="ButtonAnswer_Click" />
                <asp:Button CssClass="col-lg-6 col-xs-12 btn-sticky font-answer blue" ID="Button4" runat="server" Text="4" OnClick="ButtonAnswer_Click" />
            </div>
        </div>
    </form>
</body>
</html>
