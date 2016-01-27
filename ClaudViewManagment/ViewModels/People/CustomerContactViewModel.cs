using System;
using System.Collections.Generic;
using ClaudeData.DataRepository.LookupRepository;
using ClaudeData.Models.Lists.Settings;
using ClaudeData.Models.LookupLists;
using ClaudeData.ViewModels.Settings;
using ClaudeViewManagement.Bases;
using ClaudeViewManagement.Managers.People;

namespace ClaudeViewManagement.ViewModels.People
{
    public class CustomerContactViewModel : ViewModelBase
    {
        public CustomerContactViewModel()
        {
            SearchEntity = string.Empty;
        }

        public string SearchEntity { get; set; }
        public CustomerContactView Entity { get; set; }
        public List<CustomerContactInfo> ListEntity { get; set; }

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
            Entity.MobileCarrierList = new MobileCarrierLookupList();

            using (DbPlacesLookup db = new DbPlacesLookup())
            {
                Entity.FacilityList = db.GetFacilityLookup();
            }
        }

        protected override void Add()
        {
            IsValid = true;

            // Initialize Entity Object
            Entity = new CustomerContactView();

            AddEdit();

            base.Add();
        }

        protected override void Edit()
        {
            using (CustomerContactManager mgr = new CustomerContactManager())
            {
                // Get Product Data
                Entity = mgr.Get(Convert.ToInt32(EventArgument));
            }
            AddEdit();

            base.Edit();
        }

        protected override void Save()
        {
            int personId = Entity.CustomerContact.PersonId;
            int facilityStaffId = Entity.FacilityStaffId;

            using (CustomerContactManager mgr = new CustomerContactManager())
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

            Entity.CustomerContact.PersonId = personId;
            Entity.FacilityStaffId = facilityStaffId;

            base.Save();
        }

        protected override void Delete()
        {
            using (CustomerContactManager mgr = new CustomerContactManager())
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

            using (CustomerContactManager mgr = new CustomerContactManager())
            {
                ListEntity = mgr.Get(SearchEntity);
            }
            base.Get();
        }
    }
}