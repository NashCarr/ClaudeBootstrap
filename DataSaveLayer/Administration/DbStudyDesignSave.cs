using System;
using System.Data;
using SaveDataCommon;
using SaveDataCommon.Administration;

namespace DataSaveLayer.Administration
{
    public class DbStudyDesignSave : DbSaveBase
    {
        public ReturnBase SetInactive(int id)
        {
            ReturnValues.Id = id;
            try
            {
                SetConnectToDatabase("[StudyDesign].[usp_SetInactive]");

                CmdSql.Parameters.Add("@StudyDesignId", SqlDbType.Int).Value = ReturnValues.Id;

                SetErrMsgParameter();

                SendNonQuery();
            }
            catch (Exception ex)
            {
                ReturnValues.ErrMsg = ex.Message;
            }

            return ReturnValues;
        }

        public ReturnBase AddUpdateRecord(StudyDesignSave data)
        {
            ReturnValues.Id = data.Id;

            if (!string.IsNullOrEmpty(data.Name)) return SaveRecord(data);

            SetEmptyStringMessage("Study Design");
            return ReturnValues;
        }

        private ReturnBase SaveRecord(StudyDesignSave data)
        {
            try
            {
                IdParameter = "@StudyDesignId";

                SetConnectToDatabase("[StudyDesign].[usp_Upsert]");

                SetIdInputOutputParameter();

                CmdSql.Parameters.Add("@Name", SqlDbType.NVarChar, 50).Value = data.Name.Trim();
                CmdSql.Parameters.Add("@Radius", SqlDbType.Int).Value = data.Radius;

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