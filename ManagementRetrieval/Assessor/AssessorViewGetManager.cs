using System;
using CommonDataRetrieval.Assessor;
using DataLayerRetrieval.Assessor;
using ManagementRetrieval.People;

namespace ManagementRetrieval.Assessor
{
    public class AssessorViewGetManager : IDisposable
    {
        private AssessorView _data;

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
            using (_data)
            {
                using (DbAssessorViewGet db = new DbAssessorViewGet())
                {
                    _data = db.GetView(id);
                }
                using (PersonViewGetManager mgr = new PersonViewGetManager())
                {
                    _data.Assessor = mgr.GetAssessor(id);
                }
                return _data;
            }
        }
    }
}