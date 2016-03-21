using System;
using System.Collections.Generic;
using ClaudeData.DataRepository.LookupRepository;
using ClaudeData.Models.Lists.Settings;
using ClaudeData.Models.LookupLists;
using ClaudeData.ViewModels;
using ClaudeViewManagement.Bases;
using ClaudeViewManagement.Managers.People;

namespace ClaudeViewManagement.ViewModels.People
{
    public class AssessorViewModel : ViewModelBase
    {
        public AssessorViewModel()
        {
            SearchEntity = string.Empty;
        }

        public string SearchEntity { get; set; }
        public AssessorView Entity { get; set; }
        public List<AssessorInfo> ListEntity { get; set; }

        public override void HandleRequest()
        {
            // This is an example of adding on a new command
            switch (EventCommand.ToLower())
            {
                case "newcommand":
                    break;
            }
            base.HandleRequest();
        }

        private void AddEdit()
        {
            if (ListEntity != null)
            {
                ListEntity.Clear();
                ListEntity = null;
            }

            Entity.CountryList = new CountryLookupList();
            Entity.PhoneTypeList = new PhoneTypeLookupList();
            //Entity.MobileCarrierList = new MobileCarrierLookupList();

            using (DbPlacesLookup db = new DbPlacesLookup())
            {
                Entity.FacilityList = db.GetFacilityLookup();
            }
        }

        protected override void Add()
        {
            IsValid = true;

            // Initialize Entity Object
            Entity = new AssessorView();

            AddEdit();

            base.Add();
        }

        protected override void Edit()
        {
            using (AssessorManager mgr = new AssessorManager())
            {
                // Get Product Data
                Entity = mgr.Get(Convert.ToInt32(EventArgument));
            }
            AddEdit();
            base.Edit();
        }

        protected override void Save()
        {
            int personId = Entity.Assessor.PersonId;
            int facilityStaffId = Entity.FacilityStaffId;

            using (AssessorManager mgr = new AssessorManager())
            {
                if (Mode == "Add")
                {
                    mgr.Insert(Entity, ref personId);
                }
                else
                {
                    mgr.Update(Entity, ref personId);
                }

                // Set any validation errors
                ValidationErrors = mgr.ValidationErrors;

                // Set mode based on validation errors
            }

            Entity.Assessor.PersonId = personId;
            Entity.FacilityStaffId = facilityStaffId;

            base.Save();
        }

        protected override void Delete()
        {
            using (AssessorManager mgr = new AssessorManager())
            {
                // Call data layer to delete record
                mgr.Delete(Convert.ToInt32(EventArgument));
            }

            Get();
            base.Delete();
        }

        protected override void ResetSearch()
        {
            SearchEntity = string.Empty;
            base.ResetSearch();
        }

        protected override void Get()
        {
            if (Entity != null)
            {
                Entity.Dispose();
                Entity = null;
            }

            using (AssessorManager mgr = new AssessorManager())
            {
                ListEntity = mgr.Get(SearchEntity);
            }
            base.Get();
        }
    }
}