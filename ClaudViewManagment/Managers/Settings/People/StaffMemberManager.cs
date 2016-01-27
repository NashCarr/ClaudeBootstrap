using System;
using System.Collections.Generic;
using ClaudeData.DataRepository.PersonRepository;
using ClaudeData.DataRepository.SettingsRepository;
using ClaudeData.Models.Lists.Settings;
using ClaudeData.ViewModels.Settings;

namespace ClaudeViewManagement.Managers.Settings.People
{
    public class StaffMemberManager : IDisposable
    {
        public StaffMemberManager()
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

        public List<StaffMemberInfo> Get()
        {
            return Get(string.Empty);
        }

        public List<StaffMemberInfo> Get(string searchValue)
        {
            List<StaffMemberInfo> ret = RetrieveActiveData();

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

        public StaffMemberView Get(int recordId)
        {
            return RetrieveRecord(recordId);
        }

        public bool Update(StaffMemberView entity, ref int personId, ref int facilityStaffId)
        {
            bool ret = Validate(entity);

            if (ret)
            {
                entity.StaffUser.ErrMsg = SaveRecord(entity, ref personId, ref facilityStaffId);
            }
            return ret;
        }

        public bool Delete(int recordId)
        {
            DeleteRecord(recordId);
            return true;
        }

        public bool Validate(StaffMemberView entity)
        {
            ValidationErrors.Clear();

            if (string.IsNullOrEmpty(entity.StaffUser.FullName)) return ValidationErrors.Count == 0;

            if (entity.StaffUser.FullName.ToLower() ==
                entity.StaffUser.FullName)
            {
                ValidationErrors.Add(new
                    KeyValuePair<string, string>("Name",
                        "Staff User Name must not be all lower case."));
            }

            return ValidationErrors.Count == 0;
        }

        public bool Insert(StaffMemberView entity, ref int personId, ref int facilityStaffId)
        {
            bool ret = Validate(entity);

            if (ret)
            {
                entity.StaffUser.ErrMsg = SaveRecord(entity, ref personId, ref facilityStaffId);
            }
            return ret;
        }

        private static List<StaffMemberInfo> RetrieveActiveData()
        {
            using (DbStaffMemberInfoGet data = new DbStaffMemberInfoGet())
            {
                return data.GetActiveRecords();
            }
        }

        private static StaffMemberView RetrieveRecord(int recordId)
        {
            using (DbStaffMemberInfoGet data = new DbStaffMemberInfoGet())
            {
                return data.GetRecord(recordId);
            }
        }

        private static string SaveRecord(StaffMemberView entity, ref int personId, ref int facilityStaffId)
        {
            using (DbStaffMemberSave data = new DbStaffMemberSave())
            {
                return data.SaveStaffMember(ref entity, ref personId, ref facilityStaffId);
            }
        }

        private static void DeleteRecord(int recordId)
        {
            using (DbPersonSetInactive data = new DbPersonSetInactive())
            {
                data.SetStaffUserInactive(recordId);
            }
        }
    }
}