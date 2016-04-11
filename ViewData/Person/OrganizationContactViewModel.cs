using CommonDataRetrieval.People;
using ManagementRetrieval.People;

namespace ViewData.Person
{
    public class OrganizationContactViewModel
    {
        public OrganizationContactViewModel(int id)
        {
            using (PlaceContactGetManager mgr = new PlaceContactGetManager())
            {
                OrganizationContact = mgr.GetOrganizationContact(id);
            }
        }

        public PersonView OrganizationContact { get; set; }
    }
}