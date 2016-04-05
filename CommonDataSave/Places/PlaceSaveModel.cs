using CommonDataSave.Shared;
using DataLayerCommon.Places;

namespace CommonDataSave.Places
{
    public class PlaceSaveModel : AddressPhoneSaveModel
    {
        public Place Place { get; set; }
    }
}