﻿using System;
using System.Collections.Generic;
using System.Linq;
using CommonData.Enums;
using DataManagement.Models.Addresses;
using DataManagement.Models.People;
using DataManagement.Models.Phones;

namespace DataManagement.DataRepository.PersonRepository
{
    public class DbPersonDataNew : IDisposable
    {
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public PersonData GetNew(PersonEnums.PersonType personType)
        {
            PersonData data = new PersonData();
            try
            {
                data.Person = new Person
                {
                    PersonType = personType
                };

                data.AddressData = new AddressData {Addresses = new List<AddressAssociation>()};

                foreach (
                    AddressAssociation aa in
                        from AddressEnums.AddressType val in Enum.GetValues(typeof (AddressEnums.AddressType))
                        where (short) val != 0
                        select new AddressAssociation {AddressType = val})
                {
                    data.AddressData.Addresses.Add(aa);
                }

                data.PhoneData = new PhoneData {Phones = new List<PhoneAssociation>()};

                foreach (
                    PhoneAssociation pa in
                        from PhoneEnums.PhoneType val in Enum.GetValues(typeof (PhoneEnums.PhoneType))
                        where (short) val != 0
                        select new PhoneAssociation {PhoneType = val})
                {
                    data.PhoneData.Phones.Add(pa);
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