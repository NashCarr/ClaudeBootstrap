namespace DataLayerCommon.Enums
{
    public class EmailEnums
    {
        public enum EmailAddressType : byte
        {
            None,
            From,
            To,
            Cc,
            ReplyTo
        }
    }
}