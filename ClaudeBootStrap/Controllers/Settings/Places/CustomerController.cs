using System.Collections.Generic;
using System.Web.Mvc;
using ClaudeCommon.BaseModels;
using ClaudeData.DataRepository.PlaceRepository;
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
        public JsonResult SavePlace(Place p)
        {
            using (DbPlaceSave mgr = new DbPlaceSave())
            {
                return Json(mgr.SaveCustomer(ref p));
            }
        }

        [HttpPost]
        public JsonResult GetCustomer(string id)
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