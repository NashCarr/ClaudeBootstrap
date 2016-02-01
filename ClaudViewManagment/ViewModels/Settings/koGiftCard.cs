using System.Collections.Generic;
using ClaudeData.DataRepository.AdminRepository;
using ClaudeData.Models.Admin;

namespace ClaudeViewManagement.ViewModels.Settings
{
    public class KoGiftCard
    {
        public KoGiftCard()
        {
            Entity = new GiftCard();
            SearchEntity = string.Empty;
            using (DbGiftCardGet data = new DbGiftCardGet())
            {
                ListEntity = data.GetActiveRecords();
            }
        }
        public string SearchEntity { get; set; }
        public GiftCard Entity { get; set; }
        public List<GiftCard> ListEntity { get; set; }
    }
}
