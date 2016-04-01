using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using CommonData.Models.Administration;

namespace DataRetrieval.Administration
{
    public class DbProductGroupGet : DbGetBase
    {
        public List<ProductGroup> GetViewModel()
        {
            SetConnectToDatabase("[ProductGroup].[usp_GetActive]");

            return LoadRecords();
        }

        private List<ProductGroup> LoadRecords()
        {
            List<ProductGroup> data = new List<ProductGroup>();
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
                            int ordProductGroupId = dr.GetOrdinal("ProductGroupId");

                            while (dr.Read())
                            {
                                ProductGroup item = new ProductGroup
                                {
                                    Name = Convert.ToString(dr[ordName]),
                                    IsSystem = Convert.ToBoolean(dr[ordIsSystem]),
                                    IsSystemSort = Convert.ToString(dr[ordIsSystem]),
                                    RecordId = Convert.ToInt32(dr[ordProductGroupId]),
                                    DisplayOrder = Convert.ToInt16(dr[ordDisplayOrder]),
                                    StringLastUpdate =
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