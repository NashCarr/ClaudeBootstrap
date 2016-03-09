using System.Collections.Generic;
using System.Web.Mvc;
using ClaudeViewManagement.ViewModels.People;

namespace ClaudeBootstrap.Controllers.Settings.People
{
    public class CustomerContactController : Controller
    {
        public ActionResult Index()
        {
            PlaceContactViewModel vm = new PlaceContactViewModel();

            vm.HandleRequest();

            return View(vm);
        }

        [HttpPost]
        public ActionResult Index(PlaceContactViewModel vm)
        {
            vm.IsValid = ModelState.IsValid;
            vm.HandleRequest();

            if (vm.IsValid)
            {
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