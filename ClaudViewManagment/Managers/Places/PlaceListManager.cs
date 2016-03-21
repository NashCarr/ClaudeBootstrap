using System;
using System.Collections.Generic;
using System.Web.Mvc;
using ClaudeCommon.Models;
using ClaudeCommon.Models.Places;
using ClaudeData.DataRepository.AddressRepository;
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

        public List<PlaceList> GetList(PlaceType pt)
        {
            using (DbPlacesGetActive data = new DbPlacesGetActive())
            {
                return data.GetActive(pt);
            }
        }
    }
}