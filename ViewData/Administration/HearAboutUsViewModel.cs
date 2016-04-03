using System.Collections.Generic;
using DataLayerRetrieval.Administration;
using ViewDataCommon.Administration;

namespace ViewData.Administration
{
    public class HearAboutUsViewModel
    {
        public HearAboutUsViewModel()
        {
            using (DbHearAboutUsGet mgr = new DbHearAboutUsGet())
            {
                ListEntity = mgr.GetViewModel();
            }
        }

        public List<HearAboutUs> ListEntity { get; set; }
    }
}