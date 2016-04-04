using System.Collections.Generic;
using System.Web.Mvc;
using ManagementRetrieval.Places;
using ManagementSave.Person;
using ManagementSave.Places;
using SaveDataCommon.DisplayReorder;
using SaveDataCommon.People;
using SaveDataCommon.Places;
using ViewData.Places;
using static DataLayerCommon.Enums.PersonEnums;
using static DataLayerCommon.Enums.PlaceEnums;

namespace ClaudeBootstrap.Controllers.Places
{
    [RoutePrefix("Organization")]
    public class OrganizationController : Controller
    {
        [Route("")]
        [HttpGet]
        public ActionResult Index()
        {
            return View(new PlaceListViewModel(PlaceType.Organization));
        }

        [HttpPost]
        public JsonResult SavePlace(PlaceSaveModel p)
        {
            if (p.Place != null) p.Place.PlaceType = PlaceType.Organization;
            using (PlaceSaveManager mgr = new PlaceSaveManager())
            {
                return Json(mgr.SavePlace(p));
            }
        }

        [HttpPost]
        public JsonResult SaveContact(PersonSaveModel c)
        {
            if (c != null) c.Person.PersonType = PersonType.OrganizationContact;
            using (PersonSaveManager mgr = new PersonSaveManager())
            {
                return Json(mgr.SavePerson(c));
            }
        }

        [HttpPost]
        public JsonResult GetPlace(string id)
        {
            using (OrganizationGetManager mgr = new OrganizationGetManager())
            {
                return Json(id != null ? mgr.GetOrganization(int.Parse(id)) : mgr.GetOrganization(0));
            }
        }

        [HttpPost]
        public JsonResult GetPerson(string id)
        {
            using (PlaceContactGetManager mgr = new PlaceContactGetManager())
            {
                return Json(id != null ? mgr.GetOrganizationContact(int.Parse(id)) : mgr.GetOrganizationContact(0));
            }
        }

        [HttpPost]
        public void DisplayOrder(List<DisplayReorder> list)
        {
            using (OrganizationSaveManager mgr = new OrganizationSaveManager())
            {
                mgr.SaveDisplayOrder(list);
            }
        }

        [Route("{id:int}")]
        [HttpDelete]
        public JsonResult Delete(int id)
        {
            using (OrganizationSaveManager mgr = new OrganizationSaveManager())
            {
                return Json(mgr.DeleteOrganization(id));
            }
        }

        [HttpPost]
        public JsonResult DeleteContact(int id)
        {
            using (PlaceContactDeleteManager mgr = new PlaceContactDeleteManager())
            {
                return Json(mgr.DeleteOrganizationContact(id));
            }
        }
    }
}