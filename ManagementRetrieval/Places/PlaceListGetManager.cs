using System;
using System.Collections.Generic;
using DataLayerCommon.Enums;
using DataLayerRetrieval.Places;
using DataRetrievalCommon.Places;

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

        public List<PlaceList> GetList(PlaceEnums.PlaceType pt)
        {
            using (DbPlacesGetActive data = new DbPlacesGetActive())
            {
                return data.GetActive(pt);
            }
        }
    }
}