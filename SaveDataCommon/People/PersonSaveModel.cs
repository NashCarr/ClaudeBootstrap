using DataLayerCommon.People;
using SaveDataCommon.Shared;

namespace SaveDataCommon.People
{
    public class PersonSaveModel : AddressPhoneSaveModel
    {
        public Person Person { get; set; }
    }
}