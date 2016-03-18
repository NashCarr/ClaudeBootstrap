using ClaudeCommon.Enums;
using ClaudeData.DataRepository.PlaceRepository;
using ClaudeData.Models.Places;
using ClaudeData.ViewModels.Settings;

namespace ClaudeData.DataRepository.PlacesRepository
{
    public class DbPlaceInfoGet : DbGetBase
    {
        private PlaceData _data;

        public PlaceView GetCustomer(int recordId)
        {
            using (DbPlaceDataGet a = new DbPlaceDataGet())
            {
                _data = a.GetCustomerData(recordId);
            }

            using (DbPlaceDataStub a = new DbPlaceDataStub())
            {
                _data = a.Prefill(PlaceEnums.PlaceType.Customer, _data);
            }

            return SetPlaceView();
        }

        public PlaceView GetOrganization(int recordId)
        {
            using (DbPlaceDataGet a = new DbPlaceDataGet())
            {
                _data = a.GetOrganizationData(recordId);
            }

            using (DbPlaceDataStub a = new DbPlaceDataStub())
            {
                _data = a.Prefill(PlaceEnums.PlaceType.Organization, _data);
            }

            return SetPlaceView();
        }

        public PlaceView GetFacility(int recordId)
        {
            using (DbPlaceDataGet a = new DbPlaceDataGet())
            {
                _data = a.GetFacilityData(recordId);
            }

            using (DbPlaceDataStub a = new DbPlaceDataStub())
            {
                _data = a.Prefill(PlaceEnums.PlaceType.Facility, _data);
            }

            return SetPlaceView();
        }

        private PlaceView SetPlaceView()
        {
            PlaceView m = new PlaceView
            {
                Place = _data.Place,
                Contacts = _data.Contacts,
                Addresses =
                {
                    MailingAddress = _data.AddressData.MailingAddress,
                    ShippingAddress = _data.AddressData.PhysicalAddress
                },
                Phones =
                {
                    FaxPhone = _data.PhoneData.FaxPhone,
                    CellPhone = _data.PhoneData.CellPhone,
                    HomePhone = _data.PhoneData.HomePhone,
                    WorkPhone = _data.PhoneData.WorkPhone,
                    PhoneSettings = _data.PhoneData.PhoneSettings
                }
            };

            _data = null;

            return m;
        }
    }
}