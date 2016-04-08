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

        public List<PlaceList> GetPlaceList(PlaceType pt)
        {
            using (DbPlacesGetList data = new DbPlacesGetList())
            {
                return data.GetList(pt);
            }
        }
    }
}