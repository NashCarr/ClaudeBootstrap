using System.Collections.Generic;
using System.Web.Mvc;
using CommonDataReorder;
using CommonDataSave.Facility;
using CommonDataSave.People;
using CommonDataSave.Places;
using CommonDataSave.SiteConfiguration;
using ManagementDelete.Facility;
using ManagementDelete.Person;
using ManagementDelete.Place;
using ManagementReorder;
using ManagementSave.Facility;
using ManagementSave.Person;
using ManagementSave.Place;
using ViewData.Facility;
using ViewData.Places;

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
        public JsonResult SaveSiteConfiguration(SiteConfigurationSave c)
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
            using (PlaceSaveManager mgr = new PlaceSaveManager())
            {
                return Json(mgr.SaveFacility(p));
            }
        }

        [HttpPost]
        public JsonResult SaveContact(PersonSaveModel p)
        {
            using (PersonSaveManager mgr = new PersonSaveManager())
            {
                return Json(mgr.SaveStaffMember(p));
            }
        }

        [HttpPost]
        public JsonResult SaveResource(FacilityResourceSave r)
        {
            using (FacilityResourceSaveManager mgr = new FacilityResourceSaveManager())
            {
                return Json(mgr.SaveRecord(r));
            }
        }

        [HttpPost]
        public JsonResult GetPlace(string id)
        {
            return
              Json(string.IsNullOrEmpty(id)
                   ? new FacilityViewModel(0)
                   : new FacilityViewModel(int.Parse(id)));
        }

        [HttpPost]
        public JsonResult GetPerson(string id)
        {
            return
                Json(string.IsNullOrEmpty(id)
                    ? new StaffMemberViewModel(0)
                    : new StaffMemberViewModel(int.Parse(id)));
        }

        [HttpPost]
        public void DisplayOrder(List<DisplayReorder> list)
        {
            using (FacilityReorderManager mgr = new FacilityReorderManager())
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
                return Json(mgr.DeleteFacility(id));
            }
        }

        [HttpPost]
        public JsonResult DeleteContact(int id)
        {
            using (PersonDeleteManager mgr = new PersonDeleteManager())
            {
                return Json(mgr.DeleteStaffMember(id));
            }
        }

        [HttpPost]
        public JsonResult DeleteResource(int id)
        {
            using (FacilityResourceDeleteManager mgr = new FacilityResourceDeleteManager())
            {
                return Json(mgr.DeleteRecord(id));
            }
        }
    }
}