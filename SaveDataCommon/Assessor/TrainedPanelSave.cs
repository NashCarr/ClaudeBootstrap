namespace SaveDataCommon.Assessor
{
    public class TrainedPanelSave : SaveBase
    {
        public TrainedPanelSave()
        {
            FacilityId = 0;
            ExcludeFromConsumerTesting = false;
        }

        public int FacilityId { get; set; }
        public bool ExcludeFromConsumerTesting { get; set; }
    }
}