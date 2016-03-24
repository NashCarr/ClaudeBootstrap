using System;
using System.Collections.Generic;
using System.Data;
using ClaudeCommon.Models.People;
using static ClaudeCommon.Enums.PersonEnums;

namespace ClaudeData.DataRepository.PeopleRepository
{
    public class DbPeopleSearch : DbPeopleGet
    {
        protected internal List<PersonList> GetAssessors(string first, string last, string email)
        {
            IdValue = (byte) PersonType.Assessor;
            TypeName = Enum.GetName(typeof (PersonType), IdValue);
            return GetRecords(first, last, email);
        }

        protected internal List<PersonList> GetCustomerContacts(string first, string last, string email)
        {
            IdValue = (byte) PersonType.CustomerContact;
            TypeName = Enum.GetName(typeof (PersonType), IdValue);
            return GetRecords(first, last, email);
        }

        protected internal List<PersonList> GetStaffMembers(string first, string last, string email)
        {
            IdValue = (byte) PersonType.StaffMember;
            TypeName = Enum.GetName(typeof (PersonType), IdValue);
            return GetRecords(first, last, email);
        }

        private List<PersonList> GetRecords(string first, string last, string email)
        {
            try
            {
                IdParameter = "@PersonType";

                SetConnectToDatabase("[Admin].[usp_People_Search]");

                CmdSql.Parameters.Add(IdParameter, SqlDbType.Int).Value = IdValue;
                CmdSql.Parameters.Add("@FirstName", SqlDbType.NVarChar, 35).Value = first?.Trim() ?? string.Empty;
                CmdSql.Parameters.Add("@LastName", SqlDbType.NVarChar, 35).Value = last?.Trim() ?? string.Empty;
                CmdSql.Parameters.Add("@Email", SqlDbType.NVarChar, 50).Value = email?.Trim() ?? string.Empty;

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