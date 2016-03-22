using System;
using System.Collections.Generic;
using System.Web.Mvc;
using ClaudeCommon.Models.People;
using ClaudeData.DataRepository.PeopleRepository;
using ClaudeData.Models.LookupLists;
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
            return (StaffUserLookupList) GetLookUpList(PersonType.StaffMember);
        }

        public CustomerContactLookupList GetCustomerContactLookup()
        {
            return (CustomerContactLookupList) GetLookUpList(PersonType.CustomerContact);
        }

        private static List<PersonList> GetAssessors()
        {
            using (DbPeopleGetActive db = new DbPeopleGetActive())
            {
                return db.GetActive(PersonType.Assessor);
            }
        }

        private static List<PersonList> GetCustomerContacts()
        {
            using (DbPeopleGetActive db = new DbPeopleGetActive())
            {
                return db.GetActive(PersonType.CustomerContact);
            }
        }

        private static List<PersonList> GetStaffUsers()
        {
            using (DbPeopleGetActive db = new DbPeopleGetActive())
            {
                return db.GetActive(PersonType.StaffMember);
            }
        }

        private static PersonLookupList GetLookUpList(PersonType personType)
        {
            PersonLookupList lu = new PersonLookupList();
            lu.LookupList.Add(new SelectListItem {Value = "0", Text = "None"});

            List<PersonList> data;

            switch (personType)
            {
                case PersonType.StaffMember:
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

            foreach (PersonList t in data)
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