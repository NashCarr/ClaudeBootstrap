using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using ClaudeData.Models.Addresses;
using ClaudeData.Models.Phones;
using ClaudeData.Models.Places;
using static ClaudeCommon.Enums.AddressEnums;
using static ClaudeCommon.Enums.CountryEnums;
using static ClaudeCommon.Enums.PhoneEnums;
using static ClaudeCommon.Enums.PlaceEnums;
using static ClaudeCommon.Enums.TimeZoneEnums;

namespace ClaudeData.DataRepository.PlaceRepository
{
    public class DbPlaceDataGet : DbGetBase
    {
        protected internal PlaceData GetFacilityData(int placeId)
        {
            return LoadRecords(placeId, PlaceType.Facility);
        }

        protected internal PlaceData GetCustomerData(int placeId)
        {
            return LoadRecords(placeId, PlaceType.Customer);
        }

        protected internal PlaceData GetOrganizationData(int placeId)
        {
            return LoadRecords(placeId, PlaceType.Organization);
        }

        private PlaceData LoadRecords(int placeId, PlaceType placeType)
        {
            PlaceData data = new PlaceData();
            try
            {
                data.Place = new Place();
                data.PhoneData = new PhoneData {Phones = new List<PhoneAssociation>()};
                data.AddressData = new AddressData {Addresses = new List<AddressAssociation>()};

                IdValue = placeId;
                IdParameter = "@PlaceId";

                SetConnectToDatabase("[Admin].[usp_Place_GetPlaceData]");

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
                                data.Place.Name = Convert.ToString(dr[ordName]);
                                data.Place.PlaceId = Convert.ToInt32(dr[ordPlaceId]);
                                data.Place.Division = Convert.ToString(dr[ordDivision]);
                                data.Place.Department = Convert.ToString(dr[ordDepartment]);

                                data.Place.IsActive = Convert.ToBoolean(dr[ordIsActive]);
                                data.Place.TimeZone = (ClaudeTimeZone)Convert.ToByte(dr[ordTimeZone]);
                                data.Place.CreateDate = Convert.ToDateTime(dr[ordCreateDate]);
                                data.Place.DisplayOrder = Convert.ToByte(dr[ordDisplayOrder]);
                            }

                            //Addresses
                            dr.NextResult();

                            if (dr.HasRows)
                            {
                                int ordAddressAssociationId = dr.GetOrdinal("AddressAssociationId");

                                int ordAddressId = dr.GetOrdinal("AddressId");
                                int ordAddressType = dr.GetOrdinal("AddressType");
                                int ordPostalCodeId = dr.GetOrdinal("PostalCodeId");

                                int ordCity = dr.GetOrdinal("City");
                                int ordCountry = dr.GetOrdinal("Country");
                                int ordZipCode = dr.GetOrdinal("ZipCode");
                                int ordAddress1 = dr.GetOrdinal("Address1");
                                int ordAddress2 = dr.GetOrdinal("Address2");
                                int ordStateProvince = dr.GetOrdinal("StateProvince");

                                int ordAddressLatitude = dr.GetOrdinal("AddressLatitude");
                                int ordAddressLongitude = dr.GetOrdinal("AddressLongitude");

                                int ordPostalLatitude = dr.GetOrdinal("PostalLatitude");
                                int ordPostalLongitude = dr.GetOrdinal("PostalLongitude");

                                ordIsActive = dr.GetOrdinal("IsActive");
                                ordCreateDate = dr.GetOrdinal("CreateDate");

                                while (dr.Read())
                                {
                                    AddressAssociation item = new AddressAssociation
                                    {
                                        AddressAssociationId = Convert.ToInt32(dr[ordAddressAssociationId]),
                                        AddressId = Convert.ToInt32(dr[ordAddressId]),
                                        AddressType = (AddressType) Convert.ToInt16(dr[ordAddressType]),
                                        PostalCodeId = Convert.ToInt32(dr[ordPostalCodeId]),
                                        City = Convert.ToString(dr[ordCity]),
                                        Country = (Country) Convert.ToInt16(dr[ordCountry]),
                                        ZipCode = Convert.ToString(dr[ordZipCode]),
                                        Address1 = Convert.ToString(dr[ordAddress1]),
                                        Address2 = Convert.ToString(dr[ordAddress2]),
                                        StateProvince = Convert.ToString(dr[ordStateProvince]),
                                        IsActive = Convert.ToBoolean(dr[ordIsActive]),
                                        CreateDate = Convert.ToDateTime(dr[ordCreateDate]),
                                        AddressCoordinates = new Coordinates
                                        {
                                            Latitude = Convert.ToDecimal(dr[ordAddressLatitude]),
                                            Longitude = Convert.ToDecimal(dr[ordAddressLongitude])
                                        },
                                        PostalCoordinates = new Coordinates
                                        {
                                            Latitude = Convert.ToDecimal(dr[ordPostalLatitude]),
                                            Longitude = Convert.ToDecimal(dr[ordPostalLongitude])
                                        }
                                    };
                                    data.AddressData.Addresses.Add(item);
                                }
                            }

                            //Phones
                            dr.NextResult();

                            if (dr.HasRows)
                            {
                                int ordPhoneAssociationId = dr.GetOrdinal("PhoneAssociationId");
                                int ordPhoneId = dr.GetOrdinal("PhoneId");
                                int ordPhoneNumber = dr.GetOrdinal("PhoneNumber");
                                int ordCountry = dr.GetOrdinal("Country");
                                int ordPhoneType = dr.GetOrdinal("PhoneType");

                                ordIsActive = dr.GetOrdinal("IsActive");
                                ordCreateDate = dr.GetOrdinal("CreateDate");

                                while (dr.Read())
                                {
                                    PhoneAssociation item = new PhoneAssociation
                                    {
                                        PhoneAssociationId = Convert.ToInt32(dr[ordPhoneAssociationId]),
                                        PhoneId = Convert.ToInt32(dr[ordPhoneId]),
                                        PhoneNumber = Convert.ToInt64(dr[ordPhoneNumber]),
                                        Country = (Country) Convert.ToInt16(dr[ordCountry]),
                                        PhoneType = (PhoneType) Convert.ToInt16(dr[ordPhoneType]),
                                        IsActive = Convert.ToBoolean(dr[ordIsActive]),
                                        CreateDate = Convert.ToDateTime(dr[ordCreateDate])
                                    };
                                    data.PhoneData.Phones.Add(item);
                                }
                            }

                            //PhoneSetting
                            dr.NextResult();

                            if (dr.HasRows)
                            {
                                int ordAllowText = dr.GetOrdinal("AllowText");
                                int ordPhoneSettingId = dr.GetOrdinal("PhoneSettingId");
                                int ordMobileCarrierId = dr.GetOrdinal("MobileCarrierId");
                                int ordPrimaryPhoneType = dr.GetOrdinal("PrimaryPhoneType");

                                while (dr.Read())
                                {
                                    data.PhoneData.PhoneSettings.AllowText = Convert.ToBoolean(dr[ordAllowText]);
                                    data.PhoneData.PhoneSettings.RecordId = Convert.ToInt32(dr[ordPhoneSettingId]);
                                    data.PhoneData.PhoneSettings.MobileCarrier = Convert.ToInt16(dr[ordMobileCarrierId]);
                                    data.PhoneData.PhoneSettings.PrimaryPhoneType =
                                        (PhoneType) Convert.ToInt16(dr[ordPrimaryPhoneType]);
                                }
                            }
                        }
                    }
                    ConnSql.Close();
                }
                data.Place.PlaceType = placeType;
                data.Place.PlaceTypeName = Enum.GetName(typeof (PlaceType), placeType);
            }
            catch (Exception ex)
            {
                DocumentErrorMessage(ex.ToString());
            }
            return data;
        }
    }
}