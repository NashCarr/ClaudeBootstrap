using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CommonData.Enums;
using CommonDataRetrieval.People;
using DataLayerRetrieval.Lookup;
using DataLayerRetrieval.People;

namespace ManagementRetrieval.People
{
    public class PersonListGetManager : IDisposable
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
            using (DbPeopleGetActive db = new DbPeopleGetActive())
            {
                return db.GetActive(pt);
            }
        }

        public List<SelectListItem> GetFacilitiesLookup()
        {
            using (DbPlacesLookup db = new DbPlacesLookup())
            {
                return db.GetFacilityLookup().LookupList;
            }
        }
    }
}