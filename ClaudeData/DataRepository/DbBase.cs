using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.CodeAnalysis;
using System.Web;
using DataLayerCommon;

namespace DataManagement.DataRepository
{
    public abstract class DbBase : IDisposable
    {
        private const string ErrParameter = "@ErrMsg";

        protected internal SqlCommand CmdSql;
        protected internal SqlConnection ConnSql;

        protected internal string ErrMsg;
        protected internal string IdParameter;

        protected internal int IdValue;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected internal void SetEmptyStringMessage(string fieldName)
        {
            ErrMsg = fieldName + " must have a value.";
        }

        protected internal void SetZeroNumberMessage(string fieldName)
        {
            ErrMsg = fieldName + " cannot be zero.";
        }

        protected internal void SetErrMsgParameter()
        {
            ErrMsg = string.Empty;
            CmdSql.Parameters.Add(ErrParameter, SqlDbType.NVarChar, 512).Value = ErrMsg;
            CmdSql.Parameters[ErrParameter].Direction = ParameterDirection.InputOutput;
        }

        protected internal void SetIdInputOutputParameter()
        {
            CmdSql.Parameters.Add(IdParameter, SqlDbType.Int).Value = IdValue;
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
                            ErrMsg = CmdSql.Parameters[ErrParameter].Value.ToString();
                        }
                        IdValue = Convert.ToInt32(CmdSql.Parameters[IdParameter].Value);
                    }
                    ConnSql.Close();
                }
            }
            catch (Exception ex)
            {
                DocumentErrorMessage(ex.Message);
                ErrMsg = ex.Message;
            }
            finally
            {
                HttpContext.Current.Session["CurrentKey"] = IdValue.ToString();
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

        protected internal DataTable GetDataTable()
        {
            DataTable dt = new DataTable();
            using (SqlDataAdapter da = new SqlDataAdapter(CmdSql))
            {
                da.Fill(dt);
                CmdSql?.Dispose();
                ConnSql?.Dispose();
            }
            return dt;
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

        //protected internal class PhoneLink : List<PhoneAssociation>, IEnumerable<SqlDataRecord>
        //}
        //    }
        //        }
        //            yield return sdr;
        //            sdr.SetInt16(1, data.Order);
        //            sdr.SetInt32(0, data.Id);
        //        {

        //        foreach (DisplayOrder data in this)
        //            );
        //            new SqlMetaData("DisplayOrder", SqlDbType.Int)
        //            new SqlMetaData("Id", SqlDbType.Int),
        //        SqlDataRecord sdr = new SqlDataRecord(
        //    {
        //    IEnumerator<SqlDataRecord> IEnumerable<SqlDataRecord>.GetEnumerator()
        //{

        //protected internal class DataOrder : List<DisplayOrder>, IEnumerable<SqlDataRecord>
        //{
        //    IEnumerator<SqlDataRecord> IEnumerable<SqlDataRecord>.GetEnumerator()
        //    {
        //        SqlDataRecord sdr = new SqlDataRecord(
        //            new SqlMetaData("Id", SqlDbType.Int),
        //            new SqlMetaData("PhoneId", SqlDbType.Int)
        //            );

        //        foreach (PhoneAssociation data in this)
        //        {
        //            sdr.SetInt32(0, data.PhoneAssociationId);
        //            sdr.SetInt32(1, data.PhoneId);
        //            yield return sdr;
        //        }
        //    }
        //}

        //protected internal class AddressLink : List<AddressAssociation>, IEnumerable<SqlDataRecord>
        //{
        //    IEnumerator<SqlDataRecord> IEnumerable<SqlDataRecord>.GetEnumerator()
        //    {
        //        SqlDataRecord sdr = new SqlDataRecord(
        //            new SqlMetaData("Id", SqlDbType.Int),
        //            new SqlMetaData("AddressId", SqlDbType.Int)
        //            );

        //        foreach (AddressAssociation data in this)
        //        {
        //            sdr.SetInt32(0, data.AddressAssociationId);
        //            sdr.SetInt32(1, data.AddressId);
        //            yield return sdr;
        //        }
        //    }
        //}
    }
}