using System;
using System.Data;
using System.Data.SqlClient;
using ClaudeCommon.Enums;
using ClaudeData.Models.Phones;

namespace ClaudeData.DataRepository.PhoneRepository
{
    public class DbPhoneAssociationGet : DbSaveBase
    {
        protected internal PhoneAssociation GetPlacePhone(int phoneAssociationId)
        {
            ReturnValues.Id = phoneAssociationId;
            IdParameter = "@PlacePhoneId";

            SetConnectToDatabase("[Phone].[usp_PlacePhone_GetPhone]");

            CmdSql.Parameters.Add(IdParameter, SqlDbType.Int).Value = ReturnValues.Id;

            return GetRecord();
        }

        protected internal PhoneAssociation GetPersonPhone(int phoneAssociationId)
        {
            ReturnValues.Id = phoneAssociationId;
            IdParameter = "@PersonPhoneId";

            SetConnectToDatabase("[Phone].[usp_PersonPhone_GetPhone]");

            return GetRecord();
        }

        private PhoneAssociation GetRecord()
        {
            PhoneAssociation data = new PhoneAssociation();
            try
            {
                CmdSql.Parameters.Add(IdParameter, SqlDbType.Int).Value = ReturnValues.Id;
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

                            int ordPhoneAssociationId = dr.GetOrdinal("PhoneAssociationId");
                            int ordPhoneId = dr.GetOrdinal("PhoneId");
                            int ordPhoneNumber = dr.GetOrdinal("PhoneNumber");
                            int ordCountry = dr.GetOrdinal("Country");
                            int ordPhoneType = dr.GetOrdinal("PhoneType");

                            int ordIsActive = dr.GetOrdinal("IsActive");
                            int ordCreateDate = dr.GetOrdinal("CreateDate");

                            while (dr.Read())
                            {
                                data.PhoneAssociationId = Convert.ToInt32(dr[ordPhoneAssociationId]);
                                data.PhoneId = Convert.ToInt32(dr[ordPhoneId]);
                                data.PhoneNumber = Convert.ToInt64(dr[ordPhoneNumber]);
                                data.Country = (CountryEnums.Country) Convert.ToInt16(dr[ordCountry]);
                                data.PhoneType = (PhoneEnums.PhoneType) Convert.ToInt16(dr[ordPhoneType]);
                                data.IsActive = Convert.ToBoolean(dr[ordIsActive]);
                                data.CreateDate = Convert.ToDateTime(dr[ordCreateDate]);
                            }
                        }
                    }
                }
                ConnSql.Close();
            }
            catch (Exception ex)
            {
                DocumentErrorMessage(ex.ToString());
            }
            return data;
        }
    }
}