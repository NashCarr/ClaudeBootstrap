using System.Collections.Generic;
using System.Data;
using System.Web.Mvc;
using static CommonData.Enums.CountryEnums;

namespace DataLayerLookup.Lookup
{
    public class DbStateProvinceLookup : DbGatewayLookup
    {
        public List<SelectListItem> GetLookup()
        {
            SetConnectToDatabase("[SelectList].[usp_StateProvince_NameLookup]");
            CmdSql.Parameters.Add("@CountryId", SqlDbType.Int).Value = (int) Country.None;
            return LoadLookup();
        }
    }
}