using System;
using System.Data;
using ClaudeData.Models.Admin;

namespace ClaudeData.DataRepository.AdminRepository
{
    public class DbFacilityStaffSave : DbSaveBase
    {
        public string AddUpdateRecord(ref FacilityStaff data)
        {
            if (data.StaffUserId == 0)
            {
                SetZeroNumberMessage("Staff User");
                return ErrMsg;
            }

            try
            {
                IdValue = data.FacilityStaffId;
                IdParameter = "@FacilityStaffId";

                SetConnectToDatabase("[Admin].[usp_FacilityStaff_Upsert]");

                SetIdInputOutputParameter();

                CmdSql.Parameters.Add("@FacilityId", SqlDbType.Int).Value = data.FacilityId;
                CmdSql.Parameters.Add("@StaffUserId", SqlDbType.Int).Value = data.StaffUserId;
                CmdSql.Parameters.Add("@IsActive", SqlDbType.Bit).Value = data.IsActive;

                SetErrMsgParameter();

                SendNonQueryGetId();

                data.FacilityStaffId = IdValue;
            }
            catch (Exception ex)
            {
                ErrMsg = ex.Message;
            }
            return ErrMsg;
        }

        public string SetInactive(int facilityStaffId)
        {
            try
            {
                SetConnectToDatabase("[Admin].[usp_FacilityStaff_SetInactive]");

                CmdSql.Parameters.Add("@FacilityStaffId", SqlDbType.Int).Value = facilityStaffId;

                SetErrMsgParameter();

                SendNonQuery();
            }
            catch (Exception ex)
            {
                ErrMsg = ex.Message;
            }
            return ErrMsg;
        }
    }
}