﻿using System;
using System.Data;
using DataLayerSaveCommon;
using SaveDataCommon;
using SaveDataCommon.Return;

namespace DataLayerSave.Administration
{
    public class DbHearAboutUsSave : DbSaveBase
    {
        public ReturnBase SetInactive(int id)
        {
            ReturnValues.Id = id;
            try
            {
                SetConnectToDatabase("[HearAboutUs].[usp_SetInactive]");

                CmdSql.Parameters.Add("@HearAboutUsId", SqlDbType.Int).Value = ReturnValues.Id;

                SetErrMsgParameter();

                SendNonQuery();
            }
            catch (Exception ex)
            {
                ReturnValues.ErrMsg = ex.Message;
            }

            return ReturnValues;
        }

        public ReturnBase AddUpdateRecord(SaveBase data)
        {
            ReturnValues.Id = data.Id;

            if (!string.IsNullOrEmpty(data.Name)) return SaveRecord(data);

            SetEmptyStringMessage("Hear About Us");
            return ReturnValues;
        }

        private ReturnBase SaveRecord(SaveBase data)
        {
            try
            {
                IdParameter = "@HearAboutUsId";

                SetConnectToDatabase("[HearAboutUs].[usp_Upsert]");

                SetIdInputOutputParameter();

                CmdSql.Parameters.Add("@Name", SqlDbType.NVarChar, 50).Value = data.Name.Trim();

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