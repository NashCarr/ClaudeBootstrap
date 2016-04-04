using System;
using System.Collections.Generic;
using System.Data;
using DataLayerCommon.Enums;
using DataRetrievalCommon.Places;

namespace DataLayerRetrieval.Places
{
    public class DbPlacesGetActive : DbPlacesGet
    {
        public List<PlaceList> GetActive(PlaceEnums.PlaceType pt)
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