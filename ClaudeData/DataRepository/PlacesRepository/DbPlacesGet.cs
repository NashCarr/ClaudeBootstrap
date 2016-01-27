using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using ClaudeData.Models.Places;
using static ClaudeCommon.Enums.TimeZoneEnums;

namespace ClaudeData.DataRepository.PlacesRepository
{
    public class DbPlacesGet : DbGetBase
    {
        protected internal string TypeName;

        protected internal List<Place> GetRecords()
        {
            List<Place> data = new List<Place>();
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
                            int ordPlaceId = dr.GetOrdinal("PlaceId");
                            int ordTimeZone = dr.GetOrdinal("TimeZone");
                            int ordIsActive = dr.GetOrdinal("IsActive");
                            int ordDisplayOrder = dr.GetOrdinal("DisplayOrder");
                            int ordCreateDate = dr.GetOrdinal("CreateDate");

                            while (dr.Read())
                            {
                                Place item = new Place
                                {
                                    Name = Convert.ToString(dr[ordName]),
                                    PlaceId = Convert.ToInt32(dr[ordPlaceId]),
                                    TimeZone = (ClaudeTimeZone) Convert.ToByte(dr[ordTimeZone]),
                                    IsActive = Convert.ToBoolean(dr[ordIsActive]),
                                    CreateDate = Convert.ToDateTime(dr[ordCreateDate]),
                                    DisplayOrder = Convert.ToInt16(dr[ordDisplayOrder])
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