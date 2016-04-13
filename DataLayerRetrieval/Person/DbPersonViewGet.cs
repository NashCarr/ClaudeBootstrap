using CommonDataRetrieval.People;
using DataLayerCommon.People;
using static CommonData.Enums.PersonEnums;

namespace DataLayerRetrieval.Person
{
    public class DbPersonViewGet : DbGetBase
    {
        private PersonData _data;
        private PersonType _datatype;

        public PersonView GetAssessor(int recordId)
        {
            _datatype = PersonType.Assessor;
            using (DbPersonDataGet db = new DbPersonDataGet())
            {
                _data = db.GetAssessor(recordId);
            }

            return SetPersonView();
        }

        public PersonView GetCustomerContact(int recordId)
        {
            _datatype = PersonType.CustomerContact;
            using (DbPersonDataGet db = new DbPersonDataGet())
            {
                _data = db.GetCustomerContact(recordId);
            }

            return SetPersonView();
        }

        public PersonView GetOrganizationContact(int recordId)
        {
            _datatype = PersonType.OrganizationContact;
            using (DbPersonDataGet db = new DbPersonDataGet())
            {
                _data = db.GetOrganizationContact(recordId);
            }

            return SetPersonView();
        }

        public PersonView GetStaffMember(int recordId)
        {
            _datatype = PersonType.StaffMember;
            using (DbPersonDataGet db = new DbPersonDataGet())
            {
                _data = db.GetStaffMember(recordId);
            }

            return SetPersonView();
        }

        private PersonView SetPersonView()
        {
            using (DbPersonDataStub db = new DbPersonDataStub())
            {
                _data = db.Prefill(_datatype, _data);
            }

            PersonView p = new PersonView
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

            return p;
        }
    }
}