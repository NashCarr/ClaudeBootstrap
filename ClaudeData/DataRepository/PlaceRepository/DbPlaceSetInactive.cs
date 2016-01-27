using System;
using System.Data;

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
                ErrMsg = ex.Message;
            }
        }

        public string SetOrganizationInactive(int placeId)
        {
            try
            {
                SetConnectToDatabase("[FundRaising].[usp_Organization_SetInactive]");

                SetInactive(placeId);
            }
            catch (Exception ex)
            {
                ErrMsg = ex.Message;
            }
            return ErrMsg;
        }

        public string SetFacilityInactive(int placeId)
        {
            try
            {
                SetConnectToDatabase("[Admin].[usp_Facility_SetInactive]");

                SetInactive(placeId);
            }
            catch (Exception ex)
            {
                ErrMsg = ex.Message;
            }
            return ErrMsg;
        }

        public string SetCustomerInactive(int placeId)
        {
            try
            {
                SetConnectToDatabase("[Admin].[usp_Customer_SetInactive]");

                SetInactive(placeId);
            }
            catch (Exception ex)
            {
                ErrMsg = ex.Message;
            }
            return ErrMsg;
        }
    }
}