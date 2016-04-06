using static CommonData.Enums.PlaceEnums;

namespace ViewData.Places
{
    public class CustomerListViewModel
    {
        public CustomerListViewModel()
        {
            Customers = new PlaceListViewModel(PlaceType.Organization);
        }

        public PlaceListViewModel Customers { get; set; }
    }
}