using System;
using System.Data;
using CommonData.Models.SiteConfiguration;
using DataLayerSaveCommon;
using SaveDataCommon;

namespace DataManagement.DataRepository.SiteConfiguration
{
    public class DbStudyDefinitionsSave : DbSaveBase
    {
        public ReturnBase AddUpdateRecord(StudyDefinition data)
        {
            try
            {
                ReturnValues.Id = 1;
                IdParameter = "@StudyDefinitionId";

                SetConnectToDatabase("[Settings].[usp_StudyDefinition_Update]");

                CmdSql.Parameters.Add(IdParameter, SqlDbType.Int).Value = 1;
                CmdSql.Parameters.Add("@CustomerBrands", SqlDbType.Bit).Value = data.CustomerBrands;
                CmdSql.Parameters.Add("@CustomerContacts", SqlDbType.Bit).Value = data.CustomerContacts;
                CmdSql.Parameters.Add("@ResearchObjective", SqlDbType.Bit).Value = data.ResearchObjective;
                CmdSql.Parameters.Add("@Overview", SqlDbType.Bit).Value = data.Overview;
                CmdSql.Parameters.Add("@ScreeningCriteria", SqlDbType.Bit).Value = data.ScreeningCriteria;
                CmdSql.Parameters.Add("@AudioVisualRequirements", SqlDbType.Bit).Value = data.AudioVisualRequirements;
                CmdSql.Parameters.Add("@ContractorRequirements", SqlDbType.Bit).Value = data.ContractorRequirements;
                CmdSql.Parameters.Add("@FoodRequirements", SqlDbType.Bit).Value = data.FoodRequirements;
                CmdSql.Parameters.Add("@OtherRequirements", SqlDbType.Bit).Value = data.OtherRequirements;
                CmdSql.Parameters.Add("@Budget", SqlDbType.Bit).Value = data.Budget;
                CmdSql.Parameters.Add("@ExternalSpending", SqlDbType.Bit).Value = data.ExternalSpending;

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