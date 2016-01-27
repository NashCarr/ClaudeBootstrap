using System.Collections.Generic;
using System.Web.Mvc;
using ClaudeViewManagement.ViewModels.Settings.Places;

namespace ClaudeBootstrap.Controllers.Settings.Places
{
    public class OrganizationController : Controller
    {
        public ActionResult Index()
        {
            OrganizationViewModel vm = new OrganizationViewModel();

            vm.HandleRequest();

            return View(vm);
        }

        [HttpPost]
        public ActionResult Index(OrganizationViewModel vm)
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