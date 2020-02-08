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
				row["Name"] = "Web勤怠表";
				dt.Rows.Add(row);

				row = dt.NewRow();
				row["Name"] = "交通費精算";
				dt.Rows.Add(row);

				row = dt.NewRow();
				row["Name"] = "用語集";
				dt.Rows.Add(row);

				row = dt.NewRow();
				row["Name"] = "ログアウト";
				dt.Rows.Add(row);

                row = dt.NewRow();
                row["Name"] = "四択";
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
					Server.Transfer("~/ToDo.aspx", false);
					break;
				case "Web勤怠表":
					Server.Transfer("~/Kintai.aspx", false);
					break;
				case "交通費精算":
					Server.Transfer("~/Kotsuhi.aspx", false);
					break;
				case "用語集":
					Server.Transfer("~/FrmYogoList.aspx", false);
					break;
				case "電卓":
                    Server.Transfer("~/ToDo.aspx", false);
                    break;
                case "四択":
                    Server.Transfer("~/Yontaku/Yontaku.aspx", false);
                    break;
				default:
					Server.Transfer("~/Login.aspx", false);
					break;
			}
		}
	}
}