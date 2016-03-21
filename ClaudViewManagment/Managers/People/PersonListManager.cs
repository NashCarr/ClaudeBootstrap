using System;
using System.Collections.Generic;
using System.Web.Mvc;
using ClaudeCommon.Models.People;
using ClaudeData.DataRepository.LookupRepository;
using ClaudeData.DataRepository.PeopleRepository;
using static ClaudeCommon.Enums.PersonEnums;

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

        public List<PersonList> GetList(PersonType pt)
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