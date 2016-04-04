using DataLayerCommon.Places;
using SaveDataCommon.Shared;

namespace SaveDataCommon.Places
{
    public class PlaceSaveModel : AddressPhoneSaveModel
    {
        public Place Place { get; set; }
    }
}