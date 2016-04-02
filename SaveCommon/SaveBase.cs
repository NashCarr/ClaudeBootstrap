namespace SaveDataCommon
{
    public class SaveBase
    {
        public SaveBase()
        {
            Id = 0;
            Name = string.Empty;
        }

        public int Id { get; set; }
        public string Name { get; set; }
    }
}