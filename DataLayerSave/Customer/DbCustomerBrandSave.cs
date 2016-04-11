using System;
using System.Data;
using CommonDataReturn;
using CommonDataSave.Customer;

namespace DataLayerSave.Customer
{
    public class DbCustomerBrandSave : DbSaveBase
    {
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