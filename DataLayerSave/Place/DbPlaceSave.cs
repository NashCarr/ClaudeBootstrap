﻿using System;
using System.Data;
using CommonDataReturn;
using DataLayerCommon.Places;
using DataLayerSave.Addresses;
using DataLayerSave.Phones;
using static CommonData.Enums.PlaceEnums;

namespace DataLayerSave.Place
{
    public class DbPlaceSave : DbSaveBase
    {
        private ReturnBase AddUpdatePlace(ref PlaceBase data)
        {
            try
            {
                ReturnValues.Id = data.PlaceId;
                SetIdInputOutputParameter();

                CmdSql.Parameters.Add("@Name", SqlDbType.NVarChar, 50).Value = data.Name?.Trim() ?? string.Empty;
                CmdSql.Parameters.Add("@Division", SqlDbType.NVarChar, 50).Value = data.Division?.Trim() ?? string.Empty;
                CmdSql.Parameters.Add("@Department", SqlDbType.NVarChar, 50).Value = data.Department?.Trim() ??
                                                                                     string.Empty;
                CmdSql.Parameters.Add("@TimeZone", SqlDbType.TinyInt).Value = data.TimeZone;
                CmdSql.Parameters.Add("@Country", SqlDbType.SmallInt).Value = data.Country;
                CmdSql.Parameters.Add("@DisplayOrder", SqlDbType.Int).Value = data.DisplayOrder;

                SetErrMsgParameter();

                SendNonQueryGetId();

                data.PlaceId = ReturnValues.Id;
            }
            catch (Exception ex)
            {
                ReturnValues.ErrMsg = ex.Message;
            }
            return ReturnValues;
        }

        protected internal ReturnBase SaveFacility(ref PlaceBase data)
        {
            if (string.IsNullOrEmpty(data.Name))
            {
                SetEmptyStringMessage("Name");
                return ReturnValues;
            }

            IdParameter = "@FacilityId";

            SetConnectToDatabase("[Facility].[usp_Upsert]");

            return AddUpdatePlace(ref data);
        }

        public ReturnBase SaveCustomer(ref PlaceBase data)
        {
            if (string.IsNullOrEmpty(data.Name))
            {
                SetEmptyStringMessage("Name");
                return ReturnValues;
            }

            IdParameter = "@CustomerId";

            SetConnectToDatabase("[Customer].[usp_Upsert]");

            return AddUpdatePlace(ref data);
        }

        protected internal ReturnBase SaveOrganization(ref PlaceBase data)
        {
            if (string.IsNullOrEmpty(data.Name))
            {
                SetEmptyStringMessage("Name");
                return ReturnValues;
            }

            IdParameter = "@OrganizationId";

            SetConnectToDatabase("[FundRaising].[usp_Organization_Upsert]");

            return AddUpdatePlace(ref data);
        }

        protected internal ReturnBase SaveFacilityData(PlaceData data, ref int placeId)
        {
            PlaceBase p = data.Place;

            ReturnBase rb = SaveFacility(ref p);
            if (rb.ErrMsg.Length != 0) return rb;

            if (p.PlaceId != placeId)
            {
                placeId = p.PlaceId;
            }

            string msg;
            if (data.AddressData?.Addresses != null)
            {
                if (data.AddressData.Addresses.Count != 0)
                {
                    using (DbPlaceAddressSave db = new DbPlaceAddressSave())
                    {
                        msg = db.SaveFacilityAddresses(placeId, data.AddressData.Addresses);
                        if (msg.Length != 0)
                        {
                            rb.ErrMsg = msg;
                            return rb;
                        }
                    }
                }
            }

            if (data.PhoneData == null) return rb;

            if (data.PhoneData.Phones != null)
            {
                if (data.PhoneData.Phones.Count != 0)
                {
                    using (DbPlacePhoneSave db = new DbPlacePhoneSave())
                    {
                        msg = db.SaveFacilityPhones(placeId, data.PhoneData.Phones);
                        if (msg.Length != 0)
                        {
                            rb.ErrMsg = msg;
                            return rb;
                        }
                    }
                }
            }

            if (data.PhoneData.PhoneSettings == null) return rb;

            using (DbPlacePhoneSettingSave db = new DbPlacePhoneSettingSave())
            {
                msg = db.SaveFacilityPhoneSetting(placeId, data.PhoneData.PhoneSettings);
                if (msg.Length == 0) return rb;
                rb.ErrMsg = msg;
            }
            return rb;
        }

