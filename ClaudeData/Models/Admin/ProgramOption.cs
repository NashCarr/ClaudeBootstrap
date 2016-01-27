using ClaudeData.BaseModels;

namespace ClaudeData.Models.Admin
{
    public class ProgramOption : AdminBase
    {
        public ProgramOption()
        {
            DefaultRight = string.Empty;
        }

        public string DefaultRight { get; set; }
    }
}