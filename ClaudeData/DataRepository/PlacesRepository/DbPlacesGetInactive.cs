using System;
using System.Collections.Generic;
using System.Data;
using ClaudeData.Models.Places;
using static ClaudeCommon.Enums.PlaceEnums;

namespace ClaudeData.DataRepository.PlacesRepository
{
    public class DbPlacesGetInactive : DbPlacesGet
    {
        protected internal List<Place> GetInactiveFacilities()
        {
            IdValue = (byte) PlaceType.Facility;
            TypeName = Enum.GetName(typeof (PlaceType), IdValue);
            return GetInactive();
        }

        protected internal List<Place> GetInactiveOrganizations()
        {
            IdValue = (byte) PlaceType.Organization;
            TypeName = Enum.GetName(typeof (PlaceType), IdValue);
            return GetInactive();
        }

        protected internal List<Place> GetInactiveCustomers()
        {
            IdValue = (byte) PlaceType.Customer;
            TypeName = Enum.GetName(typeof (PlaceType), IdValue);
            return GetInactive();
        }

        private List<Place> GetInactive()
        {
            try
            {
                IdParameter = "@PlaceType";

                SetConnectToDatabase("[Admin].[usp_Places_GetInactive]");

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