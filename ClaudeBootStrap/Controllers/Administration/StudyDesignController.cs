using System.Collections.Generic;
using System.Web.Mvc;
using SaveDataCommon;
using SaveDataCommon.Administration;
using SaveManagement.Administration;
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
            using (StudyDesignManager mgr = new StudyDesignManager())
            {
                return Json(mgr.SaveRecord(data));
            }
        }

        [HttpPost]
        public void DisplayOrder(List<DisplayReorder> list)
        {
            using (StudyDesignManager mgr = new StudyDesignManager())
            {
                mgr.SaveDisplayReorder(list);
            }
        }

        [Route("{id:int}")]
        [HttpDelete]
        public JsonResult Delete(int id)
        {
            using (StudyDesignManager mgr = new StudyDesignManager())
            {
                return Json(mgr.DeleteRecord(id));
            }
        }
    }
}