using System.Collections.Generic;
using CommonData.Models.Customer;

namespace DataManagement.ViewModels
{
    public class CustomerView : PlaceView
    {
        public List<CustomerBrand> CustomerBrands { get; set; }
    }
}