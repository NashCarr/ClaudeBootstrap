using System;
using System.Collections.Generic;
using DataLayerReorder;
using DataManagement.DataRepository.PlaceRepository;
using DataManagement.ViewModels;
using SaveDataCommon;

namespace ViewManagement.Managers.Places
{
    public class OrganizationManager : IDisposable
    {
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool iAmBeingCalledFromDisposeAndNotFinalize)
        {
        }

        public PlaceView GetOrganization(int recordId)
        {
            using (DbPlaceViewGet data = new DbPlaceViewGet())
            {
                return data.GetOrganization(recordId);
            }
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
            using (DbPlaceSetInactive data = new DbPlaceSetInactive())
            {
                return data.SetOrganizationInactive(id);
            }
        }
    }
}