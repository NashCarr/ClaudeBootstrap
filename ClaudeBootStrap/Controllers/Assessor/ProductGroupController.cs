﻿using System.Collections.Generic;
using System.Web.Mvc;
using CommonData.Models.Administration;
using SaveDataCommon;
using SaveManagement.Administration;
using ViewData.Administration;

namespace ClaudeBootstrap.Controllers.Assessor
{
    [RoutePrefix("ProductGroup")]
    public class ProductGroupController : Controller
    {
        [Route("")]
        [HttpGet]
        public ActionResult Index()
        {
            return View(new ProductGroupViewModel());
        }

        [HttpPost]
        public JsonResult Save(ProductGroup entity)
        {
            using (ProductGroupManager mgr = new ProductGroupManager())
            {
                return Json(mgr.SaveRecord(entity));
            }
        }

        [HttpPost]
        public void DisplayOrder(List<DisplayReorder> list)
        {
            using (ProductGroupManager mgr = new ProductGroupManager())
            {
                mgr.SaveDisplayReorder(list);
            }
        }

        [Route("{id:int}")]
        [HttpDelete]
        public JsonResult Delete(int id)
        {
            using (ProductGroupManager mgr = new ProductGroupManager())
            {
                return Json(mgr.DeleteRecord(id));
            }
        }
    }
}