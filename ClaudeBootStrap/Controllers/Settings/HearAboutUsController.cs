using System.Collections.Generic;
using System.Web.Mvc;
using ClaudeViewManagement.ViewModels.Settings;

namespace ClaudeBootstrap.Controllers.Settings
{
    public class HearAboutUsController : Controller
    {
        public ActionResult Index()
        {
            HearAboutUsViewModel vm = new HearAboutUsViewModel();

            vm.HandleRequest();

            return View(vm);
        }

        [HttpPost]
        public ActionResult Index(HearAboutUsViewModel vm)
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