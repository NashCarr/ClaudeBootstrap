using CommonDataSave.Shared;
using DataLayerCommon.Places;

namespace CommonDataSave.Places
{
    public class PlaceSaveModel : AddressPhoneSaveModel
    {
        public PlaceBase Place { get; set; }
    }
}