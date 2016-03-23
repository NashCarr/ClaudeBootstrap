using System;
using System.Collections.Generic;
using ClaudeCommon.BaseModels;
using ClaudeCommon.BaseModels.Returns;
using ClaudeCommon.Models.Facility;
using ClaudeData.DataRepository.FacilityRepository;
using ClaudeData.DataRepository.ReorderRepository;

namespace ClaudeViewManagement.Managers.Facility
{
    public class FacilityResourceManager : IDisposable
    {
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool iAmBeingCalledFromDisposeAndNotFinalize)
        {
        }

        public List<FacilityResource> GetList()
        {
            using (DbFacilityResourceGet data = new DbFacilityResourceGet())
            {
                return data.GetViewModel();
            }
        }

        public List<FacilityResource> GetFacilityList(int facilityId)
        {
            using (DbFacilityResourceGet data = new DbFacilityResourceGet())
            {
                return data.GetFacilityViewModel(facilityId);
            }
        }

        public ReturnBase SaveRecord(FacilityResource entity)
        {
            using (DbFacilityResourceSave data = new DbFacilityResourceSave())
            {
                return data.AddUpdateRecord(entity);
            }
        }

        public void SaveDisplayReorder(List<DisplayReorder> data)
        {
            using (DbReorderSave db = new DbReorderSave())
            {
                db.FacilityResourceReorderSave(data);
            }
        }

        public ReturnBase DeleteRecord(int recordId)
        {
            using (DbFacilityResourceSave data = new DbFacilityResourceSave())
            {
                return data.SetInactive(recordId);
            }
        }
    }
}