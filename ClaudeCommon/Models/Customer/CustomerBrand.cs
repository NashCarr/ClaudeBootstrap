using ClaudeCommon.Models.Administration;

namespace ClaudeCommon.Models.Customer
{
    public class CustomerBrand : AdministrationBase
    {
        public CustomerBrand()
        {
            CustomerId = 0;
        }
        public int CustomerId { get; set; }
    }
}