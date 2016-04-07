﻿using System;
using System.Data;
using System.Data.SqlClient;
using static CommonData.Enums.PlaceEnums;
using static CommonData.Enums.TimeZoneEnums;

namespace DataLayerRetrieval.Place
{
    public class DbPlaceGet : DbGetBase
    {
        protected internal DataLayerCommon.Places.PlaceBase GetFacility(int placeId)
        {
            return LoadRecord(placeId, PlaceType.Facility);
        }

        protected internal DataLayerCommon.Places.PlaceBase GetCustomer(int placeId)
        {
            return LoadRecord(placeId, PlaceType.Customer);
        }

        protected internal DataLayerCommon.Places.PlaceBase GetOrganization(int placeId)
        {
            return LoadRecord(placeId, PlaceType.Organization);
        }

        private DataLayerCommon.Places.PlaceBase LoadRecord(int placeId, PlaceType placeType)
        {
            DataLayerCommon.Places.PlaceBase data = new DataLayerCommon.Places.PlaceBase();
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

                            int ordTimeZone = dr.GetOrdinal("TimeZone");
                            int ordDisplayOrder = dr.GetOrdinal("DisplayOrder");

                            //Place
                            while (dr.Read())
                            {
                                data.Name = Convert.ToString(dr[ordName]);
                                data.PlaceId = Convert.ToInt32(dr[ordPlaceId]);
                                data.Division = Convert.ToString(dr[ordDivision]);
                                data.Department = Convert.ToString(dr[ordDepartment]);

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