using System.Collections.Generic;
using ClaudeCommon.Models.Customer;

namespace ClaudeData.ViewModels
{
    public class CustomerView : PlaceView
    {
        public List<CustomerBrand> CustomerBrands { get; set; }
    }
}