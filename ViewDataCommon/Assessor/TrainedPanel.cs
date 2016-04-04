using ViewDataCommon.Base;

namespace ViewDataCommon.Assessor
{
    public class TrainedPanel : AdministrationBase
    {
        public TrainedPanel()
        {
            FacilityId = 0;
            FacilityName = string.Empty;
            ExcludeFromConsumerTesting = false;
        }

        public int FacilityId { get; set; }
        public string FacilityName { get; set; }
        public bool ExcludeFromConsumerTesting { get; set; }
    }
}