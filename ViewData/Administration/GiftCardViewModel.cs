using System.Collections.Generic;
using CommonDataRetrieval.Administration;
using DataLayerRetrieval.Administration;

namespace ViewData.Administration
{
    public class GiftCardViewModel
    {
        public GiftCardViewModel()
        {
            using (DbGiftCardGet db = new DbGiftCardGet())
            {
                ListEntity = db.GetViewModel();
            }
        }

        public List<GiftCard> ListEntity { get; set; }
    }
}