using System.ComponentModel;

namespace DataLayerCommon.Enums
{
    public class CountryEnums
    {
        public enum Country : short
        {
            None,
            Canada = 124,
            [Description("United States")] UnitedStates = 840
        }
    }
}