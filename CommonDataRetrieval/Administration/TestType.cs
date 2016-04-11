namespace CommonDataRetrieval.Administration
{
    public class TestType : IsSystemBase
    {
        public TestType()
        {
            Radius = 0;
            RadiusSort = string.Empty;
        }

        public int Radius { get; set; }
        public string RadiusSort { get; set; }
    }
}