using System;
using System.Data;
using System.Data.SqlClient;
using DataLayerCommon.Phones;
using static CommonData.Enums.CountryEnums;
using static CommonData.Enums.PhoneEnums;

namespace DataLayerRetrieval.Phones
{
    public class DbPhoneAssociationGet : DbGetBase
    {
        protected internal PhoneAssociation GetPlacePhone(int phoneAssociationId)
        {
            IdValue = phoneAssociationId;
            IdParameter = "@PlacePhoneId";

            SetConnectToDatabase("[Phone].[usp_PlacePhone_GetPhone]");

            CmdSql.Parameters.Add(IdParameter, SqlDbType.Int).Value = IdValue;

            return GetRecord();
        }

        protected internal PhoneAssociation GetPersonPhone(int phoneAssociationId)
        {
            IdValue = phoneAssociationId;
            IdParameter = "@PersonPhoneId";

            SetConnectToDatabase("[Phone].[usp_PersonPhone_GetPhone]");

            return GetRecord();
        }

        private PhoneAssociation GetRecord()
        {
            PhoneAssociation data = new PhoneAssociation();
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

                            int ordPhoneAssociationId = dr.GetOrdinal("PhoneAssociationId");
                            int ordPhoneId = dr.GetOrdinal("PhoneId");
                            int ordPhoneNumber = dr.GetOrdinal("PhoneNumber");
                            int ordCountry = dr.GetOrdinal("Country");
                            int ordPhoneType = dr.GetOrdinal("PhoneType");

                            while (dr.Read())
                            {
                                data.PhoneAssociationId = Convert.ToInt32(dr[ordPhoneAssociationId]);
                                data.PhoneId = Convert.ToInt32(dr[ordPhoneId]);
                                data.PhoneNumber = Convert.ToInt64(dr[ordPhoneNumber]);
                                data.Country = (Country) Convert.ToInt16(dr[ordCountry]);
                                data.PhoneType = (PhoneType) Convert.ToInt16(dr[ordPhoneType]);
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