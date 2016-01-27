using System;
using System.Collections.Generic;
using ClaudeData.DataRepository.PersonRepository;
using ClaudeData.DataRepository.SettingsRepository;
using ClaudeData.Models.Lists.Settings;
using ClaudeData.ViewModels.Settings;

namespace ClaudeViewManagement.Managers.People
{
    public class AssessorManager : IDisposable
    {
        public AssessorManager()
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

        public List<AssessorInfo> Get()
        {
            return Get(string.Empty);
        }

        public List<AssessorInfo> Get(string searchValue)
        {
            List<AssessorInfo> ret = RetrieveActiveData();

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

        public AssessorView Get(int recordId)
        {
            return RetrieveRecord(recordId);
        }

        public bool Update(AssessorView entity, ref int personId)
        {
            bool ret = Validate(entity);

            if (ret)
            {
                entity.Assessor.ErrMsg = SaveRecord(entity, ref personId);
            }
            return ret;
        }

        public bool Delete(int recordId)
        {
            DeleteRecord(recordId);
            return true;
        }

        public bool Validate(AssessorView entity)
        {
            ValidationErrors.Clear();

            if (string.IsNullOrEmpty(entity.Assessor.FullName)) return ValidationErrors.Count == 0;

            if (entity.Assessor.FullName.ToLower() ==
                entity.Assessor.FullName)
            {
                ValidationErrors.Add(new
                    KeyValuePair<string, string>("Name",
                        "Staff User Name must not be all lower case."));
            }

            return ValidationErrors.Count == 0;
        }

        public bool Insert(AssessorView entity, ref int personId)
        {
            bool ret = Validate(entity);

            if (ret)
            {
                entity.Assessor.ErrMsg = SaveRecord(entity, ref personId);
            }
            return ret;
        }

        private static List<AssessorInfo> RetrieveActiveData()
        {
            using (DbAssessorInfoGet data = new DbAssessorInfoGet())
            {
                return data.GetActiveRecords();
            }
        }

        private static AssessorView RetrieveRecord(int recordId)
        {
            using (DbAssessorInfoGet data = new DbAssessorInfoGet())
            {
                return data.GetRecord(recordId);
            }
        }

        private static string SaveRecord(AssessorView entity, ref int personId)
        {
            using (DbAssessorSave data = new DbAssessorSave())
            {
                return data.SaveAssessor(ref entity, ref personId);
            }
        }

        private static void DeleteRecord(int recordId)
        {
            using (DbPersonSetInactive data = new DbPersonSetInactive())
            {
                data.SetAssessorInactive(recordId);
            }
        }
    }
}