using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using CommonDataRetrieval.Research;

namespace DataLayerRetrieval.Research
{
    public class DbStudyDashboardGet : DbGetBase
    {
        public List<StudyDashboard> GetViewModel()
        {
            SetConnectToDatabase("[StudyDashboard].[usp_GetList]");

            return LoadRecords();
        }

        private List<StudyDashboard> LoadRecords()
        {
            List<StudyDashboard> data = new List<StudyDashboard>();
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
                            int ordStudyDashboardId = dr.GetOrdinal("StudyDashboardId");

                            while (dr.Read())
                            {
                                StudyDashboard item = new StudyDashboard
                                {
                                    Name = Convert.ToString(dr[ordName]),
                                    RecordId = Convert.ToInt32(dr[ordStudyDashboardId]),
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