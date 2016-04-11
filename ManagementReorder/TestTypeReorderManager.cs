using System;
using System.Collections.Generic;
using CommonDataReorder;
using DataLayerReorder;

namespace ManagementReorder
{
    public class TestTypeReorderManager : IDisposable
    {
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool iAmBeingCalledFromDisposeAndNotFinalize)
        {
        }

        public void SaveDisplayReorder(List<DisplayReorder> data)
        {
            using (DbReorderSave db = new DbReorderSave())
            {
                db.TestTypeReorderSave(data);
            }
        }
    }
}