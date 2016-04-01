using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using CommonData.Models.Administration;

namespace DataRetrieval.Administration
{
    public class DbStudyDesignGet : DbGetBase
    {
        public List<StudyDesign> GetViewModel()
        {
            SetConnectToDatabase("[StudyDesign].[usp_GetActive]");

            return LoadRecords();
        }

        private List<StudyDesign> LoadRecords()
        {
            List<StudyDesign> data = new List<StudyDesign>();
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
                            int ordRadius = dr.GetOrdinal("Radius");
                            int ordIsSystem = dr.GetOrdinal("IsSystem");
                            int ordLastUpdate = dr.GetOrdinal("LastUpdate");
                            int ordDisplayOrder = dr.GetOrdinal("DisplayOrder");
                            int ordStudyDesignId = dr.GetOrdinal("StudyDesignId");

                            while (dr.Read())
                            {
                                StudyDesign item = new StudyDesign
                                {
                                    Name = Convert.ToString(dr[ordName]),
                                    Radius = Convert.ToInt32(dr[ordRadius]),
                                    IsSystem = Convert.ToBoolean(dr[ordIsSystem]),
                                    IsSystemSort = Convert.ToString(dr[ordIsSystem]),
                                    RecordId = Convert.ToInt32(dr[ordStudyDesignId]),
                                    DisplayOrder = Convert.ToInt16(dr[ordDisplayOrder]),
                                    StringLastUpdate =
                                        Convert.ToDateTime(dr[ordLastUpdate]).ToString("MM/dd/yyyy hh:mm:ss tt")
                                };
                                item.RadiusSort = item.Radius.ToString("D5");
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