using static CommonData.Enums.PlaceEnums;

namespace ViewData.Places
{
    public class OrganizationListViewModel
    {
        public OrganizationListViewModel()
        {
            Organizations = new PlaceListViewModel(PlaceType.Organization);
        }

        public PlaceListViewModel Organizations { get; set; }
    }
}