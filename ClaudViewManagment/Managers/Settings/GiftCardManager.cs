using System;
using System.Collections.Generic;
using ClaudeCommon.BaseModels;
using ClaudeCommon.BaseModels.Returns;
using ClaudeCommon.Models;
using ClaudeCommon.Models.Administration;
using ClaudeData.DataRepository.AdminRepository;
using ClaudeData.DataRepository.ReorderRepository;

namespace ClaudeViewManagement.Managers.Settings
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

        public List<GiftCard> GetList()
        {
            using (DbGiftCardGet data = new DbGiftCardGet())
            {
                return data.GetViewModel();
            }
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