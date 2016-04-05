using System.Collections.Generic;
using System.Web.Mvc;
using CommonDataSave;
using CommonDataSave.DisplayReorder;
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
            using (BudgetCategorySaveManager mgr = new BudgetCategorySaveManager())
            {
                mgr.SaveDisplayReorder(list);
            }
        }

        [Route("{id:int}")]
        [HttpDelete]
        public JsonResult Delete(int id)
        {
            using (BudgetCategorySaveManager mgr = new BudgetCategorySaveManager())
            {
                return Json(mgr.DeleteRecord(id));
            }
        }
    }
}