using System.Collections.Generic;
using System.Data;
using System.Web.Mvc;
using CommonData.Enums;

namespace DataLayerRetrieval.Lookup
{
    public class DbStateProvinceLookup : DbGatewayLookup
    {
        public List<SelectListItem> GetLookup()
        {
            SetConnectToDatabase("[SelectList].[usp_StateProvince_NameLookup]");
            CmdSql.Parameters.Add("@CountryId", SqlDbType.Int).Value = (int) CountryEnums.Country.None;
            return LoadLookup();
        }
    }
}