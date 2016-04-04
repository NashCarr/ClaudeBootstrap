using static DataLayerCommon.Enums.AddressEnums;

namespace DataLayerCommon.Addresses
{
    public abstract class Address : PostalCode
    {
        protected Address()
        {
            AddressId = 0;
            Address1 = string.Empty;
            Address2 = string.Empty;
            AddressType = AddressType.None;
            AddressCoordinates = new Coordinates();
        }

        public int AddressId { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public AddressType AddressType { get; set; }
        public Coordinates AddressCoordinates { get; set; }
    }
}