using System;
using System.Collections.Generic;
using ClaudeCommon.BaseModels;
using ClaudeCommon.BaseModels.Returns;
using ClaudeData.DataRepository.PlaceRepository;
using ClaudeData.DataRepository.PlacesRepository;
using ClaudeData.DataRepository.ReorderRepository;
using ClaudeData.ViewModels.Settings;

namespace ClaudeViewManagement.Managers.Places
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
            using (DbPlaceInfoGet data = new DbPlaceInfoGet())
            {
                return data.GetOrganization(recordId);
            }
        }

        public void SaveOrganizationOrder(List<DisplayReorder> data)
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