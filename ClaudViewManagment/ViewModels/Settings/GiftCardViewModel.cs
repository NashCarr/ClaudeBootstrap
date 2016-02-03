using System.Collections.Generic;
using ClaudeCommon.Models;
using ClaudeViewManagement.Managers.Settings;

namespace ClaudeViewManagement.ViewModels.Settings
{
    public class GiftCardViewModel
    {
        public GiftCardViewModel()
        {
            using (GiftCardManager mgr = new GiftCardManager())
            {
                ListEntity = mgr.GetList();
            }
        }
        public List<GiftCard> ListEntity { get; set; }
    }
}