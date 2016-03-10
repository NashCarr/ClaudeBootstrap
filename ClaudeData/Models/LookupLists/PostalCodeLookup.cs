using static ClaudeCommon.Enums.CountryEnums;

namespace ClaudeData.Models.LookupLists
{
    public class PostalCodeLookup
    {
        public PostalCodeLookup()
        {
            StateProvinceId = 0;
            Text = string.Empty;
            City = string.Empty;
            Value = string.Empty;
            Country = Country.None;
        }

        public string Text { get; set; }
        public string City { get; set; }
        public string Value { get; set; }
        public Country Country { get; set; }
        public int StateProvinceId { get; set; }
    }
}