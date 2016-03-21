using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using ClaudeCommon.Models.People;

namespace ClaudeData.DataRepository.PeopleRepository
{
    public class DbStaffMemberListGet : DbGetBase
    {
        public List<StaffMemberList> GetList()
        {
            try
            {
                return GetRecords();
            }
            catch (Exception ex)
            {
                DocumentErrorMessage(ex.ToString());
                return new List<StaffMemberList>();
            }
        }

        private List<StaffMemberList> GetRecords()
        {
            List<StaffMemberList> data = new List<StaffMemberList>();
            try
            {
                SetConnectToDatabase("[ViewModel].[usp_Settings_StaffMemberList]");

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
                            int ordUserName = dr.GetOrdinal("UserName");
                            int ordLastName = dr.GetOrdinal("LastName");
                            int ordFirstName = dr.GetOrdinal("FirstName");
                            int ordLastLogIn = dr.GetOrdinal("LastLogIn");
                            int ordMiddleName = dr.GetOrdinal("MiddleName");
                            int ordDisplayOrder = dr.GetOrdinal("DisplayOrder");

                            while (dr.Read())
                            {
                                StaffMemberList item = new StaffMemberList
                                {
                                    Email = Convert.ToString(dr[ordEmail]),
                                    PersonId = Convert.ToInt32(dr[ordPersonId]),
                                    UserName = Convert.ToString(dr[ordUserName]),
                                    DisplayOrder = Convert.ToInt16(dr[ordDisplayOrder]),
                                    LastLoginDate = dr[ordLastLogIn] == DBNull.Value
                                        ? string.Empty
                                        : Convert.ToDateTime(dr[ordLastLogIn]).ToString("MM/dd/yyyy hh:mm:ss tt"),
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