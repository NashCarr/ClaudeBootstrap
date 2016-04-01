using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using DataManagement.Models.Administration;

namespace DataManagement.DataRepository.AdministrationRepository
{
    public class DbUserRoleGet : DbGetBase
    {
        public List<UserRole> GetActiveRecords()
        {
            SetConnectToDatabase("[Admin].[usp_UserRole_GetActive]");

            return LoadRecords();
        }

        public List<UserRole> GetInactiveRecords()
        {
            SetConnectToDatabase("[Admin].[usp_UserRole_GetInactive]");

            return LoadRecords();
        }

        public UserRole GetRecord(int recordId)
        {
            return GetRecords(recordId, string.Empty).SingleOrDefault();
        }

        public List<UserRole> GetRecords()
        {
            return GetRecords(0, string.Empty);
        }

        private List<UserRole> GetRecords(int roleId, string name)
        {
            try
            {
                SetConnectToDatabase("[Admin].[usp_UserRole_Get]");

                CmdSql.Parameters.Add("@UserRoleId", SqlDbType.Int).Value = roleId;
                CmdSql.Parameters.Add("@Name", SqlDbType.NVarChar, 50).Value = name?.Trim() ?? string.Empty;

                return LoadRecords();
            }
            catch (Exception ex)
            {
                DocumentErrorMessage(ex.ToString());
                return new List<UserRole>();
            }
        }

        private List<UserRole> LoadRecords()
        {
            List<UserRole> data = new List<UserRole>();
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

                            int ordUserRoleId = dr.GetOrdinal("UserRoleId");
                            int ordName = dr.GetOrdinal("Name");
                            int ordCreateDate = dr.GetOrdinal("CreateDate");
                            int ordIsActive = dr.GetOrdinal("IsActive");

                            while (dr.Read())
                            {
                                UserRole item = new UserRole
                                {
                                    RecordId = Convert.ToInt32(dr[ordUserRoleId]),
                                    Name = Convert.ToString(dr[ordName]),
                                    CreateDate = Convert.ToDateTime(dr[ordCreateDate]),
                                    IsActive = Convert.ToBoolean(dr[ordIsActive])
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