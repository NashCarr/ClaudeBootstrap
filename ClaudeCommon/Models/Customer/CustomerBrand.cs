using ClaudeCommon.BaseModels;

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