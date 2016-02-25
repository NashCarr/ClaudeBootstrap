using System;
using ClaudeCommon.BaseModels.Returns;
using ClaudeData.DataRepository.PlaceRepository;
using ClaudeData.Models.Addresses;
using ClaudeData.Models.Phones;
using ClaudeData.Models.Places;
using ClaudeData.ViewModels.Settings;
using static ClaudeCommon.Enums.AddressEnums;
using static ClaudeCommon.Enums.PhoneEnums;

namespace ClaudeData.DataRepository.SettingsRepository
{
    public class DbCustomerSave : IDisposable
    {
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public ReturnBase SaveCustomer(ref CustomerView data, ref int placeId)
        {
            try
            {
                data.Phones.FaxPhone.PhoneType = PhoneType.Fax;
                data.Phones.CellPhone.PhoneType = PhoneType.Cell;
                data.Phones.HomePhone.PhoneType = PhoneType.Home;
                data.Phones.WorkPhone.PhoneType = PhoneType.Work;

                data.Addresses.MailingAddress.AddressType = AddressType.Mailing;
                data.Addresses.ShippingAddress.AddressType = AddressType.Physical;

                PlaceData p = new PlaceData
                {
                    Place = data.Place,
                    AddressData = new AddressData(),
                    PhoneData = new PhoneData {PhoneSettings = data.Phones.PhoneSettings}
                };

                p.PhoneData.Phones.Add(data.Phones.FaxPhone);
                p.PhoneData.Phones.Add(data.Phones.CellPhone);
                p.PhoneData.Phones.Add(data.Phones.HomePhone);
                p.PhoneData.Phones.Add(data.Phones.WorkPhone);

                p.AddressData.Addresses.Add(data.Addresses.MailingAddress);
                p.AddressData.Addresses.Add(data.Addresses.ShippingAddress);

                using (DbPlaceSave db = new DbPlaceSave())
                {
                    return db.SaveCustomerData(p, ref placeId);
                }
            }
            catch (Exception ex)
            {
                return new ReturnBase {ErrMsg = ex.Message};
            }
        }

        protected virtual void Dispose(bool iAmBeingCalledFromDisposeAndNotFinalize)
        {
        }
    }
}