using System;
using System.Collections.Generic;
using ClaudeCommon.BaseModels;
using ClaudeData.DataRepository.SettingsRepository;
using ClaudeData.ViewModels.Settings;
using static ClaudeCommon.Enums.PlaceEnums;

namespace ClaudeViewManagement.Managers.Places
{
    public class PlaceManager : IDisposable
    {
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool iAmBeingCalledFromDisposeAndNotFinalize)
        {
        }

        public CustomerView GetCustomer(int recordId)
        {
            using (DbCustomerInfoGet data = new DbCustomerInfoGet())
            {
                return data.GetRecord(recordId);
            }
        }

        public void SaveDisplayReorder(PlaceType pt, List<DisplayReorder> data)
        {
            //using (DbReorderSave db = new DbReorderSave())
            //{
            //    db.PlaceReorderSave(data);
            //}
        }

        public ReturnBase DeleteRecord(PlaceType pt, int id)
        {
            //using (DbPlaceSave data = new DbPlaceSave())
            //{
            //    return data.(recordId);
            //}
            return null;
        }
    }
}