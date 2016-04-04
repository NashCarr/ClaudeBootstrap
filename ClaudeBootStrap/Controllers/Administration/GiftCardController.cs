using System.Collections.Generic;
using System.Web.Mvc;
using ManagementSave.Administration;
using SaveDataCommon;
using SaveDataCommon.DisplayReorder;
using ViewData.Administration;

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
            using (GiftCardSaveManager mgr = new GiftCardSaveManager())
            {
                return Json(mgr.SaveRecord(data));
            }
        }

        [HttpPost]
        public void DisplayOrder(List<DisplayReorder> list)
        {
            using (GiftCardSaveManager mgr = new GiftCardSaveManager())
            {
                mgr.SaveDisplayReorder(list);
            }
        }

        [Route("{id:int}")]
        [HttpDelete]
        public JsonResult Delete(int id)
        {
            using (GiftCardSaveManager mgr = new GiftCardSaveManager())
            {
                return Json(mgr.DeleteRecord(id));
            }
        }
    }
}