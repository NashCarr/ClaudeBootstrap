using System.Collections.Generic;
using System.Web.Mvc;
using CommonDataSave.Administration;
using CommonDataSave.DisplayReorder;
using ViewData.Administration;

namespace ClaudeBootstrap.Controllers.Administration
{
    [RoutePrefix("TestType")]
    public class TestTypeController : Controller
    {
        [Route("")]
        [HttpGet]
        public ActionResult Index()
        {
            return View(new TestTypeViewModel());
        }

        [HttpPost]
        public JsonResult Save(TestTypeSave data)
        {
            using (ManagementSave.Administration.TestTypeSaveManager mgr = new ManagementSave.Administration.TestTypeSaveManager())
            {
                return Json(mgr.SaveRecord(data));
            }
        }

        [HttpPost]
        public void DisplayOrder(List<DisplayReorder> list)
        {
            using (ManagementSave.Administration.TestTypeSaveManager mgr = new ManagementSave.Administration.TestTypeSaveManager())
            {
                mgr.SaveDisplayReorder(list);
            }
        }

        [Route("{id:int}")]
        [HttpDelete]
        public JsonResult Delete(int id)
        {
            using (ManagementSave.Administration.TestTypeSaveManager mgr = new ManagementSave.Administration.TestTypeSaveManager())
            {
                return Json(mgr.DeleteRecord(id));
            }
        }
    }
}