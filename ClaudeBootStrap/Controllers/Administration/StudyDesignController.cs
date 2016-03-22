using System.Collections.Generic;
using System.Web.Mvc;
using ClaudeCommon.BaseModels;
using ClaudeCommon.Models.Administration;
using ClaudeViewManagement.Managers.Administration;
using ClaudeViewManagement.ViewModels.Administration;

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
        public JsonResult Save(StudyDesign entity)
        {
            using (StudyDesignManager mgr = new StudyDesignManager())
            {
                return Json(mgr.SaveRecord(entity));
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