using System;
using System.Collections.Generic;
using DataLayerReorder;
using DataLayerSave.Place;
using SaveDataCommon.DisplayReorder;
using SaveDataCommon.Return;

namespace ManagementSave.Places
{
    public class OrganizationSaveManager : IDisposable
    {
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool iAmBeingCalledFromDisposeAndNotFinalize)
        {
        }

        public void SaveDisplayOrder(List<DisplayReorder> data)
        {
            using (DbReorderSave db = new DbReorderSave())
            {
                db.OrganizationReorderSave(data);
            }
        }

        public ReturnBase DeleteOrganization(int id)
        {
            using (DbPlaceSetInactive db = new DbPlaceSetInactive())
            {
                return db.SetOrganizationInactive(id);
            }
        }
    }
}