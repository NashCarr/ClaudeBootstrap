using System;
using ClaudeCommon.BaseModels.Returns;
using ClaudeData.DataRepository.PlaceRepository;
using ClaudeData.Models.Addresses;
using ClaudeData.Models.Phones;
using ClaudeData.Models.Places;
using ClaudeViewManagement.ViewModels.Places;

namespace ClaudeViewManagement.Managers.Places
{
    public class PlaceManager : IDisposable
    {
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool iAmBeingCalledFromDisposeAndNotFinalize)
        {
        }

        public ReturnBase SavePlace(PlaceSaveModel data)
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
            if (data.MailingAddress.Address1 != null && data.MailingAddress != null &&
                data.MailingAddress.Address1.Length != 0)
            {
                p.AddressData.Addresses.Add(data.MailingAddress);
            }
            if (data.ShippingAddress.Address1 != null && data.ShippingAddress != null &&
                data.ShippingAddress.Address1.Length != 0)
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