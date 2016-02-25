using System.Collections.Generic;
using System.Web.Mvc;
using ClaudeCommon.BaseModels;
using ClaudeData.DataRepository.PlaceRepository;
using ClaudeData.Models.Phones;
using ClaudeData.Models.Places;
using ClaudeViewManagement.Managers.Places;
using ClaudeViewManagement.ViewModels.Places;
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
            using (PlaceManager mgr = new PlaceManager())
            {
                return Json(mgr.SavePlace(p));
            }
        }

        [HttpPost]
        public JsonResult SavePhone(int id, PhoneAssociation p)
        {
            using (DbPlacePhoneSave mgr = new DbPlacePhoneSave())
            {
                return Json(mgr.SaveCustomerPhone(id, p));
            }
        }

        [HttpPost]
        public JsonResult GetPlace(string id)
        {
            using (PlaceManager mgr = new PlaceManager())
            {
                return Json(id != null ? mgr.GetCustomer(int.Parse(id)) : mgr.GetCustomer(0));
            }
        }

        [HttpPost]
        public void DisplayOrder(List<DisplayReorder> list)
        {
            using (PlaceListManager mgr = new PlaceListManager())
            {
                //mgr.SaveDisplayReorder(list);
            }
        }

        [Route("{id:int}")]
        [HttpDelete]
        public JsonResult Delete(int id)
        {
            using (PlaceListManager mgr = new PlaceListManager())
            {
                return Json(mgr.DeleteRecord(PlaceType.Customer, id));
            }
        }
    }
}