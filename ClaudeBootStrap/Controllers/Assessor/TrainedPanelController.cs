using System.Collections.Generic;
using System.Web.Mvc;
using CommonData.Models.Assessor;
using SaveDataCommon;
using ViewData.Assessor;
using ViewManagement.Managers.Assessor;

namespace ClaudeBootstrap.Controllers.Assessor
{
    [RoutePrefix("TrainedPanel")]
    public class TrainedPanelController : Controller
    {
        [Route("")]
        [HttpGet]
        public ActionResult Index()
        {
            return View(new TrainedPanelViewModel());
        }

        [HttpPost]
        public JsonResult Save(TrainedPanel entity)
        {
            using (TrainedPanelManager mgr = new TrainedPanelManager())
            {
                return Json(mgr.SaveRecord(entity));
            }
        }

        [HttpPost]
        public void DisplayOrder(List<DisplayReorder> list)
        {
            using (TrainedPanelManager mgr = new TrainedPanelManager())
            {
                mgr.SaveDisplayReorder(list);
            }
        }

        [Route("{id:int}")]
        [HttpDelete]
        public JsonResult Delete(int id)
        {
            using (TrainedPanelManager mgr = new TrainedPanelManager())
            {
                return Json(mgr.DeleteRecord(id));
            }
        }
    }
}