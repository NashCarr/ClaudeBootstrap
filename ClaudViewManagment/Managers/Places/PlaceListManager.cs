using System;
using System.Collections.Generic;
using CommonData.Enums;
using CommonData.Models.Places;
using DataManagement.DataRepository.PlacesRepository;

namespace ViewManagement.Managers.Places
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

        public List<PlaceList> GetList(PlaceEnums.PlaceType pt)
        {
            using (DbPlacesGetActive data = new DbPlacesGetActive())
            {
                return data.GetActive(pt);
            }
        }
    }
}