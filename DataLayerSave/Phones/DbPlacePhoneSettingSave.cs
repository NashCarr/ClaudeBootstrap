using System;
using DataLayerCommon.Phones;
using DataLayerCommon.Places;
using static CommonData.Enums.PlaceEnums;

namespace DataLayerSave.Phones
{
    public class DbPlacePhoneSettingSave : IDisposable
    {
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected internal string SaveFacilityPhoneSetting(int placeId, PhoneSetting data)
        {
            if (data == null) return string.Empty;
            using (DbPhoneSettingSave db = new DbPhoneSettingSave())
            {
                return db.SavePlacePhoneSetting(placeId, (byte) PlaceType.Facility, data);
            }
        }

        protected internal string SaveCustomerPhoneSetting(int placeId, PhoneSetting data)
        {
            if (data == null) return string.Empty;
            using (DbPhoneSettingSave db = new DbPhoneSettingSave())
            {
                return db.SavePlacePhoneSetting(placeId, (byte) PlaceType.Customer, data);
            }
        }

        protected internal string SaveOrganizationPhoneSetting(int placeId, PhoneSetting data)
        {
            if (data == null) return string.Empty;
            using (DbPhoneSettingSave db = new DbPhoneSettingSave())
            {
                return db.SavePlacePhoneSetting(placeId, (byte) PlaceType.Organization, data);
            }
        }

        protected internal string SavePlacePhoneSetting(PlaceData data)
        {
            if (data.PhoneData == null) return string.Empty;
            switch (data.Place.PlaceType)
            {
                case PlaceType.Facility:
                    return SaveFacilityPhoneSetting(data.Place.PlaceId, data.PhoneData.PhoneSettings);
                case PlaceType.Customer:
                    return SaveCustomerPhoneSetting(data.Place.PlaceId, data.PhoneData.PhoneSettings);
                case PlaceType.Organization:
                    return SaveOrganizationPhoneSetting(data.Place.PlaceId, data.PhoneData.PhoneSettings);
                case PlaceType.None:
                    return "Place Type Undetermined";
                default:
                    return "Place Type Undetermined";
            }
        }

        protected virtual void Dispose(bool iAmBeingCalledFromDisposeAndNotFinalize)
        {
        }
    }
}