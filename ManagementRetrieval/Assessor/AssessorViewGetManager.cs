using System;
using CommonDataRetrieval.Assessor;
using DataLayerRetrieval.Assessor;
using ManagementRetrieval.People;

namespace ManagementRetrieval.Assessor
{
    public class AssessorViewGetManager : IDisposable
    {
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool iAmBeingCalledFromDisposeAndNotFinalize)
        {
        }

        public AssessorView GetViewModel(int id)
        {
            AssessorView data;
            using (DbAssessorViewGet db = new DbAssessorViewGet())
            {
                data = db.GetView(id);
            }
            using (PersonViewGetManager mgr = new PersonViewGetManager())
            {
                data.Assessor = mgr.GetAssessor(id);
            }
            return data;
        }
    }
}