﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using DataLayerCommon.Addresses;
using DataLayerCommon.People;
using DataLayerCommon.Phones;
using static CommonData.Enums.AddressEnums;
using static CommonData.Enums.CountryEnums;
using static CommonData.Enums.PersonEnums;
using static CommonData.Enums.PhoneEnums;

namespace DataLayerRetrieval.Person
{
    public class DbPersonDataGet : DbGetBase
    {
        protected internal PersonData GetStaffMember(int personId)
        {
            return LoadRecords(personId, (byte) PersonType.StaffMember);
        }

        protected internal PersonData GetAssessor(int personId)
        {
            return LoadRecords(personId, (byte) PersonType.Assessor);
        }

        protected internal PersonData GetCustomerContact(int personId)
        {
            return LoadRecords(personId, (byte) PersonType.CustomerContact);
        }

        protected internal PersonData GetOrganizationContact(int personId)
        {
            return LoadRecords(personId, (byte) PersonType.OrganizationContact);
        }

        private PersonData LoadRecords(int personId, byte personType)
        {
            PersonData data = new PersonData();
            try
            {
                data.Person = new PersonBase();
                data.PhoneData = new PhoneData {Phones = new List<PhoneAssociation>()};
                data.AddressData = new AddressData {Addresses = new List<AddressAssociation>()};

                IdValue = personId;
                IdParameter = "@PersonId";

                SetConnectToDatabase("[Person].[usp_GetPersonData]");

                CmdSql.Parameters.Add(IdParameter, SqlDbType.Int).Value = IdValue;
                CmdSql.Parameters.Add("@PersonType", SqlDbType.TinyInt).Value = personType;

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

                            int ordEmail = dr.GetOrdinal("Email");
                            int ordPlaceId = dr.GetOrdinal("PlaceId");
                            int ordPersonId = dr.GetOrdinal("PersonId");
                            int ordLastName = dr.GetOrdinal("LastName");
                            int ordFirstName = dr.GetOrdinal("FirstName");
                            int ordMiddleName = dr.GetOrdinal("MiddleName");

                            //Person
                            while (dr.Read())
                            {
                                data.Person.Email = Convert.ToString(dr[ordEmail]);
                                data.Person.PlaceId = Convert.ToInt32(dr[ordPlaceId]);
                                data.Person.PersonId = Convert.ToInt32(dr[ordPersonId]);
                                data.Person.LastName = Convert.ToString(dr[ordLastName]);
                                data.Person.FirstName = Convert.ToString(dr[ordFirstName]);
                                data.Person.MiddleName = Convert.ToString(dr[ordMiddleName]);
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
                                int ordStateProvinceId = dr.GetOrdinal("StateProvinceId");

                                int ordAddressLatitude = dr.GetOrdinal("AddressLatitude");
                                int ordAddressLongitude = dr.GetOrdinal("AddressLongitude");

                                int ordPostalLatitude = dr.GetOrdinal("PostalLatitude");
                                int ordPostalLongitude = dr.GetOrdinal("PostalLongitude");

                                while (dr.Read())
                                {
                                    AddressAssociation item = new AddressAssociation
                                    {
                                        City = Convert.ToString(dr[ordCity]),
                                        Country = (Country) Convert.ToInt16(dr[ordCountry]),
                                        ZipCode = Convert.ToString(dr[ordZipCode]),
                                        Address1 = Convert.ToString(dr[ordAddress1]),
                                        Address2 = Convert.ToString(dr[ordAddress2]),
                                        AddressId = Convert.ToInt32(dr[ordAddressId]),
                                        AddressType = (AddressType) Convert.ToInt16(dr[ordAddressType]),
                                        PostalCodeId = Convert.ToInt32(dr[ordPostalCodeId]),
                                        StateProvinceId = Convert.ToInt32(dr[ordStateProvinceId]),
                                        AddressAssociationId = Convert.ToInt32(dr[ordAddressAssociationId]),
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
                                int ordCountry = dr.GetOrdinal("Country");
                                int ordPhoneId = dr.GetOrdinal("PhoneId");
                                int ordPhoneType = dr.GetOrdinal("PhoneType");
                                int ordPhoneNumber = dr.GetOrdinal("PhoneNumber");
                                int ordPhoneAssociationId = dr.GetOrdinal("PhoneAssociationId");

                                while (dr.Read())
                                {
                                    PhoneAssociation item = new PhoneAssociation
                                    {
                                        Country = (Country) Convert.ToInt16(dr[ordCountry]),
                                        PhoneId = Convert.ToInt32(dr[ordPhoneId]),
                                        PhoneType = (PhoneType) Convert.ToInt16(dr[ordPhoneType]),
                                        PhoneNumber = Convert.ToInt64(dr[ordPhoneNumber]),
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
                                        (PhoneType) Convert.ToInt16(dr[ordPrimaryPhoneType]);
                                }
                            }
                        }
                    }
                    ConnSql.Close();
                }
                data.Person.PersonType = (PersonType) personType;
            }
            catch (Exception ex)
            {
                DocumentErrorMessage(ex.ToString());
            }
            return data;
        }
    }
}