using System.Collections.Generic;
using System.Web.Mvc;
using ClaudeCommon.BaseModels;
using ClaudeCommon.Enums;
using ClaudeViewManagement.Managers.People;
using ClaudeViewManagement.Managers.Places;
using ClaudeViewManagement.ViewModels.People;
using ClaudeViewManagement.ViewModels.Places;

namespace ClaudeBootstrap.Controllers.Places
{
    [RoutePrefix("Organization")]
    public class OrganizationController : Controller
    {
        [Route("")]
        [HttpGet]
        public ActionResult Index()
        {
            return View(new PlaceListViewModel(PlaceEnums.PlaceType.Organization));
        }

        [HttpPost]
        public JsonResult SavePlace(PlaceSaveModel p)
        {
            if (p.Place != null) p.Place.PlaceType = PlaceEnums.PlaceType.Organization;
            using (PlaceSaveManager mgr = new PlaceSaveManager())
            {
                return Json(mgr.SavePlace(p));
            }
        }

        [HttpPost]
        public JsonResult SaveContact(PlaceContactSaveModel c)
        {
            if (c != null) c.Person.PersonType = PersonEnums.PersonType.OrganizationContact;
            using (PlaceContactSaveManager mgr = new PlaceContactSaveManager())
            {
                return Json(mgr.SaveContact(c));
            }
        }

        [HttpPost]
        public JsonResult GetPlace(string id)
        {
            using (OrganizationManager mgr = new OrganizationManager())
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
            using (OrganizationManager mgr = new OrganizationManager())
            {
                mgr.SaveOrganizationOrder(list);
            }
        }

        [Route("{id:int}")]
        [HttpDelete]
        public JsonResult Delete(int id)
        {
            using (OrganizationManager mgr = new OrganizationManager())
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