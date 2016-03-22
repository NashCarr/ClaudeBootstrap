using System.Collections.Generic;
using System.Web.Mvc;
using ClaudeCommon.BaseModels;
using ClaudeCommon.Models.Administration;
using ClaudeViewManagement.Managers.Administration;
using ClaudeViewManagement.ViewModels.Administration;

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
        public JsonResult Save(BudgetCategory entity)
        {
            using (BudgetCategoryManager mgr = new BudgetCategoryManager())
            {
                return Json(mgr.SaveRecord(entity));
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