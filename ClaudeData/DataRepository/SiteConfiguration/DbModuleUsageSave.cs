using System;
using System.Data;
using CommonData.Models.SiteConfiguration;
using DataLayerSaveCommon;
using SaveDataCommon;

namespace DataManagement.DataRepository.SiteConfiguration
{
    public class DbModuleUsageSave : DbSaveBase
    {
        public ReturnBase AddUpdateRecord(ModuleUsage data)
        {
            try
            {
                ReturnValues.Id = 1;
                IdParameter = "@ModuleUsageId";

                SetConnectToDatabase("[Settings].[usp_ModuleUsage_Update]");

                CmdSql.Parameters.Add(IdParameter, SqlDbType.Int).Value = 1;
                CmdSql.Parameters.Add("@UseFundraising", SqlDbType.Bit).Value = data.UseFundRaising;
                CmdSql.Parameters.Add("@UseProjectRequestForms", SqlDbType.Bit).Value = data.UseProjectRequestForms;
                CmdSql.Parameters.Add("@UseFacilitiesUtilization", SqlDbType.Bit).Value = data.UseFacilitiesUtilization;
                CmdSql.Parameters.Add("@UseStudyCosting", SqlDbType.Bit).Value = data.UseStudyCosting;
                CmdSql.Parameters.Add("@UseSensoryStudies", SqlDbType.Bit).Value = data.UseSensoryStudies;
                CmdSql.Parameters.Add("@AllowCustomEmail", SqlDbType.Bit).Value = data.AllowCustomEmail;

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