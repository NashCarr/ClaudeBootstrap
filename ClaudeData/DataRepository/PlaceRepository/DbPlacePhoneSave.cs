﻿using System;
using System.Collections.Generic;
using System.Linq;
using CommonData.Enums;
using DataManagement.DataRepository.PhoneRepository;
using DataManagement.Models.Phones;
using DataManagement.Models.Places;

namespace DataManagement.DataRepository.PlaceRepository
{
    public class DbPlacePhoneSave : IDisposable
    {
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected internal string SaveFacilityPhone(int placeId, PhoneAssociation data)
        {
            if (data == null) return string.Empty;
            if (data.PhoneNumber == 0) return "Phone Number Cannot Be Zero";
            using (DbPhoneAssociationSave db = new DbPhoneAssociationSave())
            {
                return db.SavePlacePhone(placeId, (byte) PlaceEnums.PlaceType.Facility, data);
            }
        }

        public string SaveCustomerPhone(int placeId, PhoneAssociation data)
        {
            if (data == null) return string.Empty;
            if (data.PhoneNumber == 0) return "Phone Number Cannot Be Zero";
            using (DbPhoneAssociationSave db = new DbPhoneAssociationSave())
            {
                return db.SavePlacePhone(placeId, (byte) PlaceEnums.PlaceType.Customer, data);
            }
        }

        protected internal string SaveOrganizationPhone(int placeId, PhoneAssociation data)
        {
            if (data == null) return string.Empty;
            if (data.PhoneNumber == 0) return "Phone Number Cannot Be Zero";
            using (DbPhoneAssociationSave db = new DbPhoneAssociationSave())
            {
                return db.SavePlacePhone(placeId, (byte) PlaceEnums.PlaceType.Organization, data);
            }
        }

        protected internal string SaveFacilityPhones(int placeId, List<PhoneAssociation> data)
        {
            string msg = string.Empty;
            if (data == null) return msg;
            foreach (PhoneAssociation item in data.Where(item => item.PhoneNumber != 0))
            {
                msg = SaveFacilityPhone(placeId, item);
                if (msg.Length == 0) continue;
                break;
            }
            return msg;
        }

        protected internal string SaveCustomerPhones(int placeId, List<PhoneAssociation> data)
        {
            string msg = string.Empty;
            if (data == null) return msg;
            foreach (PhoneAssociation item in data.Where(item => item.PhoneNumber != 0))
            {
                msg = SaveCustomerPhone(placeId, item);
                if (msg.Length == 0) continue;
                break;
            }
            return msg;
        }

        protected internal string SaveOrganizationPhones(int placeId, List<PhoneAssociation> data)
        {
            string msg = string.Empty;
            if (data == null) return msg;
            foreach (PhoneAssociation item in data.Where(item => item.PhoneNumber != 0))
            {
                msg = SaveOrganizationPhone(placeId, item);
                if (msg.Length == 0) continue;
                break;
            }
            return msg;
        }

        protected internal string SavePlacePhones(PlaceData data)
        {
            if (data.PhoneData == null) return string.Empty;
            switch (data.Place.PlaceType)
            {
                case PlaceEnums.PlaceType.Facility:
                    return SaveFacilityPhones(data.Place.PlaceId, data.PhoneData.Phones);
                case PlaceEnums.PlaceType.Customer:
                    return SaveCustomerPhones(data.Place.PlaceId, data.PhoneData.Phones);
                case PlaceEnums.PlaceType.Organization:
                    return SaveOrganizationPhones(data.Place.PlaceId, data.PhoneData.Phones);
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