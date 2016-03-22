﻿using System;
using System.Data;
using ClaudeCommon.BaseModels.Returns;
using ClaudeCommon.Models.Administration;

namespace ClaudeData.DataRepository.AdministrationRepository
{
    public class DbStudyDesignSave : DbSaveBase
    {
        public ReturnBase SetInactive(int recordId)
        {
            ReturnValues.Id = recordId;
            try
            {
                SetConnectToDatabase("[Admin].[usp_StudyDesign_SetInactive]");

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

        public ReturnBase AddUpdateRecord(StudyDesign data)
        {
            ReturnValues.Id = data.RecordId;

            if (!string.IsNullOrEmpty(data.Name)) return SaveRecord(data);

            SetEmptyStringMessage("Study Design");
            return ReturnValues;
        }

        private ReturnBase SaveRecord(StudyDesign data)
        {
            try
            {
                IdParameter = "@StudyDesignId";

                SetConnectToDatabase("[Admin].[usp_StudyDesign_Upsert]");

                SetIdInputOutputParameter();

                CmdSql.Parameters.Add("@Name", SqlDbType.NVarChar, 50).Value = data.Name.Trim();
                CmdSql.Parameters.Add("@Radius", SqlDbType.Int).Value = data.Radius;
                CmdSql.Parameters.Add("@DisplayOrder", SqlDbType.Int).Value = data.DisplayOrder;
                CmdSql.Parameters.Add("@IsSystem", SqlDbType.Bit).Value = data.IsSystem;

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