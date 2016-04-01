using System;
using System.Data;
using DataManagement.Models.Phones;

namespace DataManagement.DataRepository.PhoneRepository
{
    public class DbPhoneSettingSave : DbSaveBase
    {
        protected internal string SavePlacePhoneSetting(int placeId, byte placeType, PhoneSetting data)
        {
            ReturnValues.Id = data.RecordId;
            IdParameter = "@PlacePhoneSettingId";

            SetConnectToDatabase("[Phone].[usp_PlacePhoneSetting_Upsert]");

            CmdSql.Parameters.Add(IdParameter, SqlDbType.Int).Value = ReturnValues.Id;
            CmdSql.Parameters.Add("@PlaceId", SqlDbType.TinyInt).Value = placeId;
            CmdSql.Parameters.Add("@PlaceType", SqlDbType.TinyInt).Value = placeType;

            return SavePhoneSetting(ref data);
        }

        protected internal string SavePersonPhoneSetting(int personId, byte personType, PhoneSetting data)
        {
            ReturnValues.Id = data.RecordId;
            IdParameter = "@PersonPhoneSettingId";

            SetConnectToDatabase("[Phone].[usp_PersonPhoneSetting_Upsert]");

            CmdSql.Parameters.Add(IdParameter, SqlDbType.Int).Value = ReturnValues.Id;
            CmdSql.Parameters.Add("@PersonId", SqlDbType.TinyInt).Value = personId;
            CmdSql.Parameters.Add("@PersonType", SqlDbType.TinyInt).Value = personType;

            return SavePhoneSetting(ref data);
        }

        private string SavePhoneSetting(ref PhoneSetting data)
        {
            try
            {
                CmdSql.Parameters.Add("@PrimaryPhoneType", SqlDbType.TinyInt).Value = data.PrimaryPhoneType;
                CmdSql.Parameters.Add("@MobileCarrierId", SqlDbType.Int).Value = data.MobileCarrier;
                CmdSql.Parameters.Add("@AllowText", SqlDbType.Bit).Value = data.AllowText;

                SetErrMsgParameter();

                SendNonQuery();
            }
            catch (Exception ex)
            {
                ReturnValues.ErrMsg = ex.Message;
            }
            return ReturnValues.ErrMsg;
        }
    }
}