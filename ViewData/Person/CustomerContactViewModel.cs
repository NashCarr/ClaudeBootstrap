using CommonDataRetrieval.People;
using ManagementRetrieval.People;

namespace ViewData.Person
{
    public class CustomerContactViewModel
    {
        public CustomerContactViewModel(int id)
        {
            using (PlaceContactGetManager mgr = new PlaceContactGetManager())
            {
                CustomerContact = mgr.GetCustomerContact(id);
            }
        }

        public PersonView CustomerContact { get; set; }
    }
}