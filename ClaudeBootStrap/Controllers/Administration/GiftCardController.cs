using System.Collections.Generic;
using System.Web.Mvc;
using CommonDataReorder;
using CommonDataSave;
using ManagementDelete.Administration;
using ManagementReorder;
using ManagementSave.Administration;
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
            using (GiftCardReorderManager mgr = new GiftCardReorderManager())
            {
                mgr.SaveDisplayReorder(list);
            }
        }

        [Route("{id:int}")]
        [HttpDelete]
        public JsonResult Delete(int id)
        {
            using (GiftCardDeleteManager mgr = new GiftCardDeleteManager())
            {
                return Json(mgr.DeleteRecord(id));
            }
        }
    }
}