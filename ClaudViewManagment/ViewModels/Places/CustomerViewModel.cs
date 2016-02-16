using System;
using System.Collections.Generic;
using ClaudeData.Models.Lists.Settings;
using ClaudeData.Models.LookupLists;
using ClaudeData.ViewModels.Settings;
using ClaudeViewManagement.Bases;
using ClaudeViewManagement.Managers.Places;

namespace ClaudeViewManagement.ViewModels.Places
{
    public class CustomerViewModel : ViewModelBase
    {
        public CustomerViewModel()
        {
            SearchEntity = string.Empty;
        }

        public string SearchEntity { get; set; }
        public CustomerView Entity { get; set; }
        public List<CustomerInfo> ListEntity { get; set; }

    //    public override void HandleRequest()
    //    {
    //        // This is an example of adding on a new command
    //        switch (EventCommand.ToLower())
    //        {
    //            case "newcommand":
    //                break;
    //        }
    //        base.HandleRequest();
    //    }

    //    private void AddEdit()
    //    {
    //        if (ListEntity != null)
    //        {
    //            ListEntity.Clear();
    //            ListEntity = null;
    //        }

    //        Entity.CountryList = new CountryLookupList();
    //        Entity.TimeZoneList = new TimeZoneLookupList();
    //        Entity.PhoneTypeList = new PhoneTypeLookupList();
    //        Entity.MobileCarrierList = new MobileCarrierLookupList();
    //    }

    //    protected override void Add()
    //    {
    //        IsValid = true;

    //        // Initialize Entity Object
    //        Entity = new CustomerView();

    //        AddEdit();

    //        base.Add();
    //    }

    //    protected override void Edit()
    //    {
    //        using (CustomerManager mgr = new CustomerManager())
    //        {
    //            // Get Product Data
    //            Entity = mgr.Get(Convert.ToInt32(EventArgument));
    //        }
    //        AddEdit();

    //        base.Edit();
    //    }

    //    protected override void Save()
    //    {
    //        int placeId = Entity.Customer.PlaceId;
    //        using (CustomerManager mgr = new CustomerManager())
    //        {
    //            if (Mode == "Add")
    //            {
    //                mgr.Insert(Entity, ref placeId);
    //            }
    //            else
    //            {
    //                mgr.Update(Entity, ref placeId);
    //            }

    //            // Set any validation errors
    //            ValidationErrors = mgr.ValidationErrors;

    //            // Set mode based on validation errors
    //        }
    //        Entity.Customer.PlaceId = placeId;

    //        base.Save();
    //    }

    //    protected override void Delete()
    //    {
    //        using (CustomerManager mgr = new CustomerManager())
    //        {
    //            // Call data layer to delete record
    //            mgr.Delete(Convert.ToInt32(EventArgument));
    //        }

    //        Get();
    //        base.Delete();
    //    }

    //    protected override void ResetSearch()
    //    {
    //        SearchEntity = string.Empty;
    //        base.ResetSearch();
    //    }

    //    protected override void Get()
    //    {
    //        if (Entity != null)
    //        {
    //            Entity.Dispose();
    //            Entity = null;
    //        }

    //        using (CustomerManager mgr = new CustomerManager())
    //        {
    //            ListEntity = mgr.Get(SearchEntity);
    //        }
    //        base.Get();
    //    }
    }
}