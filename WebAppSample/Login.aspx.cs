using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebAppLib;

namespace WebAppSample
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonLogin_Click(object sender, EventArgs e)
        {
            try
            {
                string path = Server.MapPath("./");

                string dataSource = Path.Combine(path, "WebApp.db");

                SQLiteUtility util = new SQLiteUtility(dataSource);
                util.Connect();

                string sql = "SELECT * FROM userinfo WHERE userid = @userid";

                Dictionary<string, dynamic> parameters = new Dictionary<string, dynamic>
            {
                {  "userid", TextBoxId.Text },
            };

                DataTable dataTable = util.Fill(sql, parameters);

                if (dataTable.Rows.Count > 0)
                {
                    if (dataTable.Rows[0]["password"].ToString().Equals(TextBoxPw.Text))
                    {
                        Label1.Text = "認証に成功しました。";
                    }
                    else
                    {
                        Label1.Text = "パスワードが違います。";
                    }
                }
                else
                {
                    Label1.Text = "ユーザーが未登録です。";
                }
            }
            catch (Exception ex)
            {
                Label1.Text = ex.Message;
            }
        }
    }
}