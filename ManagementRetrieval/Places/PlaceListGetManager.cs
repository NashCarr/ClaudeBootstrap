using System;
using System.Collections.Generic;
using CommonDataRetrieval.Places;
using DataLayerRetrieval.Places;
using static CommonData.Enums.PlaceEnums;

namespace ManagementRetrieval.Places
{
    public class PlaceListGetManager : IDisposable
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