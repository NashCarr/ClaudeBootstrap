using System;
using System.Web.Mvc;
using CommonData.Enums;
using CommonDataLookup;

namespace DataLayerLookup.Lookup
{
    public class DbPeopleLookup : IDisposable
    {
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public BaseLookup GetStaffMemberLookup()
        {
            return GetLookUpList(PersonEnums.PersonType.StaffMember);
        }

        public BaseLookup GetCustomerContactLookup()
        {
            return GetLookUpList(PersonEnums.PersonType.CustomerContact);
        }

        //private static List<PersonList> GetAssessors()
        //{
        //    using (DbPeopleGetActive db = new DbPeopleGetActive())
        //    {
        //        return db.GetActive(PersonEnums.PersonType.Assessor);
        //    }
        //}

        //private static List<PersonList> GetCustomerContacts()
        //{
        //    using (DbPeopleGetActive db = new DbPeopleGetActive())
        //    {
        //        return db.GetActive(PersonEnums.PersonType.CustomerContact);
        //    }
        //}

        //private static List<PersonList> GetStaffMembers()
        //{
        //    using (DbPeopleGetActive db = new DbPeopleGetActive())
        //    {
        //        return db.GetActive(PersonEnums.PersonType.StaffMember);
        //    }
        //}

        private static BaseLookup GetLookUpList(PersonEnums.PersonType personType)
        {
            BaseLookup lu = new BaseLookup();
            lu.LookupList.Add(new SelectListItem {Value = "0", Text = "None"});

            //List<PersonList> data;

            switch (personType)
            {
                //case PersonEnums.PersonType.StaffMember:
                //    data = GetStaffMembers();
                //    break;
                //case PersonEnums.PersonType.Assessor:
                //    data = GetAssessors();
                //    break;
                //case PersonEnums.PersonType.CustomerContact:
                //    data = GetCustomerContacts();
                //    break;
                //case PersonEnums.PersonType.None:
                //    return lu;
                default:
                    return lu;
            }

            //if (data.Count == 0)
            //{
            //    return lu;
            //}

            //foreach (PersonList t in data)
            //{
            //    lu.LookupList.Add(new SelectListItem {Value = t.PersonId.ToString(), Text = t.FullName});
            //}
            //data.Clear();

            //return lu;
        }

        protected virtual void Dispose(bool iAmBeingCalledFromDisposeAndNotFinalize)
        {
        }
    }
}