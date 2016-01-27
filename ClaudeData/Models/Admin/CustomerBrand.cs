using ClaudeData.BaseModels;

namespace ClaudeData.Models.Admin
{
    public class CustomerBrand : AdminBase
    {
        public CustomerBrand()
        {
            CustomerId = 0;
        }

        public int CustomerId { get; set; }
    }
}