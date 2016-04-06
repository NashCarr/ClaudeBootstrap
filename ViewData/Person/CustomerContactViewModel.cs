using CommonDataRetrieval.People;
using ManagementRetrieval.Places;

namespace ViewData.Person
{
    public class CustomerContactViewModel
    {
        public CustomerContactViewModel(int id)
        {
            using (PlaceContactGetManager db = new PlaceContactGetManager())
            {
                CustomerContact =  db.GetCustomerContact(id);
            }
        }

        public PersonView CustomerContact { get; set; }
    }
}