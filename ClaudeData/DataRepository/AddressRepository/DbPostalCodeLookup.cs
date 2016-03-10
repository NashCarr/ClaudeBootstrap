using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using ClaudeData.Models.LookupLists;
using static ClaudeCommon.Enums.CountryEnums;

namespace ClaudeData.DataRepository.AddressRepository
{
    public class DbPostalCodeLookup: DbGetBase
    {
        public List<PostalCodeLookup> GetLookup()
        {
            SetConnectToDatabase("[Address].[usp_PostalCode_Lookup]");
 
            return LoadRecords();
        }

        private List<PostalCodeLookup> LoadRecords()
        {
            List<PostalCodeLookup> data = new List<PostalCodeLookup>();
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

                            int ordCity = dr.GetOrdinal("City");
                            int ordText = dr.GetOrdinal("Text");
                            int ordValue = dr.GetOrdinal("Value");
                            int ordCountry = dr.GetOrdinal("Country");
                            int ordStateProvinceId = dr.GetOrdinal("StateProvinceId");

                            while (dr.Read())
                            {
                                PostalCodeLookup item = new PostalCodeLookup
                                {
                                    City = Convert.ToString(dr[ordCity]),
                                    Text = Convert.ToString(dr[ordText]),
                                    Value = Convert.ToString(dr[ordValue]),
                                    Country = (Country) Convert.ToInt16(dr[ordCountry]),
                                    StateProvinceId = Convert.ToInt32(dr[ordStateProvinceId]),
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