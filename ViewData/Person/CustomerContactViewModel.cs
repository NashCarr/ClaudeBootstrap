using CommonDataRetrieval.People;
using ManagementRetrieval.People;

namespace ViewData.Person
{
    public class CustomerContactViewModel
    {
        public CustomerContactViewModel(int id)
        {
            using (PersonViewGetManager mgr = new PersonViewGetManager())
            {
                CustomerContact = mgr.GetCustomerContact(id);
            }
        }

        public PersonView CustomerContact { get; set; }
    }
}