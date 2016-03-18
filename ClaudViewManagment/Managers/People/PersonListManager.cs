using System;
using System.Collections.Generic;
using System.Web.Mvc;
using ClaudeCommon.Enums;
using ClaudeCommon.Models;
using ClaudeData.DataRepository.AddressRepository;
using ClaudeData.DataRepository.LookupRepository;
using ClaudeData.DataRepository.PeopleRepository;
using ClaudeData.Models.LookupLists;

namespace ClaudeViewManagement.Managers.People
{
    public class PersonListManager : IDisposable
    {
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool iAmBeingCalledFromDisposeAndNotFinalize)
        {
        }

        public List<PersonList> GetList(PersonEnums.PersonType pt)
        {
            using (DbPeopleGetActive data = new DbPeopleGetActive())
            {
                return data.GetActive(pt);
            }
        }

        public List<SelectListItem> GetFacilities()
        {
            using (DbPlacesLookup db = new DbPlacesLookup())
            {
                return db.GetFacilityLookup().LookupList;
            }
        }

        public List<SelectListItem> GetMobileCarriers()
        {
            using (DbMobileCarrierLookup db = new DbMobileCarrierLookup())
            {
                return db.GetLookUpList();
            }
        }

        public List<PostalCodeLookup> GetPostalCodes()
        {
            using (DbPostalCodeLookup db = new DbPostalCodeLookup())
            {
                return db.GetLookup();
            }
        }

        public List<SelectListItem> GetStatesProvinces()
        {
            using (DbStateProvinceLookup db = new DbStateProvinceLookup())
            {
                return db.GetLookup();
            }
        }

        public List<SelectListItem> GetCountries()
        {
            using (CountryLookupList db = new CountryLookupList())
            {
                return db.LookupList;
            }
        }

        public List<SelectListItem> GetTimeZones()
        {
            using (TimeZoneLookupList db = new TimeZoneLookupList())
            {
                return db.LookupList;
            }
        }
    }
}