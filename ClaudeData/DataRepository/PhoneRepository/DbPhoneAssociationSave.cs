﻿using System;
using System.Data;
using ClaudeCommon.Helpers;
using ClaudeData.Models.Phones;
using static ClaudeCommon.Enums.CountryEnums;
using static ClaudeCommon.Enums.PhoneEnums;

namespace ClaudeData.DataRepository.PhoneRepository
{
    public class DbPhoneAssociationSave : DbSaveBase
    {
        protected internal string SavePlacePhone(int placeId, byte placeType, PhoneAssociation data)
        {
            IdValue = placeId;
            IdParameter = "@PlaceId";

            SetConnectToDatabase("[Phone].[usp_PlacePhone_Upsert]");

            CmdSql.Parameters.Add(IdParameter, SqlDbType.Int).Value = IdValue;
            CmdSql.Parameters.Add("@PlaceType", SqlDbType.TinyInt).Value = placeType;

            return SavePhone(ref data);
        }

        protected internal string SavePersonPhone(int personId, byte personType, PhoneAssociation data)
        {
            IdValue = personId;
            IdParameter = "@PersonId";

            SetConnectToDatabase("[Phone].[usp_PersonPhone_Upsert]");

            CmdSql.Parameters.Add(IdParameter, SqlDbType.Int).Value = IdValue;
            CmdSql.Parameters.Add("@PersonType", SqlDbType.TinyInt).Value = personType;

            return SavePhone(ref data);
        }

        private string SavePhone(ref PhoneAssociation data)
        {
            try
            {
                CmdSql.Parameters.Add("@PhoneAssociationId", SqlDbType.Int).Value = data.PhoneAssociationId;
                CmdSql.Parameters.Add("@PhoneId", SqlDbType.Int).Value = data.PhoneId;
                CmdSql.Parameters.Add("@PhoneType", SqlDbType.TinyInt).Value =
                    EnumHelpers.GetShortFromEnum<PhoneType>(data.PhoneType.ToString());
                CmdSql.Parameters.Add("@PhoneNumber", SqlDbType.BigInt).Value = data.PhoneNumber;
                CmdSql.Parameters.Add("@Country", SqlDbType.SmallInt).Value =
                    EnumHelpers.GetShortFromEnum<Country>(data.Country.ToString());
                CmdSql.Parameters.Add("@IsActive", SqlDbType.Bit).Value = data.IsActive;

                SetErrMsgParameter();

                SendNonQuery();
            }
            catch (Exception ex)
            {
                ErrMsg = ex.Message;
            }
            return ErrMsg;
        }
    }
}