using System.Collections.Generic;
using ClaudeCommon.Models.Assessor;
using ClaudeViewManagement.Managers.Assessor;

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
        }

        public List<TrainedPanel> ListEntity { get; set; }
    }
}