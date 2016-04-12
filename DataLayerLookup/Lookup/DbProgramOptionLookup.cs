using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using CommonDataLookup;

namespace DataLayerLookup.Lookup
{
    public class DbProgramOptionLookup : DbGatewayLookupGet
    {
        public List<ProgramOptionLookup> GetLookUpList(string msgPrompt)
        {
            SetConnectToDatabase("[SelectList].[usp_ProgramOption_Lookup]");
            CmdSql.Parameters.Add("@ProgramOptionId", SqlDbType.Int).Value = 0;
            return LoadLookup();
        }

        protected internal List<ProgramOptionLookup> LoadLookup()
        {
            List<ProgramOptionLookup> data = new List<ProgramOptionLookup>();
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

                            int ordText = dr.GetOrdinal("Text");
                            int ordValue = dr.GetOrdinal("Value");
                            int ordDefaultPermision = dr.GetOrdinal("DefaultPermision");

                            while (dr.Read())
                            {
                                ProgramOptionLookup item = new ProgramOptionLookup
                                {
                                    Text = Convert.ToString(dr[ordText]),
                                    Value = Convert.ToString(dr[ordValue]),
                                    DefaultPermission = Convert.ToInt16(dr[ordDefaultPermision])
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