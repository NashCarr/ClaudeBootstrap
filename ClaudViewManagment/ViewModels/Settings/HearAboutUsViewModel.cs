using System.Collections.Generic;
using ClaudeCommon.Models;
using ClaudeViewManagement.Managers.Settings;

namespace ClaudeViewManagement.ViewModels.Settings
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