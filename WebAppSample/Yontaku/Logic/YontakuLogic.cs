using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using WebAppLib;

namespace WebAppSample.Yontaku
{
    public class YontakuLogic
    {
        /// <summary> 四択問題 データベースファイル名 </summary>
        private readonly string YONTAKU_DATABASE_FILE = "Yontaku.db";

        /// <summary>
        /// 問題の取得
        /// </summary>
        /// <returns></returns>
        public DataTable GetMondai()
        {
            using (ISQLManager manager = SQLManager.GetInterface(YONTAKU_DATABASE_FILE))
            {
                string sql = @"
                    WITH with_random_id(rowid) AS ( 
	                    SELECT
		                    abs(random() %(SELECT max(rowid) FROM yontaku)) 
	                    UNION ALL 
	                    SELECT
		                    abs(random() %(SELECT max(rowid) FROM yontaku)) 
	                    FROM
		                    yontaku
                    ) 
                    SELECT
	                    * 
                    FROM
	                    yontaku JOIN ( 
		                    SELECT DISTINCT
			                    rowid 
		                    FROM
			                    with_random_id 
		                    LIMIT
			                    10
	                    ) 
		                    ON yontaku.rowid == rowid 
                    LIMIT
	                    1; 
                ";

                return manager.Select(sql);
            }
        }

        /// <summary>
        /// ランダムに行を取得する
        /// </summary>
        /// <param name="table">DataTable</param>
        /// <returns>DataRow</returns>

        public DataRow GetRandomRow(DataTable table)
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
        public string GetQuestionText(DataRow mondaiRow)
        {
            string mondai = mondaiRow["mondai"] as string;
            string keyword = mondaiRow["keyword"] as string;

            // キーワードにアンダーバーを設定
            mondai = mondai.Replace(keyword, $"<u>{keyword}</u>");
            return mondai;
        }

        public string GetAnswerText(DataRow mondaiRow)
        {
            string mondai = mondaiRow["mondai"] as string;
            string keyword = mondaiRow["keyword"] as string;
            string answer = mondaiRow["answer"] as string;

            // 正答にアンダーバーを設定
            return mondai.Replace(keyword, $"<u>{answer}</u>");
        }

        /// <summary>
        /// 解答の取得
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
        /// <returns></returns>
        public string[] GetAnswerTexts(DataRow mondaiRow)
        {
            // 解答と候補の取得
            string answer = mondaiRow["answer"] as string;
            string choice1 = mondaiRow["choice1"] as string;
            string choice2 = mondaiRow["choice2"] as string;
            string choice3 = mondaiRow["choice3"] as string;
            if (string.IsNullOrEmpty(choice1) || string.IsNullOrEmpty(choice2) || string.IsNullOrEmpty(choice3))
            {
                // いずれかの解答が未設定の場合
                // 解答を除いた漢字をランダムに取得
                DataTable table = GetAnswers(answer);

                // ランダム解答を設定
                if (string.IsNullOrEmpty(choice1))
                {
                    choice1 = table.Rows[0]["keyword"] as string;
                }
                if (string.IsNullOrEmpty(choice2))
                {
                    choice2 = table.Rows[1]["keyword"] as string;
                }
                if (string.IsNullOrEmpty(choice3))
                {
                    choice3 = table.Rows[2]["keyword"] as string;
                }
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
        /// 解答候補の取得
        /// </summary>
        /// <returns></returns>
        private DataTable GetAnswers(string answer)
        {
            using (ISQLManager manager = SQLManager.GetInterface(YONTAKU_DATABASE_FILE))
            {
                string sql = @"
                    -- ランダムな行番号を取得
                    WITH with_random_id(rowid) AS ( 
	                    SELECT
		                    abs(random() %(SELECT max(rowid) FROM answer)) 
	                    UNION ALL 
	                    SELECT
		                    abs(random() %(SELECT max(rowid) FROM answer)) 
	                    FROM
		                    answer
                    ) 
                    SELECT
	                    * 
                    FROM
	                    answer JOIN ( 
                            -- 重複を避けて取得
		                    SELECT DISTINCT
			                    rowid 
		                    FROM
			                    with_random_id 
		                    LIMIT
			                    10
	                    ) 
		                    ON answer.rowid == rowid 
                    WHERE
	                    keyword <> @answer
                    LIMIT
	                    3;
                ";

                Dictionary<string, dynamic> parameters = new Dictionary<string, dynamic>
                {
                    { "answer", answer }
                };

                return manager.Select(sql, parameters);
            }

        }

        /// <summary>
        /// 結果の取得
        /// </summary>
        /// <param name="selectAnswer"></param>
        /// <param name="mondaiRow"></param>
        /// <returns></returns>
        public string GetResult(string selectAnswer, DataRow mondaiRow)
        {
            // 解答を取得
            string correctAnswer = GetCorrectAnswer(mondaiRow);

            // 答え合わせ
            if (correctAnswer.Equals(selectAnswer))
            {
                return $@"○：せいかい
                    <br />{GetAnswerText(mondaiRow)}";
            }
            else
            {
                return $@"×:まちがい
                    <br />{GetQuestionText(mondaiRow)}
                    <br />せいかいは「{correctAnswer}」";
            }
        }
    }
}
