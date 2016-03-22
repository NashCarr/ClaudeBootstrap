namespace ClaudeCommon.Models.Administration
{
    public class StudyDesign : IsSystemBase
    {
        public StudyDesign()
        {
            Radius = 0;
            RadiusSort = string.Empty;
        }

        public int Radius { get; set; }
        public string RadiusSort { get; set; }
    }
}