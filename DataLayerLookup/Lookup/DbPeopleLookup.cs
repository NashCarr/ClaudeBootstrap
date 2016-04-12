using System.Collections.Generic;
using System.Web.Mvc;

namespace DataLayerLookup.Lookup
{
    public class DbPeopleLookup : DbLookup
    {
        public List<SelectListItem> GetStaffMemberLookup()
        {
            SetConnectToDatabase("[StaffMember].[usp_Lookup]");
            return LoadLookup();
        }

        public List<SelectListItem> GetCustomerContactLookup()
        {
            SetConnectToDatabase("[CustomerContact].[usp_Lookup]");
            return LoadLookup();
        }
    }
}