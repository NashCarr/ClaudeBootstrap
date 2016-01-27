using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using ClaudeData.DataRepository.PersonRepository;
using ClaudeData.Models.Lists.Settings;
using ClaudeData.Models.People;
using ClaudeData.ViewModels.Settings;
using static ClaudeCommon.Enums.PersonEnums;

namespace ClaudeData.DataRepository.SettingsRepository
{
    public class DbCustomerContactInfoGet : DbGetBase
    {
        public List<CustomerContactInfo> GetActiveRecords()
        {
            SetConnectToDatabase("[ViewModel].[usp_Settings_CustomerContactList]");

            return LoadList();
        }

        public List<CustomerContactInfo> GetInactiveRecords()
        {
            SetConnectToDatabase("[Admin].[usp_CustomerContact_GetInactive]");

            return LoadList();
        }

        public CustomerContactView GetRecord(int recordId)
        {
            PersonData p;

            using (DbPersonDataGet a = new DbPersonDataGet())
            {
                p = a.GetStaffUser(recordId);
            }

            using (DbPersonDataStub a = new DbPersonDataStub())
            {
                p = a.Prefill(PersonType.StaffUser, p);
            }

            CustomerContactView m = new CustomerContactView
            {
                CustomerContact = p.Person,
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

        public List<CustomerContactInfo> GetRecords()
        {
            return GetRecords(0);
        }

        private List<CustomerContactInfo> GetRecords(int personId)
        {
            try
            {
                SetConnectToDatabase("[Admin].[usp_CustomerContact_Get]");

                CmdSql.Parameters.Add("@CustomerContactId", SqlDbType.Int).Value = personId;

                return LoadList();
            }
            catch (Exception ex)
            {
                DocumentErrorMessage(ex.ToString());
                return new List<CustomerContactInfo>();
            }
        }

        private List<CustomerContactInfo> LoadList()
        {
            List<CustomerContactInfo> data = new List<CustomerContactInfo>();
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
                                CustomerContactInfo item = new CustomerContactInfo
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