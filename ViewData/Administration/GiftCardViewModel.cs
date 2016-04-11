using System.Collections.Generic;
using CommonDataRetrieval.Administration;
using ManagementRetrieval.Administration;

namespace ViewData.Administration
{
    public class GiftCardViewModel
    {
        public GiftCardViewModel()
        {
            using (AdministrationGetManager mgr = new AdministrationGetManager())
            {
                ListEntity = mgr.GetGiftCardList();
            }
        }

        public List<GiftCard> ListEntity { get; set; }
    }
}