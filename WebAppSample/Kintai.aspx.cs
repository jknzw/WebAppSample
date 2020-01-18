using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Txtdate.Text = DateTime.Now.ToString("yyyy-MM-dd");
            DataTable table = new DataTable();
            table.Columns.Add("col1");
            table.Columns.Add("col2");
            table.Columns.Add("col3");
            table.Columns.Add("col4");
            table.Columns.Add("col5");
            table.Columns.Add("col6");
            table.Columns.Add("col7");
            

 //           table.Rows.Add("data1", "data2", "data3", "data4", "data5", "data6", "data7");

            DataRow row = table.NewRow();
            row["col1"] = DateTime.Now.ToString("yyyy-MM-dd");
            row["col2"] = "曜日";
            row["col3"] = "区分";
            row["col4"] = "出勤";
            row["col5"] = "退勤";
            row["col6"] = "作業場所";
            row["col7"] = "備考";

            table.Rows.Add(row);

            List<string> msg = new List<string>();
            msg.Add("msg1");
            msg.Add("msg2");
            msg.Add("msg3");
            RepeaterMessage.DataSource = msg;
            RepeaterMessage.DataBind();

            // 複数行のテキストボックス
            TextBoxMultiLine.Text = "aaa\r\nbbb";
            Repeater1.DataSource = table;
            Repeater1.DataBind();
        }

        protected void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {

        }
    }
}