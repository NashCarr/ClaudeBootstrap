using System.Web.Mvc;
using ClaudeCommon.Models;
using ClaudeViewManagement.Managers.Settings;
using ClaudeViewManagement.ViewModels.Settings;

namespace ClaudeBootstrap.Controllers
{
    [RoutePrefix("GiftCard")]
    public class GiftCardController : Controller
    {
        [Route("")]
        [HttpGet]
        public ActionResult Index()
        {
            return View(new GiftCardViewModel());
        }

        [Route("")]
        [HttpPost]
        public JsonResult Save(GiftCard entity)
        {
            using (GiftCardManager mgr = new GiftCardManager())
            {
                return Json(mgr.SaveRecord(entity));
            }
        }

        [Route("{id:int}")]
        [HttpDelete]
        public JsonResult Delete(int id)
        {
            using (GiftCardManager mgr = new GiftCardManager())
            {
                return Json(mgr.DeleteRecord(id));
            }
        }
    }
}