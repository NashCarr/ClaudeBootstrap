using System;
using ClaudeCommon.BaseModels.Returns;
using ClaudeData.DataRepository.PersonRepository;
using ClaudeData.Models.People;
using ClaudeViewManagement.ViewModels.People;
using static ClaudeCommon.Enums.PersonEnums;

namespace ClaudeViewManagement.Managers.People
{
    public class ContactManager : IDisposable
    {
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool iAmBeingCalledFromDisposeAndNotFinalize)
        {
        }

        public string DeleteStaffUser(int id)
        {
            using (DbPersonSetInactive data = new DbPersonSetInactive())
            {
                return data.SetStaffUserInactive(id);
            }
        }

        public string DeleteCustomer(int id)
        {
            using (DbPersonSetInactive data = new DbPersonSetInactive())
            {
                return data.SetCustomerContactInactive(id);
            }
        }

        public ReturnBase SaveContact(ContactSaveModel c)
        {
            ReturnBase rb = new ReturnBase();
            Person p = new Person
            {
                Email = c.Email,
                PlaceId = c.PlaceId,
                PersonId = c.PersonId,
                LastName = c.LastName,
                FirstName = c.FirstName,
                MiddleName = c.MiddleName,
                PersonType = c.PersonType
            };
            using (DbPersonSave s = new DbPersonSave())
            {
                switch (p.PersonType)
                {
                    case PersonType.CustomerContact:
                        rb.ErrMsg = s.SaveCustomerContact(ref p);
                        break;
                    case PersonType.OrganizationContact:
                        break;
                    case PersonType.StaffUser:
                        rb.ErrMsg = s.SaveStaffUser(ref p);
                        break;
                    default:
                        rb.ErrMsg = "Contact Type not defined";
                        break;
                }
            }
            rb.Id = p.PersonId;
            return rb;
        }
    }
}