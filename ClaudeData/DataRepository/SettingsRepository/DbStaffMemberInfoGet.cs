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
    public class DbStaffMemberInfoGet : DbGetBase
    {
        public List<StaffMemberInfo> GetActiveRecords()
        {
            SetConnectToDatabase("[ViewModel].[usp_Settings_StaffMemberList]");

            return LoadList();
        }

        public List<StaffMemberInfo> GetInactiveRecords()
        {
            SetConnectToDatabase("[Admin].[usp_StaffMember_GetInactive]");

            return LoadList();
        }

        public StaffMemberView GetRecord(int recordId)
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

            StaffMemberView m = new StaffMemberView
            {
                StaffUser = p.Person,
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

        public List<StaffMemberInfo> GetRecords()
        {
            return GetRecords(0);
        }

        private List<StaffMemberInfo> GetRecords(int staffMemberId)
        {
            try
            {
                SetConnectToDatabase("[Admin].[usp_StaffMember_Get]");

                CmdSql.Parameters.Add("@StaffMemberId", SqlDbType.Int).Value = staffMemberId;

                return LoadList();
            }
            catch (Exception ex)
            {
                DocumentErrorMessage(ex.ToString());
                return new List<StaffMemberInfo>();
            }
        }

        private List<StaffMemberInfo> LoadList()
        {
            List<StaffMemberInfo> data = new List<StaffMemberInfo>();
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
                                StaffMemberInfo item = new StaffMemberInfo
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