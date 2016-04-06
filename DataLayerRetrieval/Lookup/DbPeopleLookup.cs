using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CommonDataRetrieval.People;
using DataLayerRetrieval.LookupModel;
using DataLayerRetrieval.People;
using static CommonData.Enums.PersonEnums;

namespace DataLayerRetrieval.Lookup
{
    public class DbPeopleLookup : IDisposable
    {
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public StaffMemberLookup GetStaffMemberLookup()
        {
            return (StaffMemberLookup) GetLookUpList(PersonType.StaffMember);
        }

        public CustomerContactLookup GetCustomerContactLookup()
        {
            return (CustomerContactLookup) GetLookUpList(PersonType.CustomerContact);
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

        private static List<PersonList> GetStaffMembers()
        {
            using (DbPeopleGetActive db = new DbPeopleGetActive())
            {
                return db.GetActive(PersonType.StaffMember);
            }
        }

        private static PersonLookup GetLookUpList(PersonType personType)
        {
            PersonLookup lu = new PersonLookup();
            lu.LookupList.Add(new SelectListItem {Value = "0", Text = "None"});

            List<PersonList> data;

            switch (personType)
            {
                case PersonType.StaffMember:
                    data = GetStaffMembers();
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