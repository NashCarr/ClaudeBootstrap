using System;
using System.Collections.Generic;
using ClaudeCommon.BaseModels;
using ClaudeCommon.BaseModels.Returns;
using ClaudeCommon.Models;
using ClaudeData.DataRepository.AdminRepository;
using ClaudeData.DataRepository.ReorderRepository;

namespace ClaudeViewManagement.Managers.Settings
{
    public class ProductGroupManager : IDisposable
    {
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool iAmBeingCalledFromDisposeAndNotFinalize)
        {
        }

        public List<ProductGroup> GetList()
        {
            using (DbProductGroupGet data = new DbProductGroupGet())
            {
                return data.GetViewModel();
            }
        }

        public ReturnBase SaveRecord(ProductGroup entity)
        {
            using (DbProductGroupSave data = new DbProductGroupSave())
            {
                return data.AddUpdateRecord(entity);
            }
        }

        public void SaveDisplayReorder(List<DisplayReorder> data)
        {
            using (DbReorderSave db = new DbReorderSave())
            {
                db.ProductGroupReorderSave(data);
            }
        }

        public ReturnBase DeleteRecord(int recordId)
        {
            using (DbProductGroupSave data = new DbProductGroupSave())
            {
                return data.SetInactive(recordId);
            }
        }
    }
}