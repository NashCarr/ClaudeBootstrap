using System;
using System.Collections.Generic;
using ClaudeData.DataRepository.PersonRepository;
using ClaudeData.DataRepository.SettingsRepository;
using ClaudeData.Models.Lists.Settings;
using ClaudeData.ViewModels.Settings;

namespace ClaudeViewManagement.Managers.Settings.People
{
    public class CustomerContactManager : IDisposable
    {
        public CustomerContactManager()
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

        public List<CustomerContactInfo> Get()
        {
            return Get(string.Empty);
        }

        public List<CustomerContactInfo> Get(string searchValue)
        {
            List<CustomerContactInfo> ret = RetrieveActiveData();

            if (ret.Count == 0) return ret;

            // Do any searching
            if (!string.IsNullOrEmpty(searchValue))
            {
                ret = ret.FindAll(
                    p => p.FullName.ToLower().
                        Contains(searchValue));
            }

            return ret;
        }

        public CustomerContactView Get(int recordId)
        {
            return RetrieveRecord(recordId);
        }

        public bool Update(CustomerContactView entity, ref int personId)
        {
            bool ret = Validate(entity);

            if (ret)
            {
                entity.CustomerContact.ErrMsg = SaveRecord(entity, ref personId);
            }
            return ret;
        }

        public bool Delete(int recordId)
        {
            DeleteRecord(recordId);
            return true;
        }

        public bool Validate(CustomerContactView entity)
        {
            ValidationErrors.Clear();

            if (string.IsNullOrEmpty(entity.CustomerContact.FullName)) return ValidationErrors.Count == 0;

            if (entity.CustomerContact.FullName.ToLower() ==
                entity.CustomerContact.FullName)
            {
                ValidationErrors.Add(new
                    KeyValuePair<string, string>("Name",
                        "Staff User Name must not be all lower case."));
            }

            return ValidationErrors.Count == 0;
        }

        public bool Insert(CustomerContactView entity, ref int personId)
        {
            bool ret = Validate(entity);

            if (ret)
            {
                entity.CustomerContact.ErrMsg = SaveRecord(entity, ref personId);
            }
            return ret;
        }

        private static List<CustomerContactInfo> RetrieveActiveData()
        {
            using (DbCustomerContactInfoGet data = new DbCustomerContactInfoGet())
            {
                return data.GetActiveRecords();
            }
        }

        private static CustomerContactView RetrieveRecord(int recordId)
        {
            using (DbCustomerContactInfoGet data = new DbCustomerContactInfoGet())
            {
                return data.GetRecord(recordId);
            }
        }

        private static string SaveRecord(CustomerContactView entity, ref int personId)
        {
            using (DbCustomerContactSave data = new DbCustomerContactSave())
            {
                return data.SaveCustomerContact(ref entity, ref personId);
            }
        }

        private static void DeleteRecord(int recordId)
        {
            using (DbPersonSetInactive data = new DbPersonSetInactive())
            {
                data.SetCustomerContactInactive(recordId);
            }
        }
    }
}