using CommonDataRetrieval.Assessor;
using ManagementRetrieval.Assessor;

namespace ViewData.Assessor
{
    public class AssessorViewModel
    {
        public AssessorViewModel(int id)
        {
            using (AssessorViewGetManager mgr = new AssessorViewGetManager())
            {
                AssessorData = mgr.GetViewModel(id);
            }
        }

        public AssessorView AssessorData { get; set; }
    }
}