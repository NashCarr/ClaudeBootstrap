using System;
using CommonData.Enums;
using DataManagement.DataRepository.PhoneRepository;
using DataManagement.Models.Phones;
using DataManagement.Models.Places;

namespace DataManagement.DataRepository.PlaceRepository
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
                return db.SavePlacePhoneSetting(placeId, (byte) PlaceEnums.PlaceType.Facility, data);
            }
        }

        protected internal string SaveCustomerPhoneSetting(int placeId, PhoneSetting data)
        {
            if (data == null) return string.Empty;
            using (DbPhoneSettingSave db = new DbPhoneSettingSave())
            {
                return db.SavePlacePhoneSetting(placeId, (byte) PlaceEnums.PlaceType.Customer, data);
            }
        }

        protected internal string SaveOrganizationPhoneSetting(int placeId, PhoneSetting data)
        {
            if (data == null) return string.Empty;
            using (DbPhoneSettingSave db = new DbPhoneSettingSave())
            {
                return db.SavePlacePhoneSetting(placeId, (byte) PlaceEnums.PlaceType.Organization, data);
            }
        }

        protected internal string SavePlacePhoneSetting(PlaceData data)
        {
            if (data.PhoneData == null) return string.Empty;
            switch (data.Place.PlaceType)
            {
                case PlaceEnums.PlaceType.Facility:
                    return SaveFacilityPhoneSetting(data.Place.PlaceId, data.PhoneData.PhoneSettings);
                case PlaceEnums.PlaceType.Customer:
                    return SaveCustomerPhoneSetting(data.Place.PlaceId, data.PhoneData.PhoneSettings);
                case PlaceEnums.PlaceType.Organization:
                    return SaveOrganizationPhoneSetting(data.Place.PlaceId, data.PhoneData.PhoneSettings);
                case PlaceEnums.PlaceType.None:
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