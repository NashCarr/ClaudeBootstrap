using System;
using System.Collections.Generic;
using System.Data;
using ClaudeData.Models.Places;
using static ClaudeCommon.Enums.PlaceEnums;

namespace ClaudeData.DataRepository.PlacesRepository
{
    public class DbPlacesGetActive : DbPlacesGet
    {
        protected internal List<Place> GetActiveFacilities()
        {
            IdValue = (byte) PlaceType.Facility;
            TypeName = Enum.GetName(typeof (PlaceType), IdValue);
            return GetActive();
        }

        protected internal List<Place> GetActiveOrganizations()
        {
            IdValue = (byte) PlaceType.Organization;
            TypeName = Enum.GetName(typeof (PlaceType), IdValue);
            return GetActive();
        }

        protected internal List<Place> GetActiveCustomers()
        {
            IdValue = (byte) PlaceType.Customer;
            TypeName = Enum.GetName(typeof (PlaceType), IdValue);
            return GetActive();
        }

        private List<Place> GetActive()
        {
            try
            {
                IdParameter = "@PlaceType";

                SetConnectToDatabase("[Admin].[usp_Places_GetActive]");

                CmdSql.Parameters.Add(IdParameter, SqlDbType.Int).Value = IdValue;

                return GetRecords();
            }
            catch (Exception ex)
            {
                DocumentErrorMessage(ex.ToString());
                return new List<Place>();
            }
        }
    }
}