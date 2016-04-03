using System.Collections.Generic;
using System.Web.Mvc;
using ManagementSave.Administration;
using SaveDataCommon;
using ViewData.Administration;

namespace ClaudeBootstrap.Controllers.Administration
{
    [RoutePrefix("BudgetCategory")]
    public class BudgetCategoryController : Controller
    {
        [Route("")]
        [HttpGet]
        public ActionResult Index()
        {
            return View(new BudgetCategoryViewModel());
        }

        [HttpPost]
        public JsonResult Save(SaveBase data)
        {
            using (BudgetCategoryManager mgr = new BudgetCategoryManager())
            {
                return Json(mgr.SaveRecord(data));
            }
        }

        [HttpPost]
        public void DisplayOrder(List<DisplayReorder> list)
        {
            using (BudgetCategoryManager mgr = new BudgetCategoryManager())
            {
                mgr.SaveDisplayReorder(list);
            }
        }

        [Route("{id:int}")]
        [HttpDelete]
        public JsonResult Delete(int id)
        {
            using (BudgetCategoryManager mgr = new BudgetCategoryManager())
            {
                return Json(mgr.DeleteRecord(id));
            }
        }
    }
}