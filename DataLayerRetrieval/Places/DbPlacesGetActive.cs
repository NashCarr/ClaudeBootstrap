using System;
using System.Collections.Generic;
using System.Data;
using CommonDataRetrieval.Places;
using static CommonData.Enums.PlaceEnums;

namespace DataLayerRetrieval.Places
{
    public class DbPlacesGetActive : DbPlacesGet
    {
        public List<PlaceList> GetActive(PlaceType pt)
        {
            try
            {
                IdValue = (byte) pt;
                IdParameter = "@PlaceType";

                SetConnectToDatabase("[Places].[usp_GetList]");

                CmdSql.Parameters.Add(IdParameter, SqlDbType.Int).Value = IdValue;

                return GetRecords();
            }
            catch (Exception ex)
            {
                DocumentErrorMessage(ex.ToString());
                return new List<PlaceList>();
            }
        }
    }
}