namespace CommonData.Enums
{
    public class AddressEnums
    {
        public enum AddressType : byte
        {
            None,
            Physical,
            Mailing
        }

        public enum DistanceType : byte
        {
            None,
            Postal,
            Address
        }
    }
}