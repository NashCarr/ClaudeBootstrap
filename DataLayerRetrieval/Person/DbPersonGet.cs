using System;
using System.Data;
using System.Data.SqlClient;
using DataLayerCommon.People;
using static CommonData.Enums.PersonEnums;

namespace DataLayerRetrieval.Person
{
    public class DbPersonGet : DbGetBase
    {
        protected internal PersonBase GetAssessor(int personId)
        {
            return LoadRecord(personId, (byte) PersonType.Assessor);
        }

        protected internal PersonBase GetCustomerContact(int personId)
        {
            return LoadRecord(personId, (byte) PersonType.CustomerContact);
        }

        protected internal PersonBase GetStaffMember(int personId)
        {
            return LoadRecord(personId, (byte) PersonType.StaffMember);
        }

        private PersonBase LoadRecord(int personId, byte personType)
        {
            PersonBase data = new PersonBase();
            try
            {
                IdValue = personId;
                IdParameter = "@PersonId";

                SetConnectToDatabase("[Admin].[usp_Person_GetPerson]");

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

                            //Person
                            while (dr.Read())
                            {
                                data.Email = Convert.ToString(dr[ordEmail]);
                                data.PlaceId = Convert.ToInt32(dr[ordPlaceId]);
                                data.PersonId = Convert.ToInt32(dr[ordPersonId]);
                                data.LastName = Convert.ToString(dr[ordLastName]);
                                data.FirstName = Convert.ToString(dr[ordFirstName]);
                                data.MiddleName = Convert.ToString(dr[ordMiddleName]);
                            }
                        }
                    }
                    ConnSql.Close();
                }
                data.PersonType = (PersonType) personType;
            }
            catch (Exception ex)
            {
                DocumentErrorMessage(ex.ToString());
            }
            return data;
        }
    }
}