using System.Collections.Generic;
using System.Web.Mvc;
using ManagementSave.Administration;
using SaveDataCommon;
using SaveDataCommon.DisplayReorder;
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
            using (ProductGroupSaveManager mgr = new ProductGroupSaveManager())
            {
                mgr.SaveDisplayReorder(list);
            }
        }

        [Route("{id:int}")]
        [HttpDelete]
        public JsonResult Delete(int id)
        {
            using (ProductGroupSaveManager mgr = new ProductGroupSaveManager())
            {
                return Json(mgr.DeleteRecord(id));
            }
        }
    }
}