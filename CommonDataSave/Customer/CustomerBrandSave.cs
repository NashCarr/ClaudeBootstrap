namespace CommonDataSave.Customer
{
    public class CustomerBrandSave : SaveBase
    {
        public CustomerBrandSave()
        {
            CustomerId = 0;
        }

        public int CustomerId { get; set; }
    }
}