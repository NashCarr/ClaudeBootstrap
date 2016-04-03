using System.Collections.Generic;
using System.Web.Mvc;
using CommonData.Models.Administration;
using ManagementSave.Administration;
using SaveDataCommon;
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
            using (ProductGroupManager mgr = new ProductGroupManager())
            {
                return Json(mgr.SaveRecord(data));
            }
        }

        [HttpPost]
        public void DisplayOrder(List<DisplayReorder> list)
        {
            using (ProductGroupManager mgr = new ProductGroupManager())
            {
                mgr.SaveDisplayReorder(list);
            }
        }

        [Route("{id:int}")]
        [HttpDelete]
        public JsonResult Delete(int id)
        {
            using (ProductGroupManager mgr = new ProductGroupManager())
            {
                return Json(mgr.DeleteRecord(id));
            }
        }
    }
}