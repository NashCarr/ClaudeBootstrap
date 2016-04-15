using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using CommonDataRetrieval.Research;

namespace DataLayerRetrieval.Research
{
    public class DbResearchDashboardGet : DbGetBase
    {
        public List<ResearchStudy> GetViewModel()
        {
            SetConnectToDatabase("[Study].[usp_GetResearchDashboard]");

            return LoadRecords();
        }

        private List<ResearchStudy> LoadRecords()
        {
            List<ResearchStudy> data = new List<ResearchStudy>();
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
                            int ordResearchStudyId = dr.GetOrdinal("ResearchStudyId");

                            while (dr.Read())
                            {
                                ResearchStudy item = new ResearchStudy
                                {
                                    Name = Convert.ToString(dr[ordName]),
                                    RecordId = Convert.ToInt32(dr[ordResearchStudyId])
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