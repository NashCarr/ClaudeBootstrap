namespace ClaudeCommon.BaseModels
{
    public class ReturnBase
    {
        public ReturnBase()
        {
            Id = 0;
            ErrMsg = string.Empty;
        }

        public int Id { get; set; }
        public string ErrMsg { get; set; }
    }
}