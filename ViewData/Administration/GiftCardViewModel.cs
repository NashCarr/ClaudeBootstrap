using System.Collections.Generic;
using CommonData.Models.Administration;
using DataLayerRetrieval.Administration;

namespace ViewData.Administration
{
    public class GiftCardViewModel
    {
        public GiftCardViewModel()
        {
            using (DbGiftCardGet data = new DbGiftCardGet())
            {
                ListEntity = data.GetViewModel();
            }
        }

        public List<GiftCard> ListEntity { get; set; }
    }
}