using ClaudeCommon.Enums;
using ClaudeData.DataRepository.PersonRepository;
using ClaudeData.Models.People;
using ClaudeData.ViewModels.Settings;

namespace ClaudeData.DataRepository.PeopleRepository
{
    public class DbPlaceContactInfoGet : DbGetBase
    {
        private PersonData _data;

        public PlaceContactView GetCustomerContact(int recordId)
        {
            using (DbPersonDataGet a = new DbPersonDataGet())
            {
                _data = a.GetCustomerContact(recordId);
            }

            using (DbPersonDataStub a = new DbPersonDataStub())
            {
                _data = a.Prefill(PersonEnums.PersonType.CustomerContact, _data);
            }

            return SetPlaceContactView();
        }

        public PlaceContactView GetOrganizationContact(int recordId)
        {
            using (DbPersonDataGet a = new DbPersonDataGet())
            {
                _data = a.GetOrganizationContact(recordId);
            }

            using (DbPersonDataStub a = new DbPersonDataStub())
            {
                _data = a.Prefill(PersonEnums.PersonType.OrganizationContact, _data);
            }

            return SetPlaceContactView();
        }

        public PlaceContactView GetStaffUser(int recordId)
        {
            using (DbPersonDataGet a = new DbPersonDataGet())
            {
                _data = a.GetStaffUser(recordId);
            }

            using (DbPersonDataStub a = new DbPersonDataStub())
            {
                _data = a.Prefill(PersonEnums.PersonType.StaffUser, _data);
            }

            return SetPlaceContactView();
        }

        private PlaceContactView SetPlaceContactView()
        {
            PlaceContactView m = new PlaceContactView
            {
                Person = _data.Person,
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