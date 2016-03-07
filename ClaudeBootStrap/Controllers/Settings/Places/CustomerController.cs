using System.Collections.Generic;
using System.Web.Mvc;
using ClaudeCommon.BaseModels;
using ClaudeViewManagement.Managers.People;
using ClaudeViewManagement.Managers.Places;
using ClaudeViewManagement.ViewModels.People;
using ClaudeViewManagement.ViewModels.Places;
using static ClaudeCommon.Enums.PersonEnums;
using static ClaudeCommon.Enums.PlaceEnums;

namespace ClaudeBootstrap.Controllers.Settings.Places
{
    [RoutePrefix("Customer")]
    public class CustomerController : Controller
    {
        [Route("")]
        [HttpGet]
        public ActionResult Index()
        {
            return View(new PlaceListViewModel(PlaceType.Customer));
        }

        [HttpPost]
        public JsonResult SavePlace(PlaceSaveModel p)
        {
            if (p.Place != null) p.Place.PlaceType = PlaceType.Customer;
            using (PlaceManager mgr = new PlaceManager())
            {
                return Json(mgr.SavePlace(p));
            }
        }

        [HttpPost]
        public JsonResult SaveContact(ContactSaveModel c)
        {
            if (c != null) c.Person.PersonType = PersonType.CustomerContact;
            using (ContactManager mgr = new ContactManager())
            {
                return Json(mgr.SaveContact(c));
            }
        }

        [HttpPost]
        public JsonResult GetPlace(string id)
        {
            using (CustomerManager mgr = new CustomerManager())
            {
                return Json(id != null ? mgr.GetCustomer(int.Parse(id)) : mgr.GetCustomer(0));
            }
        }

        [HttpPost]
        public void DisplayOrder(List<DisplayReorder> list)
        {
            using (CustomerManager mgr = new CustomerManager())
            {
                mgr.SaveCustomerOrder(list);
            }
        }

        [Route("{id:int}")]
        [HttpDelete]
        public JsonResult Delete(int id)
        {
            using (CustomerManager mgr = new CustomerManager())
            {
                return Json(mgr.DeleteCustomer(id));
            }
        }

        [HttpPost]
        public JsonResult DeleteContact(int id)
        {
            using (ContactManager mgr = new ContactManager())
            {
                return Json(mgr.DeleteCustomer(id));
            }
        }
    }
}