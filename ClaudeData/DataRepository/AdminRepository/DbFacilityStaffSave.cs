using System;
using System.Data;
using ClaudeCommon.BaseModels.Returns;
using ClaudeData.Models.Admin;

namespace ClaudeData.DataRepository.AdminRepository
{
    public class DbFacilityStaffSave : DbSaveBase
    {
        public ReturnBase AddUpdateRecord(ref FacilityStaff data)
        {
            if (data.StaffUserId == 0)
            {
                SetZeroNumberMessage("Staff User");
                return ReturnValues;
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
            return ReturnValues;
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