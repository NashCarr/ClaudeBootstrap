using System;
using System.Collections.Generic;
using System.Data;
using ClaudeData.Models.People;
using static ClaudeCommon.Enums.PersonEnums;

namespace ClaudeData.DataRepository.PeopleRepository
{
    public class DbPeopleGetActive : DbPeopleGet
    {
        protected internal List<Person> GetActiveAssessors()
        {
            IdValue = (byte) PersonType.Assessor;
            TypeName = Enum.GetName(typeof (PersonType), IdValue);
            return GetActive();
        }

        protected internal List<Person> GetActiveCustomerContacts()
        {
            IdValue = (byte) PersonType.CustomerContact;
            TypeName = Enum.GetName(typeof (PersonType), IdValue);
            return GetActive();
        }

        protected internal List<Person> GetActiveStaffUsers()
        {
            IdValue = (byte) PersonType.StaffUser;
            TypeName = Enum.GetName(typeof (PersonType), IdValue);
            return GetActive();
        }

        private List<Person> GetActive()
        {
            try
            {
                IdParameter = "@PersonType";

                SetConnectToDatabase("[Admin].[usp_People_GetActive]");

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