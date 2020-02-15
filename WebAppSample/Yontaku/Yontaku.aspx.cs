using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebAppLib;
using WebAppSample.Base;
using WebAppSample.common;
using WebAppSample.Yontaku.Logic;
using WebAppSample.Yontaku.Manager;

namespace WebAppSample.Yontaku
{
    /// <summary>
    /// 四択問題
    /// </summary>
    public partial class Yontaku : BasePage
    {
        /// <summary>
        /// Logger
        /// </summary>
        private readonly Logger logger = Logger.GetInstance(nameof(Yontaku));

        public Yontaku()
        {
            // リダイレクトページ
            HiddenBasePageRedirectURL.Value = CommonConst.REDIRECT_URL_YONTAKU;
        }

        /// <summary>
        /// ページロード
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            try
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
            }
            catch (Exception ex)
            {
                LabelMessage.Text = ex.ToString();
                logger.WriteException(MethodBase.GetCurrentMethod().Name, ex);
            }
            finally
            {
                logger.EndMethod(MethodBase.GetCurrentMethod().Name);
            }
        }

        /// <summary>
        /// 初期表示
        /// </summary>
        private void PageInit()
        {
            logger.StartMethod(MethodBase.GetCurrentMethod().Name);

            // 表題の設定
            LabelQuestion.Text = "よんたくもんだい";

            // ボタンの設定
            Button1.Text = "いちねんせいのかんじ";
            Button2.Text = "にねんせいのかんじ";
            Button3.Visible = false;
            Button4.Visible = false;

            HiddenFieldOk.Value = "0";
            HiddenFieldNg.Value = "0";
            RepeaterRireki.DataSource = null;
            RepeaterRireki.DataBind();

            // セッションクリア
            SessionRemove();

            PanelKekka.Visible = false;

            logger.EndMethod(MethodBase.GetCurrentMethod().Name);
        }

        /// <summary>
        /// セッションクリア
        /// </summary>
        private void SessionRemove()
        {
            Session.Remove("table");
            Session.Remove("mondai");
            Session.Remove("answersTable");
            Session.Remove("rireki");
        }

        /// <summary>
        /// 問題の設定
        /// </summary>
        /// <param name="lvl"></param>
        /// <param name="type"></param>
        private void SetMondai(string lvl, string type)
        {
            logger.StartMethod(MethodBase.GetCurrentMethod().Name);

            // 問題の取得
            YontakuLogic logic = new YontakuLogic();
            YontakuSqlManager manager = new YontakuSqlManager();

            if (!(Session["table"] is DataTable mondaiTable) || mondaiTable.Rows.Count == 0)
            {
                // 初回 or 全問出題完了時は取得
                mondaiTable = manager.GetMondai(lvl, type);
            }

            // ランダムに問題を取得
            DataRow mondaiRow = logic.GetRandomRow(mondaiTable);

            // 問題をセッションに保持
            Session["table"] = mondaiTable;
            Session["mondai"] = mondaiRow;

            // タイトルの設定
            if (string.IsNullOrEmpty(LabelQuestionTitle.Text))
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

            // セッションから取得
            DataTable answersTable = Session["answersTable"] as DataTable;

            // ランダムに解答を設定
            string[] answers = logic.GetAnswerTexts(mondaiRow, lvl, type, ref answersTable);
            Button1.Text = answers[0];
            Button2.Text = answers[1];
            Button3.Text = answers[2];
            Button4.Text = answers[3];

            // セッションに保持
            Session["answersTable"] = answersTable;

            Button3.Visible = true;
            Button4.Visible = true;

            logger.EndMethod(MethodBase.GetCurrentMethod().Name);
        }

        /// <summary>
        /// 解答クリック
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ButtonAnswer_Click(object sender, EventArgs e)
        {
            try
            {
                logger.StartMethod(MethodBase.GetCurrentMethod().Name);

                // 押下されたボタンのテキストを取得
                string answer = ((Button)sender).Text;

                if (answer.Equals("おわる"))
                {
                    // セッションクリア
                    SessionRemove();

                    // メニューに遷移
                    Response.Redirect("~/Menu.aspx", false);
                    return;
                }

                // トークンチェック
                CheckBasePageToken();

                switch (answer)
                {
                    case "いちねんせいのかんじ":
                        {
                            string level = "1";
                            string type = "かき";
                            HiddenFieldType.Value = type;
                            HiddenFieldLevel.Value = level;
                            SetMondai(level, type);
                        }
                        Button3.Visible = true;
                        Button4.Visible = true;
                        PanelKekka.Visible = false;
                        break;
                    case "にねんせいのかんじ":
                        {
                            string level = "2";
                            string type = "かき";
                            HiddenFieldType.Value = type;
                            HiddenFieldLevel.Value = level;
                            SetMondai(level, type);
                        }
                        Button3.Visible = true;
                        Button4.Visible = true;
                        PanelKekka.Visible = false;
                        break;
                    case "つぎへ":
                        {
                            string level = HiddenFieldLevel.Value;
                            string type = HiddenFieldType.Value;
                            SetMondai(level, type);
                            PanelKekka.Visible = false;
                        }
                        break;
                    default:
                        // セッションから問題を取得
                        DataRow mondaiRow = Session["mondai"] as DataRow;

                        // 結果の設定
                        YontakuLogic logic = new YontakuLogic();
                        (bool result, string text) = logic.GetResult(answer, mondaiRow);
                        LabelQuestion.Text = text;

                        // 正解率の表示                    
                        decimal.TryParse(HiddenFieldOk.Value, out decimal ok);
                        decimal.TryParse(HiddenFieldNg.Value, out decimal ng);
                        string resultText = logic.GetResultText(result, ref ok, ref ng);
                        LabelResult.Text = resultText;
                        HiddenFieldOk.Value = ok.ToString();
                        HiddenFieldNg.Value = ng.ToString();

                        // 履歴の設定
                        List<string> rireki = Session["rireki"] as List<string>;
                        string header = LabelQuestionTitle.Text;
                        rireki = logic.AddRireki(rireki, header, answer, mondaiRow);
                        RepeaterRireki.DataSource = rireki;
                        RepeaterRireki.DataBind();
                        Session["rireki"] = rireki;

                        // 出題した問題を元のテーブルから削除
                        if (Session["table"] is DataTable mondaiTable)
                        {
                            mondaiTable.Rows.Remove(mondaiRow);
                        }

                        // ボタンの設定
                        Button1.Text = "おわる";
                        Button2.Text = "つぎへ";
                        Button3.Visible = false;
                        Button4.Visible = false;

                        PanelKekka.Visible = true;
                        break;
                }
            }
            catch (Exception ex)
            {
                LabelMessage.Text = ex.ToString();

                logger.WriteException(MethodBase.GetCurrentMethod().Name, ex);
            }
            finally
            {
                logger.EndMethod(MethodBase.GetCurrentMethod().Name);
            }
        }
    }
}
