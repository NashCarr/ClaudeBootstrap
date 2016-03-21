using ClaudeData.Models.Places;
using ClaudeViewManagement.ViewModels.Shared;

namespace ClaudeViewManagement.ViewModels.Places
{
    public class PlaceSaveModel : AddressPhoneSaveModel
    {
        public Place Place { get; set; }
    }
}