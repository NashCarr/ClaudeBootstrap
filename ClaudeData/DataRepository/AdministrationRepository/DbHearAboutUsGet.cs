using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using ClaudeCommon.Models.Administration;

namespace ClaudeData.DataRepository.AdministrationRepository
{
    public class DbHearAboutUsGet : DbGetBase
    {
        public List<HearAboutUs> GetViewModel()
        {
            SetConnectToDatabase("[ViewModel].[usp_HearAboutUs_GetActive]");

            return LoadRecords();
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
                            int ordCreateDate = dr.GetOrdinal("CreateDate");
                            int ordDisplayOrder = dr.GetOrdinal("DisplayOrder");
                            int ordHearAboutUsId = dr.GetOrdinal("HearAboutUsId");

                            while (dr.Read())
                            {
                                HearAboutUs item = new HearAboutUs
                                {
                                    Name = Convert.ToString(dr[ordName]),
                                    IsSystem = Convert.ToBoolean(dr[ordIsSystem]),
                                    RecordId = Convert.ToInt32(dr[ordHearAboutUsId]),
                                    DisplayOrder = Convert.ToInt16(dr[ordDisplayOrder]),
                                    StringCreateDate =
                                        Convert.ToDateTime(dr[ordCreateDate]).ToString("MM/dd/yyyy hh:mm:ss tt")
                                };
                                item.DisplaySort = item.DisplayOrder.ToString("D3");
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