using DataManagement.Models.Places;
using ViewManagement.ViewModels.Shared;

namespace ViewManagement.ViewModels.Places
{
    public class PlaceSaveModel : AddressPhoneSaveModel
    {
        public Place Place { get; set; }
    }
}