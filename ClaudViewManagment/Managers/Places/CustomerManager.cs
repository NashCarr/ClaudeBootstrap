using System;
using System.Collections.Generic;
using ClaudeData.DataRepository.PlaceRepository;
using ClaudeData.DataRepository.SettingsRepository;
using ClaudeData.Models.Lists.Settings;
using ClaudeData.ViewModels.Settings;

namespace ClaudeViewManagement.Managers.Places
{
    public class CustomerManager : IDisposable
    {
        public CustomerManager()
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

        public List<CustomerInfo> Get()
        {
            return Get(string.Empty);
        }

        public List<CustomerInfo> Get(string searchValue)
        {
            List<CustomerInfo> ret = RetrieveActiveData();

            if (ret.Count == 0) return ret;

            // Do any searching
            if (!string.IsNullOrEmpty(searchValue))
            {
                ret = ret.FindAll(
                    p => p.Name.ToLower().
                        Contains(searchValue));
            }

            return ret;
        }

        public CustomerView Get(int recordId)
        {
            return RetrieveRecord(recordId);
        }

        public bool Update(CustomerView entity, ref int placeId)
        {
            bool ret = Validate(entity);

            if (ret)
            {
                entity.Customer.ErrMsg = SaveRecord(entity, ref placeId);
            }
            return ret;
        }

        public bool Delete(int recordId)
        {
            DeleteRecord(recordId);
            return true;
        }

        public bool Validate(CustomerView entity)
        {
            ValidationErrors.Clear();

            if (string.IsNullOrEmpty(entity.Customer.Name)) return ValidationErrors.Count == 0;

            if (entity.Customer.Name.ToLower() ==
                entity.Customer.Name)
            {
                ValidationErrors.Add(new
                    KeyValuePair<string, string>("Name",
                        "Staff User Name must not be all lower case."));
            }

            return ValidationErrors.Count == 0;
        }

        public bool Insert(CustomerView entity, ref int placeId)
        {
            bool ret = Validate(entity);

            if (ret)
            {
                entity.Customer.ErrMsg = SaveRecord(entity, ref placeId);
            }
            return ret;
        }

        private static List<CustomerInfo> RetrieveActiveData()
        {
            using (DbCustomerInfoGet data = new DbCustomerInfoGet())
            {
                return data.GetActiveRecords();
            }
        }

        private static CustomerView RetrieveRecord(int recordId)
        {
            using (DbCustomerInfoGet data = new DbCustomerInfoGet())
            {
                return data.GetRecord(recordId);
            }
        }

        private static string SaveRecord(CustomerView entity, ref int placeId)
        {
            using (DbCustomerSave data = new DbCustomerSave())
            {
                return data.SaveCustomer(ref entity, ref placeId);
            }
        }

        private static void DeleteRecord(int recordId)
        {
            using (DbPlaceSetInactive data = new DbPlaceSetInactive())
            {
                data.SetCustomerInactive(recordId);
            }
        }
    }
}