using CommonDataRetrieval.People;
using ManagementRetrieval.People;

namespace ViewData.Person
{
    public class OrganizationContactViewModel
    {
        public OrganizationContactViewModel(int id)
        {
            using (PlaceContactGetManager db = new PlaceContactGetManager())
            {
                OrganizationContact = db.GetOrganizationContact(id);
            }
        }

        public PersonView OrganizationContact { get; set; }
    }
}