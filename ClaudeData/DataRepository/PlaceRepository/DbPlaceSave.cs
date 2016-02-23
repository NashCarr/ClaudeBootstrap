using System;
using System.Data;
using ClaudeData.Models.Places;
using static ClaudeCommon.Enums.PlaceEnums;

namespace ClaudeData.DataRepository.PlaceRepository
{
    public class DbPlaceSave : DbSaveBase
    {
        private string AddUpdatePlace(ref Place data)
        {
            try
            {
                ReturnValues.Id = data.PlaceId;
                SetIdInputOutputParameter();

                CmdSql.Parameters.Add("@Name", SqlDbType.NVarChar, 50).Value = data.Name?.Trim() ?? string.Empty;
                CmdSql.Parameters.Add("@Division", SqlDbType.NVarChar, 50).Value = data.Division?.Trim() ?? string.Empty;
                CmdSql.Parameters.Add("@Department", SqlDbType.NVarChar, 50).Value = data.Department?.Trim() ?? string.Empty;
                CmdSql.Parameters.Add("@TimeZone", SqlDbType.TinyInt).Value = data.TimeZone;
                CmdSql.Parameters.Add("@Country", SqlDbType.SmallInt).Value = data.Country;
                CmdSql.Parameters.Add("@DisplayOrder", SqlDbType.Int).Value = data.DisplayOrder;
                CmdSql.Parameters.Add("@IsActive", SqlDbType.Bit).Value = data.IsActive;

                SetErrMsgParameter();

                SendNonQueryGetId();

                data.PlaceId = ReturnValues.Id;
            }
            catch (Exception ex)
            {
                ReturnValues.ErrMsg = ex.Message;
            }
            return ReturnValues.ErrMsg;
        }

        protected internal string SaveFacility(ref Place data)
        {
            if (string.IsNullOrEmpty(data.Name))
            {
                SetEmptyStringMessage("Name");
                return ReturnValues.ErrMsg;
            }

            IdParameter = "@FacilityId";

            SetConnectToDatabase("[Admin].[usp_Facility_Upsert]");

            return AddUpdatePlace(ref data);
        }

        public string SaveCustomer(ref Place data)
        {
            if (string.IsNullOrEmpty(data.Name))
            {
                SetEmptyStringMessage("Name");
                return ReturnValues.ErrMsg;
            }

            IdParameter = "@CustomerId";

            SetConnectToDatabase("[Admin].[usp_Customer_Upsert]");

            return AddUpdatePlace(ref data);
        }

        protected internal string SaveOrganization(ref Place data)
        {
            if (string.IsNullOrEmpty(data.Name))
            {
                SetEmptyStringMessage("Name");
                return ReturnValues.ErrMsg;
            }

            IdParameter = "@OrganizationId";

            SetConnectToDatabase("[FundRaising].[usp_Organization_Upsert]");

            return AddUpdatePlace(ref data);
        }

        protected internal string SaveFacilityData(PlaceData data, ref int placeId)
        {
            Place p = data.Place;

            if (p.PlaceId != placeId)
            {
                placeId = p.PlaceId;
            }

            string msg = SaveFacility(ref p);
            if (msg.Length != 0) return msg;

            using (DbPlaceAddressSave db = new DbPlaceAddressSave())
            {
                msg = db.SaveFacilityAddresses(placeId, data.AddressData.Addresses);
            }
            if (msg.Length != 0) return msg;

            using (DbPlacePhoneSave db = new DbPlacePhoneSave())
            {
                msg = db.SaveFacilityPhones(placeId, data.PhoneData.Phones);
            }
            if (msg.Length != 0) return msg;

            using (DbPlacePhoneSettingSave db = new DbPlacePhoneSettingSave())
            {
                msg = db.SaveFacilityPhoneSetting(placeId, data.PhoneData.PhoneSettings);
            }
            return msg;
        }

        protected internal string SaveCustomerData(PlaceData data, ref int placeId)
        {
            Place p = data.Place;

            if (p.PlaceId != placeId)
            {
                placeId = p.PlaceId;
            }

            string msg = SaveCustomer(ref p);
            if (msg.Length != 0) return msg;

            using (DbPlaceAddressSave db = new DbPlaceAddressSave())
            {
                msg = db.SaveCustomerAddresses(placeId, data.AddressData.Addresses);
            }
            if (msg.Length != 0) return msg;

            using (DbPlacePhoneSave db = new DbPlacePhoneSave())
            {
                msg = db.SaveCustomerPhones(placeId, data.PhoneData.Phones);
            }
            if (msg.Length != 0) return msg;

            using (DbPlacePhoneSettingSave db = new DbPlacePhoneSettingSave())
            {
                msg = db.SaveCustomerPhoneSetting(placeId, data.PhoneData.PhoneSettings);
            }
            return msg;
        }

        protected internal string SaveOrganizationData(PlaceData data, ref int placeId)
        {
            Place p = data.Place;

            if (p.PlaceId != placeId)
            {
                placeId = p.PlaceId;
            }

            string msg = SaveOrganization(ref p);
            if (msg.Length != 0) return msg;

            using (DbPlaceAddressSave db = new DbPlaceAddressSave())
            {
                msg = db.SaveOrganizationAddresses(placeId, data.AddressData.Addresses);
            }
            if (msg.Length != 0) return msg;

            using (DbPlacePhoneSave db = new DbPlacePhoneSave())
            {
                msg = db.SaveOrganizationPhones(placeId, data.PhoneData.Phones);
            }
            if (msg.Length != 0) return msg;

            using (DbPlacePhoneSettingSave db = new DbPlacePhoneSettingSave())
            {
                msg = db.SaveOrganizationPhoneSetting(placeId, data.PhoneData.PhoneSettings);
            }

            return msg;
        }

        protected internal string SavePlace(PlaceData data, ref int placeId)
        {
            switch (data.Place.PlaceType)
            {
                case PlaceType.Facility:
                    return SaveFacilityData(data, ref placeId);
                case PlaceType.Customer:
                    return SaveCustomerData(data, ref placeId);
                case PlaceType.Organization:
                    return SaveOrganizationData(data, ref placeId);
                default:
                    return "Place Type Undetermined";
            }
        }
    }
}