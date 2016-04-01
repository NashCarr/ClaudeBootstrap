using System.Collections.Generic;
using System.Web.Mvc;
using CommonData.BaseModels;
using CommonData.Models.Administration;
using ViewData.Administration;
using ViewManagement.Managers.Administration;

namespace ClaudeBootstrap.Controllers.Administration
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

        [HttpPost]
        public JsonResult Save(GiftCard entity)
        {
            using (GiftCardManager mgr = new GiftCardManager())
            {
                return Json(mgr.SaveRecord(entity));
            }
        }

        [HttpPost]
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