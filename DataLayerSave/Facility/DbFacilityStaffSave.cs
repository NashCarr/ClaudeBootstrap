using System;
using System.Data;
using CommonDataReturn;
using CommonDataSave.Facility;

namespace DataLayerSave.Facility
{
    public class DbFacilityStaffSave : DbSaveBase
    {
        public ReturnBase AddUpdateStaffMember(int placeId, int staffMemberId)
        {
            FacilityStaffSave d = new FacilityStaffSave {FacilityId = placeId, StaffMemberId = staffMemberId};
            return AddUpdateRecord(ref d);
        }

        public ReturnBase AddUpdateStaffMember(ref FacilityStaffSave data)
        {
            return AddUpdateRecord(ref data);
        }

        private ReturnBase AddUpdateRecord(ref FacilityStaffSave data)
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
    }
}