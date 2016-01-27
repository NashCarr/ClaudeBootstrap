using System;
using System.Collections.Generic;
using ClaudeData.Models.Admin;
using ClaudeViewManagement.Bases;
using ClaudeViewManagement.Managers.Settings;

namespace ClaudeViewManagement.ViewModels.Settings
{
    public sealed class GiftCardViewModel : ViewModelBase
    {
        public GiftCardViewModel()
        {
            SearchEntity = string.Empty;
            Init();
        }

        public List<GiftCard> ListEntity { get; set; }
        public string SearchEntity { get; set; }
        public GiftCard Entity { get; set; }

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
            if (ListEntity == null) return;

            ListEntity.Clear();
            ListEntity = null;
        }

        protected override void Add()
        {
            IsValid = true;

            Entity = new GiftCard();

            AddEdit();
            base.Add();
        }

        protected override void Edit()
        {
            using (GiftCardManager mgr = new GiftCardManager())
            {
                Entity = mgr.Get(Convert.ToInt32(EventArgument));
            }
            AddEdit();
            base.Edit();
        }

        protected override void Save()
        {
            using (GiftCardManager mgr = new GiftCardManager())
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
            using (GiftCardManager mgr = new GiftCardManager())
            {
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
                Entity = null;
            }

            using (GiftCardManager mgr = new GiftCardManager())
            {
                ListEntity = mgr.Get(SearchEntity);
            }
            base.Get();
        }
    }
}