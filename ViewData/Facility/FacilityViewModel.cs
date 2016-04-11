using CommonDataRetrieval.Places;
using ManagementRetrieval.Facility;

namespace ViewData.Facility
{
    public class FacilityViewModel
    {
        public FacilityViewModel(int id)
        {
            using (FacilityGetManager mgr = new FacilityGetManager())
            {
                Facility = mgr.GetFacility(id);
            }
        }

        public PlaceView Facility { get; set; }
    }
}