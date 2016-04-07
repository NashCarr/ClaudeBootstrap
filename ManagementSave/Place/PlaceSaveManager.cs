using System;
using CommonData.Enums;
using CommonDataSave.Places;
using CommonDataSave.Return;
using DataLayerCommon.Addresses;
using DataLayerCommon.Phones;
using DataLayerCommon.Places;
using DataLayerSave.Place;

namespace ManagementSave.Place
{
    public class PlaceSaveManager : IDisposable
    {
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool iAmBeingCalledFromDisposeAndNotFinalize)
        {
        }

        public ReturnBase SaveFacility(PlaceSaveModel p)
        {
            if (p.Place != null) p.Place.PlaceType = PlaceEnums.PlaceType.Facility;
            return SavePlace(p);
        }

        public ReturnBase SaveCustomer(PlaceSaveModel p)
        {
            if (p.Place != null) p.Place.PlaceType = PlaceEnums.PlaceType.Customer;
            return SavePlace(p);
        }

        public ReturnBase SaveOrganization(PlaceSaveModel p)
        {
            if (p.Place != null) p.Place.PlaceType = PlaceEnums.PlaceType.Organization;
            return SavePlace(p);
        }

        private static ReturnBase SavePlace(PlaceSaveModel data)
        {
            PlaceData p = new PlaceData
            {
                Place = data.Place,
                PhoneData = new PhoneData(),
                AddressData = new AddressData {UseMailingForShipping = data.UseMailingForShipping}
            };

            if (data.PhoneSetting != null)
            {
                p.PhoneData.PhoneSettings = data.PhoneSetting;
            }
            if (data.FaxPhone != null && data.FaxPhone.PhoneNumber != 0)
            {
                p.PhoneData.Phones.Add(data.FaxPhone);
            }
            if (data.CellPhone != null && data.CellPhone.PhoneNumber != 0)
            {
                p.PhoneData.Phones.Add(data.CellPhone);
            }
            if (data.HomePhone != null && data.HomePhone.PhoneNumber != 0)
            {
                p.PhoneData.Phones.Add(data.HomePhone);
            }
            if (data.WorkPhone != null && data.WorkPhone.PhoneNumber != 0)
            {
                p.PhoneData.Phones.Add(data.WorkPhone);
            }
            if (!string.IsNullOrEmpty(data.MailingAddress?.Address1))
            {
                p.AddressData.Addresses.Add(data.MailingAddress);
            }
            if (!string.IsNullOrEmpty(data.ShippingAddress?.Address1))
            {
                p.AddressData.Addresses.Add(data.ShippingAddress);
            }

            int id = p.Place.PlaceId;
            using (DbPlaceSave mgr = new DbPlaceSave())
            {
                return mgr.SavePlace(p, id);
            }
        }
    }
}