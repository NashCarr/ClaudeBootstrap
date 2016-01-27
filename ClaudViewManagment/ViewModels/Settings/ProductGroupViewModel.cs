using System;
using System.Collections.Generic;
using ClaudeData.Models.Admin;
using ClaudeViewManagement.Bases;
using ClaudeViewManagement.Managers.Settings;

namespace ClaudeViewManagement.ViewModels.Settings
{
    public sealed class ProductGroupViewModel : ViewModelBase
    {
        public ProductGroupViewModel()
        {
            SearchEntity = string.Empty;
            Init();
        }

        public string SearchEntity { get; set; }
        public ProductGroup Entity { get; set; }
        public List<ProductGroup> ListEntity { get; set; }

        public override void HandleRequest()
        {
            switch (EventCommand.ToLower())
            {
                case "newcommand":
                    break;
            }
            base.HandleRequest();
        }

        private void AddEdit()
        {
            if (ListEntity == null) return;

            ListEntity.Clear();
            ListEntity = null;
        }

        protected override void Add()
        {
            IsValid = true;

            Entity = new ProductGroup();

            AddEdit();
            base.Add();
        }

        protected override void Edit()
        {
            using (ProductGroupManager mgr = new ProductGroupManager())
            {
                Entity = mgr.Get(Convert.ToInt32(EventArgument));
            }
            AddEdit();
            base.Edit();
        }

        protected override void Save()
        {
            using (ProductGroupManager mgr = new ProductGroupManager())
            {
                if (Mode == "Add")
                {
                    mgr.Insert(Entity);
                }
                else
                {
                    mgr.Update(Entity);
                }
                ValidationErrors = mgr.ValidationErrors;
            }
            base.Save();
        }

        protected override void Delete()
        {
            using (ProductGroupManager mgr = new ProductGroupManager())
            {
                mgr.Delete(Convert.ToInt32(EventArgument));

                Get();
            }
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
                Entity = null;
            }

            using (ProductGroupManager mgr = new ProductGroupManager())
            {
                ListEntity = mgr.Get(SearchEntity);
            }
            base.Get();
        }
    }
}