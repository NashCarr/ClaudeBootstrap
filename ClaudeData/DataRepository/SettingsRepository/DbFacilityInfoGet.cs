using ClaudeData.DataRepository.PlaceRepository;
using ClaudeData.Models.Places;
using ClaudeData.ViewModels.Settings;
using static ClaudeCommon.Enums.PlaceEnums;

namespace ClaudeData.DataRepository.SettingsRepository
{
    public class DbFacilityInfoGet : DbGetBase
    {
        public FacilityView GetRecord(int recordId)
        {
            PlaceData p;

            using (DbPlaceDataGet a = new DbPlaceDataGet())
            {
                p = a.GetFacilityData(recordId);
            }

            using (DbPlaceDataStub a = new DbPlaceDataStub())
            {
                p = a.Prefill(PlaceType.Facility, p);
            }

            FacilityView m = new FacilityView
            {
                Place = p.Place,
                Addresses =
                {
                    MailingAddress = p.AddressData.MailingAddress,
                    ShippingAddress = p.AddressData.PhysicalAddress
                },
                Phones =
                {
                    FaxPhone = p.PhoneData.FaxPhone,
                    CellPhone = p.PhoneData.CellPhone,
                    HomePhone = p.PhoneData.HomePhone,
                    WorkPhone = p.PhoneData.WorkPhone,
                    PhoneSettings = p.PhoneData.PhoneSettings
                }
            };

            return m;
        }
    }
}