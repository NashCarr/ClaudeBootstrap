using System;
using System.Collections.Generic;
using ClaudeData.DataRepository.AdminRepository;
using ClaudeData.Models.Admin;

namespace ClaudeViewManagement.Managers.Settings
{
    public class GiftCardManager : IDisposable
    {
        public GiftCardManager()
        {
            ValidationErrors = new List<KeyValuePair<string, string>>();
        }

        public List<KeyValuePair<string, string>> ValidationErrors { get; set; }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool iAmBeingCalledFromDisposeAndNotFinalize)
        {
        }

        public List<GiftCard> Get(string entity)
        {
            List<GiftCard> ret = RetrieveActiveData();

            if (ret.Count == 0) return ret;

            // Do any searching
            if (!string.IsNullOrEmpty(entity))
            {
                ret = ret.FindAll(
                    p => p.Name.ToLower().
                        Contains(entity));
            }

            return ret;
        }

        public GiftCard Get(int recordId)
        {
            return RetrieveRecord(recordId);
        }

        public bool Update(GiftCard entity)
        {
            bool ret = Validate(entity);

            if (ret)
            {
                entity.ErrMsg = SaveRecord(entity);
            }
            return ret;
        }

        public bool Delete(int recordId)
        {
            DeleteRecord(recordId);
            return true;
        }

        public bool Validate(GiftCard entity)
        {
            ValidationErrors.Clear();

            if (string.IsNullOrEmpty(entity.Name)) return ValidationErrors.Count == 0;

            if (entity.Name.ToLower() == entity.Name)
            {
                ValidationErrors.Add(new
                    KeyValuePair<string, string>("Name",
                        "Gift Card must not be all lower case."));
            }

            return ValidationErrors.Count == 0;
        }

        public bool Insert(GiftCard entity)
        {
            bool ret = Validate(entity);

            if (ret)
            {
                entity.ErrMsg = SaveRecord(entity);
            }
            return ret;
        }

        private static List<GiftCard> RetrieveActiveData()
        {
            using (DbGiftCardGet data = new DbGiftCardGet())
            {
                return data.GetActiveRecords();
            }
        }

        private static GiftCard RetrieveRecord(int recordId)
        {
            using (DbGiftCardGet data = new DbGiftCardGet())
            {
                return data.GetRecord(recordId);
            }
        }

        private static string SaveRecord(GiftCard entity)
        {
            using (DbGiftCardSave data = new DbGiftCardSave())
            {
                return data.AddUpdateRecord(entity);
            }
        }

        private static void DeleteRecord(int recordId)
        {
            using (DbGiftCardSave data = new DbGiftCardSave())
            {
                data.SetInactive(recordId);
            }
        }
    }
}