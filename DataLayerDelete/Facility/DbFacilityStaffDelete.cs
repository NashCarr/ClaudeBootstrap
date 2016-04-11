using System;
using System.Data;

namespace DataLayerDelete.Facility
{
    public class DbFacilityStaffDelete : DbDeleteBase
    {
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