using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using ClaudeCommon.Enums;
using ClaudeData.Models.Addresses;
using ClaudeData.Models.People;
using ClaudeData.Models.Phones;
using static ClaudeCommon.Enums.PersonEnums;
using static ClaudeCommon.Enums.PhoneEnums;

namespace ClaudeData.DataRepository.PersonRepository
{
    public class DbPersonDataGet : DbGetBase
    {
        protected internal PersonData GetAssessor(int personId)
        {
            return LoadRecords(personId, (byte) PersonType.Assessor);
        }

        protected internal PersonData GetCustomerContact(int personId)
        {
            return LoadRecords(personId, (byte) PersonType.CustomerContact);
        }

        protected internal PersonData GetStaffUser(int personId)
        {
            return LoadRecords(personId, (byte) PersonType.StaffUser);
        }

        private PersonData LoadRecords(int personId, byte personType)
        {
            PersonData data = new PersonData();
            try
            {
                data.Person = new Person();
                data.PhoneData = new PhoneData {Phones = new List<PhoneAssociation>()};
                data.AddressData = new AddressData {Addresses = new List<AddressAssociation>()};

                IdValue = personId;
                IdParameter = "@PersonId";

                SetConnectToDatabase("[Admin].[usp_Person_GetPersonData]");

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

                            int ordIsActive = dr.GetOrdinal("IsActive");
                            int ordCreateDate = dr.GetOrdinal("CreateDate");

                            //Person
                            while (dr.Read())
                            {
                                data.Person.Email = Convert.ToString(dr[ordEmail]);
                                data.Person.PlaceId = Convert.ToInt32(dr[ordPlaceId]);
                                data.Person.PersonId = Convert.ToInt32(dr[ordPersonId]);
                                data.Person.LastName = Convert.ToString(dr[ordLastName]);
                                data.Person.IsActive = Convert.ToBoolean(dr[ordIsActive]);
                                data.Person.FirstName = Convert.ToString(dr[ordFirstName]);
                                data.Person.MiddleName = Convert.ToString(dr[ordMiddleName]);
                                data.Person.CreateDate = Convert.ToDateTime(dr[ordCreateDate]);
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
                                        City = Convert.ToString(dr[ordCity]),
                                        Country = (CountryEnums.Country) Convert.ToInt16(dr[ordCountry]),
                                        ZipCode = Convert.ToString(dr[ordZipCode]),
                                        Address1 = Convert.ToString(dr[ordAddress1]),
                                        Address2 = Convert.ToString(dr[ordAddress2]),
                                        IsActive = Convert.ToBoolean(dr[ordIsActive]),
                                        AddressId = Convert.ToInt32(dr[ordAddressId]),
                                        AddressType = (AddressEnums.AddressType) Convert.ToInt16(dr[ordAddressType]),
                                        CreateDate = Convert.ToDateTime(dr[ordCreateDate]),
                                        PostalCodeId = Convert.ToInt32(dr[ordPostalCodeId]),
                                        StateProvince = Convert.ToString(dr[ordStateProvince]),
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

                                ordIsActive = dr.GetOrdinal("IsActive");
                                ordCreateDate = dr.GetOrdinal("CreateDate");

                                while (dr.Read())
                                {
                                    PhoneAssociation item = new PhoneAssociation
                                    {
                                        Country = (CountryEnums.Country) Convert.ToInt16(dr[ordCountry]),
                                        PhoneId = Convert.ToInt32(dr[ordPhoneId]),
                                        PhoneType = (PhoneType) Convert.ToInt16(dr[ordPhoneType]),
                                        IsActive = Convert.ToBoolean(dr[ordIsActive]),
                                        PhoneNumber = Convert.ToInt64(dr[ordPhoneNumber]),
                                        CreateDate = Convert.ToDateTime(dr[ordCreateDate]),
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