using System;
using System.Data;
using ClaudeCommon.BaseModels.Returns;

namespace ClaudeData.DataRepository.PlaceRepository
{
    public class DbPlaceSetInactive : DbSaveBase
    {
        private void SetInactive(int placeId)
        {
            try
            {
                CmdSql.Parameters.Add("@PlaceId", SqlDbType.Int).Value = placeId;

                SetErrMsgParameter();

                SendNonQuery();
            }
            catch (Exception ex)
            {
                ReturnValues.ErrMsg = ex.Message;
            }
        }

        public ReturnBase SetOrganizationInactive(int placeId)
        {
            try
            {
                SetConnectToDatabase("[FundRaising].[usp_Organization_SetInactive]");

                SetInactive(placeId);
            }
            catch (Exception ex)
            {
                ReturnValues.ErrMsg = ex.Message;
            }
            return ReturnValues;
        }

        public ReturnBase SetFacilityInactive(int placeId)
        {
            try
            {
                SetConnectToDatabase("[Facility].[usp_SetInactive]");

                SetInactive(placeId);
            }
            catch (Exception ex)
            {
                ReturnValues.ErrMsg = ex.Message;
            }
            return ReturnValues;
        }

        public ReturnBase SetCustomerInactive(int placeId)
        {
            try
            {
                SetConnectToDatabase("[Admin].[usp_Customer_SetInactive]");

                SetInactive(placeId);
            }
            catch (Exception ex)
            {
                ReturnValues.ErrMsg = ex.Message;
            }
            return ReturnValues;
        }
    }
}