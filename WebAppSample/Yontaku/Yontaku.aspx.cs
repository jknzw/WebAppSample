using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebAppLib;

namespace WebAppSample.Yontaku
{
    /// <summary>
    /// 四択問題
    /// </summary>
    public partial class Yontaku : System.Web.UI.Page
    {
        /// <summary>
        /// Logger
        /// </summary>
        private readonly Logger logger = Logger.GetInstance(nameof(Yontaku));

        /// <summary>
        /// ページロード
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            logger.StartMethod(MethodBase.GetCurrentMethod().Name);

            if (IsPostBack)
            {
                // ポストバック
            }
            else
            {
                // 初期表示
                PageInit();
            }

            logger.EndMethod(MethodBase.GetCurrentMethod().Name);
        }

        /// <summary>
        /// 初期表示
        /// </summary>
        private void PageInit()
        {
            logger.StartMethod(MethodBase.GetCurrentMethod().Name);

            SetMondai();

            logger.EndMethod(MethodBase.GetCurrentMethod().Name);
        }

        /// <summary>
        /// 問題の設定
        /// </summary>
        private void SetMondai()
        {
            logger.StartMethod(MethodBase.GetCurrentMethod().Name);

            // 問題の取得
            YontakuLogic logic = new YontakuLogic();
            DataTable mondaiTable = logic.GetMondai();
            DataRow mondaiRow = logic.GetRandomRow(mondaiTable);

            // 問題をセッションに保持
            Session["mondai"] = mondaiRow;

            // タイトルの設定
            string title = LabelQuestionTitle.Text;
            if (string.IsNullOrEmpty(title))
            {
                // 初回
                LabelQuestionTitle.Text = "もんだい1";
            }
            else
            {
                // 2回目以降
                int.TryParse(LabelQuestionTitle.Text.Substring(4), out int count);
                LabelQuestionTitle.Text = $"もんだい{count + 1}";
            }

            // 問題の設定
            LabelQuestion.Text = logic.GetQuestionText(mondaiRow);

            // ランダムに回答を設定
            string[] answers = logic.GetAnswerTexts(mondaiRow);
            Button1.Text = answers[0];
            Button2.Text = answers[1];
            Button3.Text = answers[2];
            Button4.Text = answers[3];

            Button3.Visible = true;
            Button4.Visible = true;

            logger.EndMethod(MethodBase.GetCurrentMethod().Name);
        }

        /// <summary>
        /// 回答クリック
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ButtonAnswer_Click(object sender, EventArgs e)
        {
            logger.StartMethod(MethodBase.GetCurrentMethod().Name);

            // 押下されたボタンのテキストを取得
            string answer = ((Button)sender).Text;

            switch(answer)
            {
                case "おわる":
                    Server.Transfer("~/Menu.aspx", true);
                    break;
                case "つぎへ":
                    SetMondai();
                    break;
                default:
                    // セッションから問題を取得
                    DataRow mondaiRow = Session["mondai"] as DataRow;

                    // 結果の設定
                    YontakuLogic logic = new YontakuLogic();
                    string result = logic.GetResult(answer, mondaiRow);
                    LabelQuestion.Text = result;

                    // ボタンの設定
                    Button1.Text = "おわる";
                    Button2.Text = "つぎへ";
                    Button3.Visible = false;
                    Button4.Visible = false;
                    break;
            }

            logger.EndMethod(MethodBase.GetCurrentMethod().Name);
        }
    }
}
