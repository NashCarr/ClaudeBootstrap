using System;
using System.Data;
using System.Data.SqlClient;
using CommonData.Enums;
using CommonDataRetrieval.Assessor;
using DataLayerCommon.Addresses;
using DataLayerCommon.Phones;

namespace DataLayerRetrieval.Assessor
{
    public class DbAssessorViewGet : DbGetBase
    {
        public AssessorView GetView(int id)
        {
            return LoadRecords(id);
        }

        private AssessorView LoadRecords(int id)
        {
            AssessorView data = new AssessorView();
            try
            {
                IdValue = id;
                IdParameter = "@AssessorId";

                SetConnectToDatabase("[Assessor].[usp_GetAssessorView]");
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

                            int ordEmail = dr.GetOrdinal("Email");
                            int ordPlaceId = dr.GetOrdinal("PlaceId");
                            int ordPersonId = dr.GetOrdinal("PersonId");
                            int ordLastName = dr.GetOrdinal("LastName");
                            int ordFirstName = dr.GetOrdinal("FirstName");
                            int ordMiddleName = dr.GetOrdinal("MiddleName");

                            //Person
                            while (dr.Read())
                            {
                                //data.Person.Email = Convert.ToString(dr[ordEmail]);
                                //data.Person.PlaceId = Convert.ToInt32(dr[ordPlaceId]);
                                //data.Person.PersonId = Convert.ToInt32(dr[ordPersonId]);
                                //data.Person.LastName = Convert.ToString(dr[ordLastName]);
                                //data.Person.FirstName = Convert.ToString(dr[ordFirstName]);
                                //data.Person.MiddleName = Convert.ToString(dr[ordMiddleName]);
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
                                        Country = (CountryEnums.Country) Convert.ToInt16(dr[ordCountry]),
                                        ZipCode = Convert.ToString(dr[ordZipCode]),
                                        Address1 = Convert.ToString(dr[ordAddress1]),
                                        Address2 = Convert.ToString(dr[ordAddress2]),
                                        AddressId = Convert.ToInt32(dr[ordAddressId]),
                                        AddressType = (AddressEnums.AddressType) Convert.ToInt16(dr[ordAddressType]),
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
                                    //data.AddressData.Addresses.Add(item);
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
                                        Country = (CountryEnums.Country) Convert.ToInt16(dr[ordCountry]),
                                        PhoneId = Convert.ToInt32(dr[ordPhoneId]),
                                        PhoneType = (PhoneEnums.PhoneType) Convert.ToInt16(dr[ordPhoneType]),
                                        PhoneNumber = Convert.ToInt64(dr[ordPhoneNumber]),
                                        PhoneAssociationId = Convert.ToInt32(dr[ordPhoneAssociationId])
                                    };
                                    //data.PhoneData.Phones.Add(item);
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
                                    //data.PhoneData.PhoneSettings.AllowText = Convert.ToBoolean(dr[ordAllowText]);
                                    //data.PhoneData.PhoneSettings.RecordId = Convert.ToInt32(dr[ordPhoneSettingId]);
                                    //data.PhoneData.PhoneSettings.MobileCarrier = Convert.ToInt16(dr[ordMobileCarrierId]);
                                    //data.PhoneData.PhoneSettings.PrimaryPhoneType =
                                    //    (PhoneEnums.PhoneType) Convert.ToInt16(dr[ordPrimaryPhoneType]);
                                }
                            }
                        }
                    }
                    ConnSql.Close();
                }
                //data.Person.PersonType = (PersonEnums.PersonType) personType;
            }
            catch (Exception ex)
            {
                DocumentErrorMessage(ex.ToString());
            }
            return data;
        }
    }
}