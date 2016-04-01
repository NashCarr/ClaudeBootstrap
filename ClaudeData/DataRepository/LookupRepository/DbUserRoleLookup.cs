using System;
using System.Collections.Generic;
using System.Web.Mvc;
using DataManagement.DataRepository.AdministrationRepository;
using DataManagement.Models.Administration;
using DataManagement.Models.LookupLists;

namespace DataManagement.DataRepository.LookupRepository
{
    public class DbUserRoleLookup : IDisposable
    {
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public UserRoleLookupList GetLookUpList(string msgPrompt)
        {
            UserRoleLookupList lu = new UserRoleLookupList();
            lu.LookupList.Add(new SelectListItem {Value = "0", Text = msgPrompt});

            List<UserRole> data;

            using (DbUserRoleGet db = new DbUserRoleGet())
            {
                data = db.GetActiveRecords();
            }

            if (data.Count == 0)
            {
                return lu;
            }

            foreach (UserRole t in data)
            {
                lu.LookupList.Add(new SelectListItem {Value = t.RecordId.ToString(), Text = t.Name});
            }
            data.Clear();

            return lu;
        }

        protected virtual void Dispose(bool iAmBeingCalledFromDisposeAndNotFinalize)
        {
        }
    }
}