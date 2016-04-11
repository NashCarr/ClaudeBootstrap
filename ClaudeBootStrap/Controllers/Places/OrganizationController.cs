using System.Collections.Generic;
using System.Web.Mvc;
using CommonDataReorder;
using CommonDataSave.People;
using CommonDataSave.Places;
using ManagementDelete.Person;
using ManagementDelete.Place;
using ManagementReorder;
using ManagementSave.Person;
using ManagementSave.Place;
using ViewData.Person;
using ViewData.Place;
using ViewData.Places;

namespace ClaudeBootstrap.Controllers.Places
{
    [RoutePrefix("Organization")]
    public class OrganizationController : Controller
    {
        [Route("")]
        [HttpGet]
        public ActionResult Index()
        {
            return View(new OrganizationListViewModel());
        }

        [HttpPost]
        public JsonResult SavePlace(PlaceSaveModel p)
        {
            using (PlaceSaveManager mgr = new PlaceSaveManager())
            {
                return Json(mgr.SaveOrganization(p));
            }
        }

        [HttpPost]
        public JsonResult SaveContact(PersonSaveModel p)
        {
            using (PersonSaveManager mgr = new PersonSaveManager())
            {
                return Json(mgr.SaveOrganizationContact(p));
            }
        }

        [HttpPost]
        public JsonResult GetPlace(string id)
        {
             return
               Json(string.IsNullOrEmpty(id)
                    ? new OrganizationViewModel(0)
                    : new OrganizationViewModel(int.Parse(id)));

        }

        [HttpPost]
        public JsonResult GetPerson(string id)
        {
            return
                Json(string.IsNullOrEmpty(id)
                    ? new OrganizationContactViewModel(0)
                    : new OrganizationContactViewModel(int.Parse(id)));
        }

        [HttpPost]
        public void DisplayOrder(List<DisplayReorder> list)
        {
            using (OrganizationReorderManager mgr = new OrganizationReorderManager())
            {
                mgr.SaveDisplayOrder(list);
            }
        }

        [Route("{id:int}")]
        [HttpDelete]
        public JsonResult Delete(int id)
        {
            using (PlaceDeleteManager mgr = new PlaceDeleteManager())
            {
                return Json(mgr.DeleteOrganization(id));
            }
        }

        [HttpPost]
        public JsonResult DeleteContact(int id)
        {
            using (PersonDeleteManager mgr = new PersonDeleteManager())
            {
                return Json(mgr.DeleteOrganizationContact(id));
            }
        }
    }
}