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
    [RoutePrefix("Facility")]
    public class FacilityController : Controller
    {
        [Route("")]
        [HttpGet]
        public ActionResult Index()
        {
            return View(new PlaceListViewModel(PlaceType.Facility));
        }

        [HttpPost]
        public JsonResult SavePlace(PlaceSaveModel p)
        {
            if (p.Place != null) p.Place.PlaceType = PlaceType.Facility;
            using (PlaceSaveManager mgr = new PlaceSaveManager())
            {
                return Json(mgr.SavePlace(p));
            }
        }

        [HttpPost]
        public JsonResult SaveContact(PlaceContactSaveModel c)
        {
            if (c != null) c.Person.PersonType = PersonType.StaffUser;
            using (PlaceContactSaveManager mgr = new PlaceContactSaveManager())
            {
                return Json(mgr.SaveContact(c));
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
                mgr.SaveFacilityOrder(list);
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
                return Json(mgr.DeleteStaffUser(id));
            }
        }
    }
}