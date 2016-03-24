using System;
using System.Data;
using ClaudeCommon.BaseModels.Returns;
using ClaudeData.Models.Administration;

namespace ClaudeData.DataRepository.AdministrationRepository
{
    public class DbFacilityStaffSave : DbSaveBase
    {
        public ReturnBase AddUpdateStaffMember(int placeId, int staffMemberId)
        {
            FacilityStaff d = new FacilityStaff {FacilityId = placeId, StaffMemberId = staffMemberId};
            return AddUpdateRecord(ref d);
        }

        public ReturnBase AddUpdateStaffMember(ref FacilityStaff data)
        {
            return AddUpdateRecord(ref data);
        }

        private ReturnBase AddUpdateRecord(ref FacilityStaff data)
        {
            if (data.StaffMemberId == 0)
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
                CmdSql.Parameters.Add("@StaffMemberId", SqlDbType.Int).Value = data.StaffMemberId;
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