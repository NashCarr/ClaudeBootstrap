using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using ClaudeCommon.Enums;
using ClaudeCommon.Models;
using ClaudeData.Models.Addresses;
using ClaudeData.Models.Phones;
using ClaudeData.Models.Places;

namespace ClaudeData.DataRepository.SettingsRepository
{
    public class DbSiteConfigurationGet : DbGetBase
    {
        protected internal PlaceData GetFacilityData(int placeId)
        {
            return LoadRecords(placeId, PlaceEnums.PlaceType.Facility);
        }

        protected internal PlaceData GetCustomerData(int placeId)
        {
            return LoadRecords(placeId, PlaceEnums.PlaceType.Customer);
        }

        protected internal PlaceData GetOrganizationData(int placeId)
        {
            return LoadRecords(placeId, PlaceEnums.PlaceType.Organization);
        }

        private PlaceData LoadRecords(int placeId, PlaceEnums.PlaceType placeType)
        {
            PlaceData data = new PlaceData();
            try
            {
                data.Place = new Place();
                data.Contacts = new List<Contact>();
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

                            int ordCountry = dr.GetOrdinal("Country");
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
                                data.Place.CreateDate = Convert.ToDateTime(dr[ordCreateDate]);
                                data.Place.DisplayOrder = Convert.ToByte(dr[ordDisplayOrder]);
                                data.Place.Country = (CountryEnums.Country) Convert.ToInt16(dr[ordCountry]);
                                data.Place.TimeZone = (TimeZoneEnums.ClaudeTimeZone) Convert.ToByte(dr[ordTimeZone]);
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
                                int ordZipCode = dr.GetOrdinal("ZipCode");
                                int ordAddress1 = dr.GetOrdinal("Address1");
                                int ordAddress2 = dr.GetOrdinal("Address2");
                                int ordStateProvinceId = dr.GetOrdinal("StateProvinceId");

                                int ordAddressLatitude = dr.GetOrdinal("AddressLatitude");
                                int ordAddressLongitude = dr.GetOrdinal("AddressLongitude");

                                int ordPostalLatitude = dr.GetOrdinal("PostalLatitude");
                                int ordPostalLongitude = dr.GetOrdinal("PostalLongitude");

                                ordCountry = dr.GetOrdinal("Country");
                                ordIsActive = dr.GetOrdinal("IsActive");
                                ordCreateDate = dr.GetOrdinal("CreateDate");

                                while (dr.Read())
                                {
                                    AddressAssociation item = new AddressAssociation
                                    {
                                        AddressAssociationId = Convert.ToInt32(dr[ordAddressAssociationId]),
                                        AddressId = Convert.ToInt32(dr[ordAddressId]),
                                        AddressType = (AddressEnums.AddressType) Convert.ToInt16(dr[ordAddressType]),
                                        PostalCodeId = Convert.ToInt32(dr[ordPostalCodeId]),
                                        City = Convert.ToString(dr[ordCity]),
                                        Country = (CountryEnums.Country) Convert.ToInt16(dr[ordCountry]),
                                        ZipCode = Convert.ToString(dr[ordZipCode]),
                                        Address1 = Convert.ToString(dr[ordAddress1]),
                                        Address2 = Convert.ToString(dr[ordAddress2]),
                                        StateProvinceId = Convert.ToInt32(dr[ordStateProvinceId]),
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
                                int ordPhoneId = dr.GetOrdinal("PhoneId");
                                int ordPhoneType = dr.GetOrdinal("PhoneType");
                                int ordPhoneNumber = dr.GetOrdinal("PhoneNumber");
                                int ordPhoneAssociationId = dr.GetOrdinal("PhoneAssociationId");

                                ordCountry = dr.GetOrdinal("Country");
                                ordIsActive = dr.GetOrdinal("IsActive");
                                ordCreateDate = dr.GetOrdinal("CreateDate");

                                while (dr.Read())
                                {
                                    PhoneAssociation item = new PhoneAssociation
                                    {
                                        PhoneId = Convert.ToInt32(dr[ordPhoneId]),
                                        IsActive = Convert.ToBoolean(dr[ordIsActive]),
                                        PhoneNumber = Convert.ToInt64(dr[ordPhoneNumber]),
                                        CreateDate = Convert.ToDateTime(dr[ordCreateDate]),
                                        Country = (CountryEnums.Country) Convert.ToInt16(dr[ordCountry]),
                                        PhoneType = (PhoneEnums.PhoneType) Convert.ToInt16(dr[ordPhoneType]),
                                        PhoneAssociationId = Convert.ToInt32(dr[ordPhoneAssociationId])
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
                                        (PhoneEnums.PhoneType) Convert.ToInt16(dr[ordPrimaryPhoneType]);
                                }
                            }

                            //Contacts
                            dr.NextResult();

                            if (dr.HasRows)
                            {
                                ordPlaceId = dr.GetOrdinal("PlaceId");
                                int ordEmail = dr.GetOrdinal("Email");
                                int ordPersonId = dr.GetOrdinal("PersonId");
                                int ordLastName = dr.GetOrdinal("LastName");
                                int ordFirstName = dr.GetOrdinal("FirstName");
                                int ordMiddleName = dr.GetOrdinal("MiddleName");

                                while (dr.Read())
                                {
                                    Contact item = new Contact
                                    {
                                        PersonType = 0,
                                        Email = Convert.ToString(dr[ordEmail]),
                                        PlaceId = Convert.ToInt32(dr[ordPlaceId]),
                                        PersonId = Convert.ToInt32(dr[ordPersonId]),
                                        LastName = Convert.ToString(dr[ordLastName]),
                                        FirstName = Convert.ToString(dr[ordFirstName]),
                                        MiddleName = Convert.ToString(dr[ordMiddleName])
                                    };
                                    data.Contacts.Add(item);
                                }
                            }
                        }
                    }
                    ConnSql.Close();
                }
                data.Place.PlaceType = placeType;
            }
            catch (Exception ex)
            {
                DocumentErrorMessage(ex.ToString());
            }
            return data;
        }
    }
}