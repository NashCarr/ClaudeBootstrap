using System.Collections.Generic;
using System.Web.Mvc;
using SaveDataCommon;
using ViewData.Administration;
using ViewManagement.Managers.Administration;
using DisplayReorder = CommonData.BaseModels.DisplayReorder;

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
        public JsonResult Save(SaveBase data)
        {
            using (GiftCardManager mgr = new GiftCardManager())
            {
                return Json(mgr.SaveRecord(data));
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