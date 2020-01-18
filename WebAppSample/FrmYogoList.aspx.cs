using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace YogoList
{
    public partial class FrmYogoList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string name = "名称";
            string biko = "備考";
            string url = "URL";

            txtNameItem.Text = name;
            txtBikoItem.Text = biko;
            txtUrlItem.Text = url;

            DataTable table = new DataTable();

            table.Columns.Add("No");
            table.Columns.Add("名称");
            table.Columns.Add("備考");
            table.Columns.Add("URL");

            for (int i = 0; i < 3; i++)
            {
                DataRow row = table.NewRow();

                row["No"] = i + 1;
                row["名称"] = name + i + 1;
                row["備考"] = biko + i + 1;
                row["URL"] = url + i + 1;

                table.Rows.Add(row);
            }

            Repeater1.DataSource = table;
            Repeater1.DataBind();

        }
    }
}