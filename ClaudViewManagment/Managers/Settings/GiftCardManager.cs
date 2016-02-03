using System;
using System.Collections.Generic;
using ClaudeCommon.BaseModels;
using ClaudeCommon.Models;
using ClaudeData.DataRepository.AdminRepository;

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

        public bool Delete(int recordId)
        {
            DeleteRecord(recordId);
            return true;
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

        public ReturnBase DeleteRecord(int recordId)
        {
            using (DbGiftCardSave data = new DbGiftCardSave())
            {
                return data.SetInactive(recordId);
            }
        }
    }
}