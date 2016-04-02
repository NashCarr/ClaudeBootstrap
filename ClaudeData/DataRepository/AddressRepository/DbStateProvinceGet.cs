using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using CommonData.Enums;
using DataManagement.Models.Addresses;
using DataRetrievalLayer;

namespace DataManagement.DataRepository.AddressRepository
{
    public class DbStateProvinceGet : DbGatewayGet
    {
        public List<StateProvince> GetActiveRecords(CountryEnums.Country id)
        {
            SetConnectToDatabase("[Address].[usp_StateProvince_GetActive]");
            CmdSql.Parameters.Add("@CountryId", SqlDbType.Int).Value = (int) id;

            return LoadRecords();
        }

        private List<StateProvince> LoadRecords()
        {
            List<StateProvince> data = new List<StateProvince>();
            try
            {
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

                            int ordStateProvinceId = dr.GetOrdinal("StateProvinceId");
                            int ordAbbreviation = dr.GetOrdinal("Abbreviation");
                            int ordCountryId = dr.GetOrdinal("CountryId");
                            int ordName = dr.GetOrdinal("Name");

                            while (dr.Read())
                            {
                                StateProvince item = new StateProvince
                                {
                                    StateProvinceId = Convert.ToInt16(dr[ordStateProvinceId]),
                                    Country = (CountryEnums.Country) Convert.ToInt16(dr[ordCountryId]),
                                    Abbreviation = Convert.ToString(dr[ordAbbreviation]),
                                    Name = Convert.ToString(dr[ordName])
                                };
                                data.Add(item);
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