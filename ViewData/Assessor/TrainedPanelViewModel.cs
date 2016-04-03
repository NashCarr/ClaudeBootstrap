using System.Collections.Generic;
using System.Web.Mvc;
using CommonData.Models.Assessor;
using ManagementLookup;
using ViewManagement.Managers.Assessor;

namespace ViewData.Assessor
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