using CommonDataRetrieval.Places;
using ManagementRetrieval.Places;

namespace ViewData.Place
{
    public class OrganizationViewModel
    {
        public OrganizationViewModel(int id)
        {
            using (OrganizationGetManager db = new OrganizationGetManager())
            {
                Organization = db.GetOrganization(id);
            }
        }

        public PlaceView Organization { get; set; }
    }
}