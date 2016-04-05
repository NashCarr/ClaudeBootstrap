using System.Collections.Generic;
using System.Web.Mvc;
using CommonDataSave.Assessor;
using CommonDataSave.DisplayReorder;
using ManagementSave.Assessor;
using ViewData.Assessor;

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
        public JsonResult Save(TrainedPanelSave data)
        {
            using (TrainedPanelSaveManager mgr = new TrainedPanelSaveManager())
            {
                return Json(mgr.SaveRecord(data));
            }
        }

        [HttpPost]
        public void DisplayOrder(List<DisplayReorder> list)
        {
            using (TrainedPanelSaveManager mgr = new TrainedPanelSaveManager())
            {
                mgr.SaveDisplayReorder(list);
            }
        }

        [Route("{id:int}")]
        [HttpDelete]
        public JsonResult Delete(int id)
        {
            using (TrainedPanelSaveManager mgr = new TrainedPanelSaveManager())
            {
                return Json(mgr.DeleteRecord(id));
            }
        }
    }
}