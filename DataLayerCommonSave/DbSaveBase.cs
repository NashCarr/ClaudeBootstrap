using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Web;
using CommonDataReturn;
using DataLayerCommon;

namespace DataLayerCommonSave
{
    public abstract class DbSaveBase : IDisposable
    {
        private const string ErrParameter = "@ErrMsg";

        protected internal SqlCommand CmdSql;
        protected internal SqlConnection ConnSql;

        protected internal string IdParameter;

        protected internal ReturnBase ReturnValues;

        protected DbSaveBase()
        {
            IdParameter = string.Empty;
            ReturnValues = new ReturnBase();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected internal void SetEmptyStringMessage(string fieldName)
        {
            ReturnValues.ErrMsg = fieldName + " must have a value.";
        }

        protected internal void SetZeroNumberMessage(string fieldName)
        {
            ReturnValues.ErrMsg = fieldName + " cannot be zero.";
        }

        protected internal void SetErrMsgParameter()
        {
            ReturnValues.ErrMsg = string.Empty;
            CmdSql.Parameters.Add(ErrParameter, SqlDbType.NVarChar, 512).Value = ReturnValues.ErrMsg;
            CmdSql.Parameters[ErrParameter].Direction = ParameterDirection.InputOutput;
        }

        protected internal SqlParameter CreateDecimalParameter(string parmName, decimal value, byte precision,
            byte scale)
        {
            SqlParameter param = new SqlParameter(parmName, SqlDbType.Decimal)
            {
                SourceColumn = value.ToString(CultureInfo.InvariantCulture),
                Precision = precision,
                Scale = scale
            };
            return param;
        }

        protected internal void SetIdInputOutputParameter()
        {
            CmdSql.Parameters.Add(IdParameter, SqlDbType.Int).Value = ReturnValues.Id;
            CmdSql.Parameters[IdParameter].Direction = ParameterDirection.InputOutput;
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
                            ReturnValues.ErrMsg = CmdSql.Parameters[ErrParameter].Value.ToString();
                        }
                    }
                    ConnSql.Close();
                }
            }
            catch (Exception ex)
            {
                DocumentErrorMessage(ex.Message);
                ReturnValues.ErrMsg = ex.Message;
            }
        }

        protected internal void SendNonQueryGetId()
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
                            ReturnValues.ErrMsg = CmdSql.Parameters[ErrParameter].Value.ToString();
                        }
                        ReturnValues.Id = Convert.ToInt32(CmdSql.Parameters[IdParameter].Value);
                    }
                    ConnSql.Close();
                }
            }
            catch (Exception ex)
            {
                DocumentErrorMessage(ex.Message);
                ReturnValues.ErrMsg = ex.Message;
            }
            finally
            {
                HttpContext.Current.Session["CurrentKey"] = ReturnValues.Id.ToString();
            }
        }

        protected internal void DocumentErrorMessage(string errorMessage)
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