using CommonData.Enums;

namespace DataManagement.Models.Addresses
{
    public abstract class Address : PostalCode
    {
        protected Address()
        {
            AddressId = 0;
            Address1 = string.Empty;
            Address2 = string.Empty;
            AddressType = AddressEnums.AddressType.None;
            AddressCoordinates = new Coordinates();
        }

        public int AddressId { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public AddressEnums.AddressType AddressType { get; set; }
        public Coordinates AddressCoordinates { get; set; }
    }
}