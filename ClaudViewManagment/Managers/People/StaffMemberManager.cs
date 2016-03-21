using System;
using System.Collections.Generic;
using ClaudeCommon.BaseModels;
using ClaudeCommon.BaseModels.Returns;
using ClaudeData.DataRepository.PersonRepository;
using ClaudeData.DataRepository.PlaceRepository;
using ClaudeData.DataRepository.ReorderRepository;
using ClaudeData.ViewModels;

namespace ClaudeViewManagement.Managers.People
{
    public class StaffMemberManager : IDisposable
    {
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool iAmBeingCalledFromDisposeAndNotFinalize)
        {
        }

        public PersonView GetStaffMember(int recordId)
        {
            using (DbPersonViewGet data = new DbPersonViewGet())
            {
                return data.GetStaffMember(recordId);
            }
        }

        public void SaveStaffMemberOrder(List<DisplayReorder> data)
        {
            using (DbReorderSave db = new DbReorderSave())
            {
                db.CustomerReorderSave(data);
            }
        }

        public ReturnBase DeleteStaffMember(int id)
        {
            using (DbPlaceSetInactive data = new DbPlaceSetInactive())
            {
                return data.SetCustomerInactive(id);
            }
        }
    }
}