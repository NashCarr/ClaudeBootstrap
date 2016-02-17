using System.Collections.Generic;
using System.Web.Mvc;
using ClaudeCommon.BaseModels;
using ClaudeViewManagement.Managers.Places;
using ClaudeViewManagement.Managers.Settings;
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

        //[HttpPost]
        //public JsonResult Save(Customer entity)
        //{
        //    using (CustomerManager mgr = new CustomerManager())
        //    {
        //        return Json(mgr.SaveRecord(entity));
        //    }
        //}

        [HttpPost]
        public void DisplayOrder(List<DisplayReorder> list)
        {
            using (PlaceManager mgr = new PlaceManager())
            {
                //mgr.SaveDisplayReorder(list);
            }
        }

        [Route("{id:int}")]
        [HttpDelete]
        public JsonResult Delete(int id)
        {
            using (PlaceManager mgr = new PlaceManager())
            {
                return Json(mgr.DeleteRecord(PlaceType.Customer, id));
            }
        }
    }
}