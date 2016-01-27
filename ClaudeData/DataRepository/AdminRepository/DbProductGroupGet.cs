using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using ClaudeData.Models.Admin;

namespace ClaudeData.DataRepository.AdminRepository
{
    public class DbProductGroupGet : DbGetBase
    {
        public List<ProductGroup> GetActiveRecords()
        {
            SetConnectToDatabase("[Admin].[usp_ProductGroup_GetActive]");

            return LoadRecords();
        }

        public List<ProductGroup> GetInactiveRecords()
        {
            SetConnectToDatabase("[Admin].[usp_ProductGroup_GetInactive]");

            return LoadRecords();
        }

        public ProductGroup GetRecord(int recordId)
        {
            return GetRecords(recordId, string.Empty).SingleOrDefault();
        }

        public List<ProductGroup> GetRecords()
        {
            return GetRecords(0, string.Empty);
        }

        private List<ProductGroup> GetRecords(int productGroupId, string name)
        {
            try
            {
                SetConnectToDatabase("[Admin].[usp_ProductGroup_Get]");

                CmdSql.Parameters.Add("@ProductGroupId", SqlDbType.Int).Value = productGroupId;
                CmdSql.Parameters.Add("@Name", SqlDbType.NVarChar, 50).Value = name?.Trim() ?? string.Empty;

                return LoadRecords();
            }
            catch (Exception ex)
            {
                DocumentErrorMessage(ex.ToString());
                return new List<ProductGroup>();
            }
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
                            int ordIsActive = dr.GetOrdinal("IsActive");
                            int ordCreateDate = dr.GetOrdinal("CreateDate");
                            int ordDisplayOrder = dr.GetOrdinal("DisplayOrder");
                            int ordProductGroupId = dr.GetOrdinal("ProductGroupId");

                            while (dr.Read())
                            {
                                ProductGroup item = new ProductGroup
                                {
                                    Name = Convert.ToString(dr[ordName]),
                                    IsActive = Convert.ToBoolean(dr[ordIsActive]),
                                    IsSystem = Convert.ToBoolean(dr[ordIsSystem]),
                                    RecordId = Convert.ToInt32(dr[ordProductGroupId]),
                                    CreateDate = Convert.ToDateTime(dr[ordCreateDate]),
                                    DisplayOrder = Convert.ToInt16(dr[ordDisplayOrder])
                                };
                                data.Add(item);
                            }
                            data.Sort((x, y) => x.DisplayOrder.CompareTo(y.DisplayOrder));
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