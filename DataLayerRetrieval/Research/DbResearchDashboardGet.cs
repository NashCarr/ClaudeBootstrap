using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using CommonDataRetrieval.Research;

namespace DataLayerRetrieval.Research
{
    public class DbResearchDashboardGet : DbGetBase
    {
        public List<ResearchDashboard> GetViewModel()
        {
            SetConnectToDatabase("[ResearchDashboard].[usp_GetList]");

            return LoadRecords();
        }

        private List<ResearchDashboard> LoadRecords()
        {
            List<ResearchDashboard> data = new List<ResearchDashboard>();
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
                            int ordResearchDashboardId = dr.GetOrdinal("ResearchDashboardId");

                            while (dr.Read())
                            {
                                ResearchDashboard item = new ResearchDashboard
                                {
                                    Name = Convert.ToString(dr[ordName]),
                                    RecordId = Convert.ToInt32(dr[ordResearchDashboardId]),
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