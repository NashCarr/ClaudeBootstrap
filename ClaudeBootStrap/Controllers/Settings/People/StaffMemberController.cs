using System.Collections.Generic;
using System.Web.Mvc;
using ClaudeViewManagement.ViewModels.People;

namespace ClaudeBootstrap.Controllers.Settings.People
{
    public class StaffMemberController : Controller
    {
        public ActionResult Index()
        {
            StaffMemberViewModel vm = new StaffMemberViewModel();

            vm.HandleRequest();

            return View(vm);
        }

        [HttpPost]
        public ActionResult Index(StaffMemberViewModel vm)
        {
            vm.IsValid = ModelState.IsValid;
            vm.HandleRequest();

            if (vm.IsValid)
            {
                // NOTE: Must clear the model state in order to bind
                //       the @Html helpers to the new model values
                ModelState.Clear();
            }
            else
            {
                foreach (KeyValuePair<string, string> item in vm.ValidationErrors)
                {
                    ModelState.AddModelError(item.Key, item.Value);
                }
            }

            return View(vm);
        }
    }
}