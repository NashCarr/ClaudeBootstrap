using System;
using System.Data;
using CommonData.Helpers;
using DataLayerCommon.Addresses;
using static CommonData.Enums.AddressEnums;
using static CommonData.Enums.CountryEnums;

namespace DataLayerSave.Addresses
{
    public class DbAddressAssociationSave : DbSaveBase
    {
        protected internal string SavePlaceAddress(int placeId, byte placeType, AddressAssociation data)
        {
            ReturnValues.Id = placeId;
            IdParameter = "@PlaceId";

            SetConnectToDatabase("[Address].[usp_PlaceAddress_Upsert]");

            CmdSql.Parameters.Add(IdParameter, SqlDbType.Int).Value = ReturnValues.Id;
            CmdSql.Parameters.Add("@PlaceType", SqlDbType.TinyInt).Value = placeType;

            return SaveAddress(ref data);
        }

        protected internal string SavePersonAddress(int personId, byte personType, AddressAssociation data)
        {
            ReturnValues.Id = personId;
            IdParameter = "@PersonId";

            SetConnectToDatabase("[Address].[usp_PersonAddress_Upsert]");

            CmdSql.Parameters.Add(IdParameter, SqlDbType.Int).Value = ReturnValues.Id;
            CmdSql.Parameters.Add("@PersonType", SqlDbType.TinyInt).Value = personType;

            return SaveAddress(ref data);
        }

        private string SaveAddress(ref AddressAssociation data)
        {
            try
            {
                CmdSql.Parameters.Add("@AddressAssociationId", SqlDbType.Int).Value = data.AddressAssociationId;
                CmdSql.Parameters.Add("@AddressId", SqlDbType.Int).Value = data.AddressId;
                CmdSql.Parameters.Add("@AddressType", SqlDbType.TinyInt).Value =
                    EnumHelpers.GetByteFromEnum<AddressType>(data.AddressType.ToString());
                CmdSql.Parameters.Add("@Address1", SqlDbType.NVarChar, 40).Value = data.Address1?.Trim() ?? string.Empty;
                CmdSql.Parameters.Add("@Address2", SqlDbType.NVarChar, 40).Value = data.Address2?.Trim() ?? string.Empty;
                CmdSql.Parameters.Add(CreateDecimalParameter("@AddressLatitude", data.AddressCoordinates.Latitude, 10, 4));
                CmdSql.Parameters.Add(CreateDecimalParameter("@AddressLongitude", data.AddressCoordinates.Longitude, 10,
                    4));
                CmdSql.Parameters.Add("@PostalCodeId", SqlDbType.Int).Value = data.PostalCodeId;
                CmdSql.Parameters.Add("@ZipCode", SqlDbType.NVarChar, 10).Value = data.ZipCode?.Trim() ?? string.Empty;
                CmdSql.Parameters.Add("@City", SqlDbType.NVarChar, 20).Value = data.City?.Trim() ?? string.Empty;
                CmdSql.Parameters.Add("@StateProvinceId", SqlDbType.Int).Value = data.StateProvinceId;
                CmdSql.Parameters.Add("@Country", SqlDbType.SmallInt).Value =
                    EnumHelpers.GetShortFromEnum<Country>(data.Country.ToString());
                CmdSql.Parameters.Add(CreateDecimalParameter("@PostalLatitude", data.PostalCoordinates.Latitude, 10, 4));
                CmdSql.Parameters.Add(CreateDecimalParameter("@PostalLongitude", data.PostalCoordinates.Longitude, 10, 4));

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