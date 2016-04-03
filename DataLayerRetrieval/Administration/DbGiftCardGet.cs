using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using ViewDataCommon.Administration;

namespace DataLayerRetrieval.Administration
{
    public class DbGiftCardGet : DbGetBase
    {
        public List<GiftCard> GetViewModel()
        {
            SetConnectToDatabase("[GiftCard].[usp_GetActive]");

            return LoadRecords();
        }

        private List<GiftCard> LoadRecords()
        {
            List<GiftCard> data = new List<GiftCard>();
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
                            int ordCreateDate = dr.GetOrdinal("CreateDate");
                            int ordGiftCardId = dr.GetOrdinal("GiftCardId");
                            int ordDisplayOrder = dr.GetOrdinal("DisplayOrder");

                            while (dr.Read())
                            {
                                GiftCard item = new GiftCard
                                {
                                    Name = Convert.ToString(dr[ordName]),
                                    RecordId = Convert.ToInt32(dr[ordGiftCardId]),
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