using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using CommonDataRetrieval.Administration;

namespace DataLayerRetrieval.Administration
{
    public class DbBudgetCategoryGet : DbGetBase
    {
        public List<BudgetCategory> GetViewModel()
        {
            SetConnectToDatabase("[BudgetCategory].[usp_GetActive]");

            return LoadRecords();
        }

        private List<BudgetCategory> LoadRecords()
        {
            List<BudgetCategory> data = new List<BudgetCategory>();
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
                            int ordLastUpdate = dr.GetOrdinal("LastUpdate");
                            int ordDisplayOrder = dr.GetOrdinal("DisplayOrder");
                            int ordBudgetCategoryId = dr.GetOrdinal("BudgetCategoryId");

                            while (dr.Read())
                            {
                                BudgetCategory item = new BudgetCategory
                                {
                                    Name = Convert.ToString(dr[ordName]),
                                    RecordId = Convert.ToInt32(dr[ordBudgetCategoryId]),
                                    DisplayOrder = Convert.ToInt16(dr[ordDisplayOrder]),
                                    StringLastUpdate =
                                        Convert.ToDateTime(dr[ordLastUpdate]).ToString("MM/dd/yyyy hh:mm:ss tt")
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