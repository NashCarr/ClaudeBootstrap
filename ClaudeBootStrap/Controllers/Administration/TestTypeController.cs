using System.Collections.Generic;
using System.Web.Mvc;
using CommonDataReorder;
using CommonDataSave.Administration;
using ManagementDelete.Administration;
using ManagementReorder;
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
            using (TestTypeReorderManager mgr = new TestTypeReorderManager())
            {
                mgr.SaveDisplayReorder(list);
            }
        }

        [Route("{id:int}")]
        [HttpDelete]
        public JsonResult Delete(int id)
        {
            using (TestTypeDeleteManager mgr = new TestTypeDeleteManager())
            {
                return Json(mgr.DeleteRecord(id));
            }
        }
    }
}