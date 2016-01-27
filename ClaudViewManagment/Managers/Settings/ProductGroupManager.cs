using System;
using System.Collections.Generic;
using ClaudeData.DataRepository.AdminRepository;
using ClaudeData.Models.Admin;

namespace ClaudeViewManagement.Managers.Settings
{
    public class ProductGroupManager : IDisposable
    {
        public ProductGroupManager()
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
            ValidationErrors?.Clear();
        }

        public List<ProductGroup> Get(string entity)
        {
            List<ProductGroup> ret = RetrieveActiveData();

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

        public ProductGroup Get(int recordId)
        {
            return RetrieveRecord(recordId);
        }

        public bool Update(ProductGroup entity)
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

        public bool Validate(ProductGroup entity)
        {
            ValidationErrors.Clear();

            if (string.IsNullOrEmpty(entity.Name)) return ValidationErrors.Count == 0;

            if (entity.Name.ToLower() ==
                entity.Name)
            {
                ValidationErrors.Add(new
                    KeyValuePair<string, string>("Name",
                        "Gift Card must not be all lower case."));
            }

            return ValidationErrors.Count == 0;
        }

        public bool Insert(ProductGroup entity)
        {
            bool ret = Validate(entity);

            if (ret)
            {
                entity.ErrMsg = SaveRecord(entity);
            }
            return ret;
        }

        private static List<ProductGroup> RetrieveActiveData()
        {
            using (DbProductGroupGet data = new DbProductGroupGet())
            {
                return data.GetActiveRecords();
            }
        }

        private static ProductGroup RetrieveRecord(int recordId)
        {
            using (DbProductGroupGet data = new DbProductGroupGet())
            {
                return data.GetRecord(recordId);
            }
        }

        private static string SaveRecord(ProductGroup entity)
        {
            using (DbProductGroupSave data = new DbProductGroupSave())
            {
                return data.AddUpdateRecord(entity);
            }
        }

        private static void DeleteRecord(int recordId)
        {
            using (DbProductGroupSave data = new DbProductGroupSave())
            {
                data.SetInactive(recordId);
            }
        }
    }
}