using System.Collections.Generic;
using System.Web.Mvc;

namespace DataLayerRetrieval.Lookup
{
    public class DbMobileCarrierLookup : DbGatewayLookup
    {
        public List<SelectListItem> GetLookUpList()
        {
            SetConnectToDatabase("[SelectList].[usp_MobileCarrier_NameLookup]");
            return LoadLookup();
        }
    }
}