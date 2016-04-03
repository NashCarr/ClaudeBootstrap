using System;
using System.Data;
using DataLayerSaveCommon;
using SaveDataCommon;
using ViewDataCommon.Customer;

namespace DataManagement.DataRepository.CustomerRepository
{
    public class DbCustomerBrandSave : DbSaveBase
    {
        public ReturnBase SetInactive(int recordId)
        {
            ReturnValues.Id = recordId;
            try
            {
                SetConnectToDatabase("[CustomerBrand].[usp_SetInactive]");

                CmdSql.Parameters.Add("@CustomerBrandId", SqlDbType.Int).Value = ReturnValues.Id;

                SetErrMsgParameter();

                SendNonQuery();
            }
            catch (Exception ex)
            {
                ReturnValues.ErrMsg = ex.Message;
            }

            return ReturnValues;
        }

        public ReturnBase AddUpdateRecord(CustomerBrand data)
        {
            ReturnValues.Id = data.RecordId;

            if (!string.IsNullOrEmpty(data.Name)) return SaveRecord(data);

            SetEmptyStringMessage("Customer Brand");
            return ReturnValues;
        }

        private ReturnBase SaveRecord(CustomerBrand data)
        {
            try
            {
                IdParameter = "@CustomerBrandId";

                SetConnectToDatabase("[CustomerBrand].[usp_Upsert]");

                SetIdInputOutputParameter();

                CmdSql.Parameters.Add("@Name", SqlDbType.NVarChar, 50).Value = data.Name.Trim();
                CmdSql.Parameters.Add("@CustomerId", SqlDbType.Int).Value = data.CustomerId;
                CmdSql.Parameters.Add("@DisplayOrder", SqlDbType.Int).Value = data.DisplayOrder;

                SetErrMsgParameter();

                SendNonQueryGetId();
            }
            catch (Exception ex)
            {
                ReturnValues.ErrMsg = ex.Message;
            }
            return ReturnValues;
        }
    }
}