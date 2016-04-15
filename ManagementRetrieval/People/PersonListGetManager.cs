using System;
using System.Collections.Generic;
using CommonDataRetrieval.People;
using DataLayerRetrieval.People;
using static CommonData.Enums.PersonEnums;

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

        public List<PersonList> GetList(PersonType pt)
        {
            using (DbPeopleGetActive db = new DbPeopleGetActive())
            {
                return db.GetActive(pt);
            }
        }

        //    using (DbPlacesLookup db = new DbPlacesLookup())
        //{

        //public List<SelectListItem> GetFacilitiesLookup()
        //    {
        //        return db.GetFacilityLookup().LookupList;
        //    }
        //}
    }
}