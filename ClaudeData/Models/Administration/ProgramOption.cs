using DataManagement.BaseModels;

namespace DataManagement.Models.Administration
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