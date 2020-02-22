using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using WebAppLib;
using WebAppSample.common;

namespace WebAppSample.Base
{
    public class BasePage : System.Web.UI.Page
    {
        /// <summary> リダイレクトページ </summary>
        public HiddenField HiddenBasePageRedirectURL { get; set; } = new HiddenField();

        #region private Field

        /// <summary> Token </summary>
        private readonly HiddenField hiddenTokenField = new HiddenField();

        /// <summary>
        /// Logger
        /// </summary>
        private readonly Logger logger = Logger.GetInstance(nameof(BasePage));

        #endregion private field

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public BasePage()
        {
            PreInit += new EventHandler(Page_PreInit);
            Load += new EventHandler(Page_Load);
        }

        /// <summary>
        /// トークンチェック
        /// </summary>
        protected void CheckBasePageToken(string redirectPage = null)
        {
            string serverToken = Session["Token"] as string;
            string clientToken = hiddenTokenField.Value;

            logger.WriteLog(MethodBase.GetCurrentMethod().Name, $"cToken[{clientToken}]", $"sToken[{serverToken}]");

            if (!string.IsNullOrEmpty(serverToken) && !string.IsNullOrEmpty(clientToken) && clientToken.Equals(serverToken))
            {
                // クライアント＆サーバートークンが存在し、トークンが一致する場合
                // トークンチェック成功

                // 新規トークンの作成 
                CreateNewToken();
            }
            else
            {
                logger.WriteLog(MethodBase.GetCurrentMethod().Name, "トークンエラー");

                // 優先度
                // ①引数のページに遷移
                // ②Hiddenに設定されたリダイレクトページに遷移
                // ③ログインページに遷移
                if (string.IsNullOrEmpty(redirectPage))
                {
                    string hiddenRedirectPage = HiddenBasePageRedirectURL.Value;
                    if (string.IsNullOrEmpty(hiddenRedirectPage))
                    {
                        Response.Redirect(CommonConst.REDIRECT_URL_LOGIN, false);
                    }
                    else
                    {
                        Response.Redirect(hiddenRedirectPage, false);
                    }
                }
                else
                {
                    Response.Redirect(redirectPage, false);
                }
            }
        }

        #region private Method
        /// <summary>
        /// PreInit
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Page_PreInit(object sender, EventArgs e)
        {
            HtmlForm form = FindControl("Form1") as HtmlForm;
            form.Controls.Add(hiddenTokenField);
            form.Controls.Add(HiddenBasePageRedirectURL);
        }

        /// <summary>
        /// Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Page_Load(object sender, EventArgs e)
        {
            logger.StartMethod(MethodBase.GetCurrentMethod().Name);

            // ユーザー認証

            if (IsPostBack)
            {
                // ポストバック
            }
            else
            {
                // 初期表示

                // トークンの設定
                CreateNewToken();
            }
            logger.EndMethod(MethodBase.GetCurrentMethod().Name);
        }

        /// <summary>
        /// 新規トークンの作成
        /// </summary>
        private void CreateNewToken()
        {
            string token = CreateCsrfToken();
            Session["Token"] = token;
            hiddenTokenField.Value = token;
            logger.WriteLog(MethodBase.GetCurrentMethod().Name, $"newToken[{token}]");
        }

        /// <summary>
        /// トークン長
        /// </summary>
        private static readonly int TOKEN_LENGTH = 16; //16*2=32バイト

        /// <summary>
        /// 32バイトのCSRFトークンを作成
        /// </summary>
        /// <returns></returns>
        private string CreateCsrfToken()
        {
            byte[] token = new byte[TOKEN_LENGTH];

            using (RNGCryptoServiceProvider gen = new RNGCryptoServiceProvider())
            {
                gen.GetBytes(token);
            }

            StringBuilder buf = new StringBuilder();
            for (int i = 0; i < token.Length; i++)
            {
                buf.AppendFormat("{0:x2}", token[i]);
            }

            return buf.ToString();
        }

        #endregion private Method
    }
}