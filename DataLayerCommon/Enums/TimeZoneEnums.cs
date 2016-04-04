using System.ComponentModel;

namespace DataLayerCommon.Enums
{
    public class TimeZoneEnums
    {
        public enum ClaudeTimeZone : byte
        {
            [Description("Please Select")] None = 0,
            Alaska = 2,
            [Description("Atlantic (Canada)")] AtlanticCanada = 6,
            Central = 21,
            Eastern = 29,
            Hawaii = 39,
            Mountain = 47,
            Pacific = 58,
            [Description("Indiana (East)")] IndianaEast = 74,
            Arizona = 75
        }
    }
}