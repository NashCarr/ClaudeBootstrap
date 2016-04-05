using System.Collections.Generic;
using System.Web.Mvc;
using CommonDataSave.Customer;
using CommonDataSave.DisplayReorder;
using CommonDataSave.People;
using CommonDataSave.Places;
using ManagementRetrieval.Customer;
using ManagementRetrieval.Places;
using ManagementSave.Customer;
using ManagementSave.Person;
using ManagementSave.Places;
using ViewData.Places;
using static CommonData.Enums.PlaceEnums;

namespace ClaudeBootstrap.Controllers.Places
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
            using (PlaceSaveManager mgr = new PlaceSaveManager())
            {
                return Json(mgr.SaveCustomer(p));
            }
        }

        [HttpPost]
        public JsonResult SaveContact(PersonSaveModel p)
        {
            using (PersonSaveManager mgr = new PersonSaveManager())
            {
                return Json(mgr.SaveCustomerContact(p));
            }
        }

        [HttpPost]
        public JsonResult SaveBrand(CustomerBrandSave c)
        {
            using (CustomerBrandSaveManager mgr = new CustomerBrandSaveManager())
            {
                return Json(mgr.SaveRecord(c));
            }
        }

        [HttpPost]
        public JsonResult GetPlace(string id)
        {
            using (CustomerGetManager mgr = new CustomerGetManager())
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
            using (CustomerSaveManager mgr = new CustomerSaveManager())
            {
                mgr.SaveDisplayOrder(list);
            }
        }

        [Route("{id:int}")]
        [HttpDelete]
        public JsonResult Delete(int id)
        {
            using (CustomerSaveManager mgr = new CustomerSaveManager())
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
            using (CustomerBrandSaveManager mgr = new CustomerBrandSaveManager())
            {
                return Json(mgr.DeleteRecord(id));
            }
        }
    }
}