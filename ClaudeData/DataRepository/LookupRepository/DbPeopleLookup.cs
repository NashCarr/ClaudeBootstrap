using System;
using System.Collections.Generic;
using System.Web.Mvc;
using ClaudeData.DataRepository.PeopleRepository;
using ClaudeData.Models.LookupLists;
using ClaudeData.Models.People;
using static ClaudeCommon.Enums.PersonEnums;

namespace ClaudeData.DataRepository.LookupRepository
{
    public class DbPeopleLookup : IDisposable
    {
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public StaffUserLookupList GetStaffUserLookup()
        {
            return (StaffUserLookupList) GetLookUpList(PersonType.StaffUser);
        }

        public CustomerContactLookupList GetCustomerContactLookup()
        {
            return (CustomerContactLookupList) GetLookUpList(PersonType.CustomerContact);
        }

        private static List<Person> GetAssessors()
        {
            using (DbPeopleGetActive db = new DbPeopleGetActive())
            {
                return db.GetActiveAssessors();
            }
        }

        private static List<Person> GetCustomerContacts()
        {
            using (DbPeopleGetActive db = new DbPeopleGetActive())
            {
                return db.GetActiveCustomerContacts();
            }
        }

        private static List<Person> GetStaffUsers()
        {
            using (DbPeopleGetActive db = new DbPeopleGetActive())
            {
                return db.GetActiveStaffUsers();
            }
        }

        private static PersonLookupList GetLookUpList(PersonType personType)
        {
            PersonLookupList lu = new PersonLookupList();
            lu.LookupList.Add(new SelectListItem {Value = "0", Text = "None"});

            List<Person> data;

            switch (personType)
            {
                case PersonType.StaffUser:
                    data = GetStaffUsers();
                    break;
                case PersonType.Assessor:
                    data = GetAssessors();
                    break;
                case PersonType.CustomerContact:
                    data = GetCustomerContacts();
                    break;
                case PersonType.None:
                    return lu;
                default:
                    return lu;
            }

            if (data.Count == 0)
            {
                return lu;
            }

            foreach (Person t in data)
            {
                lu.LookupList.Add(new SelectListItem {Value = t.PersonId.ToString(), Text = t.FullName});
            }
            data.Clear();

            return lu;
        }

        protected virtual void Dispose(bool iAmBeingCalledFromDisposeAndNotFinalize)
        {
        }
    }
}