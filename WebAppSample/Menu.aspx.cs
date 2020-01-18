using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAppSample
{
	public partial class Menu : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if(!IsPostBack)
			{
				// 初期表示
				DataTable dt = new DataTable();
				dt.Columns.Add("Name");

				DataRow row = dt.NewRow();
				row["Name"] = "ToDo";
				dt.Rows.Add(row);

				row = dt.NewRow();
				row["Name"] = "LogOut";
				dt.Rows.Add(row);

				Repeater1.DataSource = dt;
				Repeater1.DataBind();
			}
			else
			{
				// postback
			}
		}

		protected void Button1_Click(object sender, EventArgs e)
		{
			switch (((Button)sender).Text)
			{
				case "ToDo":
					Server.Transfer("~/ToDo.aspx", true);
					break;
				default:
					Server.Transfer("~/Login.aspx", true);
					break;
			}
		}
	}
}