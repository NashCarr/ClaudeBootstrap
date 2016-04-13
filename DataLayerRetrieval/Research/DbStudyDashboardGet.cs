using System;
using System.Data.SqlClient;
using CommonDataRetrieval.Research;

namespace DataLayerRetrieval.Research
{
    public class DbStudyDashboardGet : DbGetBase
    {
        public StudyDashboard GetViewModel()
        {
            SetConnectToDatabase("[Study].[usp_GetDashboard]");

            return LoadRecords();
        }

        private StudyDashboard LoadRecords()
        {
            StudyDashboard data = new StudyDashboard();
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
                                data.Name = Convert.ToString(dr[ordName]);
                                data.RecordId = Convert.ToInt32(dr[ordStudyDashboardId]);
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