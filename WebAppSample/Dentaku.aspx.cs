using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Web.UI.WebControls;
using WebAppLib;

namespace WebAppSample
{
    public partial class Dentaku : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string path = Server.MapPath("./");

                string dataSource = Path.Combine(path, "Dentaku.db");

                using (SQLiteUtility util = new SQLiteUtility(dataSource))
                {
                    util.Connect();

                    string sql = "SELECT ZEIRITU FROM ZEIRITU";

                    Dictionary<string, dynamic> parameters = null;

                    DataTable dataTable = util.Fill(sql, parameters);

                    if (dataTable.Rows.Count > 0)
                    {
                        textBoxZei.Text = dataTable.Rows[0]["ZEIRITU"].ToString();
                    }
                    else
                    {
                        textBoxZei.Text = "0";
                    }
                }
            }
            catch (Exception ex)
            {
                labelMessage.Text = ex.Message;
            }
        }

        protected void btnDot_Click(object sender, EventArgs e)
        {
            if (labelCalc.Text.IndexOf(".") < 0)
                labelCalc.Text = labelCalc.Text + ((Button)sender).Text;
        }


        protected void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                labelCalc.Text = "0";
                hiddenAction.Value = String.Empty;
            }
            catch (Exception ex)
            {
                labelMessage.Text = ex.Message;
            }
        }

        protected void btnNum_Click(object sender, EventArgs e)
        {
            try
            {
                if (labelCalc.Text.Equals("0"))
                    labelCalc.Text = ((Button)sender).Text;
                else
                {
                    labelCalc.Text = labelCalc.Text + ((Button)sender).Text;
                }
            }
            catch (Exception ex)
            {
                labelMessage.Text = ex.Message;
            }
        }
    }
}