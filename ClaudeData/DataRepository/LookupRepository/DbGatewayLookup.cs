using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Web.Mvc;

namespace DataManagement.DataRepository.LookupRepository
{
    public abstract class DbGatewayLookup : DbGatewayGet
    {
        protected internal List<SelectListItem> LoadLookup()
        {
            List<SelectListItem> data = new List<SelectListItem>();
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

                            while (dr.Read())
                            {
                                SelectListItem item = new SelectListItem
                                {
                                    Value = Convert.ToString(dr[ordValue]),
                                    Text = Convert.ToString(dr[ordText])
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