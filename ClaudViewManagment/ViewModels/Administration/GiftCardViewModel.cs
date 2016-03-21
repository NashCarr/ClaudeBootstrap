using System.Collections.Generic;
using ClaudeCommon.Models.Administration;
using ClaudeViewManagement.Managers.Administration;

namespace ClaudeViewManagement.ViewModels.Administration
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