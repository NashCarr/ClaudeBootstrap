using System;
using System.Data;
using ClaudeCommon.BaseModels.Returns;
using ClaudeData.Models.SiteConfiguration;

namespace ClaudeData.DataRepository.SettingsRepository
{
    public class DbPasswordRequirementSave : DbSaveBase
    {
        public ReturnBase AddUpdateRecord(PasswordRequirement data)
        {
            try
            {
                ReturnValues.Id = 1;
                IdParameter = "@PasswordRequirementId";

                SetConnectToDatabase("[Settings].[usp_PasswordRequirement_Update]");

                CmdSql.Parameters.Add(IdParameter, SqlDbType.Int).Value = 1;
                CmdSql.Parameters.Add("@RequireMinimumLength", SqlDbType.Bit).Value = data.RequireMinimumLength;
                CmdSql.Parameters.Add("@RequireNumber", SqlDbType.Bit).Value = data.RequireNumber;
                CmdSql.Parameters.Add("@RequireCapitalLetter", SqlDbType.Bit).Value = data.RequireCapitalLetter;
                CmdSql.Parameters.Add("@RequireSpecialCharacter", SqlDbType.Bit).Value = data.RequireSpecialCharacter;
                CmdSql.Parameters.Add("@MinimumLength", SqlDbType.SmallInt).Value = data.MinimumLength;
                CmdSql.Parameters.Add("@ExpirationDays", SqlDbType.Int).Value = data.ExpirationDays;

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