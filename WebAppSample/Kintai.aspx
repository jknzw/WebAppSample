<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Kintai.aspx.cs" Inherits="WebApplication1.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <script src="js/JavaScript.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <asp:Button ID="Btnmenu" runat="server" Text="メニュー" />
        <asp:Button ID="Btnreset" runat="server" Text="リセット" />
        <asp:Button ID="Btnrogout" runat="server" Text="ログアウト" />
        <br />
        <br />
        <div>
			<asp:TextBox ID="TextBoxMultiLine" runat="server" TextMode="MultiLine" ReadOnly="true"></asp:TextBox>
		</div>
        <asp:Repeater ID="RepeaterMessage" runat="server">
			<ItemTemplate>
				<div>
					<asp:Label ID="LblMsg" runat="server" Text='<%# Container.DataItem %>' />
				</div>
			</ItemTemplate>
		</asp:Repeater>
        <p>
            <asp:Label ID="Lblid" runat="server" Text="ID"></asp:Label>
            <asp:TextBox ID="Txtid" runat="server"></asp:TextBox>
            <asp:Button ID="Btndispray1" runat="server" Text="表示" />
        </p>
        <p>
            <asp:Label ID="Lbldate" runat="server" Text="年月日"></asp:Label>
            <asp:TextBox ID="Txtdate" type="date" runat="server"></asp:TextBox>
            <asp:Label ID="Lblclassification" runat="server" Text="出勤"></asp:Label>
            <asp:DropDownList ID="DropDownList1" runat="server" Height="16px">
                <asp:ListItem Value="0">00</asp:ListItem>
                <asp:ListItem Value="1">01</asp:ListItem>
                <asp:ListItem Value="2">02</asp:ListItem>
                <asp:ListItem Value="3">03</asp:ListItem>
                <asp:ListItem Value="4">04</asp:ListItem>
                <asp:ListItem Value="5">05</asp:ListItem>
                <asp:ListItem Value="6">06</asp:ListItem>
                <asp:ListItem Value="7">07</asp:ListItem>
                <asp:ListItem Value="8">08</asp:ListItem>
                <asp:ListItem Value="9">09</asp:ListItem>
                <asp:ListItem Value="10">10</asp:ListItem>
                <asp:ListItem Value="11">11</asp:ListItem>
                <asp:ListItem Value="12">12</asp:ListItem>
                <asp:ListItem Value="13">13</asp:ListItem>
                <asp:ListItem Value="14">14</asp:ListItem>
                <asp:ListItem Value="15">15</asp:ListItem>
                <asp:ListItem Value="16">16</asp:ListItem>
                <asp:ListItem Value="17">17</asp:ListItem>
                <asp:ListItem Value="18">18</asp:ListItem>
                <asp:ListItem Value="19">19</asp:ListItem>
                <asp:ListItem Value="20">20</asp:ListItem>
                <asp:ListItem Value="21">21</asp:ListItem>
                <asp:ListItem Value="22">22</asp:ListItem>
                <asp:ListItem Value="23">23</asp:ListItem>
                <asp:ListItem Value="24">24</asp:ListItem>
        </asp:DropDownList>
            <asp:DropDownList ID="DropDownList2" runat="server" Height="16px">
                                <asp:ListItem Value="0">00</asp:ListItem>
                <asp:ListItem Value="0">00</asp:ListItem>
                <asp:ListItem Value="1">01</asp:ListItem>
                <asp:ListItem Value="2">02</asp:ListItem>
                <asp:ListItem Value="3">03</asp:ListItem>
                <asp:ListItem Value="4">04</asp:ListItem>
                <asp:ListItem Value="5">05</asp:ListItem>
                <asp:ListItem Value="6">06</asp:ListItem>
                <asp:ListItem Value="7">07</asp:ListItem>
                <asp:ListItem Value="8">08</asp:ListItem>
                <asp:ListItem Value="9">09</asp:ListItem>
                <asp:ListItem Value="10">10</asp:ListItem>
                <asp:ListItem Value="11">11</asp:ListItem>
                <asp:ListItem Value="12">12</asp:ListItem>
                <asp:ListItem Value="13">13</asp:ListItem>
                <asp:ListItem Value="14">14</asp:ListItem>
                <asp:ListItem Value="15">15</asp:ListItem>
                <asp:ListItem Value="16">16</asp:ListItem>
                <asp:ListItem Value="17">17</asp:ListItem>
                <asp:ListItem Value="18">18</asp:ListItem>
                <asp:ListItem Value="19">19</asp:ListItem>
                <asp:ListItem Value="20">20</asp:ListItem>
                <asp:ListItem Value="21">21</asp:ListItem>
                <asp:ListItem Value="22">22</asp:ListItem>
                <asp:ListItem Value="23">23</asp:ListItem>
                <asp:ListItem Value="24">24</asp:ListItem>
                <asp:ListItem Value="25">25</asp:ListItem>
                <asp:ListItem Value="26">26</asp:ListItem>
                <asp:ListItem Value="27">27</asp:ListItem>
                <asp:ListItem Value="28">28</asp:ListItem>
                <asp:ListItem Value="29">29</asp:ListItem>
                <asp:ListItem Value="30">30</asp:ListItem>
                <asp:ListItem Value="31">31</asp:ListItem>
                <asp:ListItem Value="32">32</asp:ListItem>
                <asp:ListItem Value="33">33</asp:ListItem>
                <asp:ListItem Value="34">34</asp:ListItem>
                <asp:ListItem Value="35">35</asp:ListItem>
                <asp:ListItem Value="36">36</asp:ListItem>
                <asp:ListItem Value="37">37</asp:ListItem>
                <asp:ListItem Value="38">38</asp:ListItem>
                <asp:ListItem Value="39">39</asp:ListItem>
                <asp:ListItem Value="40">40</asp:ListItem>
                <asp:ListItem Value="41">41</asp:ListItem>
                <asp:ListItem Value="42">42</asp:ListItem>
                <asp:ListItem Value="43">43</asp:ListItem>
                <asp:ListItem Value="44">44</asp:ListItem>
                <asp:ListItem Value="45">45</asp:ListItem>
                <asp:ListItem Value="46">46</asp:ListItem>
                <asp:ListItem Value="47">47</asp:ListItem>
                <asp:ListItem Value="48">48</asp:ListItem>
                <asp:ListItem Value="49">49</asp:ListItem>
                <asp:ListItem Value="50">50</asp:ListItem>
                <asp:ListItem Value="51">51</asp:ListItem>
                <asp:ListItem Value="52">52</asp:ListItem>
                <asp:ListItem Value="53">53</asp:ListItem>
                <asp:ListItem Value="54">54</asp:ListItem>
                <asp:ListItem Value="55">55</asp:ListItem>
                <asp:ListItem Value="56">56</asp:ListItem>
                <asp:ListItem Value="57">57</asp:ListItem>
                <asp:ListItem Value="58">58</asp:ListItem>
                <asp:ListItem Value="59">59</asp:ListItem>

            </asp:DropDownList>
            <asp:Label ID="Label4" runat="server" Text="退勤"></asp:Label>
            <asp:DropDownList ID="ListBox3" runat="server" Height="21px" OnSelectedIndexChanged="ListBox1_SelectedIndexChanged" style="margin-bottom: 0px" Width="103px">
                                <asp:ListItem Value="0">00</asp:ListItem>
                <asp:ListItem Value="1">01</asp:ListItem>
                <asp:ListItem Value="2">02</asp:ListItem>
                <asp:ListItem Value="3">03</asp:ListItem>
                <asp:ListItem Value="4">04</asp:ListItem>
                <asp:ListItem Value="5">05</asp:ListItem>
                <asp:ListItem Value="6">06</asp:ListItem>
                <asp:ListItem Value="7">07</asp:ListItem>
                <asp:ListItem Value="8">08</asp:ListItem>
                <asp:ListItem Value="9">09</asp:ListItem>
                <asp:ListItem Value="10">10</asp:ListItem>
                <asp:ListItem Value="11">11</asp:ListItem>
                <asp:ListItem Value="12">12</asp:ListItem>
                <asp:ListItem Value="13">13</asp:ListItem>
                <asp:ListItem Value="14">14</asp:ListItem>
                <asp:ListItem Value="15">15</asp:ListItem>
                <asp:ListItem Value="16">16</asp:ListItem>
                <asp:ListItem Value="17">17</asp:ListItem>
                <asp:ListItem Value="18">18</asp:ListItem>
                <asp:ListItem Value="19">19</asp:ListItem>
                <asp:ListItem Value="20">20</asp:ListItem>
                <asp:ListItem Value="21">21</asp:ListItem>
                <asp:ListItem Value="22">22</asp:ListItem>
                <asp:ListItem Value="23">23</asp:ListItem>
                <asp:ListItem Value="24">24</asp:ListItem>
            </asp:DropDownList>
            <asp:DropDownList ID="ListBox4" runat="server" Height="21px" OnSelectedIndexChanged="ListBox1_SelectedIndexChanged" style="margin-bottom: 0px" Width="103px">
                                <asp:ListItem Value="0">00</asp:ListItem>
                <asp:ListItem Value="1">01</asp:ListItem>
                <asp:ListItem Value="2">02</asp:ListItem>
                <asp:ListItem Value="3">03</asp:ListItem>
                <asp:ListItem Value="4">04</asp:ListItem>
                <asp:ListItem Value="5">05</asp:ListItem>
                <asp:ListItem Value="6">06</asp:ListItem>
                <asp:ListItem Value="7">07</asp:ListItem>
                <asp:ListItem Value="8">08</asp:ListItem>
                <asp:ListItem Value="9">09</asp:ListItem>
                <asp:ListItem Value="10">10</asp:ListItem>
                <asp:ListItem Value="11">11</asp:ListItem>
                <asp:ListItem Value="12">12</asp:ListItem>
                <asp:ListItem Value="13">13</asp:ListItem>
                <asp:ListItem Value="14">14</asp:ListItem>
                <asp:ListItem Value="15">15</asp:ListItem>
                <asp:ListItem Value="16">16</asp:ListItem>
                <asp:ListItem Value="17">17</asp:ListItem>
                <asp:ListItem Value="18">18</asp:ListItem>
                <asp:ListItem Value="19">19</asp:ListItem>
                <asp:ListItem Value="20">20</asp:ListItem>
                <asp:ListItem Value="21">21</asp:ListItem>
                <asp:ListItem Value="22">22</asp:ListItem>
                <asp:ListItem Value="23">23</asp:ListItem>
                <asp:ListItem Value="24">24</asp:ListItem>
                <asp:ListItem Value="25">25</asp:ListItem>
                <asp:ListItem Value="26">26</asp:ListItem>
                <asp:ListItem Value="27">27</asp:ListItem>
                <asp:ListItem Value="28">28</asp:ListItem>
                <asp:ListItem Value="29">29</asp:ListItem>
                <asp:ListItem Value="30">30</asp:ListItem>
                <asp:ListItem Value="31">31</asp:ListItem>
                <asp:ListItem Value="32">32</asp:ListItem>
                <asp:ListItem Value="33">33</asp:ListItem>
                <asp:ListItem Value="34">34</asp:ListItem>
                <asp:ListItem Value="35">35</asp:ListItem>
                <asp:ListItem Value="36">36</asp:ListItem>
                <asp:ListItem Value="37">37</asp:ListItem>
                <asp:ListItem Value="38">38</asp:ListItem>
                <asp:ListItem Value="39">39</asp:ListItem>
                <asp:ListItem Value="40">40</asp:ListItem>
                <asp:ListItem Value="41">41</asp:ListItem>
                <asp:ListItem Value="42">42</asp:ListItem>
                <asp:ListItem Value="43">43</asp:ListItem>
                <asp:ListItem Value="44">44</asp:ListItem>
                <asp:ListItem Value="45">45</asp:ListItem>
                <asp:ListItem Value="46">46</asp:ListItem>
                <asp:ListItem Value="47">47</asp:ListItem>
                <asp:ListItem Value="48">48</asp:ListItem>
                <asp:ListItem Value="49">49</asp:ListItem>
                <asp:ListItem Value="50">50</asp:ListItem>
                <asp:ListItem Value="51">51</asp:ListItem>
                <asp:ListItem Value="52">52</asp:ListItem>
                <asp:ListItem Value="53">53</asp:ListItem>
                <asp:ListItem Value="54">54</asp:ListItem>
                <asp:ListItem Value="55">55</asp:ListItem>
                <asp:ListItem Value="56">56</asp:ListItem>
                <asp:ListItem Value="57">57</asp:ListItem>
                <asp:ListItem Value="58">58</asp:ListItem>
                <asp:ListItem Value="59">59</asp:ListItem>

            </asp:DropDownList>
        </p>
        <p>
            <asp:Label ID="Label5" runat="server" Text="区分"></asp:Label>
            <asp:DropDownList ID="DropDownList3" runat="server" Height="25px">
                <asp:ListItem Value="0">出勤</asp:ListItem>
                <asp:ListItem Value="1">退勤</asp:ListItem>
             </asp:DropDownList>
            <asp:Label ID="Label7" runat="server" Text="作業場所"></asp:Label>
            <asp:DropDownList ID="DropDownList4" runat="server" Height="25px" >
                <asp:ListItem Value="1">京橋</asp:ListItem>
                <asp:ListItem Value="2">新大阪</asp:ListItem>
            </asp:DropDownList>
            <asp:Button ID="Btnaddplase" runat="server" Text="作業場所追加" onClientClick="btnAddPlaseClick();"  />
        </p>
        <p>
            <asp:Label ID="Label6" runat="server" Text="備考"></asp:Label>
            <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
        </p>
        <p>
            <asp:Button ID="Btninsert" runat="server" Height="21px" Text="登録" />
        </p>
        <hr style="background-color:red; height:5px;"/>
        <p>
            <asp:TextBox ID="Txtdate0" type="date" runat="server"></asp:TextBox>
            <asp:Label ID="Label8" runat="server" Text="～"></asp:Label>
            <asp:TextBox ID="Txtdate1" type="date" runat="server"></asp:TextBox>
            <asp:Button ID="Btndispray2" runat="server" Height="21px" Text="表示" />
        </p>
        <p>
            <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand">
				<HeaderTemplate>
					<table style="border:1px solid black; border-collapse:collapse;">
						<thead>
							<tr>
								<th style="border:1px solid black;">
									<asp:Label ID="Label1" runat="server" Text="Label">月日</asp:Label>
								</th>
								<th style="border:1px solid black;">
									<asp:Label ID="Label2" runat="server" Text="Label">曜日</asp:Label>
								</th>
                                <th style="border:1px solid black;">
									<asp:Label ID="Label3" runat="server" Text="Label">区分</asp:Label>
								</th>
                                <th style="border:1px solid black;">
									<asp:Label ID="Label9" runat="server" Text="Label">出勤</asp:Label>
								</th>
                                <th style="border:1px solid black;">
									<asp:Label ID="Label10" runat="server" Text="Label">退勤</asp:Label>
								</th>
                                <th style="border:1px solid black;">
									<asp:Label ID="Label11" runat="server" Text="Label">作業場所</asp:Label>
								</th>
                                <th style="border:1px solid black;">
									<asp:Label ID="Label12" runat="server" Text="Label">備考</asp:Label>
								</th>
							</tr>
						</thead>
						<tbody>
				</HeaderTemplate>
				<ItemTemplate>
					<tr>
						<td style="border:1px solid black;">
							<asp:TextBox ID="TextBox1" runat="server" Text='<%# Eval("col1") %>'></asp:TextBox>
						</td>
						<td style="border:1px solid black;">
							<asp:TextBox ID="TextBox2" runat="server" Text='<%# Eval("col2") %>'></asp:TextBox>
						</td>
                        <td style="border:1px solid black;">
							<asp:TextBox ID="TextBox4" runat="server" Text='<%# Eval("col3") %>'></asp:TextBox>
						</td>
						<td style="border:1px solid black;">
							<asp:TextBox ID="TextBox5" runat="server" Text='<%# Eval("col4") %>'></asp:TextBox>
						</td>
                        <td style="border:1px solid black;">
							<asp:TextBox ID="TextBox6" runat="server" Text='<%# Eval("col5") %>'></asp:TextBox>
						</td>
						<td style="border:1px solid black;">
							<asp:TextBox ID="TextBox7" runat="server" Text='<%# Eval("col6") %>'></asp:TextBox>
						</td>
                        <td style="border:1px solid black;">
							<asp:TextBox ID="TextBox8" runat="server" Text='<%# Eval("col7") %>'></asp:TextBox>
						</td>

					</tr>
				</ItemTemplate>
				<FooterTemplate>
					</tbody>
					</table>
				</FooterTemplate>
			</asp:Repeater>
            &nbsp;</p>
        <p>

    </form>
</body>
</html>
