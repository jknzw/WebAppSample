using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebAppLib;
using System.IO;
//using System.Windows.Forms;

namespace WebAppSample
{
	public partial class Kotsuhi : System.Web.UI.Page
	{

		protected void Page_Load(object sender, EventArgs e)
		{
			try
			{
				string path = Server.MapPath("./sqlite/");

				string dataSource = Path.Combine(path, "Kotsuhi.db");

				using (SQLiteUtility util = new SQLiteUtility(dataSource))
				{
					util.Connect();

					string createTbl = "CREATE TABLE IF NOT EXISTS kotsuhi(" +
										"data_id INTEGER PRIMARY KEY AUTOINCREMENT, " +
										"userid TEXT, " +
										"target_date TEXT, " +
										"transport TEXT, " +
										"station_from TEXT, " +
										"station_to TEXT, " +
										"oneway_cost INTEGER, " +
										"ido_kbn TEXT " +
										")";

					util.Execute(createTbl, null);

				}
			}
			catch (Exception ex)
			{

			}
		}



		protected void cmdToroku_Click(object sender, EventArgs e)
		{
			//DataTable dt = (DataTable)MeisaiData.DataSource;

			//DataRow dr = dt.NewRow();
			//dr["gNo"] = "1";

			//dr.EndEdit();

			//dt.Rows.Add(dr);

			//dt.AcceptChanges();

			//this.MeisaiData.DataSource = dt;
			//this.MeisaiData.DataBind();
			try
			{
				string path = Server.MapPath("./sqlite/");

				string dataSource = Path.Combine(path, "Kotsuhi.db");

				using (SQLiteUtility util = new SQLiteUtility(dataSource))
				{
					util.Connect();
					string sql = "INSERT INTO kotsuhi" +
						"(userid, target_date, transport, station_from, station_to, oneway_cost, ido_kbn) " +
						"VALUES(@userid, @target_date, @transport, @station_from, @station_to, @oneway_cost, @ido_kbn)";

					Dictionary<string, dynamic> prams = new Dictionary<string, dynamic> {
				{ "userid", new SessionManager.UserInfo(Page.Session).UserId },
				{ "target_date", cdrDate.SelectedDate.ToShortDateString() },
				{ "transport", txtKikan.Text },
				{ "station_from", txtFrom.Text },
				{ "station_to", txtTo.Text },
				{ "oneway_cost", txtKingaku.Text },
				{ "ido_kbn", drpIkoKbn.SelectedValue }
			};
					util.Execute(sql, prams);

				}
				cmdShow_Click(sender, e);
			}
			catch (Exception ex)
			{
				// 何も見なかったことにする。
			}
		}

		protected void cmdShow_Click(object sender, EventArgs e)
		{
			DataTable dt = (DataTable)MeisaiData.DataSource;
			try
            {
                string path = Server.MapPath("./sqlite/");

                string dataSource = Path.Combine(path, "Kotsuhi.db");

                using (SQLiteUtility util = new SQLiteUtility(dataSource))
                {
                    util.Connect();

					string usr = new SessionManager.UserInfo(Page.Session).UserId;
					string sql = "SELECT "+
						" data_id" +
						", target_date"+
						", transport "+
						", station_from"+
						", station_to "+
						", oneway_cost"+
						", ido_kbn "+
						", case when ido_kbn = '片道' then oneway_cost else oneway_cost*2 end as cost" +
						" FROM kotsuhi WHERE userid = '" + usr +"' ORDER BY userid , data_id";


                    DataTable dataTable = util.Fill(sql, null);

					dataTable.Columns.Add("day");
					dataTable.Columns.Add("station_nyoro");
					//dataTable.Columns.Add("cost");

					if (dataTable.Rows.Count > 0)
                    {

						foreach (DataRow dr in dataTable.Rows)
						{
							
							dr["day"] = "";
							dr["station_nyoro"] = "～";

							//if (dr["ido_kbn"] == "0")
							//{
							//	dr["ido_kbn"] = "片道";

							//	dr["cost"] = dr["oneway_cost"];
							//}
							//else
							//{
							//	dr["ido_kbn"] = "往復";
							//	dr["cost"] = (int.Parse(dr["oneway_cost"].ToString()) * 2).ToString();
							//}

							//dt.Rows.Add(dr);


						}

						//dataTable.Rows[0][];
						//	this.MeisaiData.DataSource = dataTable;
						//this.MeisaiData.DataBind();
						dataTable.AcceptChanges();

						this.MeisaiData.DataSource = dataTable;
						this.MeisaiData.DataBind();
					}
                    else
                    {

                    }
                }
            }
            catch (Exception ex)
            {

            }

        }
    }
}