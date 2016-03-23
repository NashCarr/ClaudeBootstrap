using System.Collections.Generic;
using System.Web.Mvc;
using ClaudeCommon.BaseModels;
using ClaudeCommon.Enums;
using ClaudeCommon.Models.Facility;
using ClaudeCommon.Models.SiteConfiguration;
using ClaudeViewManagement.Managers.Facility;
using ClaudeViewManagement.Managers.People;
using ClaudeViewManagement.Managers.Places;
using ClaudeViewManagement.ViewModels.People;
using ClaudeViewManagement.ViewModels.Places;

namespace ClaudeBootstrap.Controllers.Places
{
    [RoutePrefix("SiteConfiguration")]
    public class SiteConfigurationController : Controller
    {
        [Route("")]
        [HttpGet]
        public ActionResult Index()
        {
            return View(new SiteConfigurationViewModel());
        }

        [HttpPost]
        public JsonResult SaveSiteConfiguration(SiteConfiguration c)
        {
            //using (PlaceSaveManager mgr = new PlaceSaveManager())
            //{
            //    return Json(mgr.SavePlace(p));
            //}
            return null;
        }

        [HttpPost]
        public JsonResult SavePlace(PlaceSaveModel p)
        {
            if (p.Place != null) p.Place.PlaceType = PlaceEnums.PlaceType.Facility;
            using (PlaceSaveManager mgr = new PlaceSaveManager())
            {
                return Json(mgr.SavePlace(p));
            }
        }

        [HttpPost]
        public JsonResult SaveContact(PersonSaveModel c)
        {
            if (c != null) c.Person.PersonType = PersonEnums.PersonType.StaffMember;
            using (PersonSaveManager mgr = new PersonSaveManager())
            {
                return Json(mgr.SavePerson(c));
            }
        }

        [HttpPost]
        public JsonResult SaveResource(FacilityResource r)
        {
            using (FacilityResourceManager mgr = new FacilityResourceManager())
            {
                return Json(mgr.SaveRecord(r));
            }
        }

        [HttpPost]
        public JsonResult GetPlace(string id)
        {
            using (FacilityManager mgr = new FacilityManager())
            {
                return Json(id != null ? mgr.GetFacility(int.Parse(id)) : mgr.GetFacility(0));
            }
        }

        [HttpPost]
        public JsonResult GetPerson(string id)
        {
            using (PlaceContactGetManager mgr = new PlaceContactGetManager())
            {
                return Json(id != null ? mgr.GetStaffUser(int.Parse(id)) : mgr.GetStaffUser(0));
            }
        }

        [HttpPost]
        public void DisplayOrder(List<DisplayReorder> list)
        {
            using (FacilityManager mgr = new FacilityManager())
            {
                mgr.SaveDisplayOrder(list);
            }
        }

        [Route("{id:int}")]
        [HttpDelete]
        public JsonResult Delete(int id)
        {
            using (FacilityManager mgr = new FacilityManager())
            {
                return Json(mgr.DeleteFacility(id));
            }
        }

        [HttpPost]
        public JsonResult DeleteContact(int id)
        {
            using (PlaceContactDeleteManager mgr = new PlaceContactDeleteManager())
            {
                return Json(mgr.DeleteStaffMember(id));
            }
        }

        [HttpPost]
        public JsonResult DeleteResource(int id)
        {
            using (FacilityResourceManager mgr = new FacilityResourceManager())
            {
                return Json(mgr.DeleteRecord(id));
            }
        }
    }
}