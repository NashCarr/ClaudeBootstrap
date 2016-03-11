using System;
using System.Data;

namespace ClaudeData.DataRepository.PersonRepository
{
    public class DbPersonSetInactive : DbSaveBase
    {
        private void SetInactive()
        {
            try
            {
                CmdSql.Parameters.Add("@PersonId", SqlDbType.Int).Value = ReturnValues.Id;

                SetErrMsgParameter();

                SendNonQuery();
            }
            catch (Exception ex)
            {
                ReturnValues.ErrMsg = ex.Message;
            }
        }

        public string SetAssessorInactive(int personId)
        {
            try
            {
                ReturnValues.Id = personId;
                SetConnectToDatabase("[Assessor].[usp_Assessor_SetInactive]");

                SetInactive();
            }
            catch (Exception ex)
            {
                ReturnValues.ErrMsg = ex.Message;
            }
            return ReturnValues.ErrMsg;
        }

        public string SetCustomerContactInactive(int personId)
        {
            try
            {
                ReturnValues.Id = personId;
                SetConnectToDatabase("[Admin].[usp_CustomerContact_SetInactive]");

                SetInactive();
            }
            catch (Exception ex)
            {
                ReturnValues.ErrMsg = ex.Message;
            }
            return ReturnValues.ErrMsg;
        }

        public string SetStaffUserInactive(int personId)
        {
            try
            {
                ReturnValues.Id = personId;
                SetConnectToDatabase("[Admin].[usp_StaffUser_SetInactive]");

                SetInactive();
            }
            catch (Exception ex)
            {
                ReturnValues.ErrMsg = ex.Message;
            }
            return ReturnValues.ErrMsg;
        }

        public string SetOrganizationContactInactive(int personId)
        {
            try
            {
                ReturnValues.Id = personId;
                SetConnectToDatabase("[FundRaising].[usp_OrganizationContact_SetInactive]");

                SetInactive();
            }
            catch (Exception ex)
            {
                ReturnValues.ErrMsg = ex.Message;
            }
            return ReturnValues.ErrMsg;
        }
    }
}