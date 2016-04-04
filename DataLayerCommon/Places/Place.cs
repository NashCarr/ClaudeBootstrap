﻿using DataLayerCommon.BaseModels;
using static DataLayerCommon.Enums.CountryEnums;
using static DataLayerCommon.Enums.PlaceEnums;
using static DataLayerCommon.Enums.TimeZoneEnums;

namespace DataLayerCommon.Places
{
    public class Place : AdminBase
    {
        public Place()
        {
            PlaceId = 0;
            Division = string.Empty;
            Department = string.Empty;
            PlaceType = PlaceType.None;
            Country = Country.None;
            TimeZone = ClaudeTimeZone.None;
        }

        public int PlaceId { get; set; }
        public Country Country { get; set; }
        public string Division { get; set; }
        public string Department { get; set; }
        public PlaceType PlaceType { get; set; }
        public ClaudeTimeZone TimeZone { get; set; }
    }
}