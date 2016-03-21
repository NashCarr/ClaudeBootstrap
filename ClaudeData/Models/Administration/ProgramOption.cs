using ClaudeData.BaseModels;

namespace ClaudeData.Models.Administration
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