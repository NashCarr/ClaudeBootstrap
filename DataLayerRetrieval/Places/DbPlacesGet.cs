using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using CommonData.Enums;
using CommonData.Models.Places;

namespace DataLayerRetrieval.Places
{
    public class DbPlacesGet : DbGetBase
    {
        protected internal string TypeName;

        protected internal List<PlaceList> GetRecords()
        {
            List<PlaceList> data = new List<PlaceList>();
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
                            int ordCountry = dr.GetOrdinal("Country");
                            int ordTimeZone = dr.GetOrdinal("TimeZone");
                            int ordDivision = dr.GetOrdinal("Division");
                            int ordDepartment = dr.GetOrdinal("Department");
                            int ordDisplayOrder = dr.GetOrdinal("DisplayOrder");

                            while (dr.Read())
                            {
                                PlaceList item = new PlaceList
                                {
                                    Name = Convert.ToString(dr[ordName]),
                                    PlaceId = Convert.ToInt32(dr[ordPlaceId]),
                                    Division = Convert.ToString(dr[ordDivision]),
                                    Department = Convert.ToString(dr[ordDepartment]),
                                    DisplayOrder = Convert.ToInt16(dr[ordDisplayOrder]),
                                    Country = (CountryEnums.Country) Convert.ToInt16(dr[ordCountry]),
                                    TimeZone = (TimeZoneEnums.ClaudeTimeZone) Convert.ToByte(dr[ordTimeZone])
                                };
                                item.DisplaySort = item.DisplayOrder.ToString("D3");
                                item.CountryName = Enum.GetName(typeof (CountryEnums.Country), item.Country);
                                item.TimeZoneName = Enum.GetName(typeof (TimeZoneEnums.ClaudeTimeZone), item.TimeZone);
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