using System;
using System.Collections.Generic;
using CommonData.Models.Administration;
using DataManagement.DataRepository.ReorderRepository;
using DataSaveLayer.Administration;
using SaveDataCommon;

namespace SaveManagement.Administration
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