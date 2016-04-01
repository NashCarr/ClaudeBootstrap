namespace DataManagement.Models.Phones
{
    public class PhoneAssociation : Phone
    {
        public PhoneAssociation()
        {
            PhoneAssociationId = 0;
        }

        public int PhoneAssociationId { get; set; }
    }
}