using System.Collections.Generic;
using System.Web.Mvc;
using ClaudeCommon.BaseModels;
using ClaudeCommon.Models;
using ClaudeViewManagement.Managers.Settings;
using ClaudeViewManagement.ViewModels.Settings;
using Microsoft.Ajax.Utilities;

namespace ClaudeBootstrap.Controllers
{
    [RoutePrefix("GiftCard")]
    public class GiftCardController : Controller
    {
        [Route("")]
        [HttpGet]
        public ActionResult Index()
        {
            return View(new GiftCardViewModel());
        }

        //[Route("")]
        [HttpPost]
        //[ActionName("save")]
        public JsonResult Save(GiftCard entity)
        {
            using (GiftCardManager mgr = new GiftCardManager())
            {
                return Json(mgr.SaveRecord(entity));
            }
        }

        //[Route("")]
        [HttpPost]
        //[ActionName("reorder")]
        public void DisplayOrder(List<DisplayReorder> list)
        {
            using (GiftCardManager mgr = new GiftCardManager())
            {
                mgr.SaveDisplayReorder(list);
            }
        }

        [Route("{id:int}")]
        [HttpDelete]
        public JsonResult Delete(int id)
        {
            using (GiftCardManager mgr = new GiftCardManager())
            {
                return Json(mgr.DeleteRecord(id));
            }
        }
    }
}