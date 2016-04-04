using DataLayerCommon.BaseModels;

namespace DataLayerCommon.Administration
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