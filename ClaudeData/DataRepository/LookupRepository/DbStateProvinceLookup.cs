﻿using System.Collections.Generic;
using System.Data;
using System.Web.Mvc;
using static ClaudeCommon.Enums.CountryEnums;

namespace ClaudeData.DataRepository.LookupRepository
{
    public class DbStateProvinceLookup : DbLookup
    {
        public List<SelectListItem> GetLookup()
        {
            SetConnectToDatabase("[SelectList].[usp_StateProvince_NameLookup]");
            CmdSql.Parameters.Add("@CountryId", SqlDbType.Int).Value = (int) Country.None;
            return LoadLookup();
        }
    }
}