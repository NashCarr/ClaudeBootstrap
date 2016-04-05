using CommonDataSave.Shared;
using DataLayerCommon.People;

namespace CommonDataSave.People
{
    public class PersonSaveModel : AddressPhoneSaveModel
    {
        public Person Person { get; set; }
    }
}