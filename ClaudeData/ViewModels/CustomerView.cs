using System.Collections.Generic;
using ViewDataCommon.Customer;

namespace DataManagement.ViewModels
{
    public class CustomerView : PlaceView
    {
        public List<CustomerBrand> CustomerBrands { get; set; }
    }
}