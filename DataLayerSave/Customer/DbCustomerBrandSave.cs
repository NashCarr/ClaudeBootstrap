using System;
using System.Data;
using CommonDataSave.Customer;
using CommonDataSave.Return;
using DataLayerCommonSave;

namespace DataLayerSave.Customer
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

        public ReturnBase AddUpdateRecord(CustomerBrandSave data)
        {
            ReturnValues.Id = data.Id;

            if (!string.IsNullOrEmpty(data.Name)) return SaveRecord(data);

            SetEmptyStringMessage("Customer Brand");
            return ReturnValues;
        }

        private ReturnBase SaveRecord(CustomerBrandSave data)
        {
            try
            {
                IdParameter = "@CustomerBrandId";

                SetConnectToDatabase("[CustomerBrand].[usp_Upsert]");

                SetIdInputOutputParameter();

                CmdSql.Parameters.Add("@Name", SqlDbType.NVarChar, 50).Value = data.Name.Trim();
                CmdSql.Parameters.Add("@CustomerId", SqlDbType.Int).Value = data.CustomerId;

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