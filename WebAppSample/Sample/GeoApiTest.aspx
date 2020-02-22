<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GeoApiTest.aspx.cs" Inherits="WebAppSample.Sample.GeoApiTest" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <script src="../js/jquery-3.3.0.js"></script>
    <script src="js/GeoApiTest.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <label id="address"></label>
            <button onclick="getPosition();return false;">位置情報を取得する</button>
            <button onclick="setAddress('34.6021283','135.496903');return false;">住所を取得する</button>
        </div>
    </form>
</body>
</html>
