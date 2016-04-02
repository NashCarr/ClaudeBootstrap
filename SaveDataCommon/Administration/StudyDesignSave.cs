namespace SaveDataCommon.Administration
{
    public class StudyDesignSave : SaveBase
    {
        public StudyDesignSave()
        {
            Radius = 0;
        }

        public int Radius { get; set; }
    }
}