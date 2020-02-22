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

                AddRedirectButton(dt, "四択");
                AddRedirectButton(dt, "サンプルテーブル");
                AddRedirectButton(dt, "Vue.js");
                AddRedirectButton(dt, "位置情報");

                Repeater1.DataSource = dt;
                Repeater1.DataBind();
            }
            else
			{
				// postback
			}
		}

        private void AddRedirectButton(DataTable dt,string name)
        {
            DataRow row = dt.NewRow();
            row["Name"] = name;
            dt.Rows.Add(row);
        }

        protected void Button1_Click(object sender, EventArgs e)
		{
			switch (((Button)sender).Text)
			{
				case "ToDo":
                    Response.Redirect("~/ToDo.aspx", false);
					break;
				case "Web勤怠表":
                    Response.Redirect("~/Kintai.aspx", false);
					break;
				case "交通費精算":
                    Response.Redirect("~/Kotsuhi.aspx", false);
					break;
				case "用語集":
                    Response.Redirect("~/FrmYogoList.aspx", false);
					break;
				case "電卓":
                    Response.Redirect("~/ToDo.aspx", false);
                    break;
                case "四択":
                    Response.Redirect("~/Yontaku/Yontaku.aspx", false);
                    break;
                case "サンプルテーブル":
                    Response.Redirect("~/Sample/SampleTable.aspx", false);
                    break;
                case "Vue.js":
                    Response.Redirect("~/Sample/VueTest.aspx", false);
                    break;
                case "位置情報":
                    Response.Redirect("~/Sample/GeoApiTest.aspx", false);
                    break;
                default:
					Response.Redirect("~/Login.aspx", false);
					break;
			}
		}
	}
}