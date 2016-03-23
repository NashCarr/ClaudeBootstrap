using System;
using System.Data;
using ClaudeCommon.BaseModels.Returns;
using ClaudeCommon.Models.Facility;

namespace ClaudeData.DataRepository.FacilityRepository
{
    public class DbFacilityResourceSave : DbSaveBase
    {
        public ReturnBase SetInactive(int recordId)
        {
            ReturnValues.Id = recordId;
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

        public ReturnBase AddUpdateRecord(FacilityResource data)
        {
            ReturnValues.Id = data.RecordId;

            if (!string.IsNullOrEmpty(data.Name)) return SaveRecord(data);

            SetEmptyStringMessage("Facility Resource");
            return ReturnValues;
        }

        private ReturnBase SaveRecord(FacilityResource data)
        {
            try
            {
                IdParameter = "@FacilityResourceId";

                SetConnectToDatabase("[FacilityResource].[usp_Upsert]");

                SetIdInputOutputParameter();

                CmdSql.Parameters.Add("@Name", SqlDbType.NVarChar, 50).Value = data.Name.Trim();
                CmdSql.Parameters.Add("@ShortName", SqlDbType.NVarChar, 10).Value = data.ShortName.Trim();
                CmdSql.Parameters.Add("@FacilityId", SqlDbType.Int).Value = data.FacilityId;
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