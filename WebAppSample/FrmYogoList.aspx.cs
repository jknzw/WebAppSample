using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebAppLib;
using WebAppSample;

namespace YogoList
{
    public partial class FrmYogoList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string path = Server.MapPath("./sqlite/");

                string dataSource = Path.Combine(path, "yougo.db");

                using (SQLiteUtility util = new SQLiteUtility(dataSource))
                {
                    util.Connect();

                    string sql = "SELECT * FROM  yougo";

                    string name = this.txtNameItem.Text;
                    string biko = this.txtBikoItem.Text;
                    string url = this.txtUrlItem.Text;

                    Dictionary<string, dynamic> parameters = new Dictionary<string, dynamic>
                    {
                        {"name",name },
                        {"biko",biko },
                        {"url",url },
                    };

                    DataTable dataTable = util.Fill(sql, parameters);

                    if (dataTable.Rows.Count > 0)
                    {
                        Repeater1.DataSource = dataTable;
                        Repeater1.DataBind();
                    }
                }
            }
            catch (Exception ex)
            {
                this.LabelMessage.Text = ex.Message;
            }
        }

        protected void btnInsert_Click(object sender, EventArgs e)
        {
            try
            {
              string path = Server.MapPath("./sqlite/");

                string dataSource = Path.Combine(path, "yougo.db");

                using (SQLiteUtility util = new SQLiteUtility(dataSource))
                {
                    util.Connect();

                    string sql = "INSERT INTO yougo VALUES(\"\",\"\",@name,@biko,@URL);";

                    string name = this.txtNameItem.Text;
                    string biko = this.txtBikoItem.Text;
                    string url = this.txtUrlItem.Text;

                    Dictionary<string, dynamic> parameters = new Dictionary<string, dynamic>
                            {
                                {"name",name },
                                {"biko",biko },
                                {"url",url },
                            };

                    util.Execute(sql, parameters);

                    sql = "SELECT * FROM  yougo";
                    DataTable dataTable = util.Fill(sql);

                    if (dataTable.Rows.Count > 0)
                    {
                        Repeater1.DataSource = dataTable;
                        Repeater1.DataBind();
                    }
                }
            }
            catch(Exception ex)
            {
                var  aaa = ex;
            }
        }
        protected void btnUpd_Click(object sender, EventArgs e)
        {
            try
            {

            }
                    catch (Exception ex)
            {
                this.LabelMessage.Text = ex.Message;
            }
        }
        protected void btnDel_Click(object sender, EventArgs e)
        {
        }
    }
}

      