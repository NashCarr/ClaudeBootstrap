using DataLayerCommon.People;
using ViewManagement.Models.Shared;

namespace ViewManagement.Models.People
{
    public class PersonSaveModel : AddressPhoneSaveModel
    {
        public Person Person { get; set; }
    }
}