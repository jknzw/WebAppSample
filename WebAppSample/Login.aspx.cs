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
        protected void ButtonInsert_Click(object sender, EventArgs e)
        {

        }

        protected void ButtonLogin_Click(object sender, EventArgs e)
        {
            try
            {
                //string path = Server.MapPath("./sqlite/");
                //string dataSource = Path.Combine(path, "WebApp.db");

                //using (SQLiteUtility util = new SQLiteUtility(dataSource))
                //{
                //    util.Connect();
                //    string sql = "SELECT * FROM userinfo WHERE userid = @userid";
                //    string userid = TextBoxId.Text;
                //    Dictionary<string, dynamic> parameters = new Dictionary<string, dynamic>
                //    {
                //        {  "userid", userid },
                //    };
                //    DataTable dataTable = util.Fill(sql, parameters);
                //    if (dataTable.Rows.Count > 0)
                //    {
                //        if (dataTable.Rows[0]["password"].ToString().Equals(TextBoxPw.Text))
                //        {
                //            LabelMessage.Text = "認証に成功しました。";
                //            SessionManager.UserInfo userInfo = new SessionManager.UserInfo(Session)
                //            {
                //                UserId = userid,
                //            };
                //            Server.Transfer("~/Menu.aspx", true);
                //        }
                //        else
                //        {
                //            LabelMessage.Text = "パスワードが違います。";
                //        }
                //    }
                //    else
                //    {
                //        LabelMessage.Text = "ユーザーが未登録です。";
                //    }
                //}

                using (ISQLManager manager = SQLManager.GetInterface("WebApp.db"))
                {
                    string sql = "SELECT * FROM userinfo WHERE userid = @userid";

                    string userid = TextBoxId.Text;

                    Dictionary<string, dynamic> parameters = new Dictionary<string, dynamic>
                    {
                        {  "userid", userid },
                    };

                    DataTable dataTable = manager.Select(sql, parameters);

                    if (dataTable.Rows.Count > 0)
                    {
                        if (dataTable.Rows[0]["password"].ToString().Equals(TextBoxPw.Text))
                        {
                            LabelMessage.Text = "認証に成功しました。";

                            SessionManager.UserInfo userInfo = new SessionManager.UserInfo(Session)
                            {
                                UserId = userid,
                            };

                            Server.Transfer("~/Menu.aspx", true);
                        }
                        else
                        {
                            LabelMessage.Text = "パスワードが違います。";
                        }
                    }
                    else
                    {
                        LabelMessage.Text = "ユーザーが未登録です。";
                    }
                }
            }
            catch (Exception ex)
            {
                LabelMessage.Text = ex.Message;
            }
        }
    }
}