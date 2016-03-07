using System.Collections.Generic;
using System.Web.Mvc;
using ClaudeCommon.BaseModels;
using ClaudeViewManagement.Managers.People;
using ClaudeViewManagement.Managers.Places;
using ClaudeViewManagement.ViewModels.People;
using ClaudeViewManagement.ViewModels.Places;
using static ClaudeCommon.Enums.PersonEnums;
using static ClaudeCommon.Enums.PlaceEnums;

namespace ClaudeBootstrap.Controllers.Settings.Places
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
            using (PlaceManager mgr = new PlaceManager())
            {
                return Json(mgr.SavePlace(p));
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
        public JsonResult SaveContact(ContactSaveModel c)
        {
            if (c != null) c.Person.PersonType = PersonType.OrganizationContact;
            using (ContactManager mgr = new ContactManager())
            {
                return Json(mgr.SaveContact(c));
            }
        }

        [HttpPost]
        public JsonResult DeleteContact(int id)
        {
            using (ContactManager mgr = new ContactManager())
            {
                return Json(mgr.DeleteCustomer(id));
            }
        }
    }
}