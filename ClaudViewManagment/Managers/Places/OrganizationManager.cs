using System;
using System.Collections.Generic;
using ClaudeData.DataRepository.PlaceRepository;
using ClaudeData.DataRepository.SettingsRepository;
using ClaudeData.Models.Lists.Settings;
using ClaudeData.ViewModels.Settings;

namespace ClaudeViewManagement.Managers.Places
{
    public class OrganizationManager : IDisposable
    {
        public OrganizationManager()
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

        public List<OrganizationInfo> Get()
        {
            return Get(string.Empty);
        }

        public List<OrganizationInfo> Get(string searchValue)
        {
            List<OrganizationInfo> ret = RetrieveActiveData();

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

        public OrganizationView Get(int recordId)
        {
            return RetrieveRecord(recordId);
        }

        public bool Update(OrganizationView entity, ref int placeId)
        {
            bool ret = Validate(entity);

            if (ret)
            {
                entity.Organization.ErrMsg = SaveRecord(entity, ref placeId);
            }
            return ret;
        }

        public bool Delete(int recordId)
        {
            DeleteRecord(recordId);
            return true;
        }

        public bool Validate(OrganizationView entity)
        {
            ValidationErrors.Clear();

            if (string.IsNullOrEmpty(entity.Organization.Name)) return ValidationErrors.Count == 0;

            if (entity.Organization.Name.ToLower() ==
                entity.Organization.Name)
            {
                ValidationErrors.Add(new
                    KeyValuePair<string, string>("Name",
                        "Staff User Name must not be all lower case."));
            }

            return ValidationErrors.Count == 0;
        }

        public bool Insert(OrganizationView entity, ref int placeId)
        {
            bool ret = Validate(entity);

            if (ret)
            {
                entity.Organization.ErrMsg = SaveRecord(entity, ref placeId);
            }
            return ret;
        }

        private static List<OrganizationInfo> RetrieveActiveData()
        {
            using (DbOrganizationInfoGet data = new DbOrganizationInfoGet())
            {
                return data.GetActiveRecords();
            }
        }

        private static OrganizationView RetrieveRecord(int recordId)
        {
            using (DbOrganizationInfoGet data = new DbOrganizationInfoGet())
            {
                return data.GetRecord(recordId);
            }
        }

        private static string SaveRecord(OrganizationView entity, ref int placeId)
        {
            using (DbOrganizationSave data = new DbOrganizationSave())
            {
                return data.SaveOrganization(ref entity, ref placeId);
            }
        }

        private static void DeleteRecord(int recordId)
        {
            using (DbPlaceSetInactive data = new DbPlaceSetInactive())
            {
                data.SetOrganizationInactive(recordId);
            }
        }
    }
}