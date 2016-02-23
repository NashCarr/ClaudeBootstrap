using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using ClaudeCommon.Models;
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
                            int ordDivision = dr.GetOrdinal("Division");
                            int ordDepartment = dr.GetOrdinal("Department");
                            int ordDisplayOrder = dr.GetOrdinal("DisplayOrder");

                            while (dr.Read())
                            {
                                Place item = new Place
                                {
                                    Name = Convert.ToString(dr[ordName]),
                                    PlaceId = Convert.ToInt32(dr[ordPlaceId]),
                                    Division = Convert.ToString(dr[ordDivision]),
                                    Department = Convert.ToString(dr[ordDepartment]),
                                    DisplayOrder = Convert.ToInt16(dr[ordDisplayOrder]),
                                    TimeZone = (ClaudeTimeZone) Convert.ToByte(dr[ordTimeZone])
                                };
                                item.TimeZoneName = Enum.GetName(typeof (ClaudeTimeZone), item.TimeZone);
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