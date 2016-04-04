using System;
using System.Collections.Generic;
using System.Data;
using ViewDataCommon.Person;
using static DataLayerCommon.Enums.PersonEnums;

namespace DataLayerRetrieval.People
{
    public class DbPeopleGetActive : DbPeopleGet
    {
        public List<PersonList> GetActive(PersonType pt)
        {
            try
            {
                IdValue = (byte) pt;
                IdParameter = "@PlaceType";

                SetConnectToDatabase("[ViewModel].[usp_People_List]");

                CmdSql.Parameters.Add(IdParameter, SqlDbType.Int).Value = IdValue;

                return GetRecords();
            }
            catch (Exception ex)
            {
                DocumentErrorMessage(ex.ToString());
                return new List<PersonList>();
            }
        }
    }
}