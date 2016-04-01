using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CommonData.Enums;
using CommonData.Models.People;
using DataManagement.DataRepository.LookupRepository;
using DataManagement.DataRepository.PeopleRepository;

namespace ViewManagement.Managers.People
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
    }
}