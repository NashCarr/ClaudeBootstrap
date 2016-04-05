using System.Collections.Generic;
using CommonDataRetrieval.Customer;

namespace CommonDataRetrieval.Places
{
    public class CustomerView : PlaceView
    {
        public List<CustomerBrand> CustomerBrands { get; set; }
    }
}