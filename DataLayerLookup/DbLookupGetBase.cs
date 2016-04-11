using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.CodeAnalysis;
using DataLayerCommon;

namespace DataLayerLookup
{
    public abstract class DbLookupGetBase : IDisposable
    {
        private const string ErrParameter = "@ErrMsg";

        protected internal static SqlCommand CmdSql;
        protected internal static SqlConnection ConnSql;
        protected internal string ErrMsg;
        protected internal string IdParameter;

        protected internal int IdValue;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        [SuppressMessage("Microsoft.Security", "CA2100:Review SQL queries for security vulnerabilities")]
        protected bool SetConnectToDatabase(string storedProcedure)
        {
            try
            {
                ConnSql = new SqlConnection(DbConnect.GetClaudeConnStr());
                CmdSql = new SqlCommand
                {
                    Connection = ConnSql,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = storedProcedure
                };
                return true;
            }
            catch (Exception ex)
            {
                DocumentErrorMessage(ex.Message);
                return false;
            }
        }

        protected internal void SendNonQuery()
        {
            try
            {
                using (ConnSql)
                {
                    ConnSql.Open();
                    using (CmdSql)
                    {
                        CmdSql.ExecuteNonQuery();
                        if (!Convert.IsDBNull(CmdSql.Parameters[ErrParameter].Value))
                        {
                            ErrMsg = CmdSql.Parameters[ErrParameter].Value.ToString();
                        }
                    }
                    ConnSql.Close();
                }
            }
            catch (Exception ex)
            {
                DocumentErrorMessage(ex.Message);
                ErrMsg = ex.Message;
            }
        }

        protected internal static void DocumentErrorMessage(string errorMessage)
        {
            //using (SaveDataRepositoryError e = new SaveDataRepositoryError())
            //{
            //    e.SaveDBError(0, errorMessage);
            //}
        }

        protected virtual void Dispose(bool iAmBeingCalledFromDisposeAndNotFinalize)
        {
            CmdSql?.Dispose();
            ConnSql?.Close();
            // ReSharper disable once UseNullPropagation
            if (ConnSql != null) ConnSql.Dispose();
        }
    }
}