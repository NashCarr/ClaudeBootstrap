using System.Collections.Generic;
using System.Web.Mvc;
using CommonDataSave.DisplayReorder;
using CommonDataSave.People;
using ManagementRetrieval.Places;
using ManagementSave.Person;
using ViewData.Facility;

namespace ClaudeBootstrap.Controllers.People
{
    [RoutePrefix("StaffMember")]
    public class StaffMemberController : Controller
    {
        [Route("")]
        [HttpGet]
        public ActionResult Index()
        {
            return View(new StaffMemberListViewModel());
        }

        [HttpPost]
        public JsonResult SavePerson(PersonSaveModel p)
        {
            using (PersonSaveManager mgr = new PersonSaveManager())
            {
                return Json(mgr.SaveStaffMember(p));
            }
        }

        [HttpPost]
        public JsonResult GetPerson(string id)
        {
            using (StaffMemberManager mgr = new StaffMemberManager())
            {
                return Json(id != null ? mgr.GetStaffMember(int.Parse(id)) : mgr.GetStaffMember(0));
            }
        }

        [HttpPost]
        public void DisplayOrder(List<DisplayReorder> list)
        {
            //using (PersonManager mgr = new PersonManager())
            //{
            //    mgr.SaveStaffMemberOrder(list);
            //}
        }

        [Route("{id:int}")]
        [HttpDelete]
        public JsonResult Delete(int id)
        {
            //using (PersonManager mgr = new PersonManager())
            //{
            //    return Json(mgr.DeleteStaffMember(id));
            //}
            return null;
        }

        [HttpPost]
        public JsonResult DeleteContact(int id)
        {
            //using (PersonContactDeleteManager mgr = new PersonContactDeleteManager())
            //{
            //    return Json(mgr.DeleteStaffMemberContact(id));
            //}
            return null;
        }
    }
}