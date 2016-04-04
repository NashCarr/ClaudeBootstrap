using System.Collections.Generic;
using System.Web.Mvc;
using ManagementLookup;
using ManagementRetrieval.Assessor;
using ViewDataCommon.Assessor;

namespace ViewData.Assessor
{
    public class TrainedPanelViewModel
    {
        public TrainedPanelViewModel()
        {
            using (TrainedPanelGetManager mgr = new TrainedPanelGetManager())
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