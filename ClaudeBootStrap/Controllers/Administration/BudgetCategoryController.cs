using System.Collections.Generic;
using System.Web.Mvc;
using CommonDataReorder;
using CommonDataSave;
using ManagementDelete.Administration;
using ManagementReorder;
using ManagementSave.Administration;
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
            using (BudgetCategorySaveManager mgr = new BudgetCategorySaveManager())
            {
                return Json(mgr.SaveRecord(data));
            }
        }

        [HttpPost]
        public void DisplayOrder(List<DisplayReorder> list)
        {
            using (BudgetCategoryReorderManager mgr = new BudgetCategoryReorderManager())
            {
                mgr.SaveDisplayReorder(list);
            }
        }

        [Route("{id:int}")]
        [HttpDelete]
        public JsonResult Delete(int id)
        {
            using (BudgetCategoryDeleteManager mgr = new BudgetCategoryDeleteManager())
            {
                return Json(mgr.DeleteRecord(id));
            }
        }
    }
}