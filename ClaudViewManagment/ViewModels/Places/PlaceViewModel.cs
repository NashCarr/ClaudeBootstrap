using System.Collections.Generic;
using ClaudeCommon.Models;
using ClaudeViewManagement.Managers.Places;
using static ClaudeCommon.Enums.PlaceEnums;

namespace ClaudeViewManagement.ViewModels.Places
{
    public class PlaceViewModel
    {
        public PlaceViewModel(PlaceType pt)
        {
            using (PlaceManager mgr = new PlaceManager())
            {
                ListEntity = mgr.GetList(pt);
            }
        }
        public List<Place> ListEntity { get; set; }
    }
}