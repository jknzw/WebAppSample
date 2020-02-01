using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
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
			if (IsPostBack)
			{
				// ポスト時の処理
				return;
			}
			else
			{
				// 初回起動

				//==============================
				// Repeater1へのデータ設定サンプル
				//==============================
				// 新規データテーブルの作成
				DataTable table = new DataTable();
				// 列の作成
				table.Columns.Add("col1");
				table.Columns.Add("col2");
				
				// 行の追加①
				table.Rows.Add("data1", "data2");

				// 行の追加②
				DataRow row = table.NewRow();
				row["col1"] = "data3";
				row["col2"] = "data4";
				table.Rows.Add(row);

				// リピーターにデータソースを設定
				Repeater1.DataSource = table;
				Repeater1.DataBind();

				// データソースを画面に保持(編集前データ)
				ViewState["DataSource"] = table;

				//==============================
				// メッセージの追加サンプル
				//==============================
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

		protected void Button1_Click(object sender, EventArgs e)
		{
			// 選択されたIDの取得
			string[] ids = ((Button)sender).ClientID.Split('_');
			string selectIndexText = ids[ids.Length - 1];
			int.TryParse(selectIndexText, out int selectIndex);
			Debug.WriteLine($"selectIndex[{selectIndexText}]");

			// 変更前データの取得
			DataTable table = (DataTable)ViewState["DataSource"];
			Debug.WriteLine($"変更前col1[{table.Rows[selectIndex][0]}]");
			Debug.WriteLine($"変更前col2[{table.Rows[selectIndex]["col2"]}]");

			// 変更後データの取得
			string text1 = ((TextBox)Repeater1.Items[selectIndex].FindControl("TextBox1")).Text;
			string text2 = ((TextBox)Repeater1.Items[selectIndex].FindControl("TextBox2")).Text;
			Debug.WriteLine($"変更後col1[{text1}]");
			Debug.WriteLine($"変更後col2[{text2}]");
		}
	}
}
