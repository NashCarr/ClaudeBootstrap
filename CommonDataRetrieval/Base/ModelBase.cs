namespace CommonDataRetrieval.Base
{
    public class ModelBase
    {
        public ModelBase()
        {
            RecordId = 0;
            Name = string.Empty;
        }

        public string Name { get; set; }
        public int RecordId { get; set; }
    }
}