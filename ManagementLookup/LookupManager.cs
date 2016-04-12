using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CommonDataLookup;
using DataLayerLookup.Lookup;
using ManagementLookup.LookupData;

namespace ManagementLookup
{
    public class LookupManager : IDisposable
    {
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool iAmBeingCalledFromDisposeAndNotFinalize)
        {
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
            using (LuCountryLookup db = new LuCountryLookup())
            {
                return db.LookupList;
            }
        }

        public List<SelectListItem> GetTimeZones()
        {
            using (LuTimeZoneLookup db = new LuTimeZoneLookup())
            {
                return db.LookupList;
            }
        }

        public List<SelectListItem> GetCompensationTypes()
        {
            using (LuCompensationTypeLookup db = new LuCompensationTypeLookup())
            {
                return db.LookupList;
            }
        }

        public List<SelectListItem> GetFacilities()
        {
            using (DbPlacesLookup db = new DbPlacesLookup())
            {
                return db.GetFacilityLookup();
            }
        }
    }
}