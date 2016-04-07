using CommonDataRetrieval.Places;
using ManagementRetrieval.Facility;

namespace ViewData.Facility
{
    public class FacilityViewModel
    {
        public FacilityViewModel(int id)
        {
            using (FacilityGetManager db = new FacilityGetManager())
            {
                Facility = db.GetFacility(id);
            }
        }

        public PlaceView Facility { get; set; }
    }
}