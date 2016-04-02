using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using DataManagement.Models.Administration;
using DataRetrievalLayer;

namespace DataManagement.DataRepository.AdministrationRepository
{
    public class DbProgramOptionGet : DbGetBase
    {
        public List<ProgramOption> GetActiveRecords()
        {
            SetConnectToDatabase("[Admin].[usp_ProgramOption_GetActive]");

            return LoadRecords();
        }

        public List<ProgramOption> GetInactiveRecords()
        {
            SetConnectToDatabase("[Admin].[usp_ProgramOption_GetInactive]");

            return LoadRecords();
        }

        public ProgramOption GetRecord(int recordId)
        {
            return GetRecords(recordId, string.Empty).SingleOrDefault();
        }

        public List<ProgramOption> GetRecords()
        {
            return GetRecords(0, string.Empty);
        }

        private List<ProgramOption> GetRecords(int programOptionId, string programOption)
        {
            try
            {
                SetConnectToDatabase("[Admin].[usp_ProgramOption_Get]");

                CmdSql.Parameters.Add("@ProgramOptionId", SqlDbType.Int).Value = programOptionId;
                CmdSql.Parameters.Add("@Name", SqlDbType.NVarChar, 50).Value = programOption?.Trim() ?? string.Empty;

                return LoadRecords();
            }
            catch (Exception ex)
            {
                DocumentErrorMessage(ex.ToString());
                return new List<ProgramOption>();
            }
        }

        private List<ProgramOption> LoadRecords()
        {
            List<ProgramOption> data = new List<ProgramOption>();
            try
            {
                using (ConnSql)
                {
                    ConnSql.Open();
                    using (CmdSql)
                    {
                        using (SqlDataReader dr = CmdSql.ExecuteReader())
                        {
                            if (!dr.HasRows)
                            {
                                return data;
                            }

                            int ordProgramOptionId = dr.GetOrdinal("ProgramOptionId");
                            int ordDefaultRight = dr.GetOrdinal("DefaultRight");
                            int ordCreateDate = dr.GetOrdinal("CreateDate");
                            int ordIsActive = dr.GetOrdinal("IsActive");
                            int ordName = dr.GetOrdinal("Name");

                            while (dr.Read())
                            {
                                ProgramOption item = new ProgramOption
                                {
                                    RecordId = Convert.ToInt32(dr[ordProgramOptionId]),
                                    DefaultRight = Convert.ToString(dr[ordDefaultRight]),
                                    CreateDate = Convert.ToDateTime(dr[ordCreateDate]),
                                    IsActive = Convert.ToBoolean(dr[ordIsActive]),
                                    Name = Convert.ToString(dr[ordName])
                                };
                                data.Add(item);
                            }
                        }
                    }
                    ConnSql.Close();
                }
            }
            catch (Exception ex)
            {
                DocumentErrorMessage(ex.ToString());
            }
            return data;
        }
    }
}