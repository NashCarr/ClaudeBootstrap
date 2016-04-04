using System;
using System.Collections.Generic;
using System.Web.Mvc;
using DataLayerCommon.Enums;
using DataLayerRetrieval.Lookup;
using DataLayerRetrieval.People;
using ViewDataCommon.Person;

namespace ManagementRetrieval.Places
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