using System;
using System.Collections.Generic;
using ClaudeData.DataRepository.PlaceRepository;
using ClaudeData.DataRepository.SettingsRepository;
using ClaudeData.Models.Lists.Settings;
using ClaudeData.ViewModels.Settings;

namespace ClaudeViewManagement.Managers.Places
{
    public class ClientFacilityManager : IDisposable
    {
        public ClientFacilityManager()
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

        public List<ClientFacilityInfo> Get()
        {
            return Get(string.Empty);
        }

        public List<ClientFacilityInfo> Get(string searchValue)
        {
            List<ClientFacilityInfo> ret = RetrieveActiveData();

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

        public ClientFacilityView Get(int recordId)
        {
            return RetrieveRecord(recordId);
        }

        public bool Update(ClientFacilityView entity, ref int placeId)
        {
            bool ret = Validate(entity);

            if (ret)
            {
                entity.Facility.ErrMsg = SaveRecord(entity, ref placeId);
            }
            return ret;
        }

        public bool Delete(int recordId)
        {
            DeleteRecord(recordId);
            return true;
        }

        public bool Validate(ClientFacilityView entity)
        {
            ValidationErrors.Clear();

            if (string.IsNullOrEmpty(entity.Facility.Name)) return ValidationErrors.Count == 0;

            if (entity.Facility.Name.ToLower() ==
                entity.Facility.Name)
            {
                ValidationErrors.Add(new
                    KeyValuePair<string, string>("Name",
                        "Staff User Name must not be all lower case."));
            }

            return ValidationErrors.Count == 0;
        }

        public bool Insert(ClientFacilityView entity, ref int placeId)
        {
            bool ret = Validate(entity);

            if (ret)
            {
                entity.Facility.ErrMsg = SaveRecord(entity, ref placeId);
            }
            return ret;
        }

        private static List<ClientFacilityInfo> RetrieveActiveData()
        {
            using (DbClientFacilityInfoGet data = new DbClientFacilityInfoGet())
            {
                return data.GetActiveRecords();
            }
        }

        private static ClientFacilityView RetrieveRecord(int recordId)
        {
            using (DbClientFacilityInfoGet data = new DbClientFacilityInfoGet())
            {
                return data.GetRecord(recordId);
            }
        }

        private static string SaveRecord(ClientFacilityView entity, ref int placeId)
        {
            using (DbClientFacilitySave data = new DbClientFacilitySave())
            {
                return data.SaveClientFacility(ref entity, ref placeId);
            }
        }

        private static void DeleteRecord(int recordId)
        {
            using (DbPlaceSetInactive data = new DbPlaceSetInactive())
            {
                data.SetFacilityInactive(recordId);
            }
        }
    }
}