using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using WebAppLib;

namespace WebAppSample.Yontaku.Manager
{
    public class YontakuSqlManager
    {
        /// <summary> 四択問題 データベースファイル名 </summary>
        private readonly string YONTAKU_DATABASE_FILE = "Yontaku.db";

        /// <summary>
        /// 問題の取得
        /// </summary>
        /// <param name="lvl"></param>
        /// <param name="type"></param>
        /// <param name="mode">モード</param>
        /// <returns></returns>
        internal DataTable GetMondai(string lvl, string type, string mode = null)
        {
            // 最大100件をランダムに抽出
            // 乱数次第で取得件数が変動するので要注意
            using (ISQLManager manager = SQLManager.GetInterface(YONTAKU_DATABASE_FILE))
            {
                string whereLvl = "<= @lvl";
                if ("一致".Equals(mode)){
                    whereLvl = "= @lvl";
                }

                string sql = $@"
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
			                    1000
	                    ) 
		                    ON yontaku.rowid == rowid 
                    WHERE
                        lvl  {whereLvl}
                    AND type = @type
                    LIMIT
	                    100;
                ";

                Dictionary<string, dynamic> parameters = new Dictionary<string, dynamic>
                {
                    { "lvl", lvl },
                    { "type", type },
                };

                return manager.Select(sql, parameters);
            }
        }

        /// <summary>
        /// 解答候補の取得
        /// </summary>
        /// <param name="lvl"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        internal DataTable GetAnswers(string lvl, string type, string mode = null)
        {
            string whereLvl = "<= @lvl";
            if ("一致".Equals(mode))
            {
                whereLvl = "= @lvl";
            }

            using (ISQLManager manager = SQLManager.GetInterface(YONTAKU_DATABASE_FILE))
            {
                string sql = $@"
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
			                    1000
	                    ) 
		                    ON answer.rowid == rowid 
                    WHERE
                        lvl  {whereLvl}
                    AND type = @type
                    LIMIT
	                    100;
                ";

                Dictionary<string, dynamic> parameters = new Dictionary<string, dynamic>
                {
                    { "lvl", lvl },
                    { "type", type },
                };

                return manager.Select(sql, parameters);
            }

        }
    }
}