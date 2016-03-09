using System.Collections.Generic;
using System.Web.Mvc;
using ClaudeViewManagement.ViewModels.People;

namespace ClaudeBootstrap.Controllers.Settings.People
{
    public class StaffUserController : Controller
    {
        public ActionResult Index()
        {
            StaffUserViewModel vm = new StaffUserViewModel();

            vm.HandleRequest();

            return View(vm);
        }

        [HttpPost]
        public ActionResult Index(StaffUserViewModel vm)
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