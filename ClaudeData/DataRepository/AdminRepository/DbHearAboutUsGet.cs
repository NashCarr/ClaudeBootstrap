using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using ClaudeData.Models.Admin;

namespace ClaudeData.DataRepository.AdminRepository
{
    public class DbHearAboutUsGet : DbGetBase
    {
        public List<HearAboutUs> GetActiveRecords()
        {
            SetConnectToDatabase("[Admin].[usp_HearAboutUs_GetActive]");

            return LoadRecords();
        }

        public List<HearAboutUs> GetInactiveRecords()
        {
            SetConnectToDatabase("[Admin].[usp_HearAboutUs_GetInactive]");

            return LoadRecords();
        }

        public HearAboutUs GetRecord(int recordId)
        {
            return GetRecords(recordId, string.Empty).SingleOrDefault();
        }

        public List<HearAboutUs> GetRecords()
        {
            return GetRecords(0, string.Empty);
        }

        private List<HearAboutUs> GetRecords(int hearAboutUsId, string name)
        {
            try
            {
                SetConnectToDatabase("[Admin].[usp_HearAboutUs_Get]");

                CmdSql.Parameters.Add("@HearAboutUsId", SqlDbType.Int).Value = hearAboutUsId;
                CmdSql.Parameters.Add("@Name", SqlDbType.NVarChar, 50).Value = name?.Trim() ?? string.Empty;

                return LoadRecords();
            }
            catch (Exception ex)
            {
                DocumentErrorMessage(ex.ToString());
                return new List<HearAboutUs>();
            }
        }

        private List<HearAboutUs> LoadRecords()
        {
            List<HearAboutUs> data = new List<HearAboutUs>();
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

                            int ordName = dr.GetOrdinal("Name");
                            int ordIsSystem = dr.GetOrdinal("IsSystem");
                            int ordIsActive = dr.GetOrdinal("IsActive");
                            int ordCreateDate = dr.GetOrdinal("CreateDate");
                            int ordDisplayOrder = dr.GetOrdinal("DisplayOrder");
                            int ordHearAboutUsId = dr.GetOrdinal("HearAboutUsId");

                            while (dr.Read())
                            {
                                HearAboutUs item = new HearAboutUs
                                {
                                    Name = Convert.ToString(dr[ordName]),
                                    IsSystem = Convert.ToBoolean(dr[ordIsSystem]),
                                    IsActive = Convert.ToBoolean(dr[ordIsActive]),
                                    RecordId = Convert.ToInt32(dr[ordHearAboutUsId]),
                                    CreateDate = Convert.ToDateTime(dr[ordCreateDate]),
                                    DisplayOrder = Convert.ToInt16(dr[ordDisplayOrder])
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