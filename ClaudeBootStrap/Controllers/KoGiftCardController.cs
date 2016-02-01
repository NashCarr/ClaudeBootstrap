using System.Web.Mvc;
using ClaudeViewManagement.ViewModels.Settings;

namespace ClaudeBootstrap.Controllers
{
    [RoutePrefix("KoGiftCard")]
    public class KoGiftCardController : Controller
    {
        [Route("")]
        [HttpGet]
        public ActionResult Index()
        {
            KoGiftCard list = new KoGiftCard();

            return View(list);
        }

        [Route("{id:int}")]
        [HttpPost]
        public ActionResult Edit(int id)
        {
            //KoGiftCard vm = id == 0 ? new KoGiftCard() : new KoGiftCard();
            KoGiftCard vm = new KoGiftCard();
            return View(vm);
        }

        [Route("")]
        [HttpPost]
        public ActionResult Create()
        {
            KoGiftCard vm = new KoGiftCard();

            return View(vm);
        }

        [Route("")]
        [HttpPost]
        public JsonResult Post(KoGiftCard model)
        {
            return Json(model);
        }

        [Route("{id:int}")]
        [HttpDelete]
        public void Delete(int id)
        {
            //repo.Delete(id);
            //return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }
}