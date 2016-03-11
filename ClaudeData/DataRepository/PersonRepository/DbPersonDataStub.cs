using System;
using System.Collections.Generic;
using ClaudeData.Models.Addresses;
using ClaudeData.Models.People;
using ClaudeData.Models.Phones;
using static ClaudeCommon.Enums.AddressEnums;
using static ClaudeCommon.Enums.PersonEnums;
using static ClaudeCommon.Enums.PhoneEnums;

namespace ClaudeData.DataRepository.PersonRepository
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
                    data.Person = new Person
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
                data.Person = new Person {ErrMsg = ex.ToString()};
            }
            return data;
        }

        protected virtual void Dispose(bool iAmBeingCalledFromDisposeAndNotFinalize)
        {
        }
    }
}