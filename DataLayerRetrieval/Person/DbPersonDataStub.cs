using System;
using System.Collections.Generic;
using DataLayerCommon.Addresses;
using DataLayerCommon.People;
using DataLayerCommon.Phones;
using static CommonData.Enums.AddressEnums;
using static CommonData.Enums.PersonEnums;
using static CommonData.Enums.PhoneEnums;

namespace DataLayerRetrieval.Person
{
    public class DbPersonDataStub : IDisposable
    {
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected internal PersonData Prefill(PersonType personType, PersonData data)
        {
            try
            {
                if (data.Person == null)
                {
                    data.Person = new DataLayerCommon.People.Person
                    {
                        PersonType = personType
                    };
                }

                if (data.AddressData == null)
                {
                    data.AddressData = new AddressData {Addresses = new List<AddressAssociation>()};
                }

                if (data.AddressData.PhysicalAddress == null)
                {
                    AddressAssociation a = new AddressAssociation {AddressType = AddressType.Physical};
                    data.AddressData.Addresses.Add(a);
                }

                if (data.AddressData.MailingAddress == null)
                {
                    AddressAssociation a = new AddressAssociation {AddressType = AddressType.Mailing};
                    data.AddressData.Addresses.Add(a);
                }

                if (data.PhoneData == null)
                {
                    data.PhoneData = new PhoneData {Phones = new List<PhoneAssociation>()};
                }

                if (data.PhoneData.HomePhone == null)
                {
                    PhoneAssociation p = new PhoneAssociation {PhoneType = PhoneType.Home};
                    data.PhoneData.Phones.Add(p);
                }

                if (data.PhoneData.CellPhone == null)
                {
                    PhoneAssociation p = new PhoneAssociation {PhoneType = PhoneType.Cell};
                    data.PhoneData.Phones.Add(p);
                }

                if (data.PhoneData.WorkPhone == null)
                {
                    PhoneAssociation p = new PhoneAssociation {PhoneType = PhoneType.Work};
                    data.PhoneData.Phones.Add(p);
                }

                if (data.PhoneData.FaxPhone == null)
                {
                    PhoneAssociation p = new PhoneAssociation {PhoneType = PhoneType.Fax};
                    data.PhoneData.Phones.Add(p);
                }
            }
            catch (Exception ex)
            {
                data.Person = new DataLayerCommon.People.Person {ErrMsg = ex.ToString()};
            }
            return data;
        }

        protected virtual void Dispose(bool iAmBeingCalledFromDisposeAndNotFinalize)
        {
        }
    }
}