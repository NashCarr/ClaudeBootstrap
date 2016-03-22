﻿using System.Collections.Generic;
using System.Web.Mvc;
using ClaudeViewManagement.ViewModels.People;

namespace ClaudeBootstrap.Controllers.People
{
    public class AssessorController : Controller
    {
        public ActionResult Index()
        {
            AssessorViewModel vm = new AssessorViewModel();

            vm.HandleRequest();

            return View(vm);
        }

        [HttpPost]
        public ActionResult Index(AssessorViewModel vm)
        {
            vm.IsValid = ModelState.IsValid;
            vm.HandleRequest();

            if (vm.IsValid)
            {
                // NOTE: Must clear the model state in order to bind
                //       the @Html helpers to the new model values
                ModelState.Clear();
            }
            else
            {
                foreach (KeyValuePair<string, string> item in vm.ValidationErrors)
                {
                    ModelState.AddModelError(item.Key, item.Value);
                }
            }

            return View(vm);
        }
    }
}