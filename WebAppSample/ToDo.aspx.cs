using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAppSample
{
	public partial class ToDo1 : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			DataTable table = new DataTable();
			table.Columns.Add("StatusBox");
			table.Columns.Add("TaskBox");
			table.Columns.Add("RemarksBox");
			table.Columns.Add("DeleteButton");

			DataRow row = table.NewRow();
			row["StatusBox"] = "未着手";
			row["TaskBox"] = "帳票作成";
			row["RemarksBox"] = "税改正対応";
			row["DeleteButton"] = "削除";
			table.Rows.Add(row);

			MainRepeater.DataSource = table;
			MainRepeater.DataBind();
		}
	}
}