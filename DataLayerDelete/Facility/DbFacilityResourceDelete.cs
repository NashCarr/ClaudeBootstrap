using System;
using System.Data;
using CommonDataReturn;

namespace DataLayerDelete.Facility
{
    public class DbFacilityResourceDelete : DbDeleteBase
    {
        public ReturnBase SetInactive(int id)
        {
            ReturnValues.Id = id;
            try
            {
                SetConnectToDatabase("[FacilityResource].[usp_SetInactive]");

                CmdSql.Parameters.Add("@FacilityResourceId", SqlDbType.Int).Value = ReturnValues.Id;

                SetErrMsgParameter();

                SendNonQuery();
            }
            catch (Exception ex)
            {
                ReturnValues.ErrMsg = ex.Message;
            }

            return ReturnValues;
        }
    }
}