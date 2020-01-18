using System;
using System.Data;

namespace WebAppSample
{
	public partial class Kotsuhi : System.Web.UI.Page
	{

		protected void Page_Load(object sender, EventArgs e)
		{
			DataTable dt = new DataTable();
			dt.Columns.Add("gNo", typeof(string));
			dt.Columns.Add("gDate", typeof(string));
			dt.Columns.Add("gDay", typeof(string));
			dt.Columns.Add("gKikan", typeof(string));
			dt.Columns.Add("gEki1", typeof(string));
			dt.Columns.Add("gEki2", typeof(string));
			dt.Columns.Add("gEki3", typeof(string));
			dt.Columns.Add("gKataKingaku", typeof(string));
			dt.Columns.Add("gIdoKBN", typeof(string));
			dt.Columns.Add("gKingaku", typeof(string));

			dt.Columns["gEki2"].DefaultValue = "～";

			GridView1.ShowHeaderWhenEmpty = true;

			GridView1.DataSource = dt;
			GridView1.DataBind();
			GridView1.HeaderRow.Cells[0].Text = "Noaaa.";
		}

		protected void CmdToroku_Click(object sender, EventArgs e)
		{
			DataTable dt = (DataTable)GridView1.DataSource;

			DataRow dr = dt.NewRow();
			dr["gNo"] = "1";

			dr.EndEdit();

			dt.Rows.Add(dr);

			dt.AcceptChanges();

			GridView1.DataSource = dt;
			GridView1.DataBind();
		}
	}
}