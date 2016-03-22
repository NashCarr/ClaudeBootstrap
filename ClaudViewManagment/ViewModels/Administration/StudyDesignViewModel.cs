using System.Collections.Generic;
using ClaudeCommon.Models.Administration;
using ClaudeViewManagement.Managers.Administration;

namespace ClaudeViewManagement.ViewModels.Administration
{
    public class StudyDesignViewModel
    {
        public StudyDesignViewModel()
        {
            using (StudyDesignManager mgr = new StudyDesignManager())
            {
                ListEntity = mgr.GetList();
            }
        }

        public List<StudyDesign> ListEntity { get; set; }
    }
}