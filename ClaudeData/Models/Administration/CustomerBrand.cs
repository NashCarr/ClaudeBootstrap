using ClaudeData.BaseModels;

namespace ClaudeData.Models.Administration
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