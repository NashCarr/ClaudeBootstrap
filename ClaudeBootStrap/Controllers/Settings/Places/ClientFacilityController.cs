using System.Collections.Generic;
using System.Web.Mvc;
using ClaudeViewManagement.ViewModels.Places;

namespace ClaudeBootstrap.Controllers.Settings.Places
{
    public class ClientFacilityController : Controller
    {
        public ActionResult Index()
        {
            ClientFacilityViewModel vm = new ClientFacilityViewModel();

            vm.HandleRequest();

            return View(vm);
        }

        [HttpPost]
        public ActionResult Index(ClientFacilityViewModel vm)
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