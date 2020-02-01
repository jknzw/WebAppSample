using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace WebAppLib
{
    interface IDataBaseUtility : IDisposable
    {
        void Connect();

        void BeginTransaction();

		void RollBack();

		void Commit();

		DataTable Fill(string sql);

		DataTable Fill(string sql, Dictionary<string, dynamic> parameters);

        int Execute(string sql, Dictionary<string, dynamic> parameters);

		void Close();
    }
}
