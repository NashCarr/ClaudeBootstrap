using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using CommonData.Models.People;

namespace DataLayerRetrieval.People
{
    public class DbPeopleGet : DbGetBase
    {
        protected internal string TypeName;

        protected internal List<PersonList> GetRecords()
        {
            List<PersonList> data = new List<PersonList>();
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

                            int ordEmail = dr.GetOrdinal("Email");
                            int ordPersonId = dr.GetOrdinal("PersonId");
                            int ordLastName = dr.GetOrdinal("LastName");
                            int ordFirstName = dr.GetOrdinal("FirstName");
                            int ordMiddleName = dr.GetOrdinal("MiddleName");
                            int ordPrimaryPhone = dr.GetOrdinal("PrimaryPhone");
                            int ordDisplayOrder = dr.GetOrdinal("DisplayOrder");

                            while (dr.Read())
                            {
                                PersonList item = new PersonList
                                {
                                    Email = Convert.ToString(dr[ordEmail]),
                                    PersonId = Convert.ToInt32(dr[ordPersonId]),
                                    DisplayOrder = Convert.ToInt16(dr[ordDisplayOrder]),
                                    PrimaryPhone = Convert.ToString(dr[ordPrimaryPhone]),
                                    FullName =
                                        ((Convert.ToString(dr[ordFirstName]) + ' ' + Convert.ToString(dr[ordMiddleName]))
                                            .Trim() + ' ' + Convert.ToString(dr[ordLastName])).Trim()
                                };
                                item.DisplaySort = item.DisplayOrder.ToString("D4");
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