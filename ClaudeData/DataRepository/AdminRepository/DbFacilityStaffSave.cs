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
                return ReturnValues.ErrMsg;
            }

            try
            {
                ReturnValues.Id = data.FacilityStaffId;
                IdParameter = "@FacilityStaffId";

                SetConnectToDatabase("[Admin].[usp_FacilityStaff_Upsert]");

                SetIdInputOutputParameter();

                CmdSql.Parameters.Add("@FacilityId", SqlDbType.Int).Value = data.FacilityId;
                CmdSql.Parameters.Add("@StaffUserId", SqlDbType.Int).Value = data.StaffUserId;
                CmdSql.Parameters.Add("@IsActive", SqlDbType.Bit).Value = data.IsActive;

                SetErrMsgParameter();

                SendNonQueryGetId();

                data.FacilityStaffId = ReturnValues.Id;
            }
            catch (Exception ex)
            {
                ReturnValues.ErrMsg = ex.Message;
            }
            return ReturnValues.ErrMsg;
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
                ReturnValues.ErrMsg = ex.Message;
            }
            return ReturnValues.ErrMsg;
        }
    }
}