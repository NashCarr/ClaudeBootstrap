using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using CommonData.Enums;
using DataLayerCommon.Lists.Settings;
using DataLayerCommon.People;
using DataLayerRetrieval.Person;
using DataRetrievalCommon.People;

namespace DataLayerRetrieval.People
{
    public class DbAssessorInfoGet : DbGetBase
    {
        public List<AssessorInfo> GetActiveRecords()
        {
            SetConnectToDatabase("[ViewModel].[usp_Settings_AssessorList]");

            return LoadList();
        }

        public List<AssessorInfo> GetInactiveRecords()
        {
            SetConnectToDatabase("[Admin].[usp_Assessor_GetInactive]");

            return LoadList();
        }

        public AssessorView GetRecord(int recordId)
        {
            PersonData p;

            using (DbPersonDataGet a = new DbPersonDataGet())
            {
                p = a.GetStaffMember(recordId);
            }

            using (DbPersonDataStub a = new DbPersonDataStub())
            {
                p = a.Prefill(PersonEnums.PersonType.StaffMember, p);
            }

            AssessorView m = new AssessorView
            {
                Assessor = p.Person,
                Addresses =
                {
                    MailingAddress = p.AddressData.MailingAddress,
                    ShippingAddress = p.AddressData.PhysicalAddress
                },
                Phones =
                {
                    FaxPhone = p.PhoneData.FaxPhone,
                    CellPhone = p.PhoneData.CellPhone,
                    HomePhone = p.PhoneData.HomePhone,
                    WorkPhone = p.PhoneData.WorkPhone,
                    PhoneSettings = p.PhoneData.PhoneSettings
                }
            };

            return m;
        }

        public List<AssessorInfo> GetRecords()
        {
            return GetRecords(0);
        }

        private List<AssessorInfo> GetRecords(int personId)
        {
            try
            {
                SetConnectToDatabase("[Admin].[usp_Assessor_Get]");

                CmdSql.Parameters.Add("@AssessorId", SqlDbType.Int).Value = personId;

                return LoadList();
            }
            catch (Exception ex)
            {
                DocumentErrorMessage(ex.ToString());
                return new List<AssessorInfo>();
            }
        }

        private List<AssessorInfo> LoadList()
        {
            List<AssessorInfo> data = new List<AssessorInfo>();
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
                            int ordUserId = dr.GetOrdinal("UserId");
                            int ordPersonId = dr.GetOrdinal("PersonId");
                            int ordUserName = dr.GetOrdinal("UserName");
                            int ordLastName = dr.GetOrdinal("LastName");
                            int ordLastLogin = dr.GetOrdinal("LastLogin");
                            int ordFirstName = dr.GetOrdinal("FirstName");
                            int ordMiddleName = dr.GetOrdinal("MiddleName");
                            int ordAccessRight = dr.GetOrdinal("AccessRight");

                            while (dr.Read())
                            {
                                AssessorInfo item = new AssessorInfo
                                {
                                    Email = Convert.ToString(dr[ordEmail]),
                                    UserId = Convert.ToString(dr[ordUserId]),
                                    PersonId = Convert.ToInt32(dr[ordPersonId]),
                                    LastName = Convert.ToString(dr[ordLastName]),
                                    UserName = Convert.ToString(dr[ordUserName]),
                                    FirstName = Convert.ToString(dr[ordFirstName]),
                                    MiddleName = Convert.ToString(dr[ordMiddleName]),
                                    AccessRight = Convert.ToString(dr[ordAccessRight]),
                                    LastLogin = dr[ordLastLogin] == DBNull.Value
                                        ? null
                                        : (DateTime?) Convert.ToDateTime(dr[ordLastLogin])
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