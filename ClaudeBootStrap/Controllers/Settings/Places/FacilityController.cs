﻿using System.Collections.Generic;
using System.Web.Mvc;
using ClaudeCommon.BaseModels;
using ClaudeViewManagement.Managers.Places;
using ClaudeViewManagement.ViewModels.Places;
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
            using (PlaceManager mgr = new PlaceManager())
            {
                return Json(mgr.SavePlace(p));
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
    }
}