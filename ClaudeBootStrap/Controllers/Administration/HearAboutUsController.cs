using System.Collections.Generic;
using System.Web.Mvc;
using SaveDataCommon;
using SaveManagement.Administration;
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
            using (HearAboutUsManager mgr = new HearAboutUsManager())
            {
                return Json(mgr.SaveRecord(data));
            }
        }

        [HttpPost]
        public void DisplayOrder(List<DisplayReorder> list)
        {
            using (HearAboutUsManager mgr = new HearAboutUsManager())
            {
                mgr.SaveDisplayReorder(list);
            }
        }

        [Route("{id:int}")]
        [HttpDelete]
        public JsonResult Delete(int id)
        {
            using (HearAboutUsManager mgr = new HearAboutUsManager())
            {
                return Json(mgr.DeleteRecord(id));
            }
        }
    }
}