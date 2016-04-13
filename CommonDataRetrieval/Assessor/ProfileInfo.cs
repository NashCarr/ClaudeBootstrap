using CommonDataRetrieval.Base;

namespace CommonDataRetrieval.Assessor
{
    public class ProfileInfo : ModelBase
    {
        public ProfileInfo()
        {
            LastUpdate = string.Empty;
        }

        public string LastUpdate { get; set; }
    }
}