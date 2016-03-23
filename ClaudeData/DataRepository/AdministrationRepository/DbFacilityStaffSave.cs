using System;
using System.Data;
using ClaudeCommon.BaseModels.Returns;
using ClaudeData.Models.Administration;

namespace ClaudeData.DataRepository.AdministrationRepository
{
    public class DbFacilityStaffSave : DbSaveBase
    {
        public ReturnBase AddUpdateStaffUser(int placeId, int staffUserId)
        {
            FacilityStaff d = new FacilityStaff {FacilityId = placeId, StaffUserId = staffUserId};
            return AddUpdateRecord(ref d);
        }

        public ReturnBase AddUpdateStaffUser(ref FacilityStaff data)
        {
            return AddUpdateRecord(ref data);
        }

        private ReturnBase AddUpdateRecord(ref FacilityStaff data)
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

                SetConnectToDatabase("[FacilityStaff].[usp_Upsert]");

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
                SetConnectToDatabase("[FacilityStaff].[usp_SetInactive]");

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