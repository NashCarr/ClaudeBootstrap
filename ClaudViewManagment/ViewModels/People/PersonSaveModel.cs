using DataManagement.Models.People;
using ViewManagement.ViewModels.Shared;

namespace ViewManagement.ViewModels.People
{
    public class PersonSaveModel : AddressPhoneSaveModel
    {
        public Person Person { get; set; }
    }
}