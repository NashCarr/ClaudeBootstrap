using System;
using System.Collections.Generic;
using System.Linq;
using DataLayerCommon.Addresses;
using DataLayerCommon.Enums;
using DataLayerCommon.Places;

namespace DataLayerSave.Addresses
{
    public class DbPlaceAddressSave : IDisposable
    {
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected internal string SaveFacilityAddress(int placeId, AddressAssociation data)
        {
            if (data == null) return string.Empty;
            using (DbAddressAssociationSave db = new DbAddressAssociationSave())
            {
                return db.SavePlaceAddress(placeId, (byte) PlaceEnums.PlaceType.Facility, data);
            }
        }

        protected internal string SaveCustomerAddress(int placeId, AddressAssociation data)
        {
            if (data == null) return string.Empty;
            using (DbAddressAssociationSave db = new DbAddressAssociationSave())
            {
                return db.SavePlaceAddress(placeId, (byte) PlaceEnums.PlaceType.Customer, data);
            }
        }

        protected internal string SaveOrganizationAddress(int placeId, AddressAssociation data)
        {
            if (data == null) return string.Empty;
            using (DbAddressAssociationSave db = new DbAddressAssociationSave())
            {
                return db.SavePlaceAddress(placeId, (byte) PlaceEnums.PlaceType.Organization, data);
            }
        }

        protected internal string SaveFacilityAddresses(int placeId, List<AddressAssociation> data)
        {
            string msg = string.Empty;
            if (data == null) return msg;
            foreach (AddressAssociation item in data.Where(item => !string.IsNullOrEmpty(item.Address1)))
            {
                msg = SaveFacilityAddress(placeId, item);
                if (msg.Length == 0) continue;
                break;
            }
            return msg;
        }

        protected internal string SaveCustomerAddresses(int placeId, List<AddressAssociation> data)
        {
            string msg = string.Empty;
            if (data == null) return msg;
            foreach (AddressAssociation item in data.Where(item => !string.IsNullOrEmpty(item.Address1)))
            {
                msg = SaveCustomerAddress(placeId, item);
                if (msg.Length == 0) continue;
                break;
            }
            return msg;
        }

        protected internal string SaveOrganizationAddresses(int placeId, List<AddressAssociation> data)
        {
            string msg = string.Empty;
            if (data == null) return msg;
            foreach (AddressAssociation item in data.Where(item => !string.IsNullOrEmpty(item.Address1)))
            {
                msg = SaveOrganizationAddress(placeId, item);
                if (msg.Length == 0) continue;
                break;
            }
            return msg;
        }

        protected internal string SavePlaceAddresses(PlaceData data)
        {
            if (data.AddressData == null) return string.Empty;
            switch (data.Place.PlaceType)
            {
                case PlaceEnums.PlaceType.Facility:
                    return SaveFacilityAddresses(data.Place.PlaceId, data.AddressData.Addresses);
                case PlaceEnums.PlaceType.Customer:
                    return SaveCustomerAddresses(data.Place.PlaceId, data.AddressData.Addresses);
                case PlaceEnums.PlaceType.Organization:
                    return SaveOrganizationAddresses(data.Place.PlaceId, data.AddressData.Addresses);
                default:
                    return "Place Type Undetermined";
            }
        }

        protected virtual void Dispose(bool iAmBeingCalledFromDisposeAndNotFinalize)
        {
        }
    }
}