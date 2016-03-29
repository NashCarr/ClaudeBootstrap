using System;
using System.Data;
using System.Data.SqlClient;
using ClaudeData.Models.Places;
using static ClaudeCommon.Enums.PlaceEnums;
using static ClaudeCommon.Enums.TimeZoneEnums;

namespace ClaudeData.DataRepository.PlaceRepository
{
    public class DbPlaceGet : DbGetBase
    {
        protected internal Place GetFacility(int placeId)
        {
            return LoadRecord(placeId, PlaceType.Facility);
        }

        protected internal Place GetCustomer(int placeId)
        {
            return LoadRecord(placeId, PlaceType.Customer);
        }

        protected internal Place GetOrganization(int placeId)
        {
            return LoadRecord(placeId, PlaceType.Organization);
        }

        private Place LoadRecord(int placeId, PlaceType placeType)
        {
            Place data = new Place();
            try
            {
                IdValue = placeId;
                IdParameter = "@PlaceId";

                SetConnectToDatabase("[Place].[usp_GetPlace]");

                CmdSql.Parameters.Add(IdParameter, SqlDbType.Int).Value = IdValue;
                CmdSql.Parameters.Add("@PlaceType", SqlDbType.TinyInt).Value = placeType;

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
                            int ordDivision = dr.GetOrdinal("Division");
                            int ordDepartment = dr.GetOrdinal("Department");

                            int ordIsActive = dr.GetOrdinal("IsActive");
                            int ordTimeZone = dr.GetOrdinal("TimeZone");
                            int ordCreateDate = dr.GetOrdinal("CreateDate");
                            int ordDisplayOrder = dr.GetOrdinal("DisplayOrder");

                            //Place
                            while (dr.Read())
                            {
                                data.Name = Convert.ToString(dr[ordName]);
                                data.PlaceId = Convert.ToInt32(dr[ordPlaceId]);
                                data.Division = Convert.ToString(dr[ordDivision]);
                                data.Department = Convert.ToString(dr[ordDepartment]);

                                data.IsActive = Convert.ToBoolean(dr[ordIsActive]);
                                data.CreateDate = Convert.ToDateTime(dr[ordCreateDate]);
                                data.DisplayOrder = Convert.ToByte(dr[ordDisplayOrder]);
                                data.TimeZone = (ClaudeTimeZone) Convert.ToByte(dr[ordTimeZone]);
                            }
                        }
                    }
                    ConnSql.Close();
                }
                data.PlaceType = placeType;
            }
            catch (Exception ex)
            {
                DocumentErrorMessage(ex.ToString());
            }
            return data;
        }
    }
}