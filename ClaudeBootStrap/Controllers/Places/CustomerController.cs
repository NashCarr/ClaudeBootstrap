using System.Collections.Generic;
using System.Web.Mvc;
using CommonData.Enums;
using SaveDataCommon;
using ViewDataCommon.Customer;
using ViewManagement.Managers.Customer;
using ViewManagement.Managers.People;
using ViewManagement.Managers.Places;
using ViewManagement.Models.People;
using ViewManagement.Models.Places;

namespace ClaudeBootstrap.Controllers.Places
{
    [RoutePrefix("Customer")]
    public class CustomerController : Controller
    {
        [Route("")]
        [HttpGet]
        public ActionResult Index()
        {
            return View(new PlaceListViewModel(PlaceEnums.PlaceType.Customer));
        }

        [HttpPost]
        public JsonResult SavePlace(PlaceSaveModel p)
        {
            if (p.Place != null) p.Place.PlaceType = PlaceEnums.PlaceType.Customer;
            using (PlaceSaveManager mgr = new PlaceSaveManager())
            {
                return Json(mgr.SavePlace(p));
            }
        }

        [HttpPost]
        public JsonResult SaveContact(PersonSaveModel c)
        {
            if (c != null) c.Person.PersonType = PersonEnums.PersonType.CustomerContact;
            using (PersonSaveManager mgr = new PersonSaveManager())
            {
                return Json(mgr.SavePerson(c));
            }
        }

        [HttpPost]
        public JsonResult SaveBrand(CustomerBrand c)
        {
            using (CustomerBrandManager mgr = new CustomerBrandManager())
            {
                return Json(mgr.SaveRecord(c));
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
        public JsonResult GetPerson(string id)
        {
            using (PlaceContactGetManager mgr = new PlaceContactGetManager())
            {
                return Json(id != null ? mgr.GetCustomerContact(int.Parse(id)) : mgr.GetCustomerContact(0));
            }
        }

        [HttpPost]
        public void DisplayOrder(List<DisplayReorder> list)
        {
            using (CustomerManager mgr = new CustomerManager())
            {
                mgr.SaveDisplayOrder(list);
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
            using (PlaceContactDeleteManager mgr = new PlaceContactDeleteManager())
            {
                return Json(mgr.DeleteCustomerContact(id));
            }
        }

        [HttpPost]
        public JsonResult DeleteBrand(int id)
        {
            using (CustomerBrandManager mgr = new CustomerBrandManager())
            {
                return Json(mgr.DeleteRecord(id));
            }
        }
    }
}