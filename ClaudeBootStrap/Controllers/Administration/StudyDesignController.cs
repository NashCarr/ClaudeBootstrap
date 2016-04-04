using System.Collections.Generic;
using System.Web.Mvc;
using SaveDataCommon.Administration;
using SaveDataCommon.DisplayReorder;
using ViewData.Administration;

namespace ClaudeBootstrap.Controllers.Administration
{
    [RoutePrefix("StudyDesign")]
    public class StudyDesignController : Controller
    {
        [Route("")]
        [HttpGet]
        public ActionResult Index()
        {
            return View(new StudyDesignViewModel());
        }

        [HttpPost]
        public JsonResult Save(StudyDesignSave data)
        {
            using (ManagementSave.Administration.StudyDesignSaveManager mgr = new ManagementSave.Administration.StudyDesignSaveManager())
            {
                return Json(mgr.SaveRecord(data));
            }
        }

        [HttpPost]
        public void DisplayOrder(List<DisplayReorder> list)
        {
            using (ManagementSave.Administration.StudyDesignSaveManager mgr = new ManagementSave.Administration.StudyDesignSaveManager())
            {
                mgr.SaveDisplayReorder(list);
            }
        }

        [Route("{id:int}")]
        [HttpDelete]
        public JsonResult Delete(int id)
        {
            using (ManagementSave.Administration.StudyDesignSaveManager mgr = new ManagementSave.Administration.StudyDesignSaveManager())
            {
                return Json(mgr.DeleteRecord(id));
            }
        }
    }
}