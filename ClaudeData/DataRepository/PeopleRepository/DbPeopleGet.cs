using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using ClaudeData.Models.People;
using static ClaudeCommon.Enums.PersonEnums;

namespace ClaudeData.DataRepository.PeopleRepository
{
    public class DbPeopleGet : DbGetBase
    {
        protected internal string TypeName;

        protected internal List<Person> GetRecords()
        {
            List<Person> data = new List<Person>();
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
                            int ordPlaceId = dr.GetOrdinal("PlaceId");
                            int ordIsActive = dr.GetOrdinal("IsActive");
                            int ordPersonId = dr.GetOrdinal("PersonId");
                            int ordLastName = dr.GetOrdinal("LastName");
                            int ordFirstName = dr.GetOrdinal("FirstName");
                            int ordMiddleName = dr.GetOrdinal("MiddleName");
                            int ordCreateDate = dr.GetOrdinal("CreateDate");

                            while (dr.Read())
                            {
                                Person item = new Person
                                {
                                    CreateDate = Convert.ToDateTime(dr[ordCreateDate]),
                                    MiddleName = Convert.ToString(dr[ordMiddleName]),
                                    FirstName = Convert.ToString(dr[ordFirstName]),
                                    IsActive = Convert.ToBoolean(dr[ordIsActive]),
                                    LastName = Convert.ToString(dr[ordLastName]),
                                    PersonId = Convert.ToInt32(dr[ordPersonId]),
                                    PlaceId = Convert.ToInt32(dr[ordPlaceId]),
                                    Email = Convert.ToString(dr[ordEmail]),
                                    PersonType = (PersonType) IdValue
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