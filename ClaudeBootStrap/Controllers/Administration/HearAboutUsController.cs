using System.Collections.Generic;
using System.Web.Mvc;
using CommonData.BaseModels;
using CommonData.Models.Administration;
using ViewData.Administration;
using ViewManagement.Managers.Administration;

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
        public JsonResult Save(HearAboutUs entity)
        {
            using (HearAboutUsManager mgr = new HearAboutUsManager())
            {
                return Json(mgr.SaveRecord(entity));
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