using System.Collections.Generic;
using ViewDataCommon.Customer;

namespace DataRetrievalCommon.Places
{
    public class CustomerView : PlaceView
    {
        public List<CustomerBrand> CustomerBrands { get; set; }
    }
}