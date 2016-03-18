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
    public class FacilityManager : IDisposable
    {
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool iAmBeingCalledFromDisposeAndNotFinalize)
        {
        }

        public PlaceView GetFacility(int recordId)
        {
            using (DbPlaceInfoGet data = new DbPlaceInfoGet())
            {
                return data.GetFacility(recordId);
            }
        }

        public void SaveFacilityOrder(List<DisplayReorder> data)
        {
            using (DbReorderSave db = new DbReorderSave())
            {
                db.FacilityReorderSave(data);
            }
        }

        public ReturnBase DeleteFacility(int id)
        {
            using (DbPlaceSetInactive data = new DbPlaceSetInactive())
            {
                return data.SetFacilityInactive(id);
            }
        }
    }
}