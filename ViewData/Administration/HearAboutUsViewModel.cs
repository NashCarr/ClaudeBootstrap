using System.Collections.Generic;
using CommonData.Models.Administration;
using DataRetrievalLayer.Administration;

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