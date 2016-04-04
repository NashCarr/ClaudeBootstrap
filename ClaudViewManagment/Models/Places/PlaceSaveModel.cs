using DataLayerCommon.Places;
using ViewManagement.Models.Shared;

namespace ViewManagement.Models.Places
{
    public class PlaceSaveModel : AddressPhoneSaveModel
    {
        public Place Place { get; set; }
    }
}