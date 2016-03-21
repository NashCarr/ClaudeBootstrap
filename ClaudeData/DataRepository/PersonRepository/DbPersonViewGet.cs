using ClaudeCommon.Enums;
using ClaudeData.Models.People;
using ClaudeData.ViewModels;

namespace ClaudeData.DataRepository.PersonRepository
{
    public class DbPersonViewGet : DbGetBase
    {
        private PersonData _data;

        public PersonView GetCustomerContact(int recordId)
        {
            using (DbPersonDataGet a = new DbPersonDataGet())
            {
                _data = a.GetCustomerContact(recordId);
            }

            using (DbPersonDataStub a = new DbPersonDataStub())
            {
                _data = a.Prefill(PersonEnums.PersonType.CustomerContact, _data);
            }

            return SetPersonView();
        }

        public PersonView GetOrganizationContact(int recordId)
        {
            using (DbPersonDataGet a = new DbPersonDataGet())
            {
                _data = a.GetOrganizationContact(recordId);
            }

            using (DbPersonDataStub a = new DbPersonDataStub())
            {
                _data = a.Prefill(PersonEnums.PersonType.OrganizationContact, _data);
            }

            return SetPersonView();
        }

        public PersonView GetStaffMember(int recordId)
        {
            using (DbPersonDataGet a = new DbPersonDataGet())
            {
                _data = a.GetStaffMember(recordId);
            }

            using (DbPersonDataStub a = new DbPersonDataStub())
            {
                _data = a.Prefill(PersonEnums.PersonType.StaffMember, _data);
            }

            return SetPersonView();
        }

        private PersonView SetPersonView()
        {
            PersonView m = new PersonView
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