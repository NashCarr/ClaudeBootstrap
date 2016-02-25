using System;
using System.Collections.Generic;
using ClaudeCommon.BaseModels;
using ClaudeCommon.BaseModels.Returns;
using ClaudeCommon.Models;
using ClaudeData.DataRepository.AdminRepository;
using ClaudeData.DataRepository.ReorderRepository;

namespace ClaudeViewManagement.Managers.Settings
{
    public class HearAboutUsManager : IDisposable
    {
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool iAmBeingCalledFromDisposeAndNotFinalize)
        {
        }

        public List<HearAboutUs> GetList()
        {
            using (DbHearAboutUsGet data = new DbHearAboutUsGet())
            {
                return data.GetViewModel();
            }
        }

        public ReturnBase SaveRecord(HearAboutUs entity)
        {
            using (DbHearAboutUsSave data = new DbHearAboutUsSave())
            {
                return data.AddUpdateRecord(entity);
            }
        }

        public void SaveDisplayReorder(List<DisplayReorder> data)
        {
            using (DbReorderSave db = new DbReorderSave())
            {
                db.HearAboutUsReorderSave(data);
            }
        }

        public ReturnBase DeleteRecord(int recordId)
        {
            using (DbHearAboutUsSave data = new DbHearAboutUsSave())
            {
                return data.SetInactive(recordId);
            }
        }
    }
}