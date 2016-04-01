﻿using System.Collections.Generic;
using System.Web.Mvc;

namespace DataManagement.Models.LookupLists
{
    public class PostalZoneLookupList
    {
        public PostalZoneLookupList()
        {
            LookupList = new List<SelectListItem>();
        }

        public List<SelectListItem> LookupList { get; set; }
    }
}