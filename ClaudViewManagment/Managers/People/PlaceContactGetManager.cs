using System;
using ClaudeData.DataRepository.PeopleRepository;
using ClaudeData.ViewModels.Settings;

namespace ClaudeViewManagement.Managers.People
{
    public class PlaceContactGetManager : IDisposable
    {
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool iAmBeingCalledFromDisposeAndNotFinalize)
        {
        }

        public PlaceContactView GetCustomerContact(int recordId)
        {
            using (DbPlaceContactInfoGet data = new DbPlaceContactInfoGet())
            {
                return data.GetCustomerContact(recordId);
            }
        }

        public PlaceContactView GetOrganizationContact(int recordId)
        {
            using (DbPlaceContactInfoGet data = new DbPlaceContactInfoGet())
            {
                return data.GetOrganizationContact(recordId);
            }
        }

        public PlaceContactView GetStaffUser(int recordId)
        {
            using (DbPlaceContactInfoGet data = new DbPlaceContactInfoGet())
            {
                return data.GetStaffUser(recordId);
            }
        }
    }
}