using System;
using System.Collections.Generic;
using CommonData.BaseModels;
using CommonData.BaseModels.Returns;
using CommonData.Models.Administration;
using DataManagement.DataRepository.AdministrationRepository;
using DataManagement.DataRepository.ReorderRepository;

namespace ViewManagement.Managers.Administration
{
    public class GiftCardManager : IDisposable
    {
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool iAmBeingCalledFromDisposeAndNotFinalize)
        {
        }

        public ReturnBase SaveRecord(GiftCard entity)
        {
            using (DbGiftCardSave data = new DbGiftCardSave())
            {
                return data.AddUpdateRecord(entity);
            }
        }

        public void SaveDisplayReorder(List<DisplayReorder> data)
        {
            using (DbReorderSave db = new DbReorderSave())
            {
                db.GiftCardReorderSave(data);
            }
        }

        public ReturnBase DeleteRecord(int recordId)
        {
            using (DbGiftCardSave data = new DbGiftCardSave())
            {
                return data.SetInactive(recordId);
            }
        }
    }
}