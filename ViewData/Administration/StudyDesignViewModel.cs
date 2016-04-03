using System.Collections.Generic;
using DataLayerRetrieval.Administration;
using ViewDataCommon.Administration;

namespace ViewData.Administration
{
    public class StudyDesignViewModel
    {
        public StudyDesignViewModel()
        {
            using (DbStudyDesignGet mgr = new DbStudyDesignGet())
            {
                ListEntity = mgr.GetViewModel();
            }
        }

        public List<StudyDesign> ListEntity { get; set; }
    }
}