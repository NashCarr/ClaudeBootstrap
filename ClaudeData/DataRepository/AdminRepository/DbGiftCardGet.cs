using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using ClaudeData.Models.Admin;

namespace ClaudeData.DataRepository.AdminRepository
{
    public class DbGiftCardGet : DbGetBase
    {
        public List<GiftCard> GetActiveRecords()
        {
            SetConnectToDatabase("[Admin].[usp_GiftCard_GetActive]");

            return LoadRecords();
        }

        public List<GiftCard> GetInactiveRecords()
        {
            SetConnectToDatabase("[Admin].[usp_GiftCard_GetInactive]");

            return LoadRecords();
        }

        public GiftCard GetRecord(int recordId)
        {
            return GetRecords(recordId, string.Empty).SingleOrDefault();
        }

        public List<GiftCard> GetRecords()
        {
            return GetRecords(0, string.Empty);
        }

        private List<GiftCard> GetRecords(int giftCardId, string name)
        {
            try
            {
                SetConnectToDatabase("[Admin].[usp_GiftCard_Get]");

                CmdSql.Parameters.Add("@GiftCardId", SqlDbType.Int).Value = giftCardId;
                CmdSql.Parameters.Add("@Name", SqlDbType.NVarChar, 50).Value = name?.Trim() ?? string.Empty;

                return LoadRecords();
            }
            catch (Exception ex)
            {
                DocumentErrorMessage(ex.ToString());
                return new List<GiftCard>();
            }
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

                            int ordGiftCardId = dr.GetOrdinal("GiftCardId");
                            int ordName = dr.GetOrdinal("Name");
                            int ordDisplayOrder = dr.GetOrdinal("DisplayOrder");
                            int ordCreateDate = dr.GetOrdinal("CreateDate");
                            int ordIsActive = dr.GetOrdinal("IsActive");

                            while (dr.Read())
                            {
                                GiftCard item = new GiftCard
                                {
                                    RecordId = Convert.ToInt32(dr[ordGiftCardId]),
                                    Name = Convert.ToString(dr[ordName]),
                                    DisplayOrder = Convert.ToInt16(dr[ordDisplayOrder]),
                                    CreateDate = Convert.ToDateTime(dr[ordCreateDate]),
                                    IsActive = Convert.ToBoolean(dr[ordIsActive])
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