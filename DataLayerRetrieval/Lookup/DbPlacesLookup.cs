using System;
using System.Web.Mvc;
using CommonDataRetrieval.Lookup;
using static CommonData.Enums.PlaceEnums;

namespace DataLayerRetrieval.Lookup
{
    public class DbPlacesLookup : IDisposable
    {
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public BaseLookup GetFacilityLookup()
        {
            return GetLookUpList(PlaceType.Facility);
        }

        public BaseLookup GetCustomerLookup()
        {
            return GetLookUpList(PlaceType.Customer);
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

        private static BaseLookup GetLookUpList(PlaceType placeType)
        {
            BaseLookup lu = new BaseLookup();
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
                case PlaceType.None:
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