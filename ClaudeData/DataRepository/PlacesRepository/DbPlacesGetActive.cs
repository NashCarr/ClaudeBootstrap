using System;
using System.Collections.Generic;
using System.Data;
using ClaudeCommon.Models;
using static ClaudeCommon.Enums.PlaceEnums;

namespace ClaudeData.DataRepository.PlacesRepository
{
    public class DbPlacesGetActive : DbPlacesGet
    {
        public List<PlaceList> GetActive(PlaceType pt)
        {
            try
            {
                IdValue = (byte) pt;
                IdParameter = "@PlaceType";

                SetConnectToDatabase("[ViewModel].[usp_Places_List]");

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