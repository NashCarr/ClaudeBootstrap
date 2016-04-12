using System.Collections.Generic;
using System.Data;
using System.Web.Mvc;

namespace DataLayerLookup.Lookup
{
    public class DbMobileCarrierLookup : DbGatewayLookup
    {
        public List<SelectListItem> GetLookUpList()
        {
            SetConnectToDatabase("[SelectList].[usp_MobileCarrier_NameLookup]");
            CmdSql.Parameters.Add("@MobileCarrierId", SqlDbType.Int).Value = 0;
            return LoadLookup();
        }
    }
}