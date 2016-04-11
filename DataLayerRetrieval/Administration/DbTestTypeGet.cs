using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using CommonDataRetrieval.Administration;

namespace DataLayerRetrieval.Administration
{
    public class DbTestTypeGet : DbGetBase
    {
        public List<TestType> GetViewModel()
        {
            SetConnectToDatabase("[TestType].[usp_GetActive]");

            return LoadRecords();
        }

        private List<TestType> LoadRecords()
        {
            List<TestType> data = new List<TestType>();
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
                            int ordTestTypeId = dr.GetOrdinal("TestTypeId");

                            while (dr.Read())
                            {
                                TestType item = new TestType
                                {
                                    Name = Convert.ToString(dr[ordName]),
                                    Radius = Convert.ToInt32(dr[ordRadius]),
                                    IsSystem = Convert.ToBoolean(dr[ordIsSystem]),
                                    IsSystemSort = Convert.ToString(dr[ordIsSystem]),
                                    RecordId = Convert.ToInt32(dr[ordTestTypeId]),
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