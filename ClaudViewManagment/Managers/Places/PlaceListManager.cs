using System;
using System.Collections.Generic;
using System.Web.Mvc;
using ClaudeCommon.BaseModels;
using ClaudeCommon.BaseModels.Returns;
using ClaudeCommon.Models;
using ClaudeData.DataRepository.LookupRepository;
using ClaudeData.DataRepository.PlacesRepository;
using ClaudeData.Models.LookupLists;
using static ClaudeCommon.Enums.PlaceEnums;

namespace ClaudeViewManagement.Managers.Places
{
    public class PlaceListManager : IDisposable
    {
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool iAmBeingCalledFromDisposeAndNotFinalize)
        {
        }

        public List<Place> GetList(PlaceType pt)
        {
            using (DbPlacesGetActive data = new DbPlacesGetActive())
            {
                return data.GetActive(pt);
            }
        }

        public List<SelectListItem> GetMobileCarriers()
        {
            using (DbMobileCarrierLookup db = new DbMobileCarrierLookup())
            {
                return db.GetLookUpList();
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

        public void SaveDisplayReorder(PlaceType pt, List<DisplayReorder> data)
        {
            //using (DbReorderSave db = new DbReorderSave())
            //{
            //    db.PlaceReorderSave(data);
            //}
        }

        public ReturnBase DeleteRecord(PlaceType pt, int id)
        {
            //using (DbPlaceSave data = new DbPlaceSave())
            //{
            //    return data.(recordId);
            //}
            return null;
        }
    }
}