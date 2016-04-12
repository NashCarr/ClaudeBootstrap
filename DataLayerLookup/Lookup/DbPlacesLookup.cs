using System.Collections.Generic;
using System.Web.Mvc;

namespace DataLayerLookup.Lookup
{
    public class DbPlacesLookup : DbLookup
    {
        public List<SelectListItem> GetFacilityLookup()
        {
            SetConnectToDatabase("[Facility].[usp_Lookup]");
            return LoadLookup();
        }

        public List<SelectListItem> GetCustomerLookup()
        {
            SetConnectToDatabase("[Customer].[usp_Lookup]");
            return LoadLookup();
        }

        public List<SelectListItem> GetOrganizationLookup()
        {
            SetConnectToDatabase("[Organization].[usp_Lookup]");
            return LoadLookup();
        }
    }
}