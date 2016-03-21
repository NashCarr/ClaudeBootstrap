using System.Collections.Generic;
using ClaudeCommon.Models.Administration;
using ClaudeViewManagement.Managers.Administration;

namespace ClaudeViewManagement.ViewModels.Administration
{
    public class HearAboutUsViewModel
    {
        public HearAboutUsViewModel()
        {
            using (HearAboutUsManager mgr = new HearAboutUsManager())
            {
                ListEntity = mgr.GetList();
            }
        }

        public List<HearAboutUs> ListEntity { get; set; }
    }
}