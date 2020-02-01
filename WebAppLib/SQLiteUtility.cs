using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAppLib
{
    public class SQLiteUtility : IDataBaseUtility
    {
        private SQLiteConnection con;
        private SQLiteTransaction tran;

        private readonly string dataSource = ":memory:";

        public SQLiteUtility(string dataSource)
        {
            this.dataSource = dataSource;
        }

        public void BeginTransaction()
        {
            tran = con.BeginTransaction();
        }
		public void RollBack()
		{
			tran.Rollback();
		}
		public void Commit()
		{
			tran.Commit();
		}

		public void Close()
        {
            RollBack();
            con.Close();
        }

        public void Connect()
        {
            SQLiteConnectionStringBuilder conStrBuilder = new SQLiteConnectionStringBuilder { DataSource = dataSource };

            con = new SQLiteConnection(conStrBuilder.ToString());
            con.Open();
        }

        public int Execute(string sql, Dictionary<string, dynamic> parameters = null)
        {
            using (SQLiteCommand cmd = new SQLiteCommand(sql, con, tran))
            {
                SetSQLiteCommand(cmd, sql, parameters);
                return cmd.ExecuteNonQuery();
            }
        }

        private void SetSQLiteCommand(SQLiteCommand cmd, string sql, Dictionary<string, dynamic> parameters)
        {
            cmd.CommandText = sql;
            if (parameters != null)
            {
                foreach (string key in parameters.Keys)
                {
                    DbType dbType = DbType.String;

                    if (parameters[key] is int)
                    {
                        dbType = DbType.Int32;
                    }
                    if (parameters[key] == null)
                    {
                        parameters[key] = DBNull.Value;
                    }
                    cmd.Parameters.Add(new SQLiteParameter { ParameterName = key, DbType = dbType, Value = parameters[key] });
                }
            }
        }

		public DataTable Fill(string sql)
		{
			DataTable dataTable = new DataTable();

			using (SQLiteCommand cmd = new SQLiteCommand(sql, con, tran))
			{
				SetSQLiteCommand(cmd, sql, null);
				using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(cmd))
				{
					int ret = adapter.Fill(dataTable);
				}
			}
			return dataTable;
		}

		public DataTable Fill(string sql, Dictionary<string, dynamic> parameters)
        {
            DataTable dataTable = new DataTable();

            using (SQLiteCommand cmd = new SQLiteCommand(sql, con, tran))
            {
                SetSQLiteCommand(cmd, sql, parameters);
                using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(cmd))
                {
                    int ret = adapter.Fill(dataTable);
                }
            }
            return dataTable;
        }

        #region IDisposable Support
        private bool disposedValue = false; // 重複する呼び出しを検出するには

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // マネージ状態を破棄します (マネージ オブジェクト)。
                    tran?.Rollback();
                    tran?.Dispose();
                    con?.Close();
                    con?.Dispose();
                }

                // アンマネージ リソース (アンマネージ オブジェクト) を解放し、下のファイナライザーをオーバーライドします。

                // 大きなフィールドを null に設定します。
                tran = null;
                con = null;

                disposedValue = true;
            }
        }

        // 上の Dispose(bool disposing) にアンマネージ リソースを解放するコードが含まれる場合にのみ、ファイナライザーをオーバーライドします。
        // ~SQLiteUtility()
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
