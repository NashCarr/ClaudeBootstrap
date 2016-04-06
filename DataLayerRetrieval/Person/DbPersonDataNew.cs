using System;
using System.Collections.Generic;
using System.Linq;
using DataLayerCommon.Addresses;
using DataLayerCommon.People;
using DataLayerCommon.Phones;
using static CommonData.Enums.AddressEnums;
using static CommonData.Enums.PersonEnums;
using static CommonData.Enums.PhoneEnums;

namespace DataLayerRetrieval.Person
{
    public class DbPersonDataNew : IDisposable
    {
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public PersonData GetNew(PersonType personType)
        {
            PersonData data = new PersonData();
            try
            {
                data.Person = new DataLayerCommon.People.Person
                {
                    PersonType = personType
                };

                data.AddressData = new AddressData {Addresses = new List<AddressAssociation>()};

                foreach (
                    AddressAssociation aa in
                        from AddressType val in Enum.GetValues(typeof (AddressType))
                        where (short) val != 0
                        select new AddressAssociation {AddressType = val})
                {
                    data.AddressData.Addresses.Add(aa);
                }

                data.PhoneData = new PhoneData {Phones = new List<PhoneAssociation>()};

                foreach (
                    PhoneAssociation pa in
                        from PhoneType val in Enum.GetValues(typeof (PhoneType))
                        where (short) val != 0
                        select new PhoneAssociation {PhoneType = val})
                {
                    data.PhoneData.Phones.Add(pa);
                }
            }
            catch (Exception ex)
            {
                data.Person = new DataLayerCommon.People.Person();
            }
            return data;
        }

        protected virtual void Dispose(bool iAmBeingCalledFromDisposeAndNotFinalize)
        {
        }
    }
}