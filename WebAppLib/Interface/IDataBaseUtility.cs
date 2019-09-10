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

        DataTable Fill(string sql, Dictionary<string, dynamic> parameters);

        int Execute(string sql, Dictionary<string, dynamic> parameters);

        void Commit();

        void RollBack();

        void Close();
    }
}
