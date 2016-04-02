using System;
using System.Collections.Generic;
using CommonData.BaseModels;
using CommonData.BaseModels.Returns;
using CommonData.Models.Administration;
using DataManagement.DataRepository.ReorderRepository;
using DataSaveLayer.Administration;

namespace ViewManagement.Managers.Administration
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