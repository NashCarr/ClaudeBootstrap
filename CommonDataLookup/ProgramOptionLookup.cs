namespace CommonDataLookup
{
    public class ProgramOptionLookup
    {
        public ProgramOptionLookup()
        {
            Text = string.Empty;
            Value = string.Empty;
            DefaultPermission = 0;
        }

        public string Text { get; set; }
        public string Value { get; set; }
        public short DefaultPermission { get; set; }
    }
}