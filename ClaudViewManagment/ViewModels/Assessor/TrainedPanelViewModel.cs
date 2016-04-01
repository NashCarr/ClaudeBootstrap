using System.Collections.Generic;
using System.Web.Mvc;
using ClaudeCommon.Models.Assessor;
using ClaudeViewManagement.Managers.Assessor;
using ClaudeViewManagement.Managers.Shared;

namespace ClaudeViewManagement.ViewModels.Assessor
{
    public class TrainedPanelViewModel
    {
        public TrainedPanelViewModel()
        {
            using (TrainedPanelManager mgr = new TrainedPanelManager())
            {
                //ListEntity = mgr.GetList();
            }
            using (LookupManager mgr = new LookupManager())
            {
                Facilities = mgr.GetFacilities();
            }
        }

        public List<TrainedPanel> ListEntity { get; set; }
        public List<SelectListItem> Facilities { get; set; }
    }
}