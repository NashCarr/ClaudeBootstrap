using System;

namespace ClaudeCommon.BaseModels.Returns
{
    public class ReturnBase
    {
        public ReturnBase()
        {
            Id = 0;
            ErrMsg = string.Empty;
            StringCreateDate = DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss tt");
        }

        public int Id { get; set; }
        public string ErrMsg { get; set; }
        public string StringCreateDate { get; set; }
    }
}