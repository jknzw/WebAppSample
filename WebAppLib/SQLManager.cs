using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Reflection;
using System.Text;
using System.Web;

namespace WebAppLib
{
    public class SQLManager : ISQLManager
    {
        private static readonly DataBaseType defaultType = DataBaseType.SQLite;
        private static readonly string defaultDbName = "WebApp.db";

        private enum DataBaseType
        {
            SQLServer,
            SQLite,
        }

        private IDataBaseUtility dbUtil;
        private Logger logger;

        private SQLManager()
        {
            logger = Logger.GetInstance(nameof(SQLManager));
        }

        public static ISQLManager GetInterface()
        {
            return GetInterface(defaultDbName);
        }

        public static ISQLManager GetInterface(string dbName)
        {
            return GetInterface(dbName, null, null, null);
        }

        public static ISQLManager GetInterface(string dataSource, string dataBase, string userId, string password)
        {
            return GetInstance(defaultType, dataSource, dataBase, userId, password);
        }

        private static SQLManager GetInstance(DataBaseType type, string dataSource, string dataBase, string userId, string password)
        {
            SQLManager service = new SQLManager();
            service.logger.StartMethod(MethodBase.GetCurrentMethod().Name);

            switch (type)
            {
                case DataBaseType.SQLServer:
                    service.dbUtil = new SQLServerUtility(dataSource, dataBase, userId, password);
                    break;
                case DataBaseType.SQLite:
                default:
                    string basePath = HttpContext.Current.Server.MapPath("~/sqlite/");
                    string path = Path.Combine(basePath, dataSource);
                    service.dbUtil = new SQLiteUtility(path);
                    break;
            }

            service.dbUtil.Connect();
            service.dbUtil.BeginTransaction();

            service.logger.EndMethod(MethodBase.GetCurrentMethod().Name);
            return service;
        }

        public int Insert(string sql, Dictionary<string, dynamic> parameters)
        {
            logger.StartMethod(MethodBase.GetCurrentMethod().Name);

            int count = Update(sql, parameters);

            logger.EndMethod(MethodBase.GetCurrentMethod().Name);
            return count;
        }

        public DataTable Select(string sql, Dictionary<string, dynamic> parameters = null)
        {
            logger.StartMethod(MethodBase.GetCurrentMethod().Name);

            WriteSqlLog(sql, parameters);
            DataTable table = dbUtil.Fill(sql, parameters);

            logger.EndMethod(MethodBase.GetCurrentMethod().Name);
            return table;
        }
        public DataTable Lock(string sql, Dictionary<string, dynamic> parameters)
        {
            logger.StartMethod(MethodBase.GetCurrentMethod().Name);

            DataTable table = Select(sql, parameters);

            logger.EndMethod(MethodBase.GetCurrentMethod().Name);
            return table;
        }

        public int Update(string sql, Dictionary<string, dynamic> parameters)
        {
            logger.StartMethod(MethodBase.GetCurrentMethod().Name);

            WriteSqlLog(sql, parameters);
            int count = dbUtil.Execute(sql, parameters);

            logger.EndMethod(MethodBase.GetCurrentMethod().Name);
            return count;
        }

        private void WriteSqlLog(string sql, Dictionary<string, dynamic> parameters)
        {
            string debugsql = sql;
            if (parameters != null)
            {
                foreach (string key in parameters.Keys)
                {
                    switch (parameters[key])
                    {
                        case DateTime dt:
                            debugsql = debugsql.Replace($"@{key}", $"'{dt.ToString("yyyy/MM/dd HH:mm:ss.fff")}'");
                            break;
                        case string s:
                            debugsql = debugsql.Replace($"@{key}", $"'{s}'");
                            break;
                        default:
                            debugsql = debugsql.Replace($"@{key}", parameters[key].ToString());
                            break;
                    }
                }
            }
            logger.WriteLine(debugsql);
        }

        public int Delete(string sql, Dictionary<string, dynamic> parameters)
        {
            logger.StartMethod(MethodBase.GetCurrentMethod().Name);

            int count = Update(sql, parameters);

            logger.EndMethod(MethodBase.GetCurrentMethod().Name);
            return count;
        }

        public int Call(string sql, Dictionary<string, dynamic> parameters)
        {
            logger.StartMethod(MethodBase.GetCurrentMethod().Name);

            // TODO:outパラメータを受け取る
            // TODO:outパラメータにDictionaryを追加する
            throw new NotSupportedException("未実装");

            //int count = Update(sql, parameters);

            //logger.EndMethod(MethodBase.GetCurrentMethod().Name);
            //return count;
        }

        public void Commit()
        {
            logger.StartMethod(MethodBase.GetCurrentMethod().Name);

            dbUtil.Commit();
            dbUtil.BeginTransaction();

            logger.EndMethod(MethodBase.GetCurrentMethod().Name);
        }

        public void RollBack()
        {
            logger.StartMethod(MethodBase.GetCurrentMethod().Name);

            dbUtil.RollBack();
            dbUtil.BeginTransaction();

            logger.EndMethod(MethodBase.GetCurrentMethod().Name);
        }

        #region IDisposable Support
        private bool disposedValue = false; // 重複する呼び出しを検出するには

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    logger.StartMethod(MethodBase.GetCurrentMethod().Name);

                    // マネージ状態を破棄します (マネージ オブジェクト)。
                    dbUtil?.Dispose();

                    logger.EndMethod(MethodBase.GetCurrentMethod().Name);
                    logger?.Dispose();
                }

                // アンマネージ リソース (アンマネージ オブジェクト) を解放し、下のファイナライザーをオーバーライドします。
                // 大きなフィールドを null に設定します。
                dbUtil = null;
                logger = null;

                disposedValue = true;
            }
        }

        // 上の Dispose(bool disposing) にアンマネージ リソースを解放するコードが含まれる場合にのみ、ファイナライザーをオーバーライドします。
        // ~SQLService()
        // {
        //   // このコードを変更しないでください。クリーンアップ コードを上の Dispose(bool disposing) に記述します。
        //   Dispose(false);
        // }

        // このコードは、破棄可能なパターンを正しく実装できるように追加されました。
        public void Dispose()
        {
            // このコードを変更しないでください。クリーンアップ コードを上の Dispose(bool disposing) に記述します。
            Dispose(true);
            // 上のファイナライザーがオーバーライドされる場合は、次の行のコメントを解除してください。
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}
