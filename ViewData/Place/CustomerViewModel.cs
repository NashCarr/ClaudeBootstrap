using CommonDataRetrieval.Places;
using ManagementRetrieval.Customer;

namespace ViewData.Place
{
    public class CustomerViewModel
    {
        public CustomerViewModel(int id)
        {
            using (CustomerGetManager db = new CustomerGetManager())
            {
                Customer = db.GetCustomer(id);
            }
        }

        public PlaceView Customer { get; set; }
    }
}