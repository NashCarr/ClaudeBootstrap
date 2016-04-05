using System.Collections.Generic;
using System.Web.Mvc;
using CommonDataSave.DisplayReorder;
using CommonDataSave.Facility;
using CommonDataSave.People;
using CommonDataSave.Places;
using CommonDataSave.SiteConfiguration;
using ManagementRetrieval.Facility;
using ManagementRetrieval.Places;
using ManagementSave.Facility;
using ManagementSave.Person;
using ManagementSave.Places;
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
            using (FacilityGetManager mgr = new FacilityGetManager())
            {
                return Json(id != null ? mgr.GetFacility(int.Parse(id)) : mgr.GetFacility(0));
            }
        }

        [HttpPost]
        public JsonResult GetPerson(string id)
        {
            using (PlaceContactGetManager mgr = new PlaceContactGetManager())
            {
                return Json(id != null ? mgr.GetStaffMember(int.Parse(id)) : mgr.GetStaffMember(0));
            }
        }

        [HttpPost]
        public void DisplayOrder(List<DisplayReorder> list)
        {
            using (FacilitySaveManager mgr = new FacilitySaveManager())
            {
                mgr.SaveDisplayOrder(list);
            }
        }

        [Route("{id:int}")]
        [HttpDelete]
        public JsonResult Delete(int id)
        {
            using (FacilitySaveManager mgr = new FacilitySaveManager())
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
            using (FacilityResourceSaveManager mgr = new FacilityResourceSaveManager())
            {
                return Json(mgr.DeleteRecord(id));
            }
        }
    }
}