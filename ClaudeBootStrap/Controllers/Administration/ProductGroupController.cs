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
    [RoutePrefix("ProductGroup")]
    public class ProductGroupController : Controller
    {
        [Route("")]
        [HttpGet]
        public ActionResult Index()
        {
            return View(new ProductGroupViewModel());
        }

        [HttpPost]
        public JsonResult Save(SaveBase data)
        {
            using (ProductGroupSaveManager mgr = new ProductGroupSaveManager())
            {
                return Json(mgr.SaveRecord(data));
            }
        }

        [HttpPost]
        public void DisplayOrder(List<DisplayReorder> list)
        {
            using (ProductGroupReorderManager mgr = new ProductGroupReorderManager())
            {
                mgr.SaveDisplayReorder(list);
            }
        }

        [Route("{id:int}")]
        [HttpDelete]
        public JsonResult Delete(int id)
        {
            using (ProductGroupDeleteManager mgr = new ProductGroupDeleteManager())
            {
                return Json(mgr.DeleteRecord(id));
            }
        }
    }
}