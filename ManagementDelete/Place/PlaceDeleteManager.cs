using System;
using CommonDataReturn;
using DataLayerDelete.Place;

namespace ManagementDelete.Place
{
    public class PlaceDeleteManager : IDisposable
    {
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool iAmBeingCalledFromDisposeAndNotFinalize)
        {
        }

        public ReturnBase DeleteFacility(int id)
        {
            using (DbPlaceDelete db = new DbPlaceDelete())
            {
                return db.SetFacilityInactive(id);
            }
        }

        public ReturnBase DeleteCustomer(int id)
        {
            using (DbPlaceDelete db = new DbPlaceDelete())
            {
                return db.SetCustomerInactive(id);
            }
        }

        public ReturnBase DeleteOrganization(int id)
        {
            using (DbPlaceDelete db = new DbPlaceDelete())
            {
                return db.SetOrganizationInactive(id);
            }
        }
    }
}