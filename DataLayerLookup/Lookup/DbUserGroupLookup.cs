using System.Collections.Generic;
using System.Web.Mvc;

namespace DataLayerLookup.Lookup
{
    public class DbUserGroupLookup : DbLookup
    {
        public List<SelectListItem> GetLookUpList(string msgPrompt)
        {
            SetConnectToDatabase("[UserGroup].[usp_GetLookup]");
            return LoadLookup();
        }
    }
}