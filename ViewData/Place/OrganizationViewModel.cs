using CommonDataRetrieval.Places;
using ManagementRetrieval.Places;

namespace ViewData.Place
{
    public class OrganizationViewModel
    {
        public OrganizationViewModel(int id)
        {
            using (OrganizationGetManager mgr = new OrganizationGetManager())
            {
                Organization = mgr.GetOrganization(id);
            }
        }

        public PlaceView Organization { get; set; }
    }
}