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

        DataTable Fill(string sql, Dictionary<string, dynamic> parameters = null);

        int Execute(string sql, Dictionary<string, dynamic> parameters = null);

		void Close();
    }
}