        protected internal ReturnBase SaveCustomerData(PlaceData data, ref int placeId)
        {
            PlaceBase p = data.Place;

            ReturnBase rb = SaveCustomer(ref p);
            if (rb.ErrMsg.Length != 0) return rb;

            if (p.PlaceId != placeId)
            {
                placeId = p.PlaceId;
            }

            string msg;
            if (data.AddressData?.Addresses != null)
            {
                if (data.AddressData.Addresses.Count != 0)
                {
                    using (DbPlaceAddressSave db = new DbPlaceAddressSave())
                    {
                        msg = db.SaveCustomerAddresses(placeId, data.AddressData.Addresses);
                        if (msg.Length != 0)
                        {
                            rb.ErrMsg = msg;
                            return rb;
                        }
                    }
                }
            }

            if (data.PhoneData == null) return rb;

            if (data.PhoneData.Phones != null)
            {
                if (data.PhoneData.Phones.Count != 0)
                {
                    using (DbPlacePhoneSave db = new DbPlacePhoneSave())
                    {
                        msg = db.SaveCustomerPhones(placeId, data.PhoneData.Phones);
                        if (msg.Length != 0)
                        {
                            rb.ErrMsg = msg;
                            return rb;
                        }
                    }
                }
            }

            if (data.PhoneData.PhoneSettings == null) return rb;

            using (DbPlacePhoneSettingSave db = new DbPlacePhoneSettingSave())
            {
                msg = db.SaveCustomerPhoneSetting(placeId, data.PhoneData.PhoneSettings);
                if (msg.Length == 0) return rb;
                rb.ErrMsg = msg;
            }
            return rb;
        }

        protected internal ReturnBase SaveOrganizationData(PlaceData data, ref int placeId)
        {
            PlaceBase p = data.Place;

            ReturnBase rb = SaveOrganization(ref p);
            if (rb.ErrMsg.Length != 0) return rb;

            if (p.PlaceId != placeId)
            {
                placeId = p.PlaceId;
            }

            string msg;
            if (data.AddressData?.Addresses != null)
            {
                if (data.AddressData.Addresses.Count != 0)
                {
                    using (DbPlaceAddressSave db = new DbPlaceAddressSave())
                    {
                        msg = db.SaveOrganizationAddresses(placeId, data.AddressData.Addresses);
                        if (msg.Length != 0)
                        {
                            rb.ErrMsg = msg;
                            return rb;
                        }
                    }
                }
            }

            if (data.PhoneData == null) return rb;

            if (data.PhoneData.Phones != null)
            {
                if (data.PhoneData.Phones.Count != 0)
                {
                    using (DbPlacePhoneSave db = new DbPlacePhoneSave())
                    {
                        msg = db.SaveOrganizationPhones(placeId, data.PhoneData.Phones);
                        if (msg.Length != 0)
                        {
                            rb.ErrMsg = msg;
                            return rb;
                        }
                    }
                }
            }

            if (data.PhoneData.PhoneSettings == null) return rb;

            using (DbPlacePhoneSettingSave db = new DbPlacePhoneSettingSave())
            {
                msg = db.SaveOrganizationPhoneSetting(placeId, data.PhoneData.PhoneSettings);
                if (msg.Length == 0) return rb;
                rb.ErrMsg = msg;
            }
            return rb;
        }

        public ReturnBase SavePlace(PlaceData data, int placeId)
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
                    return new ReturnBase {ErrMsg = "Place Type Undetermined"};
            }
        }
    }
}