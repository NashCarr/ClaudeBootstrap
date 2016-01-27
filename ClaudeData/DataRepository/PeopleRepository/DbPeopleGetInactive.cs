using System;
using System.Collections.Generic;
using System.Data;
using ClaudeData.Models.People;
using static ClaudeCommon.Enums.PersonEnums;

namespace ClaudeData.DataRepository.PeopleRepository
{
    public class DbPeopleGetInactive : DbPeopleGet
    {
        protected internal List<Person> GetInactiveAssessors()
        {
            IdValue = (byte) PersonType.Assessor;
            TypeName = Enum.GetName(typeof (PersonType), IdValue);
            return GetInactive();
        }

        protected internal List<Person> GetInactiveCustomerContacts()
        {
            IdValue = (byte) PersonType.Assessor;
            TypeName = Enum.GetName(typeof (PersonType), IdValue);
            return GetInactive();
        }

        protected internal List<Person> GetInactiveStaffUsers()
        {
            IdValue = (byte) PersonType.Assessor;
            TypeName = Enum.GetName(typeof (PersonType), IdValue);
            return GetInactive();
        }

        private List<Person> GetInactive()
        {
            try
            {
                IdParameter = "@PersonType";

                SetConnectToDatabase("[Admin].[usp_People_GetInactive]");

                CmdSql.Parameters.Add(IdParameter, SqlDbType.Int).Value = IdValue;

                return GetRecords();
            }
            catch (Exception ex)
            {
                DocumentErrorMessage(ex.ToString());
                return new List<Person>();
            }
        }
    }
}