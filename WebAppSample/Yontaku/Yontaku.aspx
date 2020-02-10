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
    <script src="../js/common.js"></script>
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
                <asp:Button CssClass="col-lg-6 col-xs-12 btn-sticky font-answer red" ID="Button1" runat="server" Text="1" OnClientClick="this.disabled = true;" UseSubmitBehavior="false" OnClick="ButtonAnswer_Click" />
                <asp:Button CssClass="col-lg-6 col-xs-12 btn-sticky font-answer yellow" ID="Button2" runat="server" Text="2" OnClientClick="this.disabled = true;" UseSubmitBehavior="false"  OnClick="ButtonAnswer_Click" />
                <asp:Button CssClass="col-lg-6 col-xs-12 btn-sticky font-answer green" ID="Button3" runat="server" Text="3" OnClientClick="this.disabled = true;" UseSubmitBehavior="false"  OnClick="ButtonAnswer_Click" />
                <asp:Button CssClass="col-lg-6 col-xs-12 btn-sticky font-answer blue" ID="Button4" runat="server" Text="4" OnClientClick="this.disabled = true;" UseSubmitBehavior="false"  OnClick="ButtonAnswer_Click" />
            </div>
            <asp:HiddenField ID="HiddenFieldLevel" runat="server" />
            <asp:HiddenField ID="HiddenFieldType" runat="server" />

            <asp:Panel ID="PanelKekka" runat="server">
                <div class="row">
                    <div class="card col-lg-8 col-xs-12">
                        <asp:Label ID="LabelResult" CssClass="card-body font-answer mx-auto" runat="server" Text="" />
                    </div>
                    <button type="button" class="col-lg-4 col-xs-12 btn btn-primary" data-toggle="collapse" data-target="#collapseExample" aria-expanded="false" aria-controls="collapseExample">
                        りれきをみる
                    </button>
                </div>
            </asp:Panel>
            <div class="row">
                <div class="collapse col-12" id="collapseExample">
                    <div class="border p-3">
                        <asp:Repeater ID="RepeaterRireki" runat="server">
                            <ItemTemplate>
                                <div><%# Container.DataItem %></div>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                </div>
            </div>
            <asp:HiddenField ID="HiddenFieldOk" runat="server" />
            <asp:HiddenField ID="HiddenFieldNg" runat="server" />
        </div>
        <uc1:WebFooterControl runat="server" ID="WebFooterControl" />
    </form>
</body>
</html>
