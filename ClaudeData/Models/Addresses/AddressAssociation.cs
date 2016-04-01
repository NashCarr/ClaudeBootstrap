namespace DataManagement.Models.Addresses
{
    public class AddressAssociation : Address
    {
        public AddressAssociation()
        {
            AddressAssociationId = 0;
        }

        public int AddressAssociationId { get; set; }
    }
}