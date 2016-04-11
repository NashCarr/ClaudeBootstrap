using System.Collections.Generic;
using System.Web.Mvc;
using CommonDataReorder;
using CommonDataSave.Customer;
using CommonDataSave.People;
using CommonDataSave.Places;
using ManagementDelete.Customer;
using ManagementDelete.Person;
using ManagementDelete.Place;
using ManagementReorder;
using ManagementSave.Customer;
using ManagementSave.Person;
using ManagementSave.Place;
using ViewData.Person;
using ViewData.Place;
using ViewData.Places;

namespace ClaudeBootstrap.Controllers.Places
{
    [RoutePrefix("Customer")]
    public class CustomerController : Controller
    {
        [Route("")]
        [HttpGet]
        public ActionResult Index()
        {
            return View(new CustomerListViewModel());
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
            return
                Json(string.IsNullOrEmpty(id)
                    ? new CustomerViewModel(0)
                    : new CustomerViewModel(int.Parse(id)));
        }

        [HttpPost]
        public JsonResult GetPerson(string id)
        {
            return
                Json(string.IsNullOrEmpty(id)
                    ? new CustomerContactViewModel(0)
                    : new CustomerContactViewModel(int.Parse(id)));
        }

        [HttpPost]
        public void DisplayOrder(List<DisplayReorder> list)
        {
            using (CustomerReorderManager mgr = new CustomerReorderManager())
            {
                mgr.SaveDisplayOrder(list);
            }
        }

        [Route("{id:int}")]
        [HttpDelete]
        public JsonResult Delete(int id)
        {
            using (PlaceDeleteManager mgr = new PlaceDeleteManager())
            {
                return Json(mgr.DeleteCustomer(id));
            }
        }

        [HttpPost]
        public JsonResult DeleteContact(int id)
        {
            using (PersonDeleteManager mgr = new PersonDeleteManager())
            {
                return Json(mgr.DeleteCustomerContact(id));
            }
        }

        [HttpPost]
        public JsonResult DeleteBrand(int id)
        {
            using (CustomerBrandDeleteManager mgr = new CustomerBrandDeleteManager())
            {
                return Json(mgr.DeleteRecord(id));
            }
        }
    }
}