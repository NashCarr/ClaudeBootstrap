using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using CommonDataRetrieval.Facility;
using static CommonData.Enums.CountryEnums;
using static CommonData.Enums.TimeZoneEnums;

namespace DataLayerRetrieval.Facility
{
    public class DbFacilityGetList : DbGetBase
    {
        public List<FacilityList> GetList()
        {
            try
            {
                SetConnectToDatabase("[Facility].[usp_GetList]");

                return GetRecords();
            }
            catch (Exception ex)
            {
                DocumentErrorMessage(ex.ToString());
                return new List<FacilityList>();
            }
        }

        private static List<FacilityList> GetRecords()
        {
            List<FacilityList> data = new List<FacilityList>();
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

                            int ordCity = dr.GetOrdinal("City");
                            int ordName = dr.GetOrdinal("Name");
                            int ordRadius = dr.GetOrdinal("Radius");
                            int ordPlaceId = dr.GetOrdinal("PlaceId");
                            int ordCountry = dr.GetOrdinal("Country");
                            int ordZipCode = dr.GetOrdinal("ZipCode");
                            int ordAddress = dr.GetOrdinal("Address");
                            int ordTimeZone = dr.GetOrdinal("TimeZone");
                            int ordDivision = dr.GetOrdinal("Division");
                            int ordDepartment = dr.GetOrdinal("Department");
                            int ordPrimaryPhone = dr.GetOrdinal("PrimaryPhone");
                            int ordDisplayOrder = dr.GetOrdinal("DisplayOrder");
                            int ordStateProvince = dr.GetOrdinal("StateProvince");

                            while (dr.Read())
                            {
                                FacilityList item = new FacilityList
                                {
                                    City = Convert.ToString(dr[ordCity]),
                                    Name = Convert.ToString(dr[ordName]),
                                    Radius = Convert.ToInt16(dr[ordRadius]),
                                    PlaceId = Convert.ToInt32(dr[ordPlaceId]),
                                    Address = Convert.ToString(dr[ordAddress]),
                                    ZipCode = Convert.ToString(dr[ordZipCode]),
                                    Division = Convert.ToString(dr[ordDivision]),
                                    Department = Convert.ToString(dr[ordDepartment]),
                                    DisplayOrder = Convert.ToInt16(dr[ordDisplayOrder]),
                                    PrimaryPhone = Convert.ToInt64(dr[ordPrimaryPhone]),
                                    Country = (Country) Convert.ToInt16(dr[ordCountry]),
                                    StateProvince = Convert.ToString(dr[ordStateProvince]),
                                    TimeZone = (ClaudeTimeZone) Convert.ToByte(dr[ordTimeZone])
                                };
                                item.DisplaySort = item.DisplayOrder.ToString("D3");
                                item.CountryName = Enum.GetName(typeof (Country), item.Country);
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