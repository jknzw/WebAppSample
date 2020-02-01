using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebAppLib;

namespace WebAppSample
{
	public partial class ToDo1 : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			string path = Server.MapPath("./sqlite/");
			string dataSource = Path.Combine(path, "todo.db");

			using (SQLiteUtility util = new SQLiteUtility(dataSource))
			{
				util.Connect();

				string sql = "SELECT * FROM Todo";
				Dictionary<string, dynamic> parameters = null;

				DataTable table = util.Fill(sql, parameters);

				MainRepeater.DataSource = table;
				MainRepeater.DataBind();
			}
		}

		protected void EditButton_Click(object sender, EventArgs e)
		{
			string id = ((Button)sender).CommandArgument;

		}
	}
}