using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAppLib
{
    public interface ISQLManager : IDisposable
    {
        /// <summary>
        /// 検索
        /// </summary>
        /// <param name="sql">クエリ</param>
        /// <param name="parameters">パラメータ</param>
        /// <returns></returns>
        DataTable Select(string sql, Dictionary<string, dynamic> parameters = null);
        int Insert(string sql, Dictionary<string, dynamic> parameters = null);

        DataTable Lock(string sql, Dictionary<string, dynamic> parameters = null);
        int Update(string sql, Dictionary<string, dynamic> parameters = null);
        int Delete(string sql, Dictionary<string, dynamic> parameters = null);

        void Commit();
        void RollBack();
    }
}
