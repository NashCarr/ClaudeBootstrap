using ClaudeData.Models.People;
using ClaudeViewManagement.ViewModels.Shared;

namespace ClaudeViewManagement.ViewModels.People
{
    public class PersonSaveModel : AddressPhoneSaveModel
    {
        public Person Person { get; set; }
    }
}