using System.Collections.Generic;
using CommonDataRetrieval.Base;

namespace CommonDataRetrieval.Research
{
    public class StudyDashboard : ModelBase
    {
        public StudyDashboard()
        {
            Quotas = new List<StudyQuota>();
            Components = new List<StudyComponent>();
            Populations = new List<StudyPopulation>();
            Communications = new List<StudyCommunication>();
        }

        public List<StudyQuota> Quotas { get; set; }
        public List<StudyComponent> Components { get; set; }
        public List<StudyPopulation> Populations { get; set; }
        public List<StudyCommunication> Communications { get; set; }
    }
}