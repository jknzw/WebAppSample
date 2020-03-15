using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using WebAppLib;
using WebAppSample.Yontaku.Manager;

namespace WebAppSample.Yontaku.Logic
{
    public class YontakuLogic
    {
        /// <summary>
        /// ランダムに行を取得する
        /// </summary>
        /// <param name="table">DataTable</param>
        /// <returns>DataRow</returns>

        internal DataRow GetRandomRow(DataTable table)
        {
            if (table.Rows.Count == 0)
            {
                return null;
            }

            Random r = new Random();
            int index = r.Next(0, table.Rows.Count - 1);
            return table.Rows[index];
        }

        /// <summary>
        /// 問題文の取得
        /// </summary>
        /// <param name="mondaiRow"></param>
        /// <returns></returns>
        internal string GetQuestionText(DataRow mondaiRow)
        {
            string mondai = mondaiRow["mondai"] as string;
            string keyword = mondaiRow["keyword"] as string;

            // キーワードにアンダーバーを設定
            if (mondai.IndexOf("*") >= 0)
            {
                // *が含まれる場合、*を変換
                mondai = mondai.Replace("*", $"<u>{keyword}</u>");
            }
            else
            {
                mondai = mondai.Replace(keyword, $"<u>{keyword}</u>");
            }
            return mondai;
        }

        /// <summary>
        /// 解答文の取得
        /// </summary>
        /// <param name="mondaiRow"></param>
        /// <returns></returns>
        internal string GetAnswerText(DataRow mondaiRow)
        {
            string mondai = mondaiRow["mondai"] as string;
            string keyword = mondaiRow["keyword"] as string;
            string answer = mondaiRow["answer"] as string;

            // 正答にアンダーバーを設定
            if (mondai.IndexOf("*") >= 0)
            {
                // *が含まれる場合、*を変換
                mondai = mondai.Replace("*", $"<u>{answer}</u>");
            }
            else
            {
                mondai = mondai.Replace(keyword, $"<u>{answer}</u>");
            }
            return mondai;
        }

        /// <summary>
        /// 正答の取得
        /// </summary>
        /// <param name="mondaiRow"></param>
        /// <returns></returns>
        public string GetCorrectAnswer(DataRow mondaiRow)
        {
            return mondaiRow["answer"] as string;
        }

        /// <summary>
        /// 解答候補の取得
        /// </summary>
        /// <param name="mondaiRow"></param>
        /// <param name="lvl"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        internal string[] GetAnswerTexts(DataRow mondaiRow, string lvl, string type,string mode, ref DataTable answersTable)
        {
            // 解答と候補の取得
            string answer = mondaiRow["answer"] as string;
            string choice1 = mondaiRow["choice1"] as string;
            string choice2 = mondaiRow["choice2"] as string;
            string choice3 = mondaiRow["choice3"] as string;
            if (string.IsNullOrEmpty(choice1) || string.IsNullOrEmpty(choice2) || string.IsNullOrEmpty(choice3))
            {
                if (answersTable == null || answersTable.Rows.Count <= 10)
                {
                    // いずれかの解答が未設定の場合 or 候補が10件以下の場合

                    // 解答候補を取得
                    YontakuSqlManager manager = new YontakuSqlManager();
                    answersTable = manager.GetAnswers(lvl, type, mode);
                }

                // ランダム解答候補を並べ替え
                DataRow[] rows = answersTable.AsEnumerable()
                    .Where(x => !x.Field<string>("keyword").Equals(answer)
                        && !x.Field<string>("keyword").Equals(choice1)
                        && !x.Field<string>("keyword").Equals(choice2)
                        && !x.Field<string>("keyword").Equals(choice3))
                    .OrderBy(i => Guid.NewGuid()).ToArray();

                if (string.IsNullOrEmpty(choice1))
                {
                    choice1 = rows[0]["keyword"] as string;
                    answersTable.Rows.Remove(rows[0]);
                }
                if (string.IsNullOrEmpty(choice2))
                {
                    choice2 = rows[1]["keyword"] as string;
                    answersTable.Rows.Remove(rows[1]);
                }
                if (string.IsNullOrEmpty(choice3))
                {
                    choice3 = rows[2]["keyword"] as string;
                    answersTable.Rows.Remove(rows[2]);
                }
                // Removeを確定
                answersTable.AcceptChanges();
            }

            // 並べ替え用に一旦リストに格納
            List<string> answers = new List<string>
            {
                answer,
                choice1,
                choice2,
                choice3
            };

            // ランダムに並べ替えて返却
            return answers.OrderBy(i => Guid.NewGuid()).ToArray();
        }

        /// <summary>
        /// 結果の取得
        /// </summary>
        /// <param name="selectAnswer"></param>
        /// <param name="mondaiRow"></param>
        /// <returns></returns>
        internal (bool result, string text) GetResult(string selectAnswer, DataRow mondaiRow)
        {
            // 解答を取得
            string correctAnswer = GetCorrectAnswer(mondaiRow);

            // 答え合わせ
            if (correctAnswer.Equals(selectAnswer))
            {
                return (true,
                    $@"○：せいかい
                    <br />{GetAnswerText(mondaiRow)}");
            }
            else
            {
                return (false,
                    $@"×:まちがい
                    <br />{GetQuestionText(mondaiRow)}
                    <br />せいかいは「{correctAnswer}」");
            }
        }

        /// <summary>
        /// 履歴の追加
        /// </summary>
        /// <param name="rireki"></param>
        /// <param name="selectAnswer"></param>
        /// <param name="mondaiRow"></param>
        /// <returns></returns>
        internal List<string> AddRireki(List<string> rireki, string header, string selectAnswer, DataRow mondaiRow)
        {
            if (rireki == null)
            {
                rireki = new List<string>();
            }

            // 解答を取得
            string correctAnswer = GetCorrectAnswer(mondaiRow);

            // 答え合わせ
            if (correctAnswer.Equals(selectAnswer))
            {
                string text = $"[{header}]○[{correctAnswer}]:{GetAnswerText(mondaiRow)}";
                rireki.Insert(0, text);
            }
            else
            {
                string text = $"[{header}]×[{selectAnswer}]:{GetAnswerText(mondaiRow)}";
                rireki.Insert(0, text);
            }
            if (rireki.Count > 100)
            {
                rireki.RemoveAt(100);
            }
            return rireki;
        }

        /// <summary>
        /// リザルトの取得
        /// </summary>
        /// <param name="result"></param>
        /// <param name="ok"></param>
        /// <param name="ng"></param>
        /// <param name="resultText"></param>
        internal string GetResultText(bool result, ref decimal ok, ref decimal ng)
        {
            if (result)
            {
                ok++;
            }
            else
            {
                ng++;
            }
            decimal wariai = ok * 100 / (ok + ng);
            return $"けっか [○:{ok}] [×:{ng}] せいかいりつ{decimal.Round(wariai, 2, MidpointRounding.AwayFromZero)}% ";
        }
    }
}
