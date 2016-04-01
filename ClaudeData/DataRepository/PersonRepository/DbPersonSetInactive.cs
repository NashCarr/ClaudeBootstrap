using System;
using System.Data;

namespace DataManagement.DataRepository.PersonRepository
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
                ReturnValues.ErrMsg = ex.Message;
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
                ReturnValues.ErrMsg = ex.Message;
            }
            return ReturnValues.ErrMsg;
        }

        public string SetCustomerContactInactive(int personId)
        {
            try
            {
                SetConnectToDatabase("[CustomerContact].[usp_SetInactive]");

                SetInactive(personId);
            }
            catch (Exception ex)
            {
                ReturnValues.ErrMsg = ex.Message;
            }
            return ReturnValues.ErrMsg;
        }

        public string SetStaffMemberInactive(int personId)
        {
            try
            {
                SetConnectToDatabase("[StaffMember].[usp_SetInactive]");

                SetInactive(personId);
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
                SetConnectToDatabase("[FundRaising].[usp_OrganizationContact_SetInactive]");

                SetInactive(personId);
            }
            catch (Exception ex)
            {
                ReturnValues.ErrMsg = ex.Message;
            }
            return ReturnValues.ErrMsg;
        }
    }
}