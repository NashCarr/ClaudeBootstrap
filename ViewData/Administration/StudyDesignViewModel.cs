using System.Collections.Generic;
using CommonData.Models.Administration;
using DataRetrievalLayer.Administration;

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