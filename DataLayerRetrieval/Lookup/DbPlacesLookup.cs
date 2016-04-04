using System;
using System.Web.Mvc;
using DataLayerCommon.Enums;
using DataLayerCommon.LookupLists;

namespace DataLayerRetrieval.Lookup
{
    public class DbPlacesLookup : IDisposable
    {
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public PlaceLookupList GetFacilityLookup()
        {
            return GetLookUpList(PlaceEnums.PlaceType.Facility);
        }

        public PlaceLookupList GetCustomerLookup()
        {
            return GetLookUpList(PlaceEnums.PlaceType.Customer);
        }

        //private static List<Place> GetOrganizations()
        //{
        //    using (DbPlacesGetActive db = new DbPlacesGetActive())
        //    {
        //        return db.GetActiveOrganizations();
        //    }
        //}

        //private static List<Place> GetCustomers()
        //{
        //    using (DbPlacesGetActive db = new DbPlacesGetActive())
        //    {
        //        return db.GetActiveCustomers();
        //    }
        //}

        //private static List<Place> GetFacilities()
        //{
        //    using (DbPlacesGetActive db = new DbPlacesGetActive())
        //    {
        //        return db.GetActiveFacilities();
        //    }
        //}

        private static PlaceLookupList GetLookUpList(PlaceEnums.PlaceType placeType)
        {
            PlaceLookupList lu = new PlaceLookupList();
            lu.LookupList.Add(new SelectListItem {Value = "0", Text = "None"});

            //List<Place> data;

            switch (placeType)
            {
                //case PlaceType.Facility:
                //    data = GetFacilities();
                //    break;
                //case PlaceType.Organization:
                //    data = GetOrganizations();
                //    break;
                //case PlaceType.Customer:
                //    data = GetCustomers();
                //    break;
                case PlaceEnums.PlaceType.None:
                    return lu;
                default:
                    return lu;
            }

            //if (data.Count == 0)
            //{
            //    return lu;
            //}

            //foreach (Place t in data)
            //{
            //    lu.LookupList.Add(new SelectListItem {Value = t.PlaceId.ToString(), Text = t.Name});
            //}
            //data.Clear();

            //return lu;
        }

        protected virtual void Dispose(bool iAmBeingCalledFromDisposeAndNotFinalize)
        {
        }
    }
}