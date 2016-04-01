using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CommonData.Enums;
using CommonData.Models.People;
using DataManagement.DataRepository.PeopleRepository;
using DataManagement.Models.LookupLists;

namespace DataManagement.DataRepository.LookupRepository
{
    public class DbPeopleLookup : IDisposable
    {
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public StaffMemberLookupList GetStaffMemberLookup()
        {
            return (StaffMemberLookupList) GetLookUpList(PersonEnums.PersonType.StaffMember);
        }

        public CustomerContactLookupList GetCustomerContactLookup()
        {
            return (CustomerContactLookupList) GetLookUpList(PersonEnums.PersonType.CustomerContact);
        }

        private static List<PersonList> GetAssessors()
        {
            using (DbPeopleGetActive db = new DbPeopleGetActive())
            {
                return db.GetActive(PersonEnums.PersonType.Assessor);
            }
        }

        private static List<PersonList> GetCustomerContacts()
        {
            using (DbPeopleGetActive db = new DbPeopleGetActive())
            {
                return db.GetActive(PersonEnums.PersonType.CustomerContact);
            }
        }

        private static List<PersonList> GetStaffMembers()
        {
            using (DbPeopleGetActive db = new DbPeopleGetActive())
            {
                return db.GetActive(PersonEnums.PersonType.StaffMember);
            }
        }

        private static PersonLookupList GetLookUpList(PersonEnums.PersonType personType)
        {
            PersonLookupList lu = new PersonLookupList();
            lu.LookupList.Add(new SelectListItem {Value = "0", Text = "None"});

            List<PersonList> data;

            switch (personType)
            {
                case PersonEnums.PersonType.StaffMember:
                    data = GetStaffMembers();
                    break;
                case PersonEnums.PersonType.Assessor:
                    data = GetAssessors();
                    break;
                case PersonEnums.PersonType.CustomerContact:
                    data = GetCustomerContacts();
                    break;
                case PersonEnums.PersonType.None:
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