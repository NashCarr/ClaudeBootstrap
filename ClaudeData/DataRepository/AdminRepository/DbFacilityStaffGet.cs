using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using ClaudeData.Models.Admin;

namespace ClaudeData.DataRepository.AdminRepository
{
    public class DbFacilityStaffGet : DbGetBase
    {
        public List<FacilityStaff> GetActiveRecords()
        {
            SetConnectToDatabase("[Admin].[usp_FacilityStaff_GetActive]");

            return LoadRecords();
        }

        public List<FacilityStaff> GetInactiveRecords()
        {
            SetConnectToDatabase("[Admin].[usp_FacilityStaff_GetInactive]");

            return LoadRecords();
        }

        public FacilityStaff GetRecord(int recordId)
        {
            return GetRecords(recordId, 0, 0).SingleOrDefault();
        }

        public List<FacilityStaff> GetRecords()
        {
            return GetRecords(0, 0, 0);
        }

        private List<FacilityStaff> GetRecords(int facilityStaffId, int facilityId, int staffUserId)
        {
            try
            {
                SetConnectToDatabase("[Admin].[usp_FacilityStaff_Get]");

                CmdSql.Parameters.Add("@FacilityStaffId", SqlDbType.Int).Value = facilityStaffId;
                CmdSql.Parameters.Add("@FacilityId", SqlDbType.Int).Value = facilityId;
                CmdSql.Parameters.Add("@StaffUserId", SqlDbType.Int).Value = staffUserId;

                return LoadRecords();
            }
            catch (Exception ex)
            {
                DocumentErrorMessage(ex.ToString());
                return new List<FacilityStaff>();
            }
        }

        private List<FacilityStaff> LoadRecords()
        {
            List<FacilityStaff> data = new List<FacilityStaff>();
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

                            int ordFacilityStaffId = dr.GetOrdinal("FacilityStaffId");
                            int ordStaffUserId = dr.GetOrdinal("StaffUserId");
                            int ordFacilityId = dr.GetOrdinal("FacilityId");
                            int ordCreateDate = dr.GetOrdinal("CreateDate");
                            int ordIsActive = dr.GetOrdinal("IsActive");

                            while (dr.Read())
                            {
                                FacilityStaff item = new FacilityStaff
                                {
                                    IsActive = Convert.ToBoolean(dr[ordIsActive]),
                                    FacilityId = Convert.ToInt32(dr[ordFacilityId]),
                                    StaffUserId = Convert.ToInt32(dr[ordStaffUserId]),
                                    CreateDate = Convert.ToDateTime(dr[ordCreateDate]),
                                    FacilityStaffId = Convert.ToInt32(dr[ordFacilityStaffId])
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