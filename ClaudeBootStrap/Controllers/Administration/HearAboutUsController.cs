using System.Collections.Generic;
using System.Web.Mvc;
using ManagementSave.Administration;
using SaveDataCommon;
using SaveDataCommon.DisplayReorder;
using ViewData.Administration;

namespace ClaudeBootstrap.Controllers.Administration
{
    [RoutePrefix("HearAboutUs")]
    public class HearAboutUsController : Controller
    {
        [Route("")]
        [HttpGet]
        public ActionResult Index()
        {
            return View(new HearAboutUsViewModel());
        }

        [HttpPost]
        public JsonResult Save(SaveBase data)
        {
            using (HearAboutUsSaveManager mgr = new HearAboutUsSaveManager())
            {
                return Json(mgr.SaveRecord(data));
            }
        }

        [HttpPost]
        public void DisplayOrder(List<DisplayReorder> list)
        {
            using (HearAboutUsSaveManager mgr = new HearAboutUsSaveManager())
            {
                mgr.SaveDisplayReorder(list);
            }
        }

        [Route("{id:int}")]
        [HttpDelete]
        public JsonResult Delete(int id)
        {
            using (HearAboutUsSaveManager mgr = new HearAboutUsSaveManager())
            {
                return Json(mgr.DeleteRecord(id));
            }
        }
    }
}