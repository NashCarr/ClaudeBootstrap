using System;
using System.Data;
using CommonDataSave.Facility;
using CommonDataSave.Return;
using DataLayerCommonSave;

namespace DataLayerSave.Facility
{
    public class DbFacilityResourceSave : DbSaveBase
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

        public ReturnBase AddUpdateRecord(FacilityResourceSave data)
        {
            ReturnValues.Id = data.Id;

            if (!string.IsNullOrEmpty(data.Name)) return SaveRecord(data);

            SetEmptyStringMessage("Facility Resource");
            return ReturnValues;
        }

        private ReturnBase SaveRecord(FacilityResourceSave data)
        {
            try
            {
                IdParameter = "@FacilityResourceId";

                SetConnectToDatabase("[FacilityResource].[usp_Upsert]");

                SetIdInputOutputParameter();

                CmdSql.Parameters.Add("@Name", SqlDbType.NVarChar, 50).Value = data.Name.Trim();
                CmdSql.Parameters.Add("@ShortName", SqlDbType.NVarChar, 10).Value = data.ShortName.Trim();
                CmdSql.Parameters.Add("@FacilityId", SqlDbType.Int).Value = data.FacilityId;

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