using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAppSample
{
	public partial class SampleTable : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			// Repeater1へのデータ設定
			DataTable table = new DataTable();
			table.Columns.Add("col1");
			table.Columns.Add("col2");

			table.Rows.Add("data1", "data2");

			DataRow row = table.NewRow();
			row["col1"] = "data3";
			row["col2"] = "data4";

			table.Rows.Add(row);

			Repeater1.DataSource = table;
			Repeater1.DataBind();

			List<string> msg = new List<string>();
			msg.Add("msg1");
			msg.Add("msg2");
			msg.Add("msg3");
			RepeaterMessage.DataSource = msg;
			RepeaterMessage.DataBind();

			// 複数行のテキストボックス
			TextBoxMultiLine.Text = "aaa\r\nbbb";
		}
	}
}