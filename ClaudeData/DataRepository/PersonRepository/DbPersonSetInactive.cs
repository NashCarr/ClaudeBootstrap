using System;
using System.Data;

namespace ClaudeData.DataRepository.PersonRepository
{
    public class DbPersonSetInactive : DbSaveBase
    {
        private void SetInactive(int personId)
        {
            try
            {
                CmdSql.Parameters.Add("@PersonId", SqlDbType.Int).Value = personId;

                SetErrMsgParameter();

                SendNonQuery();
            }
            catch (Exception ex)
            {
                ErrMsg = ex.Message;
            }
        }

        public string SetAssessorInactive(int personId)
        {
            try
            {
                SetConnectToDatabase("[Assessor].[usp_Assessor_SetInactive]");

                SetInactive(personId);
            }
            catch (Exception ex)
            {
                ErrMsg = ex.Message;
            }
            return ErrMsg;
        }

        public string SetCustomerContactInactive(int personId)
        {
            try
            {
                SetConnectToDatabase("[Admin].[usp_CustomerContact_SetInactive]");

                SetInactive(personId);
            }
            catch (Exception ex)
            {
                ErrMsg = ex.Message;
            }
            return ErrMsg;
        }

        public string SetStaffUserInactive(int personId)
        {
            try
            {
                SetConnectToDatabase("[Admin].[usp_StaffUser_SetInactive]");

                SetInactive(personId);
            }
            catch (Exception ex)
            {
                ErrMsg = ex.Message;
            }
            return ErrMsg;
        }
    }
}