using System;
using System.Data;
using System.Data.SqlClient;
using DataLayerCommon.Addresses;
using static DataLayerCommon.Enums.AddressEnums;
using static DataLayerCommon.Enums.CountryEnums;

namespace DataLayerRetrieval.Addresses
{
    public class DbAddressAssociationGet : DbGetBase
    {
        protected internal AddressAssociation GetPlaceAddress(int addressAssociationId)
        {
            IdValue = addressAssociationId;
            IdParameter = "@PlaceAddressId";

            SetConnectToDatabase("[Address].[usp_PlaceAddress_GetAddress]");

            CmdSql.Parameters.Add(IdParameter, SqlDbType.Int).Value = IdValue;

            return GetRecords();
        }

        protected internal AddressAssociation GetPersonAddress(int addressAssociationId)
        {
            IdValue = addressAssociationId;
            IdParameter = "@PersonAddressId";

            SetConnectToDatabase("[Address].[usp_PersonAddress_GetAddress]");

            CmdSql.Parameters.Add(IdParameter, SqlDbType.Int).Value = IdValue;

            return GetRecords();
        }

        private AddressAssociation GetRecords()
        {
            AddressAssociation data = new AddressAssociation();
            try
            {
                CmdSql.Parameters.Add(IdParameter, SqlDbType.Int).Value = IdValue;
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

                            int ordAddressAssociationId = dr.GetOrdinal("AddressAssociationId");

                            int ordAddressId = dr.GetOrdinal("AddressId");
                            int ordAddressType = dr.GetOrdinal("AddressType");
                            int ordPostalCodeId = dr.GetOrdinal("PostalCodeId");

                            int ordCity = dr.GetOrdinal("City");
                            int ordCountry = dr.GetOrdinal("Country");
                            int ordZipCode = dr.GetOrdinal("ZipCode");
                            int ordAddress1 = dr.GetOrdinal("Address1");
                            int ordAddress2 = dr.GetOrdinal("Address2");
                            int ordStateProvinceId = dr.GetOrdinal("StateProvinceId");

                            int ordAddressLatitude = dr.GetOrdinal("AddressLatitude");
                            int ordAddressLongitude = dr.GetOrdinal("AddressLongitude");

                            int ordPostalLatitude = dr.GetOrdinal("PostalLatitude");
                            int ordPostalLongitude = dr.GetOrdinal("PostalLongitude");

                            int ordIsActive = dr.GetOrdinal("IsActive");
                            int ordCreateDate = dr.GetOrdinal("CreateDate");

                            while (dr.Read())
                            {
                                data.AddressAssociationId = Convert.ToInt32(dr[ordAddressAssociationId]);

                                data.AddressId = Convert.ToInt32(dr[ordAddressId]);
                                data.AddressType = (AddressType) Convert.ToInt16(dr[ordAddressType]);
                                data.PostalCodeId = Convert.ToInt32(dr[ordPostalCodeId]);

                                data.City = Convert.ToString(dr[ordCity]);
                                data.ZipCode = Convert.ToString(dr[ordZipCode]);
                                data.Address1 = Convert.ToString(dr[ordAddress1]);
                                data.Address2 = Convert.ToString(dr[ordAddress2]);
                                data.Country = (Country) Convert.ToInt16(dr[ordCountry]);
                                data.StateProvinceId = Convert.ToInt32(dr[ordStateProvinceId]);

                                data.IsActive = Convert.ToBoolean(dr[ordIsActive]);
                                data.CreateDate = Convert.ToDateTime(dr[ordCreateDate]);

                                data.AddressCoordinates = new Coordinates
                                {
                                    Latitude = Convert.ToDecimal(dr[ordAddressLatitude]),
                                    Longitude = Convert.ToDecimal(dr[ordAddressLongitude])
                                };

                                data.PostalCoordinates = new Coordinates
                                {
                                    Latitude = Convert.ToDecimal(dr[ordPostalLatitude]),
                                    Longitude = Convert.ToDecimal(dr[ordPostalLongitude])
                                };
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