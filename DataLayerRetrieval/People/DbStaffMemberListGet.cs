using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using CommonDataRetrieval.Places;

namespace DataLayerRetrieval.People
{
    public class DbStaffMemberListGet : DbGetBase
    {
        public List<StaffMember> GetList()
        {
            try
            {
                return GetRecords();
            }
            catch (Exception ex)
            {
                DocumentErrorMessage(ex.ToString());
                return new List<StaffMember>();
            }
        }

        private List<StaffMember> GetRecords()
        {
            List<StaffMember> data = new List<StaffMember>();
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
                                StaffMember item = new StaffMember
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