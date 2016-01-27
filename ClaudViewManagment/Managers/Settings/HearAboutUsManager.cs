using System;
using System.Collections.Generic;
using ClaudeData.DataRepository.AdminRepository;
using ClaudeData.Models.Admin;

namespace ClaudeViewManagement.Managers.Settings
{
    public class HearAboutUsManager : IDisposable
    {
        public HearAboutUsManager()
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

        public List<HearAboutUs> Get(string entity)
        {
            List<HearAboutUs> ret = RetrieveActiveData();

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

        public HearAboutUs Get(int recordId)
        {
            return RetrieveRecord(recordId);
        }

        public bool Update(HearAboutUs entity)
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

        public bool Validate(HearAboutUs entity)
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

        public bool Insert(HearAboutUs entity)
        {
            bool ret = Validate(entity);

            if (ret)
            {
                entity.ErrMsg = SaveRecord(entity);
            }
            return ret;
        }

        private static List<HearAboutUs> RetrieveActiveData()
        {
            using (DbHearAboutUsGet data = new DbHearAboutUsGet())
            {
                return data.GetActiveRecords();
            }
        }

        private static HearAboutUs RetrieveRecord(int recordId)
        {
            using (DbHearAboutUsGet data = new DbHearAboutUsGet())
            {
                return data.GetRecord(recordId);
            }
        }

        private static string SaveRecord(HearAboutUs entity)
        {
            using (DbHearAboutUsSave data = new DbHearAboutUsSave())
            {
                return data.AddUpdateRecord(entity);
            }
        }

        private static void DeleteRecord(int recordId)
        {
            using (DbHearAboutUsSave data = new DbHearAboutUsSave())
            {
                data.SetInactive(recordId);
            }
        }
    }
}